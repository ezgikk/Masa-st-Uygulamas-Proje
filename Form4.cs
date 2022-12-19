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
using WindowsFormsApp6;

namespace WindowsFormsApp3
{
    
    using Excel = Microsoft.Office.Interop.Excel;
    public partial class Form4 : Form
    {


        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=galata21;");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM sirket1.sirkets", connection);


                connection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "sirkets");

                dataGridView1.DataSource = ds.Tables["sirkets"];

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void CopyAlltoClipboard()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            CopyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlworksheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkbook = xlexcel.Workbooks.Add(misValue);
            xlworksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlworksheet.Cells[1, 1];
            CR.Select();
            xlworksheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
    }
}