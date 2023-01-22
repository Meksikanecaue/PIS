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
    public partial class Form5 : Form
    {
        DataSet ds = new DataSet();

        public Form5()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            String название = textBox2.Text;
            String тип = comboBox2.Text;
            String жанр = comboBox1.Text;
            String год = comboBox4.Text;
            String страна = comboBox3.Text;
            


            DB db = new DB();
            db.openConnection();
            DataTable table = new DataTable();

           
            MySqlCommand command = new MySqlCommand("SELECT * FROM films WHERE название = @uL or тип = @uP  or жанр = @ua or год = @us or страна = @ud", db.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = название;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = тип;
            command.Parameters.Add("@ua", MySqlDbType.VarChar).Value = жанр;
            command.Parameters.Add("@us", MySqlDbType.VarChar).Value = год;
            command.Parameters.Add("@ud", MySqlDbType.VarChar).Value = страна;
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["idfilms"].ReadOnly = true;
            
        }
    }
}
