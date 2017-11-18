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
    public partial class NewCustomer : Form
    {
        int id = 0;
        public NewCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Fillcombo1();
                string str1 = textBox2.Text;
                string str2 = textBox1.Text;
                string str3 = textBox3.Text;
                string str4 = textBox4.Text;
                string str5 = textBox5.Text;
                string str6 = textBox6.Text;
                string str7 = textBox7.Text;
                string str8 = textBox8.Text;
                string str9 = textBox9.Text;
                string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
                string Query = "insert into evotsis_gspot.Customers (SURNAME,NAME,AFM,ADRESS,CITY,PHONE,CELL,FAX,EMAIL,ID) values('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + textBox10.Text + "');";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    while (myReader.Read())
                    {
                        //nothing this time to do
                    }
                    myConn.Close();
                    this.Close();

                }
                catch (Exception)
                {

                }

            }
            catch (Exception)
            {
                MessageBox.Show("ΤΟ ΠΡΟΓΡΑΜΜΑ ΔΕΝ ΜΠΟΡΕΙ ΝΑ ΣΥΝΔΕΘΕΙ ΣΤΗ ΒΑΣΗ ΔΕΔΟΜΕΝΩΝ ΓΙΑ ΝΑ ΑΠΟΘHΚΕΥΣΕΙ ΤΑ ΣΤΟΙΧΕΙΑ ΠΕΛΑΤΗ");
            }
        }


        void Fillcombo1()
        {

            string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query = "select max(NUMBER) from evotsis_gspot.IDNumber;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            try
            {
                myConn.Open();
                textBox10.Text = cmdDatabase.ExecuteScalar().ToString();
                id = Int32.Parse(textBox10.Text);
                myConn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("ΤΟ ΠΡΟΓΡΑΜΜΑ ΔΕΝ ΜΠΟΡΕΙ ΝΑ ΑΝΑΚΤΗΣΕΙ ΝΕΟ ID ΠΕΛΑΤΗ - ΕΠΙΚΟΙΝΩΝΗΣΤΕ ΜΕ ΤΟΝ ADMINISTRATOR");
                this.Close();
            }

            int id2 = id;
            id2 += 1;
            string myConnection2 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query2 = "insert into evotsis_gspot.IDNumber (NUMBER) values('" + id2 + "');";
            MySqlConnection myConn2 = new MySqlConnection(myConnection2);
            MySqlCommand cmdDatabase2 = new MySqlCommand(Query2, myConn2);
            MySqlDataReader myReader2;
            try
            {
                myConn2.Open();
                myReader2 = cmdDatabase2.ExecuteReader();
                while (myReader2.Read())
                {
                    //nothing this time to do
                }

                myConn2.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Λάθος στην αποθήκευση - Πιθανή προσπάθεια διπλοεγγραφής");
                //this.Close();
            }

        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
