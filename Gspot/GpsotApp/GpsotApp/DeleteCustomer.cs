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

namespace GpsotApp
{
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
            Fillcombo1();
        }
        DataTable dbdataset;
        DataTable dt = new DataTable();
        private void DeleteCustomer_Load(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("SURNAME LIKE '%{0}%'", textBox2.Text);
            dataGridView1.DataSource = DV;
        }

        void Fillcombo1()
        {

            string myConnection = "datasource=50.87.144.102;port=3306;username=evotsis_gspot;password=gspot@123";//connection parameters
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
                dataGridView1.Columns[0].Width = 158;
                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].Width = 130;
                dataGridView1.Columns[3].Width = 170;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("CELL LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox3.Text = row.Cells["SURNAME"].Value.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Διαγραφή εγγραφής?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    string myConnection = "datasource=50.87.144.102;port=3306;username=evotsis_gspot;password=gspot@123";//connection parameters
                    string Query = "delete from evotsis_gspot.Customers where ID='" + textBox12.Text + "';";
                    MySqlConnection MyConn = new MySqlConnection(myConnection);
                    MySqlCommand MyCommand = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyConn.Open();
                    MyReader = MyCommand.ExecuteReader();
                    MessageBox.Show("Τα στοιχεία πελάτη διαγράφτηκαν");
                    while (MyReader.Read())
                    {
                    }
                    MyConn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Σφάλμα στη διαγραφή");
                }
                Fillcombo1();

            }
           
        }
    }
}
