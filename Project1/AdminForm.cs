using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Скрываем админскую форму
            this.Hide();
            // Запускаем форму для изменения таблиц FIO и Login_in
            ChaingeDateOnFromLogin FormChangeDate = new ChaingeDateOnFromLogin();
            FormChangeDate.ShowDialog();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // При закрытии формы должна запускаться форма входа в систему.
            MainForm form = new MainForm();
            form.Show();
            form.BringToFront();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
