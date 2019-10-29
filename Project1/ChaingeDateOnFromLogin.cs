﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Project1
{
    public partial class ChaingeDateOnFromLogin : Form
    {
        public ChaingeDateOnFromLogin()
        {
            InitializeComponent();
        }

        private void ChaingeDateOnFromLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // При закрытии формы открываем предыдущюю (Админскую форму)
            // Запуск админской формы
            AdminForm formadmin = new AdminForm();
            formadmin.Show();
            formadmin.BringToFront();
            //this.Close();
        }

        private void ChaingeDateOnFromLogin_Load(object sender, EventArgs e)
        {
            // Строка для подключения к БД.
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1q2w3e4r;Database=Expert_ERA;";

            // Подключаем Базу Данных PostgreSQL через Npgsql
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();

            // Строка запроса для отображения таблицы в DataGridView
            string check_access_level = "SELECT Login_in.Login, Login_in.Access_level, Login_in.Password, FIO.First_name, FIO.Second_name, FIO.Surname FROM Login_in, FIO WHERE Login_in.Id_fio = FIO.Id_fio";
            // Выполняем запрос к Базе Данных
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(check_access_level, npgSqlConnection);

            // Инициализируем адаптер для вывода результата запроса из БД
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(npgSqlCommand);
            DataTable table = new DataTable();
            // Кидаем результат запроса в таблицу
            adapter.Fill(table);
            // Выводим результат запроса в dataGridView
            dataGridView1.DataSource = table;
            // Блокируем dataGridView чтобы пользователь не наломал дров в таблице
            dataGridView1.ReadOnly = true;

            // Изменяем название столбцов для удобного прочтения
            dataGridView1.Columns[0].HeaderText = "Логин";
            dataGridView1.Columns[1].HeaderText = "Уровень доступа";
            dataGridView1.Columns[2].HeaderText = "Пароль";
            dataGridView1.Columns[3].HeaderText = "Фамилия";
            dataGridView1.Columns[4].HeaderText = "Имя";
            dataGridView1.Columns[5].HeaderText = "Отчество";

            // Закрываем соединение с Базой данных
            npgSqlConnection.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Добавление нового пользователя в систему
            // Инициализация переменных
            string Surname_textbox1 = textBox1.Text;
            string Name_textbox2 = textBox2.Text;
            string Middlename_textbox3 = textBox3.Text;

            // Тут должна быть проверка на корректность входящих значений
            // Нужно ли тут это? Или понадеятся что администратор всё будет вводить корректно.
            //Chainge_textbox(Surname_textbox1);
            //Chainge_textbox(Name_textbox2);
            //Chainge_textbox(Middlename_textbox3);

            // Строка для подключения к БД.
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1q2w3e4r;Database=Expert_ERA;";

            // Подключаем Базу Данных PostgreSQL через Npgsql
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();

            // Строка запроса для определения последнего номера в таблице, для формирования запроса к БД
            string text_max_id_fio = "SELECT MAX(ID_FIO) FROM FIO";
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(text_max_id_fio, npgSqlConnection);
            // Записываем ответ в переменную.
            string result_max_id_fio = npgSqlCommand.ExecuteScalar().ToString();
            // Преобразовываем переменную в int а так же прибавляем 1 для продолжения нумерации. Про автоинкримент ничего не знаю!Ы
            int result = Convert.ToInt32(result_max_id_fio) + 1;

            // Строка запроса для вставки в БД данных с формы
            string insert_into_FIO = "INSERT INTO FIO (Id_fio, First_name, Second_name, Surname) VALUES('" + result + "', '" + Surname_textbox1 + "', '" + Name_textbox2 + "', '" + Middlename_textbox3 + "');";
            npgSqlCommand = new NpgsqlCommand(insert_into_FIO, npgSqlConnection);
            result_max_id_fio = npgSqlCommand.ExecuteNonQuery().ToString();
            MessageBox.Show(result_max_id_fio);

            // Обновить таблицу DataGridView

        }
    }
}
