using System;
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
            // Данные для перевода в транслит Фамилии
            words.Add("а", "a");
            words.Add("б", "b");
            words.Add("в", "v");
            words.Add("г", "g");
            words.Add("д", "d");
            words.Add("е", "e");
            words.Add("ё", "yo");
            words.Add("ж", "zh");
            words.Add("з", "z");
            words.Add("и", "i");
            words.Add("й", "j");
            words.Add("к", "k");
            words.Add("л", "l");
            words.Add("м", "m");
            words.Add("н", "n");
            words.Add("о", "o");
            words.Add("п", "p");
            words.Add("р", "r");
            words.Add("с", "s");
            words.Add("т", "t");
            words.Add("у", "u");
            words.Add("ф", "f");
            words.Add("х", "h");
            words.Add("ц", "c");
            words.Add("ч", "ch");
            words.Add("ш", "sh");
            words.Add("щ", "sch");
            words.Add("ъ", "j");
            words.Add("ы", "i");
            words.Add("ь", "j");
            words.Add("э", "e");
            words.Add("ю", "yu");
            words.Add("я", "ya");
            words.Add("А", "A");
            words.Add("Б", "B");
            words.Add("В", "V");
            words.Add("Г", "G");
            words.Add("Д", "D");
            words.Add("Е", "E");
            words.Add("Ё", "Yo");
            words.Add("Ж", "Zh");
            words.Add("З", "Z");
            words.Add("И", "I");
            words.Add("Й", "J");
            words.Add("К", "K");
            words.Add("Л", "L");
            words.Add("М", "M");
            words.Add("Н", "N");
            words.Add("О", "O");
            words.Add("П", "P");
            words.Add("Р", "R");
            words.Add("С", "S");
            words.Add("Т", "T");
            words.Add("У", "U");
            words.Add("Ф", "F");
            words.Add("Х", "H");
            words.Add("Ц", "C");
            words.Add("Ч", "Ch");
            words.Add("Ш", "Sh");
            words.Add("Щ", "Sch");
            words.Add("Ъ", "J");
            words.Add("Ы", "I");
            words.Add("Ь", "J");
            words.Add("Э", "E");
            words.Add("Ю", "Yu");
            words.Add("Я", "Ya");

            // Блокируем изменение сгенерированного логина в textbox9
            textBox9.ReadOnly = true;
        }

        Dictionary<string, string> words = new Dictionary<string, string>();

        public string generate_login(string Surname, string Name, string Middlename)
        {
            // Переменная для сгенерируемого логина
            string login;

            login = Surname + "_" + Name[0] + Middlename[0];

            return login;
        }

        // Функция для генерации пароля
        public string generate_password()
        {
            // Переменная для сгенерируемого логина
            string password = "";
            // Массив для генерации пароля в 6 символов
            int[] arr = new int[6];
            // Запуск рандомизатора
            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(97, 122);
                password += (char)arr[i];
            }            
            return password;
        }
        
        // Функция посика
        public string search_fio(string Surname, string Name, string Middlename)
        {
            // Строка для подключения к БД.
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=Expert_ERA;";

            // Подключаем Базу Данных PostgreSQL через Npgsql
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();

            // Переменная для возвращаемого значения
            string id_fio;
            // Создаём переменную для запроса по поиску id человека
            string id_from_fio_request;
            id_from_fio_request = "SELECT Id_fio FROM FIO WHERE First_name = '" + Surname + "', Second_name = '" + Name + "', Surname = '" + Middlename + "'";

            // Ищем Id человека которого добавляем в таблице FIO
            NpgsqlCommand command = new NpgsqlCommand(id_from_fio_request, npgSqlConnection);
            id_fio = (String)command.ExecuteScalar();
            return id_fio;
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
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=Expert_ERA;";

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

            // Загружаем в элемент ComboBox элементы выбора типа учётной записи
                comboBox1.Items.Add("administrator");
                comboBox1.Items.Add("user");

            // Заставляем выделять пользователя всю строку вместо одной ячейки
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Добавление нового пользователя в систему
            // Инициализация переменных
            string Surname_textbox1 = textBox1.Text;
            string Name_textbox2 = textBox2.Text;
            string Middlename_textbox3 = textBox3.Text;
            string Login;
            string Password;

            // Тут должна быть проверка на корректность входящих значений
            // Нужно ли тут это? Или понадеятся что администратор всё будет вводить корректно.
            //Chainge_textbox(Surname_textbox1);
            //Chainge_textbox(Name_textbox2);
            //Chainge_textbox(Middlename_textbox3);

            // Строка для подключения к БД.
            String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=123;Database=Expert_ERA;";

            // Подключаем Базу Данных PostgreSQL через Npgsql
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();

            // Строка запроса для вставки в БД данных с формы
            string insert_into_FIO = "INSERT INTO FIO (First_name, Second_name, Surname) VALUES('" + Surname_textbox1 + "', '" + Name_textbox2 + "', '" + Middlename_textbox3 + "');";
            // Записываем ФИО в таблицу FIO
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(insert_into_FIO, npgSqlConnection);

            // Берём логин из textbox9 
            Login = textBox9.Text;
            // Генерируем пароль
            Password = generate_password();

            // Обьявляем переменную для поиска
            string id_from_fio;
            // Получаем id человека которого необходимо добавить
            id_from_fio = search_fio(Surname_textbox1, Name_textbox2, Middlename_textbox3);

            // Записываем сгенерируемые данные в таблицу
            //string intsert_into_Login_in = "INSERT INTO Login_in(Id_fio, Login, Access_level, Password) VALUES('" + ;

            // Обновить таблицу DataGridView
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string source = textBox1.Text;
            foreach (KeyValuePair<string, string> pair in words)
            {
                source = source.Replace(pair.Key, pair.Value);
            }
            textBox9.Text = source;
        }
    }
}
