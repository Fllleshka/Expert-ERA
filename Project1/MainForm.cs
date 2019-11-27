using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Npgsql;

namespace Project1
{
    public partial class MainForm : Form
    {
        // Глобальная переменная для подключения к БД.
        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=Expert_ERA;";

        public MainForm()
        {
            InitializeComponent();
        }
        // Функция проверки Логина и пароля
        bool Check_pass(string Login, string Pass)
        {
            // Подключаем Базу Данных PostgreSQL через Npgsql
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
            
            // Строка для выявления роли пользователя
            string check_login_pass = "SELECT COUNT(*) FROM Login_in WHERE Login_in.Login = '" + Login + "' AND Login_in.Password = '" + Pass + "';";
            // Выполняем запрос к Базе Данных
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(check_login_pass, npgSqlConnection);
            // Записываем ответ в переменную.
            string check_result = npgSqlCommand.ExecuteScalar().ToString();
            
            // Закрываем соединение с Базой Данных
            npgSqlConnection.Close();

            // Проверяем на корректность данных
            if (check_result == "1")
            {
                return true;
            }
            else
            { 
                return false;
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // При введении пароля он будет отображаться "звёздочками"
            textBox2.UseSystemPasswordChar = true;

            // Подключаем Базу Данных PostgreSQL через Npgsql
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            // Открываем соединение с Базой данных
            try
            {
                npgSqlConnection.Open();
                linkLabel1.BackColor = Color.Silver;
                linkLabel1.Text = "База данных подключена";
            }
            catch
            {
                linkLabel1.BackColor = Color.Red;
                MessageBox.Show("Подключение отсутствует!", "Ошибка");
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // При нажатии на кнопку выполняется проверка логина и пароля.
            string Login_textbox1 = textBox1.Text;
            string Password_textbox1 = textBox2.Text;
            string Access_level = "NULL";
            // Проверка логина и пароля
            bool Checker = false;
            Checker = Check_pass(Login_textbox1, Password_textbox1);
            if (Checker == true)
            {
                // Запускаем экран загрузки. 
                Access_level = StartSplashScreen(Login_textbox1, Password_textbox1);
                this.BringToFront();
            }
            else
            {
                // Отчистка textBox2 с паролем.
                textBox2.Text = "";
                textBox2.Clear();
            }

            // В соответствии с уровнем допуска запускаем определённую форму
            switch (Access_level)
            {
                // Открываем форму Администратора
                case "administrator":
                    // Запуск админской формы
                    AdminForm formadmin = new AdminForm();
                    // Выводим админскую форму на первый план
                    formadmin.Show();
                    // Скрываем форму с логином и паролем
                    this.Hide();
                    break;
                case "user":
                    // Запуск формы пользователя
                    UserForm formuser = new UserForm();
                    // Выводим форму для пользователя на первый план
                    formuser.Show();
                    // Скрываем форму с логином и паролем
                    this.Hide();
                    break;
                default:
                    MessageBox.Show("Ваш статус в системе не установлен. Обратитесь к администратору.");
                    break;
            }
        }

        // Фунция проверки доступа пользователя к системе
        public string Check_Login(string Login_textbox1, string Password_textbox1)
        {
            // Обьявляем переменную в которую мы положим результат запроса о статусе пользователя в системе
            string Access_level;
            // Подключаем Базу Данных PostgreSQL через Npgsql
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();

            // Проверяем уровень допуска пользователя
            string check_access_level = "SELECT Login_in.Access_level FROM Login_in WHERE Login_in.Login = '" + Login_textbox1 + "' AND Login_in.Password = '" + Password_textbox1 + "';";
            // Выполняем запрос к Базе Данных
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(check_access_level, npgSqlConnection);
            // Записываем ответ в переменную.
            Access_level = npgSqlCommand.ExecuteScalar().ToString();

            // Закрываем соединение с Базой данных
            npgSqlConnection.Close();

            // Возвращаем статус пользователя
            return Access_level;
        }

        public string StartSplashScreen(string Login_textbox1, string Password_textbox1)
        {
            string Access_level;

            // Запуск проверки логина, пароля, роли в системе
            Access_level = Check_Login(Login_textbox1, Password_textbox1);

            // Запуск экрана загрузки
            FormSplashScreen f = new FormSplashScreen();
            f.ShowDialog();

            // Возвращаем уровень допуска
            return Access_level;
        }

        public void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // При закрытии формы закрываем соединение с Базой Данных.
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            // Закрываем соединение с Базой данных
            npgSqlConnection.Close();
        }
    }
}

