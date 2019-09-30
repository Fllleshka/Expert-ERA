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
        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1q2w3e4r;Database=Expert_ERA;";

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
            // Выполяем преобразование переменной в тип boolean
 
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

            // Проверка логина и пароля
            bool Checker = false;
            Checker = Check_pass(Login_textbox1, Password_textbox1);
            if (Checker == true)
            {
                // Запускаем экран загрузки. 
                Thread t = new Thread(() => StartSplashScreen(Login_textbox1, Password_textbox1));
                t.Start();
                Thread.Sleep(5000);
                t.Abort();
                this.BringToFront();
            }
            else
            {
                MessageBox.Show("Логин или пароль не верны.");
                // Отчистка textBox2 с паролем.
                textBox2.Text = "";
                textBox2.Clear();
            }


        }
        public void StartSplashScreen(string Login_textbox1, string Password_textbox1)
        {
            string Access_level;
            Application.Run(new FormSplashScreen());

            // Проверяем уровень допуска пользователя
            string sqlcheck = "SELECT Login_in.Access_level FROM Login_in WHERE Login_in.Login = " + Login_textbox1 + " AND Login_in.Password = " + Password_textbox1 + ";";

            Access_level = "administrator";

            // В соответствии с уровнем допуска запускаем определённую форму
            switch(Access_level)
            {
                // Открываем форму Администратора
                case "administrator":
                    MessageBox.Show("Тут должна вывестись форма администратора.");
                    break;
                case "user":
                    MessageBox.Show("Тут должна вывестись форма пользователя системы.");
                    break;
                default:
                    MessageBox.Show("Ваш статус в системе не установлен. Обратитесь к администратору.");
                    break;


            }
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

