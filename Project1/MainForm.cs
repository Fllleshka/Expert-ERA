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
        public MainForm()
        {
            InitializeComponent();
        }
        // Функция проверки Логина и пароля
        static bool Check_pass(string Login, string Pass)
        {
            if (Login == "admin")
            {
                if (Pass == "admin")
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // При введении пароля он будет отображаться "звёздочками"
            textBox2.UseSystemPasswordChar = true;

            // Подключаем Базу Данных PostgreSQL через Npgsql
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1q2w3e4r;Database=123;";
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
                Thread t = new Thread(new ThreadStart(StartSplashScreen));
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
        public void StartSplashScreen()
        {
            Application.Run(new FormSplashScreen());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // При закрытии формы закрываем соединение с Базой Данных.
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1q2w3e5r;Database=123;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            // Закрываем соединение с Базой данных
            npgSqlConnection.Close();
        }
    }
}

