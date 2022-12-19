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

namespace WindowsFormsApp6
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=galata21;");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM sirket1.sirkets", connection);


                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "müdür");

                dataGridView1.DataSource = ds.Tables["müdür"];

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection baglanti = new MySqlConnection("datasource=localhost;port=3306;username=root;password=galata21;Initial Catalog=sirket1");
            MySqlDataAdapter komut = new MySqlDataAdapter("select*from sirkets where sirketspart like '" + textBox1.Text + "'", baglanti);
            DataTable tablo = new DataTable();
            tablo.Clear();
            baglanti.Open();
            komut.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
