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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String loginUser = textBox2.Text;
            String passUser = textBox3.Text;
            



            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE элпочта = @uL AND пароль = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Program.idUsers = table.Rows[0]["idUsers"].ToString();
                Program.Фамилия = table.Rows[0]["Фамилия"].ToString();
                Program.Имя = table.Rows[0]["Имя"].ToString();
                Program.Отчество = table.Rows[0]["Отчество"].ToString();
                Program.Элпочта = table.Rows[0]["Элпочта"].ToString();
                Program.Пароль = table.Rows[0]["Пароль"].ToString();
                if (table.Rows.Count > 0)
                {
                    Form5 f5 = new Form5();
                    f5.Show();
                    this.Hide();
                }
            }
        }
        

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }
    }
    }
