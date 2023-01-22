using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiwi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (имя.Text == "")
            {
                MessageBox.Show("Введите имя");
                return;
            }

            if (фамилия.Text == "")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }

            if (почта.Text == "")
            {
                MessageBox.Show("Укажи почту");
                return;
            }

            if (пароль.Text == "")
            {
                MessageBox.Show("Придумай пароль");
                return;
            }

            if (checkUser())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO users (Имя, Фамилия, Элпочта, Пароль) VALUES (@Имя, @Фамилия, @Элпочта, @Пароль)", db.getConnection());

            command.Parameters.Add("@Имя", MySqlDbType.VarChar).Value = имя.Text;
            command.Parameters.Add("@Фамилия", MySqlDbType.VarChar).Value = фамилия.Text;
            command.Parameters.Add("@Элпочта", MySqlDbType.VarChar).Value = почта.Text;
            command.Parameters.Add("@Пароль", MySqlDbType.VarChar).Value = пароль.Text;
            


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Вы успешно создали аккаунт");
            else
                MessageBox.Show("Аккаунт не был создан");


            db.closeConnection();
        }
        public Boolean checkUser()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE имя = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = имя.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже существует!");
                return true;
            }

            else
                return false;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
