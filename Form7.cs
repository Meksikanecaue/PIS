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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO zakaz (login, Color, Coplect, Adress) VALUES (@login, @col, @comp, @adress)", db.getConnection());

            command.Parameters.Add("@adress", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@col", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@comp", MySqlDbType.VarChar).Value = comboBox2.Text;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Program.login;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Вы успешно подали заявке");
            else
                MessageBox.Show("Вы ввели некоректные данные");


            db.closeConnection();
        }
    }
}
