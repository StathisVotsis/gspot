using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace gspot
{
    public partial class CustomerTab : Form
    {
        DateTimePicker oDateTimePicker1 = new DateTimePicker();//calendar 
        DateTimePicker oDateTimePicker2 = new DateTimePicker();//calendar 
        DateTimePicker oDateTimePicker3 = new DateTimePicker();//calendar 
        DateTimePicker oDateTimePicker4 = new DateTimePicker();//calendar 
        double totalsum = 0;
        double totalsum2 = 0;
        int offset2 = 180;
        int count = 0;
        int i;
        int flag = 0;
        DataTable dbdataset;
        DataTable dt = new DataTable();
        public string MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public string MyProperty3 { get; set; }
        public string MyProperty4 { get; set; }
        public string MyProperty5 { get; set; }
        public string MyProperty6 { get; set; }
        public string MyProperty7 { get; set; }
        public string MyProperty8 { get; set; }
        public string MyProperty9 { get; set; }
        public string MyProperty10 { get; set; }

        public CustomerTab()
        {
            InitializeComponent();
        }

        private void CustomerTab_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.MyProperty1;
            textBox2.Text = this.MyProperty2;
            textBox3.Text = this.MyProperty3;
            textBox4.Text = this.MyProperty4;
            textBox5.Text = this.MyProperty5;
            textBox6.Text = this.MyProperty6;
            textBox7.Text = this.MyProperty7;
            textBox8.Text = this.MyProperty8;
            textBox9.Text = this.MyProperty9;
            try
            {
                Fillcombo1();
            }
            catch (Exception)
            {
                MessageBox.Show("Το σύστημα δεν μπορεί να συνδεθεί στη βάση δεδομένων InvoiceData2");
            }
        }

        void Fillcombo1()
        {

            string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query = "select AA, PARATHRHSEIS, STADIOPARAGGELIAS, HMEROMHNIAPARAGGELIAS, PROKATAVOLH, YPOLOIPO, ID, SYNOLIKOKOSTOS, HMEROMHNIAPARADOSHS  from evotsis_gspot.InvoiceData2 where ID ='" + MyProperty10 + "';";
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
                dataGridView1.Columns[0].HeaderText = "Α/Α";
                dataGridView1.Columns[1].HeaderText = "ΠΕΡΙΓΡΑΦΗ ΠΑΡΑΓΓΕΛΙΑΣ";
                dataGridView1.Columns[2].HeaderText = "ΣΤΑΔΙΟ ΠΑΡΑΓΓΕΛΙΑΣ";
                dataGridView1.Columns[3].HeaderText = "ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΓΓΕΛΙΑΣ";
                dataGridView1.Columns[4].HeaderText = "ΠΡΟΚΑΤΑΒΟΛΗ";
                dataGridView1.Columns[5].HeaderText = "ΥΠΟΛΟΙΠΟ";
                dataGridView1.Columns[6].HeaderText = "ID";
                dataGridView1.Columns[7].HeaderText = "ΣΥΝΟΛΙΚΟ ΚΟΣΤΟΣ";
                dataGridView1.Columns[8].HeaderText = "ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΔΟΣΗΣ";
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to database InvoiceData2");
            }

        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            textBox11.Text = oDateTimePicker1.Text.ToString();

        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker1.Visible = false;
        }

        private void dateTimePicker_OnTextChange2(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            textBox10.Text = oDateTimePicker2.Text.ToString();

        }

        void oDateTimePicker_CloseUp2(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker2.Visible = false;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            //Initialized a new DateTimePicker Control  
            oDateTimePicker1 = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            textBox11.Controls.Add(oDateTimePicker1);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker1.Format = DateTimePickerFormat.Short;
            //oDateTimePicker1.Format = DateTimePickerFormat.Custom;
            //oDateTimePicker1.CustomFormat = "yyyy MMM dd";

            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = textBox11.DisplayRectangle;

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

        private void textBox10_Click(object sender, EventArgs e)
        {
            //Initialized a new DateTimePicker Control  
            oDateTimePicker2 = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            textBox10.Controls.Add(oDateTimePicker2);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker2.Format = DateTimePickerFormat.Short;
            //oDateTimePicker1.Format = DateTimePickerFormat.Custom;
            //oDateTimePicker1.CustomFormat = "yyyy MMM dd";

            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = textBox10.DisplayRectangle;

            //Setting area for DateTimePicker Control  
            oDateTimePicker2.Size = new Size(oRectangle.Width, oRectangle.Height);

            // Setting Location  
            oDateTimePicker2.Location = new Point(oRectangle.X, oRectangle.Y);

            // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            oDateTimePicker2.CloseUp += new EventHandler(oDateTimePicker_CloseUp2);

            // An event attached to dateTimePicker Control which is fired when any date is selected  
            oDateTimePicker2.TextChanged += new EventHandler(dateTimePicker_OnTextChange2);

            // Now make it visible  
            oDateTimePicker2.Visible = true;
        }

        private void textBox14_Click(object sender, EventArgs e)
        {
            //Initialized a new DateTimePicker Control  
            oDateTimePicker3 = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            textBox14.Controls.Add(oDateTimePicker3);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker3.Format = DateTimePickerFormat.Short;
            //oDateTimePicker1.Format = DateTimePickerFormat.Custom;
            //oDateTimePicker1.CustomFormat = "yyyy MMM dd";

            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = textBox14.DisplayRectangle;

            //Setting area for DateTimePicker Control  
            oDateTimePicker3.Size = new Size(oRectangle.Width, oRectangle.Height);

            // Setting Location  
            oDateTimePicker3.Location = new Point(oRectangle.X, oRectangle.Y);

            // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            oDateTimePicker3.CloseUp += new EventHandler(oDateTimePicker_CloseUp3);

            // An event attached to dateTimePicker Control which is fired when any date is selected  
            oDateTimePicker3.TextChanged += new EventHandler(dateTimePicker_OnTextChange3);

            // Now make it visible  
            oDateTimePicker3.Visible = true;
        }

        void oDateTimePicker_CloseUp3(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker3.Visible = false;
        }

        private void dateTimePicker_OnTextChange3(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            textBox14.Text = oDateTimePicker3.Text.ToString();

        }

        void oDateTimePicker_CloseUp4(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker4.Visible = false;
        }

        private void dateTimePicker_OnTextChange4(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            textBox15.Text = oDateTimePicker4.Text.ToString();

        }

        private void textBox15_Click(object sender, EventArgs e)
        {
            //Initialized a new DateTimePicker Control  
            oDateTimePicker4 = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            textBox15.Controls.Add(oDateTimePicker4);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker4.Format = DateTimePickerFormat.Short;
            //oDateTimePicker1.Format = DateTimePickerFormat.Custom;
            //oDateTimePicker1.CustomFormat = "yyyy MMM dd";

            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = textBox15.DisplayRectangle;

            //Setting area for DateTimePicker Control  
            oDateTimePicker4.Size = new Size(oRectangle.Width, oRectangle.Height);

            // Setting Location  
            oDateTimePicker4.Location = new Point(oRectangle.X, oRectangle.Y);

            // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            oDateTimePicker4.CloseUp += new EventHandler(oDateTimePicker_CloseUp4);

            // An event attached to dateTimePicker Control which is fired when any date is selected  
            oDateTimePicker4.TextChanged += new EventHandler(dateTimePicker_OnTextChange4);

            // Now make it visible  
            oDateTimePicker4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox14.Text) && string.IsNullOrEmpty(textBox15.Text))
            {
                string myConnection2 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
                string Query2 = "select YPOLOIPO from evotsis_gspot.InvoiceData2 where  ID = '" + MyProperty10 + "' ;";
                MySqlConnection myConn2 = new MySqlConnection(myConnection2);
                MySqlCommand cmdDatabase2 = new MySqlCommand(Query2, myConn2);
                MySqlDataReader myReader2;
                try
                {
                    myConn2.Open();
                    myReader2 = cmdDatabase2.ExecuteReader();
                    while (myReader2.Read())
                    {
                        string sum = myReader2.GetString("YPOLOIPO");//one reading in parameter
                        double numVal = Convert.ToDouble(sum);
                        totalsum2 += numVal;
                    }
                    textBox13.Text = totalsum2.ToString();
                    totalsum2 = 0;
                    myConn2.Close();


                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot connect to database InvoiceData2");
                }
            }
            else if (string.IsNullOrEmpty(textBox14.Text))
            {
                MessageBox.Show("Δεν έχεις επιλέξει ΑΠΟ ΗΜΕΡΟΜΗΝΙΑ");
            }
            else if (string.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show("Δεν έχεις επιλέξει ΕΩΣ ΗΜΕΡΟΜΗΝΙΑ");
            }
            else
            {
                string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
                string Query = "select YPOLOIPO from evotsis_gspot.InvoiceData2 where  ID = '" + MyProperty10 + "' and HMEROMHNIAPARAGGELIAS between '" + Convert.ToDateTime(textBox14.Text).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(textBox15.Text).ToString("yyyy-MM-dd") + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    while (myReader.Read())
                    {
                        string sum = myReader.GetString("YPOLOIPO");//one reading in parameter
                        double numVal = Convert.ToDouble(sum);
                        totalsum2 += numVal;
                    }
                    textBox13.Text = totalsum2.ToString();
                    totalsum2 = 0;
                    myConn.Close();


                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot connect to database InvoiceData2");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;
            textBox14.Text = null;
            textBox15.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text) && string.IsNullOrEmpty(textBox10.Text))
            {
                string myConnection2 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
                string Query2 = "select SYNOLIKOKOSTOS from evotsis_gspot.InvoiceData2 where  ID = '" + MyProperty10 + "' ;";
                MySqlConnection myConn2 = new MySqlConnection(myConnection2);
                MySqlCommand cmdDatabase2 = new MySqlCommand(Query2, myConn2);
                MySqlDataReader myReader2;
                try
                {
                    myConn2.Open();
                    myReader2 = cmdDatabase2.ExecuteReader();
                    while (myReader2.Read())
                    {
                        string sum = myReader2.GetString("SYNOLIKOKOSTOS");//one reading in parameter
                        double numVal = Convert.ToDouble(sum);
                        totalsum += numVal;
                    }
                    textBox12.Text = totalsum.ToString();
                    totalsum = 0;
                    myConn2.Close();


                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot connect to database InvoiceData2");
                }
            }
            else if (string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Δεν έχεις επιλέξει ΑΠΟ ΗΜΕΡΟΜΗΝΙΑ");
            }
            else if (string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Δεν έχεις επιλέξει ΕΩΣ ΗΜΕΡΟΜΗΝΙΑ");
            }
            else
            {
                string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
                string Query = "select SYNOLIKOKOSTOS from evotsis_gspot.InvoiceData2 where  ID = '" + MyProperty10 + "' and HMEROMHNIAPARAGGELIAS between '" + Convert.ToDateTime(textBox11.Text).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(textBox10.Text).ToString("yyyy-MM-dd") + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = cmdDatabase.ExecuteReader();
                    while (myReader.Read())
                    {
                        string sum = myReader.GetString("SYNOLIKOKOSTOS");//one reading in parameter
                        double numVal = Convert.ToDouble(sum);
                        totalsum += numVal;
                    }
                    textBox12.Text = totalsum.ToString();
                    totalsum = 0;
                    myConn.Close();


                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot connect to database InvoiceData2");
                }
            }
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query = "update evotsis_gspot.Customers set SURNAME = '" + textBox1.Text + "',NAME = '" + textBox2.Text + "' ,AFM = '" + textBox3.Text + "' ,ADRESS = '" + textBox4.Text + "' ,CITY = '" + textBox5.Text + "' ,PHONE = '" + textBox6.Text + "' ,CELL = '" + textBox7.Text + "' ,FAX = '" + textBox8.Text + "' ,EMAIL = '" + textBox9.Text + "' where ID = '" + MyProperty10 + "';";
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
                MessageBox.Show("Τα στοιχεία ανανεώθηκαν επιτυχώς");
            }
            catch (Exception)
            {
                MessageBox.Show("Το πρόγραμμα δεν μπορεί, να συνδεθεί στη βάση δεδομένων Custmers για ανανέωση");
            }
        }

        private void print_button_Click(object sender, EventArgs e)
        {
            try
            {
                //button1.PerformClick();
                //Fillcombo7();
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
            float pageHeight = e.PageSettings.PrintableArea.Height;
            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int offset = 40;
            if (flag == 0)
            {

                graphic.DrawString("ΠΑΡΑΓΓΕΛΙΕΣ ΠΕΛΑΤΗ", new Font("Order", 18), new SolidBrush(Color.Black), 400, 14);
                //graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 11), new SolidBrush(Color.Black), startX + offset, 33);
                //graphic.DrawString(textBox15.Text, new Font("Order", 9), new SolidBrush(Color.Black), startX + offset + 2, 51);



                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                graphic.DrawString("ΕΠΙΘΕΤΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + offset + 3, startY + 60);
                graphic.DrawString(textBox1.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + offset + 3, startY + 80);

                graphic.DrawString("ΟΝΟΜΑ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 280, startY + 60);
                graphic.DrawString(textBox2.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 280, startY + 80);

                graphic.DrawString("ΑΦΜ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 478, startY + 60);
                graphic.DrawString(textBox3.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 478, startY + 80);

                graphic.DrawString("ΠΟΛΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 576, startY + 60);
                graphic.DrawString(textBox5.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 576, startY + 80);

                graphic.DrawString("ΔΙΕΥΘΥΝΣΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 734, startY + 60);
                graphic.DrawString(textBox4.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 734, startY + 80);

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                graphic.DrawString("ΤΗΛΕΦΩΝΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + offset + 3, startY + 110);
                graphic.DrawString(textBox6.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + offset + 3, startY + 130);

                graphic.DrawString("ΚΙΝΗΤΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 280, startY + 110);
                graphic.DrawString(textBox7.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 280, startY + 130);

                graphic.DrawString("ΦΑΧ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 478, startY + 110);
                graphic.DrawString(textBox8.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 478, startY + 130);

                graphic.DrawString("EMAIL", new Font("Order", 10), new SolidBrush(Color.Black), startX + 734, startY + 110);
                graphic.DrawString(textBox9.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 734, startY + 130);
                Pen blackPen = new Pen(Color.Black, 1);
                graphic.DrawLine(blackPen, 0, 159, startX + 1140, 159);
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                graphic.DrawString("ΠΕΡΙΓΡΑΦΗ", new Font("Order", 9), new SolidBrush(Color.Black), startX, startY + 160);
                graphic.DrawString("ΣΤΑΔΙΟ ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 270, startY + 160);
                graphic.DrawString("ΗΜ.ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 460, startY + 160);
                graphic.DrawString("ΠΡΟΚΑΤΑΒΟΛΗ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 618, startY + 160);
                graphic.DrawString("ΥΠΟΛΟΙΠΟ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 740, startY + 160);
                graphic.DrawString("ΣΥΝΟΛΙΚΟ ΚΟΣΤΟΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 825, startY + 160);
                graphic.DrawString("ΗΜ.ΠΑΡΑΔΟΣΗΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 964, startY + 160);

            }
            else
            {
                graphic.DrawString("ΠΕΡΙΓΡΑΦΗ", new Font("Order", 9), new SolidBrush(Color.Black), startX, startY + 20);
                graphic.DrawString("ΣΤΑΔΙΟ ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 270, startY + 20);
                graphic.DrawString("ΗΜ.ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 460, startY + 20);
                graphic.DrawString("ΠΡΟΚΑΤΑΒΟΛΗ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 618, startY + 20);
                graphic.DrawString("ΥΠΟΛΟΙΠΟ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 740, startY + 20);
                graphic.DrawString("ΣΥΝΟΛΙΚΟ ΚΟΣΤΟΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 825, startY + 20);
                graphic.DrawString("ΗΜ.ΠΑΡΑΔΟΣΗΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 964, startY + 20);
            }

            for (i = count; i < dataGridView1.RowCount; i++)
            {
                string str = dataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
                str = Regex.Replace(str, @"\s+", " ", RegexOptions.Multiline);
                int i2 = str.Length;
                if (i2 <= 40) { graphic.DrawString(str, new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + offset2); }
                else if (i2 > 40 && i2 <= 80)
                {
                    string str1 = str.Substring(0, 40);
                    graphic.DrawString(str1, new Font("Order", 6), new SolidBrush(Color.Black), startX, startY + offset2);
                    string str2 = str.Substring(40);
                    graphic.DrawString(str2, new Font("Order", 6), new SolidBrush(Color.Black), startX, startY + offset2 + 10);
                }
                else if (i2 > 80 && i2 <= 120)
                {
                    string str1 = str.Substring(0, 40);
                    graphic.DrawString(str1, new Font("Order", 6), new SolidBrush(Color.Black), startX, startY + offset2);
                    string str2 = str.Substring(40, 40);
                    graphic.DrawString(str2, new Font("Order", 6), new SolidBrush(Color.Black), startX, startY + offset2 + 10);
                    string str3 = str.Substring(80);
                    graphic.DrawString(str3, new Font("Order", 6), new SolidBrush(Color.Black), startX, startY + offset2 + 20);
                }
                else
                {
                    string str1 = str.Substring(0, 40);
                    graphic.DrawString(str1, new Font("Order", 6), new SolidBrush(Color.Black), startX, startY + offset2);
                    string str2 = str.Substring(40, 40);
                    graphic.DrawString(str2, new Font("Order", 6), new SolidBrush(Color.Black), startX, startY + offset2 + 10);
                    string str3 = str.Substring(80);
                    graphic.DrawString(str3, new Font("Order", 6), new SolidBrush(Color.Black), startX, startY + offset2 + 20);
                }
                //graphic.DrawString(dataGridView1.Rows[i].Cells[1].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[2].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 270, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[3].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 470, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[4].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 618, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[5].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Red), startX + 750, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[7].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 835, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[8].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 974, startY + offset2);
                offset2 += 35;
                if (offset2 >= startY + 745) { offset2 = 50; count = i; flag = 1; e.HasMorePages = true; return; } else { e.HasMorePages = false; }
                //
            }
            Pen blackPen2 = new Pen(Color.Black, 1);
            graphic.DrawLine(blackPen2, 0, startY + 700, startX + 1140, startY + 700);
            graphic.DrawLine(blackPen2, startX + 330, startY + 700, startX + 330, startY + 1000);
            graphic.DrawLine(blackPen2, startX + 520, startY + 700, startX + 520, startY + 1000);
            graphic.DrawString("ΣΥΝΟΛΟ ΚΟΣΤΟΥΣ", new Font("Order", 11), new SolidBrush(Color.Black), startX + 164, startY + 720);
            graphic.DrawString("ΣΥΝΟΛΟ ΠΛΗΡΩΜΩΝ", new Font("Order", 11), new SolidBrush(Color.Black), startX + 344, startY + 720);
            graphic.DrawString("ΥΠΟΛΟΙΠΟ", new Font("Order", 11), new SolidBrush(Color.Black), startX + 534, startY + 720);
            graphic.DrawString("created by", new Font("Order", 7), new SolidBrush(Color.Black), startX + 870, startY + 720);
            graphic.DrawString("Stathis Votsis", new Font("Order", 7), new SolidBrush(Color.Black), startX + 870, startY + 735);
            graphic.DrawString("software engineer", new Font("Order", 7), new SolidBrush(Color.Black), startX + 870, startY + 750);
            graphic.DrawString("stathisvotsis@gmail.com", new Font("Order", 7), new SolidBrush(Color.Black), startX + 870, startY + 765);
            double totalcost = 0;
            double totalypoloipo = 0;
            double totalpayment;
            foreach (DataGridViewRow dgRow in dataGridView1.Rows)
            {
                totalcost += Convert.ToDouble(dgRow.Cells[7].Value);
                totalypoloipo += Convert.ToDouble(dgRow.Cells[5].Value);
            }
            totalpayment = totalcost - totalypoloipo;
            graphic.DrawString(totalcost.ToString(), new Font("Order", 11), new SolidBrush(Color.Black), startX + 174, startY + 745);
            graphic.DrawString(totalpayment.ToString(), new Font("Order", 11), new SolidBrush(Color.Black), startX + 354, startY + 745);
            graphic.DrawString(totalypoloipo.ToString(), new Font("Order", 11), new SolidBrush(Color.Red), startX + 544, startY + 745);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = this.MyProperty1;
            textBox2.Text = this.MyProperty2;
            textBox3.Text = this.MyProperty3;
            textBox4.Text = this.MyProperty4;
            textBox5.Text = this.MyProperty5;
            textBox6.Text = this.MyProperty6;
            textBox7.Text = this.MyProperty7;
            textBox8.Text = this.MyProperty8;
            textBox9.Text = this.MyProperty9;
            try
            {
                Fillcombo1();
            }
            catch (Exception)
            {
                MessageBox.Show("Το σύστημα δεν μπορεί να συνδεθεί στη βάση δεδομένων InvoiceData2");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewOrder myform = new NewOrder();
            myform.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string string1 = row.Cells["AA"].Value.ToString();
                string string2 = row.Cells["ID"].Value.ToString();
                SpecificOrder frm3 = new SpecificOrder();
                frm3.MyProperty11 = string1;
                frm3.MyProperty12 = string2;
                frm3.Show();
            }
        }
    }
}
