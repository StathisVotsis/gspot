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
using System.Globalization;
using System.Drawing.Printing;

namespace gspot
{
    public partial class NewOrder : Form
    {
        DateTimePicker oDateTimePicker1 = new DateTimePicker();//calendar 
        CultureInfo provider = CultureInfo.InvariantCulture;
        DataTable dbdataset;
        DataTable dt = new DataTable();

        public NewOrder()
        {
            InitializeComponent();
            Fillcombo2();
            Fillcombo4();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            NewOrder myform1 = new NewOrder();
            myform1.Show();
        }

        private void NewOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet54.AdditionalWorks' table. You can move, or remove it, as needed.
            this.additionalWorksTableAdapter.Fill(this.evotsis_gspotDataSet54.AdditionalWorks);
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet53.PrintType' table. You can move, or remove it, as needed.
            this.printTypeTableAdapter.Fill(this.evotsis_gspotDataSet53.PrintType);
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet52.PrintSize' table. You can move, or remove it, as needed.
            this.printSizeTableAdapter.Fill(this.evotsis_gspotDataSet52.PrintSize);
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet51.Ylika7' table. You can move, or remove it, as needed.
            this.ylika7TableAdapter.Fill(this.evotsis_gspotDataSet51.Ylika7);
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet50.Work' table. You can move, or remove it, as needed.
            this.workTableAdapter.Fill(this.evotsis_gspotDataSet50.Work);


        }

