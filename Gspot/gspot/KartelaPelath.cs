using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gspot
{
    public partial class KartelaPelath : Form
    {
        DataTable dbdataset;
        DataTable dt = new DataTable();

        public KartelaPelath()
        {
            InitializeComponent();
            Fillcombo1();
        }    

        private void KartelaPelath_Load(object sender, EventArgs e)
        {
            try
            {
                Fillcombo1();
            }
            catch (Exception)
            {
                MessageBox.Show("Το σύστημα δεν μπορεί να συνδεθεί στη βάση δεδομένων InvoiceData2");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = textBox1.Text;
            string str2 = textBox4.Text;
            string str3 = textBox5.Text;
            string str4 = textBox6.Text;
            string str5 = textBox7.Text;
            string str6 = textBox8.Text;
            string str7 = textBox9.Text;
            string str8 = textBox10.Text;
            string str9 = textBox11.Text;
            string str10 = textBox12.Text;
            CustomerTab frm2 = new CustomerTab();
            frm2.MyProperty1 = str1;
            frm2.MyProperty2 = str2;
            frm2.MyProperty3 = str3;
            frm2.MyProperty4 = str4;
            frm2.MyProperty5 = str5;
            frm2.MyProperty6 = str6;
            frm2.MyProperty7 = str7;
            frm2.MyProperty8 = str8;
            frm2.MyProperty9 = str9;
            frm2.MyProperty10 = str10;
            frm2.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("SURNAME LIKE '%{0}%'", textBox2.Text);
            dataGridView1.DataSource = DV;
        }

        void Fillcombo1()
        {

            string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query = "select SURNAME, NAME, AFM, ADRESS, CITY, PHONE, CELL, FAX, EMAIL, ID from evotsis_gspot.Customers ;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);
                dataGridView1.Columns[0].Width = 138;
                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].Width = 130;
                dataGridView1.Columns[3].Width = 160;
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[0].HeaderText = "ΕΠΙΘΕΤΟ";
                dataGridView1.Columns[1].HeaderText = "ΟΝΟΜΑ";
                dataGridView1.Columns[2].HeaderText = "ΑΦΜ";
                dataGridView1.Columns[3].HeaderText = "ΔΙΕΥΘΥΝΣΗ";
                dataGridView1.Columns[4].HeaderText = "ΠΟΛΗ";
                dataGridView1.Columns[5].HeaderText = "ΤΗΛ";
                dataGridView1.Columns[6].HeaderText = "ΚΙΝΗΤΟ";
                dataGridView1.Columns[7].HeaderText = "ΦΑΧ";
                dataGridView1.Columns[8].HeaderText = "EMAIL";
                dataGridView1.Columns[9].HeaderText = "ID";

            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to database");
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("CELL LIKE '%{0}%'", textBox3.Text);
            dataGridView1.DataSource = DV;
        }
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["SURNAME"].Value.ToString();
                textBox4.Text = row.Cells["NAME"].Value.ToString();
                textBox5.Text = row.Cells["AFM"].Value.ToString();
                textBox6.Text = row.Cells["ADRESS"].Value.ToString();
                textBox7.Text = row.Cells["CITY"].Value.ToString();
                textBox8.Text = row.Cells["PHONE"].Value.ToString();
                textBox9.Text = row.Cells["CELL"].Value.ToString();
                textBox10.Text = row.Cells["FAX"].Value.ToString();
                textBox11.Text = row.Cells["EMAIL"].Value.ToString();
                textBox12.Text = row.Cells["ID"].Value.ToString();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string str1 = textBox1.Text;
                string str2 = textBox4.Text;
                string str3 = textBox5.Text;
                string str4 = textBox6.Text;
                string str5 = textBox7.Text;
                string str6 = textBox8.Text;
                string str7 = textBox9.Text;
                string str8 = textBox10.Text;
                string str9 = textBox11.Text;
                string str10 = textBox12.Text;
                CustomerTab frm2 = new CustomerTab();
                frm2.MyProperty1 = str1;
                frm2.MyProperty2 = str2;
                frm2.MyProperty3 = str3;
                frm2.MyProperty4 = str4;
                frm2.MyProperty5 = str5;
                frm2.MyProperty6 = str6;
                frm2.MyProperty7 = str7;
                frm2.MyProperty8 = str8;
                frm2.MyProperty9 = str9;
                frm2.MyProperty10 = str10;
                frm2.Show();
            }
        }
    }
}
