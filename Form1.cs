using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //MySqlConnection baglanti = new MySqlConnection(@"Data Source=DESKTOP-0I220AP;Initial Catalog=kisiler;Integrated Security=True;");
            MySqlConnection baglanti = new MySqlConnection("datasource=localhost;port=3306;username=root;password=galata21;Initial Catalog=kisiler");
            //MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM kisiler", baglanti);

            string user;
            string password;
            user = textBox1.Text;
            password = textBox2.Text;
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select*from kisiler.bilgi where bilgiad='" + user + "' and bilgisifre='" + password + "'", baglanti);
            MySqlDataReader oku = komut.ExecuteReader();


            if (oku.Read())
            {
                MessageBox.Show("Hoşgeldiniz " + user + "");
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı ve şifre");
            }

            baglanti.Close();
            Form2 fr2 = new Form2();
            fr2.ShowDialog();

        }
    }
    }