        void Fillcombo2()
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

            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to database");
            }
        }

        void Fillcombo3()
        {
            string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query = "select * from evotsis_gspot.InvoiceNumber;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string customerNumber = myReader.GetString(0);//one reading in parameter
                    int numVal = Int32.Parse(customerNumber);
                    //numVal = numVal + 1;
                    textBox13.Text = numVal.ToString();
                }
                myConn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Το πρόγραμμα δεν μπορεί, να συνδεθεί στη βάση δεδομένων InvoiceNumber");
            }

        }

        void Fillcombo4()
        {

            string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query = "select * from evotsis_gspot.StagesOfOrder ;";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string StagesOfOrder = myReader.GetString("TYPE");//one reading in parameter

                    comboBox1.Items.Add(StagesOfOrder);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect combobox Neworder.cs to Stages Of Order database");
            }
        }

        void Fillcombo6()
        {
            string myConnection3 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters

            string Query3 = "insert into evotsis_gspot.PLHRWMES (AA,ID) values('" + textBox13.Text + "','" + textBox15.Text + "');";
            MySqlConnection myConn3 = new MySqlConnection(myConnection3);
            MySqlCommand cmdDatabase3 = new MySqlCommand(Query3, myConn3);
            MySqlDataReader myReader3;
            try
            {
                myConn3.Open();
                myReader3 = cmdDatabase3.ExecuteReader();
                while (myReader3.Read())
                {
                    //nothing this time to do
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error on saving PLHRWMES");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            NewCustomer myform = new NewCustomer();
            myform.Show();
            this.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("SURNAME LIKE '%{0}%'", textBox11.Text);
            dataGridView1.DataSource = DV;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("CELL LIKE '%{0}%'", textBox12.Text);
            dataGridView1.DataSource = DV;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["SURNAME"].Value.ToString();
                textBox3.Text = row.Cells["NAME"].Value.ToString();
                textBox4.Text = row.Cells["AFM"].Value.ToString();
                textBox5.Text = row.Cells["ADRESS"].Value.ToString();
                textBox6.Text = row.Cells["CITY"].Value.ToString();
                textBox7.Text = row.Cells["PHONE"].Value.ToString();
                textBox8.Text = row.Cells["CELL"].Value.ToString();
                textBox9.Text = row.Cells["FAX"].Value.ToString();
                textBox10.Text = row.Cells["EMAIL"].Value.ToString();
                textBox15.Text = row.Cells["ID"].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["SURNAME"].Value.ToString();
                textBox3.Text = row.Cells["NAME"].Value.ToString();
                textBox4.Text = row.Cells["AFM"].Value.ToString();
                textBox5.Text = row.Cells["ADRESS"].Value.ToString();
                textBox6.Text = row.Cells["CITY"].Value.ToString();
                textBox7.Text = row.Cells["PHONE"].Value.ToString();
                textBox8.Text = row.Cells["CELL"].Value.ToString();
                textBox9.Text = row.Cells["FAX"].Value.ToString();
                textBox10.Text = row.Cells["EMAIL"].Value.ToString();
                textBox15.Text = row.Cells["ID"].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["SURNAME"].Value.ToString();
                textBox3.Text = row.Cells["NAME"].Value.ToString();
                textBox4.Text = row.Cells["AFM"].Value.ToString();
                textBox5.Text = row.Cells["ADRESS"].Value.ToString();
                textBox6.Text = row.Cells["CITY"].Value.ToString();
                textBox7.Text = row.Cells["PHONE"].Value.ToString();
                textBox8.Text = row.Cells["CELL"].Value.ToString();
                textBox9.Text = row.Cells["FAX"].Value.ToString();
                textBox10.Text = row.Cells["EMAIL"].Value.ToString();
                textBox15.Text = row.Cells["ID"].Value.ToString();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["SURNAME"].Value.ToString();
                textBox3.Text = row.Cells["NAME"].Value.ToString();
                textBox4.Text = row.Cells["AFM"].Value.ToString();
                textBox5.Text = row.Cells["ADRESS"].Value.ToString();
                textBox6.Text = row.Cells["CITY"].Value.ToString();
                textBox7.Text = row.Cells["PHONE"].Value.ToString();
                textBox8.Text = row.Cells["CELL"].Value.ToString();
                textBox9.Text = row.Cells["FAX"].Value.ToString();
                textBox10.Text = row.Cells["EMAIL"].Value.ToString();
                textBox15.Text = row.Cells["ID"].Value.ToString();
            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            textBox14.Text = oDateTimePicker1.Text.ToString();

        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker1.Visible = false;
        }

        private void textBox14_Click(object sender, EventArgs e)
        {
            //Initialized a new DateTimePicker Control  
            oDateTimePicker1 = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            textBox14.Controls.Add(oDateTimePicker1);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker1.Format = DateTimePickerFormat.Short;
            //oDateTimePicker1.Format = DateTimePickerFormat.Custom;
            //oDateTimePicker1.CustomFormat = "yyyy MMM dd";

            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = textBox14.DisplayRectangle;

            //Setting area for DateTimePicker Control  
            oDateTimePicker1.Size = new Size(oRectangle.Width, oRectangle.Height);

            // Setting Location  
            oDateTimePicker1.Location = new Point(oRectangle.X, oRectangle.Y);

            // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            oDateTimePicker1.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

            // An event attached to dateTimePicker Control which is fired when any date is selected  
            oDateTimePicker1.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

            // Now make it visible  
            oDateTimePicker1.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query = "select * from evotsis_gspot.StagesOfOrder where TYPE = '" + comboBox1.Text + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    string OrderType = myReader.GetString("TYPE");//one reading in parameter
                    comboBox1.Text = OrderType;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to database");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgRow in dataGridView2.Rows)
            {
                if (dgRow.Cells[6].Value != null) //Check for null reference
                {
                    if (dgRow.Cells[7].Value != null)
                    {
                        dgRow.Cells[8].Value = (Convert.ToDouble(dgRow.Cells[6].Value) * Convert.ToDouble(dgRow.Cells[7].Value)).ToString();
                    }
                }
            }
            double sum = 0;
            foreach (DataGridViewRow dgRow in dataGridView2.Rows)
            {
                if (dgRow.Cells[8].Value != null) //Check for null reference
                {
                    if (!string.IsNullOrEmpty(dgRow.Cells[8].Value.ToString())) //Check for empty string
                    {
                        dgRow.Cells[8].Style.BackColor = Color.Orange;
                        sum = sum + Convert.ToDouble(dgRow.Cells[8].Value.ToString());
                    }
                    else
                    {
                        dgRow.Cells[8].Style.BackColor = Color.Red;
                    }
                }

                textBox16.Text = sum.ToString();
                textBox17.Text = ((sum * 24) / 100).ToString();
                if (string.IsNullOrWhiteSpace(textBox18.Text))
                {
                    textBox19.Text = textBox16.Text;
                }
                else
                {
                    textBox19.Text = (sum - Convert.ToDouble(textBox18.Text)).ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentCell.RowIndex);

            }
            catch (Exception)
            {
                MessageBox.Show("Error on deleting row");
            }
        }

        private void dataGridView2_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox14.Text))
            {
                MessageBox.Show("To πεδίο ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΓΓΕΛΙΑΣ είναι άδειο.");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Δεν έχετε επιλέξει πελάτη.");
            }
            else if (dataGridView2.Rows.Count == 1)
            {
                MessageBox.Show("Δεν έχετε κάνει παραγγελία.");
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Δεν έχετε επιλέξει ΣΤΑΔΙΟ ΠΑΡΑΓΓΕΛΙΑΣ.");
            }
            // else if (string.IsNullOrEmpty(textBox16.Text))
            // {
            //    MessageBox.Show("Δεν έχετε εκτελέσει ΥΠΟΛΟΓΙΣΜΟ ΠΑΡΑΓΓΕΛΙΑΣ.");
            // }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Δεν έχετε συμπληρώσει περιγραφή παραγγελίας");
            }
            else
            {
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                {
                    if (dgRow.Cells[6].Value != null) //Check for null reference
                    {
                        if (dgRow.Cells[7].Value != null)
                        {
                            dgRow.Cells[8].Value = (Convert.ToDouble(dgRow.Cells[6].Value) * Convert.ToDouble(dgRow.Cells[7].Value)).ToString();
                        }
                    }
                }
                double sum = 0;
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                {
                    if (dgRow.Cells[8].Value != null) //Check for null reference
                    {
                        if (!string.IsNullOrEmpty(dgRow.Cells[8].Value.ToString())) //Check for empty string
                        {
                            sum = sum + Convert.ToDouble(dgRow.Cells[8].Value.ToString());
                        }
                        else
                        {
                            dgRow.Cells[8].Style.BackColor = Color.Red;
                        }
                    }

                    textBox16.Text = sum.ToString();
                    textBox17.Text = ((sum * 24) / 100).ToString();
                    if (string.IsNullOrWhiteSpace(textBox18.Text))
                    {
                        textBox19.Text = textBox16.Text;
                    }
                    else
                    {
                        textBox19.Text = (sum - (float)Convert.ToDouble(textBox18.Text)).ToString();
                    }
                }

                Fillcombo3();
                Fillcombo5();
                try
                {
                    string myConnection3 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters

                    string Query3 = "insert into evotsis_gspot.InvoiceData2 (AA,PARATHRHSEIS,STADIOPARAGGELIAS,HMEROMHNIAPARAGGELIAS,PROKATAVOLH,YPOLOIPO,ID,SYNOLIKOKOSTOS,HMEROMHNIAPARADOSHS,SURNAME) values('" + textBox13.Text + "','" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + Convert.ToDateTime(textBox14.Text).ToString("yyyy-MM-dd") + "','" + textBox18.Text + "','" + textBox19.Text + "','" + textBox15.Text + "', '" + textBox16.Text + "', '2000/1/1','" + textBox2.Text + "');";
                    MySqlConnection myConn3 = new MySqlConnection(myConnection3);
                    MySqlCommand cmdDatabase3 = new MySqlCommand(Query3, myConn3);
                    MySqlDataReader myReader3;
                    try
                    {
                        myConn3.Open();
                        myReader3 = cmdDatabase3.ExecuteReader();
                        while (myReader3.Read())
                        {
                            //nothing this time to do
                        }

                        /////
                        int count = 0;
                        foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                        {

                            if (dgRow.Cells[0].Value != null)
                            {
                                try
                                {
                                    string myConnection2 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters
                                                                                                                                          //
                                    MySqlConnection myConn2 = new MySqlConnection(myConnection2);


                                    MySqlCommand cmd = new MySqlCommand();
                                    cmd = myConn2.CreateCommand();
                                    myConn2.Open();
                                    count = count + 1;
                                    cmd.CommandText = @"INSERT INTO evotsis_gspot.InvoiceData1 (AA,AAP,ERGASIA,YLIKO,PRINTSIZE,PRINTTYPE,PERIGRAFH,EPIPLEONERGASIES,POSOTHTA,TIMHMONADAS,KOSTOS,ID) VALUES(@data9,@data11,@data0,@data1,@data2,@data3,@data4,@data5,@data6,@data7,@data8,@data10);";
                                    cmd.Parameters.AddWithValue("@data9", textBox13.Text);
                                    cmd.Parameters.AddWithValue("@data11", count.ToString());
                                    cmd.Parameters.AddWithValue("@data0", dgRow.Cells[0].Value);
                                    cmd.Parameters.AddWithValue("@data1", dgRow.Cells[1].Value);
                                    cmd.Parameters.AddWithValue("@data2", dgRow.Cells[2].Value);
                                    cmd.Parameters.AddWithValue("@data3", dgRow.Cells[3].Value);
                                    cmd.Parameters.AddWithValue("@data4", dgRow.Cells[4].Value);
                                    cmd.Parameters.AddWithValue("@data5", dgRow.Cells[5].Value);
                                    cmd.Parameters.AddWithValue("@data6", dgRow.Cells[6].Value);
                                    cmd.Parameters.AddWithValue("@data7", dgRow.Cells[7].Value);
                                    cmd.Parameters.AddWithValue("@data8", dgRow.Cells[8].Value);
                                    cmd.Parameters.AddWithValue("@data10", textBox15.Text);
                                    cmd.ExecuteNonQuery();
                                    myConn2.Close();
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Οι παραγγελίες δεν καταχωρήθηκαν επιτυχώς");

                                }

                            }

                        }
                        /////
                        myConn3.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Λάθος στην αποθήκευση παραγγελίας - Διπλή εγγραφή πιθανόν για λεπτομέρειες επικοινωνήστε με τον administrator");

                    }

                    Fillcombo6();
                    MessageBox.Show("H παραγγελία καταχωρήθηκε επιτυχώς");
                    this.Close();

                }


                catch (Exception)
                {
                    MessageBox.Show("Σφάλμα σύνδεσης σε κάποια από τις βάσης δεδομένων");
                }



            }
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                {
                    if (dgRow.Cells[6].Value != null) //Check for null reference
                    {
                        if (dgRow.Cells[7].Value != null)
                        {
                            dgRow.Cells[8].Value = (Convert.ToDouble(dgRow.Cells[6].Value) * Convert.ToDouble(dgRow.Cells[7].Value)).ToString();
                        }
                    }
                }
            }
            if (e.KeyChar == (Char)Keys.Tab)
            {
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                {
                    if (dgRow.Cells[6].Value != null) //Check for null reference
                    {
                        if (dgRow.Cells[7].Value != null)
                        {
                            dgRow.Cells[8].Value = (Convert.ToDouble(dgRow.Cells[6].Value) * Convert.ToDouble(dgRow.Cells[7].Value)).ToString();
                        }
                    }
                }
            }
        }

        private void dataGridView2_Enter(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgRow in dataGridView2.Rows)
            {
                if (dgRow.Cells[6].Value != null) //Check for null reference
                {
                    if (dgRow.Cells[7].Value != null)
                    {
                        dgRow.Cells[8].Value = (Convert.ToDouble(dgRow.Cells[6].Value) * Convert.ToDouble(dgRow.Cells[7].Value)).ToString();
                    }
                }
            }
        }

        private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                {
                    if (dgRow.Cells[6].Value != null) //Check for null reference
                    {
                        if (dgRow.Cells[7].Value != null)
                        {
                            dgRow.Cells[8].Value = (Convert.ToDouble(dgRow.Cells[6].Value) * Convert.ToDouble(dgRow.Cells[7].Value)).ToString();
                        }
                    }
                }
            }

            base.OnKeyUp(e);
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                {
                    if (dgRow.Cells[6].Value != null) //Check for null reference
                    {
                        if (dgRow.Cells[7].Value != null)
                        {
                            dgRow.Cells[8].Value = (Convert.ToDouble(dgRow.Cells[6].Value) * Convert.ToDouble(dgRow.Cells[7].Value)).ToString();
                        }
                    }
                }
            }
            base.OnKeyDown(e);
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 44)
            {
                e.Handled = true;
            }
        }

        void Fillcombo5()//update the invoice number
        {
            try
            {
                int numval = Int32.Parse(textBox13.Text);
                numval += 1;
                string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
                string Query = "update evotsis_gspot.InvoiceNumber set NUMBER = '" + numval.ToString() + "'  where NUMBER = '" + textBox13.Text + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    while (myReader.Read())
                    {

                    }
                    myConn.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Το πρόγραμμα δεν μπορεί, να συνδεθεί στη βάση δεδομένων InvoiceNumber");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Το πρόγραμμα δεν μπορεί, να συνδεθεί στη βάση δεδομένων InvoiceNumber");
            }
        }

        private void print_button_Click(object sender, EventArgs e)
        {
            try
            {
                button3.PerformClick();
                Fillcombo7();

            }
            catch (Exception) { MessageBox.Show("Λάθος στον υπολογισμό υπολοίπων παραγγελιών"); }
            PrintReceipt();
        }

        private void PrintReceipt()
        {
            printDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.Landscape = true;//reverse page
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Graphics graphic = e.Graphics;
            Font font = new Font("Order", 12);
            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int offset = 40;
            graphic.DrawString("ΠΑΡΑΓΓΕΛΙΑ", new Font("Order", 18), new SolidBrush(Color.Black), 450, 4);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 11), new SolidBrush(Color.Black), startX + offset, 33);
            graphic.DrawString(textBox14.Text, new Font("Order", 9), new SolidBrush(Color.Black), startX + offset + 2, 51);



            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            graphic.DrawString("ΕΠΙΘΕΤΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + offset + 3, startY + 60);
            graphic.DrawString(textBox2.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + offset + 3, startY + 80);

            graphic.DrawString("ΟΝΟΜΑ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 280, startY + 60);
            graphic.DrawString(textBox3.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 280, startY + 80);

            graphic.DrawString("ΑΦΜ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 478, startY + 60);
            graphic.DrawString(textBox4.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 478, startY + 80);

            graphic.DrawString("ΠΟΛΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 576, startY + 60);
            graphic.DrawString(textBox10.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 576, startY + 80);

            graphic.DrawString("ΔΙΕΥΘΥΝΣΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 734, startY + 60);
            graphic.DrawString(textBox5.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 734, startY + 80);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            graphic.DrawString("ΤΗΛΕΦΩΝΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + offset + 3, startY + 110);
            graphic.DrawString(textBox7.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + offset + 3, startY + 130);

            graphic.DrawString("ΚΙΝΗΤΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 280, startY + 110);
            graphic.DrawString(textBox8.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 280, startY + 130);

            graphic.DrawString("ΦΑΧ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 478, startY + 110);
            graphic.DrawString(textBox9.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 478, startY + 130);

            graphic.DrawString("EMAIL", new Font("Order", 10), new SolidBrush(Color.Black), startX + 734, startY + 110);
            graphic.DrawString(textBox10.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 734, startY + 130);
            Pen blackPen = new Pen(Color.Black, 1);
            graphic.DrawLine(blackPen, 0, 159, startX + 1140, 159);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            graphic.DrawString("ΕΡΓΑΣΙΑ", new Font("Order", 9), new SolidBrush(Color.Black), startX, startY + 160);
            graphic.DrawString("ΥΛΙΚΟ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 125, startY + 160);
            //graphic.DrawString("ΜΕΓΕΘΗ ΕΚΤΥΠΩΣΗΣ", new Font("Order", 7), new SolidBrush(Color.Black), startX + 245, startY + 160);
            graphic.DrawString("ΤΥΠΟΣ ΕΚΤΥΠΩΣΗΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 330, startY + 160);
            graphic.DrawString("ΠΕΡΙΓΡΑΦΗ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 520, startY + 160);
            graphic.DrawString("ΕΠΙΠΛΕΟΝ ΕΡΓΑΣΙΕΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 750, startY + 160);
            graphic.DrawString("ΠΟΣΟΤΗΤΑ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 890, startY + 160);
            graphic.DrawString("ΤΙΜΗ ΜΟΝ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 964, startY + 160);
            graphic.DrawString("ΚΟΣΤΟΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 1035, startY + 160);
            int offset2 = 180;


            foreach (DataGridViewRow dgRow in dataGridView2.Rows)
            {
                graphic.DrawString(dgRow.Cells[0].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + offset2);
                graphic.DrawString(dgRow.Cells[1].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 125, startY + offset2);
                //graphic.DrawString(dgRow.Cells[2].FormattedValue.ToString(), new Font("Order", 6), new SolidBrush(Color.Black), startX + 245, startY + offset2);//ΜΕΓΕΘΗ ΕΚΤΥΠΩΣΗΣ
                graphic.DrawString(dgRow.Cells[3].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 330, startY + offset2);
                string str = dgRow.Cells[4].FormattedValue.ToString();
                int i = str.Length;
                if (i <= 40) { graphic.DrawString(str, new Font("Order", 6), new SolidBrush(Color.Black), startX + 520, startY + offset2); }
                if (i > 40 && i <= 80)
                {
                    string str1 = str.Substring(0, 40);
                    graphic.DrawString(str1, new Font("Order", 6), new SolidBrush(Color.Black), startX + 520, startY + offset2);
                    string str2 = str.Substring(40);
                    graphic.DrawString(str2, new Font("Order", 6), new SolidBrush(Color.Black), startX + 520, startY + offset2 + 10);
                }
                if (i > 80 && i <= 120)
                {
                    string str1 = str.Substring(0, 40);
                    graphic.DrawString(str1, new Font("Order", 6), new SolidBrush(Color.Black), startX + 520, startY + offset2);
                    string str2 = str.Substring(40, 40);
                    graphic.DrawString(str2, new Font("Order", 6), new SolidBrush(Color.Black), startX + 520, startY + offset2 + 10);
                    string str3 = str.Substring(80);
                    graphic.DrawString(str3, new Font("Order", 6), new SolidBrush(Color.Black), startX + 520, startY + offset2 + 20);
                }

                graphic.DrawString(dgRow.Cells[5].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 750, startY + offset2);
                graphic.DrawString(dgRow.Cells[6].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 890, startY + offset2);
                graphic.DrawString(dgRow.Cells[7].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 964, startY + offset2);
                graphic.DrawString(dgRow.Cells[8].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 1035, startY + offset2);
                offset2 += 35;
            }
            /*graphic.DrawRectangle(Pens.Black, startX - 10, startY - 10 + 535, 1320, 125);
            graphic.DrawString("ΠΛΗΡΩΜΗ1", new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[0].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX, startY + 563);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ1", new Font("Order", 7), new SolidBrush(Color.Black), startX + 63, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[1].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 63, startY + 563);
            graphic.DrawString("ΠΛΗΡΩΜΗ2", new Font("Order", 7), new SolidBrush(Color.Black), startX + 145, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[2].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 145, startY + 563);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ2", new Font("Order", 7), new SolidBrush(Color.Black), startX + 208, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[3].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 208, startY + 563);
            graphic.DrawString("ΠΛΗΡΩΜΗ3", new Font("Order", 7), new SolidBrush(Color.Black), startX + 290, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[4].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 290, startY + 563);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ3", new Font("Order", 7), new SolidBrush(Color.Black), startX + 355, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[5].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 355, startY + 563);
            graphic.DrawString("ΠΛΗΡΩΜΗ4", new Font("Order", 7), new SolidBrush(Color.Black), startX + 436, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[6].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 436, startY + 563);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ4", new Font("Order", 7), new SolidBrush(Color.Black), startX + 499, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[7].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 499, startY + 563);
            graphic.DrawString("ΠΛΗΡΩΜΗ5", new Font("Order", 7), new SolidBrush(Color.Black), startX + 578, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[8].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 578, startY + 563);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ5", new Font("Order", 7), new SolidBrush(Color.Black), startX + 645, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[9].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 645, startY + 563);
            graphic.DrawString("ΠΛΗΡΩΜΗ6", new Font("Order", 7), new SolidBrush(Color.Black), startX + 729, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[10].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 729, startY + 563);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ6", new Font("Order", 7), new SolidBrush(Color.Black), startX + 796, startY + 535);
            graphic.DrawString(dataGridView1.Rows[0].Cells[11].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 796, startY + 563);

            graphic.DrawString("ΠΛΗΡΩΜΗ7", new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[12].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX, startY + 623);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ7", new Font("Order", 7), new SolidBrush(Color.Black), startX + 63, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[13].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 63, startY + 623);
            graphic.DrawString("ΠΛΗΡΩΜΗ8", new Font("Order", 7), new SolidBrush(Color.Black), startX + 145, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[14].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 145, startY + 623);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ8", new Font("Order", 7), new SolidBrush(Color.Black), startX + 208, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[15].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 208, startY + 623);
            graphic.DrawString("ΠΛΗΡΩΜΗ9", new Font("Order", 7), new SolidBrush(Color.Black), startX + 290, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[16].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 290, startY + 623);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ9", new Font("Order", 7), new SolidBrush(Color.Black), startX + 355, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[17].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 355, startY + 623);
            graphic.DrawString("ΠΛΗΡΩΜΗ10", new Font("Order", 7), new SolidBrush(Color.Black), startX + 436, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[18].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 436, startY + 623);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ10", new Font("Order", 7), new SolidBrush(Color.Black), startX + 505, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[19].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 505, startY + 623);
            graphic.DrawString("ΠΛΗΡΩΜΗ11", new Font("Order", 7), new SolidBrush(Color.Black), startX + 593, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[20].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 593, startY + 623);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ11", new Font("Order", 7), new SolidBrush(Color.Black), startX + 660, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[21].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 660, startY + 623);
            graphic.DrawString("ΠΛΗΡΩΜΗ12", new Font("Order", 7), new SolidBrush(Color.Black), startX + 744, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[22].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 744, startY + 623);
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ12", new Font("Order", 7), new SolidBrush(Color.Black), startX + 814, startY + 595);
            graphic.DrawString(dataGridView1.Rows[0].Cells[23].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 814, startY + 623);*/
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            graphic.DrawString("ΥΠΟΛΟΙΠΟ ΠΑΡΑΓΓΕΛΙΩΝ ΠΕΛΑΤΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 430, startY + 765);
            graphic.DrawString(textBox20.Text, new Font("Order", 10), new SolidBrush(Color.Red), startX + 480, startY + 785);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            graphic.DrawRectangle(Pens.Black, startX - 10, startY - 10 + 668, 755, 250);
            graphic.DrawRectangle(Pens.Black, startX + 745, startY - 10 + 668, 350, 250);

            graphic.DrawString("ΠΑΡΑΤΗΡΗΣΕΙΣ - ΠΕΡΙΓΡΑΦΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX, startY + 668);
            string str11 = textBox1.Text;
            int i2 = str11.Length;
            if (i2 <= 80) { graphic.DrawString(str11, new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + 687); }
            if (i2 > 80 && i2 <= 160)
            {
                string str12 = str11.Substring(0, 80);
                graphic.DrawString(str12, new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + 687);
                string str13 = str11.Substring(80);
                graphic.DrawString(str13, new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + 697);
            }
            if (i2 > 160 && i2 <= 240)
            {
                string str12 = str11.Substring(0, 80);
                graphic.DrawString(str12, new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + 687);
                string str13 = str11.Substring(80, 80);
                graphic.DrawString(str13, new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + 697);
                string str14 = str11.Substring(120);
                graphic.DrawString(str14, new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + 707);
            }
            graphic.DrawString("ΣΤΑΔΙΟ ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX, startY + 715);
            graphic.DrawString(comboBox1.Text, new Font("Order", 8), new SolidBrush(Color.Red), startX, startY + 733);
            //graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΔΟΣΗΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX, startY + 752);
            //graphic.DrawString(textBox16.Text, new Font("Order", 8), new SolidBrush(Color.Red), startX, startY + 769);
            graphic.DrawString("ΣΥΝΟΛΙΚΟ ΚΟΣΤΟΣ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 754, startY + 668);
            graphic.DrawString(textBox16.Text, new Font("Order", 10), new SolidBrush(Color.Black), startX + 904, startY + 668);
            graphic.DrawString("ΠΡΟΚΑΤΑΒΟΛΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 754, startY + 692);
            graphic.DrawString(textBox18.Text, new Font("Order", 10), new SolidBrush(Color.Black), startX + 904, startY + 692);
            graphic.DrawString("ΥΠΟΛΟΙΠΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 754, startY + 715);
            graphic.DrawString(textBox19.Text, new Font("Order", 10), new SolidBrush(Color.Red), startX + 904, startY + 712);
            graphic.DrawString("+ ΦΠΑ 24 %", new Font("Order", 9), new SolidBrush(Color.Black), startX + 754, startY + 765);
            graphic.DrawString(textBox17.Text, new Font("Order", 9), new SolidBrush(Color.Black), startX + 904, startY + 765);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        void Fillcombo7()
        {
            double sum = 0;
            string myConnection5 = "192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query5 = "select * from evotsis_gspot.InvoiceData2 where ID = '" + textBox15.Text + "';";
            MySqlConnection myConn5 = new MySqlConnection(myConnection5);
            MySqlCommand cmdDatabase5 = new MySqlCommand(Query5, myConn5);
            MySqlDataReader myReader5;
            try
            {
                myConn5.Open();
                myReader5 = cmdDatabase5.ExecuteReader();
                while (myReader5.Read())
                {

                    string str1 = myReader5.GetString("YPOLOIPO");//one reading in parameter
                    sum += Convert.ToDouble(str1);


                }
                myConn5.Close();
                if (!string.IsNullOrEmpty(textBox19.Text)) //Check for empty string
                {
                    sum = sum + Convert.ToDouble(textBox19.Text);
                }

                textBox20.Text = sum.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to database Ypoloipa from InvoiceData2");
            }
        }
    }
}
