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

namespace gspot
{
    public partial class SpecificOrder : Form
    {
        DateTimePicker oDateTimePicker1 = new DateTimePicker();//calendar 
        DateTimePicker oDateTimePicker2 = new DateTimePicker();//calendar 
        DateTimePicker oDateTimePicker3 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker4 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker5 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker6 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker7 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker8 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker9 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker10 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker11 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker12 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker13 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker14 = new DateTimePicker();//calendar
        DateTimePicker oDateTimePicker15 = new DateTimePicker();//calendar
                                                                //DataTable dbdataset;
        DataTable dt = new DataTable();
        //DataTable dbdataset2;
        int flag1 = 1;
        int flag2 = 1;
        //int flag3 = 1;
        double sum2 = 0;
        DataTable dt2 = new DataTable();
        public string MyProperty11 { get; set; }
        public string MyProperty12 { get; set; }
        //string date1;

        public SpecificOrder()
        {
            InitializeComponent();
        }

        private void SpecificOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet61.AdditionalWorks' table. You can move, or remove it, as needed.
            this.additionalWorksTableAdapter.Fill(this.evotsis_gspotDataSet61.AdditionalWorks);
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet60.PrintType' table. You can move, or remove it, as needed.
            this.printTypeTableAdapter.Fill(this.evotsis_gspotDataSet60.PrintType);
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet59.PrintSize' table. You can move, or remove it, as needed.
            this.printSizeTableAdapter.Fill(this.evotsis_gspotDataSet59.PrintSize);
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet58.Ylika7' table. You can move, or remove it, as needed.
            this.ylika7TableAdapter.Fill(this.evotsis_gspotDataSet58.Ylika7);
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet57.Work' table. You can move, or remove it, as needed.
            this.workTableAdapter.Fill(this.evotsis_gspotDataSet57.Work);


            try
            {

                Fillcombo2();
                Fillcombo4();
                this.invoiceData1TableAdapter.FillBy(this.evotsis_gspotDataSet55.InvoiceData1, MyProperty11, MyProperty12);
                this.pLHRWMESTableAdapter.FillBy(this.evotsis_gspotDataSet56.PLHRWMES, MyProperty11, MyProperty12);
            }
            catch (Exception)
            {
                MessageBox.Show("Το σύστημα δεν μπορεί να συνδεθεί στη βάση δεδομένων PLHRWMES,Customers");
            }
        }

        void Fillcombo2()//ΓΕΜΙΣΜΑ ΣΤΟΙΧΕΙΩΝ ΠΕΛΑΤΗ ΠΑΡΑΓΓΕΛΙΑΣ ΟΝ LOAD
        {

            string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query = "select SURNAME,NAME,AFM,ADRESS,CITY,PHONE,CELL,FAX,EMAIL from evotsis_gspot.Customers where ID = '" + MyProperty12 + "';";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                while (myReader.Read())
                {
                    textBox6.Text = myReader.GetString("SURNAME");//one reading in parameter
                    textBox7.Text = myReader.GetString("NAME");//one reading in parameter
                    textBox8.Text = myReader.GetString("AFM");//one reading in parameter
                    textBox9.Text = myReader.GetString("ADRESS");//one reading in parameter
                    textBox10.Text = myReader.GetString("CITY");//one reading in parameter
                    textBox11.Text = myReader.GetString("PHONE");//one reading in parameter
                    textBox12.Text = myReader.GetString("CELL");//one reading in parameter
                    textBox13.Text = myReader.GetString("FAX");//one reading in parameter
                    textBox14.Text = myReader.GetString("EMAIL");//one reading in parameter
                }

                myConn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to Customers ");
            }

            string myConnection7 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query7 = "select PARATHRHSEIS,STADIOPARAGGELIAS,HMEROMHNIAPARAGGELIAS,PROKATAVOLH,YPOLOIPO,SYNOLIKOKOSTOS,HMEROMHNIAPARADOSHS from evotsis_gspot.InvoiceData2 where AA = '" + MyProperty11 + "' and ID = '" + MyProperty12 + "';";
            MySqlConnection myConn7 = new MySqlConnection(myConnection7);
            MySqlCommand cmdDatabase7 = new MySqlCommand(Query7, myConn7);
            MySqlDataReader myReader7;
            try
            {
                myConn7.Open();
                myReader7 = cmdDatabase7.ExecuteReader();
                while (myReader7.Read())
                {
                    textBox1.Text = myReader7.GetString("PARATHRHSEIS");//one reading in parameter
                    comboBox1.Text = myReader7.GetString("STADIOPARAGGELIAS");//one reading in parameter

                    textBox15.Text = Convert.ToDateTime(myReader7.GetString("HMEROMHNIAPARAGGELIAS")).ToString("yyyy/MM/dd");//one reading in parameter//////////////////////////////////////////////////////////////////////////////////////
                    textBox3.Text = myReader7.GetString("PROKATAVOLH");//one reading in parameter
                    textBox4.Text = myReader7.GetString("YPOLOIPO");//one reading in parameter
                    textBox2.Text = myReader7.GetString("SYNOLIKOKOSTOS");//one reading in parameter
                    textBox16.Text = myReader7.GetString("HMEROMHNIAPARADOSHS");//one reading in parameter

                }

                myConn7.Close();

            }
            catch (Exception)
            {

            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            textBox15.Text = oDateTimePicker1.Text.ToString();

        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker1.Visible = false;
        }

        private void dateTimePicker_OnTextChange2(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            textBox16.Text = oDateTimePicker2.Text.ToString();

        }

        void oDateTimePicker_CloseUp2(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker2.Visible = false;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_Click(object sender, EventArgs e)
        {
            //Initialized a new DateTimePicker Control  
            oDateTimePicker1 = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            textBox15.Controls.Add(oDateTimePicker1);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker1.Format = DateTimePickerFormat.Short;
            //oDateTimePicker1.Format = DateTimePickerFormat.Custom;
            //oDateTimePicker1.CustomFormat = "yyyy MMM dd";

            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = textBox15.DisplayRectangle;

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

        private void textBox16_Click(object sender, EventArgs e)
        {
            //Initialized a new DateTimePicker Control  
            oDateTimePicker2 = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            textBox16.Controls.Add(oDateTimePicker2);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker2.Format = DateTimePickerFormat.Short;
            //oDateTimePicker1.Format = DateTimePickerFormat.Custom;
            //oDateTimePicker1.CustomFormat = "yyyy MMM dd";

            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = textBox16.DisplayRectangle;

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker4 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker4);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker4.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

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
            else if (e.ColumnIndex == 3)
            { //Initialized a new DateTimePicker Control  
                oDateTimePicker5 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker5);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker5.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker5.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker5.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker5.CloseUp += new EventHandler(oDateTimePicker_CloseUp5);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker5.TextChanged += new EventHandler(dateTimePicker_OnTextChange5);

                // Now make it visible  
                oDateTimePicker5.Visible = true;
            }
            else if (e.ColumnIndex == 5)
            { //Initialized a new DateTimePicker Control  
                oDateTimePicker6 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker6);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker6.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker6.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker6.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker6.CloseUp += new EventHandler(oDateTimePicker_CloseUp6);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker6.TextChanged += new EventHandler(dateTimePicker_OnTextChange6);

                // Now make it visible  
                oDateTimePicker6.Visible = true;
            }
            else if (e.ColumnIndex == 7)
            {//Initialized a new DateTimePicker Control  
                oDateTimePicker7 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker7);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker7.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker7.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker7.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker7.CloseUp += new EventHandler(oDateTimePicker_CloseUp7);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker7.TextChanged += new EventHandler(dateTimePicker_OnTextChange7);

                // Now make it visible  
                oDateTimePicker7.Visible = true;
            }
            else if (e.ColumnIndex == 9)
            {//Initialized a new DateTimePicker Control  
                oDateTimePicker8 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker8);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker8.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker8.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker8.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker8.CloseUp += new EventHandler(oDateTimePicker_CloseUp8);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker8.TextChanged += new EventHandler(dateTimePicker_OnTextChange8);

                // Now make it visible  
                oDateTimePicker8.Visible = true;
            }
            else if (e.ColumnIndex == 11)
            {//Initialized a new DateTimePicker Control  
                oDateTimePicker9 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker9);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker9.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker9.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker9.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker9.CloseUp += new EventHandler(oDateTimePicker_CloseUp9);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker9.TextChanged += new EventHandler(dateTimePicker_OnTextChange9);

                // Now make it visible  
                oDateTimePicker9.Visible = true;
            }
            else if (e.ColumnIndex == 13)
            {//Initialized a new DateTimePicker Control  
                oDateTimePicker10 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker10);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker10.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker10.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker10.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker10.CloseUp += new EventHandler(oDateTimePicker_CloseUp10);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker10.TextChanged += new EventHandler(dateTimePicker_OnTextChange10);

                // Now make it visible  
                oDateTimePicker10.Visible = true;
            }
            else if (e.ColumnIndex == 15)
            {//Initialized a new DateTimePicker Control  
                oDateTimePicker11 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker11);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker11.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker11.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker11.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker11.CloseUp += new EventHandler(oDateTimePicker_CloseUp11);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker11.TextChanged += new EventHandler(dateTimePicker_OnTextChange11);

                // Now make it visible  
                oDateTimePicker11.Visible = true;
            }
            else if (e.ColumnIndex == 17)
            { //Initialized a new DateTimePicker Control  
                oDateTimePicker12 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker12);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker12.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker12.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker12.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker12.CloseUp += new EventHandler(oDateTimePicker_CloseUp12);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker12.TextChanged += new EventHandler(dateTimePicker_OnTextChange12);

                // Now make it visible  
                oDateTimePicker12.Visible = true;
            }
            else if (e.ColumnIndex == 19)
            {//Initialized a new DateTimePicker Control  
                oDateTimePicker13 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker13);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker13.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker13.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker13.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker13.CloseUp += new EventHandler(oDateTimePicker_CloseUp13);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker13.TextChanged += new EventHandler(dateTimePicker_OnTextChange13);

                // Now make it visible  
                oDateTimePicker13.Visible = true;
            }
            else if (e.ColumnIndex == 21)
            {//Initialized a new DateTimePicker Control  
                oDateTimePicker14 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker14);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker14.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker14.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker14.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker14.CloseUp += new EventHandler(oDateTimePicker_CloseUp14);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker14.TextChanged += new EventHandler(dateTimePicker_OnTextChange14);

                // Now make it visible  
                oDateTimePicker14.Visible = true;
            }
            else if (e.ColumnIndex == 23)
            { //Initialized a new DateTimePicker Control  
                oDateTimePicker15 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker15);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker15.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker15.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker15.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker15.CloseUp += new EventHandler(oDateTimePicker_CloseUp15);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker15.TextChanged += new EventHandler(dateTimePicker_OnTextChange15);

                // Now make it visible  
                oDateTimePicker15.Visible = true;
            }
        }

       private void dateTimePicker_OnTextChange4(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker4.Text.ToString();
        }

        void oDateTimePicker_CloseUp4(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker4.Visible = false;
        }

        private void dateTimePicker_OnTextChange5(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker5.Text.ToString();
        }

        void oDateTimePicker_CloseUp5(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker5.Visible = false;
        }

        private void dateTimePicker_OnTextChange6(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker6.Text.ToString();
        }

        void oDateTimePicker_CloseUp6(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker6.Visible = false;
        }

        private void dateTimePicker_OnTextChange7(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker7.Text.ToString();
        }

        void oDateTimePicker_CloseUp7(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker7.Visible = false;
        }

        private void dateTimePicker_OnTextChange8(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker8.Text.ToString();
        }

        void oDateTimePicker_CloseUp8(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker8.Visible = false;
        }

        private void dateTimePicker_OnTextChange9(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker9.Text.ToString();
        }

        void oDateTimePicker_CloseUp9(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker9.Visible = false;
        }

        private void dateTimePicker_OnTextChange10(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker10.Text.ToString();
        }

        void oDateTimePicker_CloseUp10(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker10.Visible = false;
        }

        private void dateTimePicker_OnTextChange11(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker11.Text.ToString();
        }

        void oDateTimePicker_CloseUp11(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker11.Visible = false;
        }

        private void dateTimePicker_OnTextChange12(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker12.Text.ToString();
        }

        void oDateTimePicker_CloseUp12(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker12.Visible = false;
        }

        private void dateTimePicker_OnTextChange13(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker13.Text.ToString();
        }

        void oDateTimePicker_CloseUp13(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker13.Visible = false;
        }

        private void dateTimePicker_OnTextChange14(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker14.Text.ToString();
        }

        void oDateTimePicker_CloseUp14(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker14.Visible = false;
        }

        private void dateTimePicker_OnTextChange15(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker15.Text.ToString();
        }

        void oDateTimePicker_CloseUp15(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker15.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
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
                sum2 = 0;
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                {
                    if (dgRow.Cells[8].Value != null) //Check for null reference
                    {
                        if (!string.IsNullOrEmpty(dgRow.Cells[8].Value.ToString())) //Check for empty string
                        {
                            sum2 = sum2 + Convert.ToDouble(dgRow.Cells[8].Value.ToString());
                            textBox2.Text = sum2.ToString();
                            textBox5.Text = ((sum2 * 24) / 100).ToString();
                            flag1 = 1;
                        }
                        else
                        {
                            dgRow.Cells[8].Style.BackColor = Color.Red;
                        }
                    }



                }

                //MessageBox.Show(sum2.ToString());
            }
            catch (Exception)
            { MessageBox.Show("Κοίτα τα κελιά κάπου έχεις λάθος"); }
            if (flag1 == 1)
            {

                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    sum2 = sum2 - Convert.ToDouble(textBox3.Text);


                }

                foreach (DataGridViewRow dgRow2 in dataGridView1.Rows)
                {
                    for (int i = 0; i < 23; i++)
                    {

                        if (dgRow2.Cells[i].Value != null)
                        {
                            if (!string.IsNullOrEmpty(dgRow2.Cells[i].Value.ToString()))
                            { sum2 = sum2 - Convert.ToDouble(dgRow2.Cells[i].Value.ToString()); }
                        }
                        i = i + 1;

                    }
                }

                textBox4.Text = (Math.Round(sum2, 2).ToString());

            }
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    foreach (DataGridViewRow dgRow2 in dataGridView2.Rows)
                    {



                        if (dgRow2.Cells[4].Value != null)
                        {
                            if (!string.IsNullOrEmpty(dgRow2.Cells[4].Value.ToString()))
                            { textBox1.Text = textBox1.Text + dgRow2.Cells[4].Value.ToString(); }
                        }



                    }
                }
                flag2 = 1;
            }
            catch (Exception) { }
            if (flag1 == 1 && flag2 == 1)
            {
                string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters
                string Query = "update evotsis_gspot.Customers set SURNAME = '" + textBox6.Text + "',NAME = '" + textBox7.Text + "' ,AFM = '" + textBox8.Text + "' ,ADRESS = '" + textBox9.Text + "' ,CITY = '" + textBox10.Text + "' ,PHONE = '" + textBox11.Text + "' ,CELL = '" + textBox12.Text + "' ,FAX = '" + textBox13.Text + "' ,EMAIL = '" + textBox14.Text + "' where ID = '" + MyProperty12 + "';";
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
                    MessageBox.Show("1");
                }
                //SelectedItem.ToString()
                string myConnection3 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters
                try
                {
                    MySqlConnection myConn3 = new MySqlConnection(myConnection3);
                    string Query3 = "update evotsis_gspot.InvoiceData2 set PARATHRHSEIS = '" + textBox1.Text + "',STADIOPARAGGELIAS = '" + comboBox1.Text + "',HMEROMHNIAPARAGGELIAS = '" + Convert.ToDateTime(textBox15.Text).ToString("yyyy-MM-dd") + "',PROKATAVOLH = '" + textBox3.Text + "',YPOLOIPO = '" + textBox4.Text + "',SYNOLIKOKOSTOS = '" + textBox2.Text + "',HMEROMHNIAPARADOSHS = '" + Convert.ToDateTime(textBox16.Text).ToString("yyyy-MM-dd") + "'  where AA = '" + MyProperty11 + "'and ID = '" + MyProperty12 + "' ;";
                    MySqlCommand cmdDatabase3 = new MySqlCommand(Query3, myConn3);
                    MySqlDataReader myReader3;
                    try
                    {
                        myConn3.Open();
                        myReader3 = cmdDatabase3.ExecuteReader();
                        while (myReader3.Read())
                        {

                        }
                        myConn3.Close();

                    }
                    catch (Exception) { MessageBox.Show("2"); }/////

                }
                catch (Exception) { MessageBox.Show("3"); }



                int count = 0;
                foreach (DataGridViewRow dgRow in dataGridView1.Rows)
                {
                    if (count < 1)
                    {
                        try
                        {
                            string myConnection2 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters
                                                                                                                                  //
                            MySqlConnection myConn2 = new MySqlConnection(myConnection2);


                            MySqlCommand cmd = new MySqlCommand();
                            cmd = myConn2.CreateCommand();
                            myConn2.Open();

                            cmd.CommandText = "UPDATE evotsis_gspot.PLHRWMES set PLHRWMH1=@data9,DATE1=@data10,PLHRWMH2=@data11,DATE2=@data12,PLHRWMH3=@data13,DATE3=@data14,PLHRWMH4=@data15,DATE4=@data16,PLHRWMH5=@data17,DATE5=@data18,PLHRWMH6=@data19,DATE6=@data20,PLHRWMH7=@data21,DATE7=@data22,PLHRWMH8=@data23,DATE8=@data24,PLHRWMH9=@data25,DATE9=@data26,PLHRWMH10=@data27,DATE10=@data28,PLHRWMH11=@data29,DATE11=@data30,PLHRWMH12=@data31,DATE12=@data32 where AA = '" + MyProperty11 + "' and ID = '" + MyProperty12 + "';";

                            cmd.Parameters.AddWithValue("@data9", dgRow.Cells[0].Value);
                            cmd.Parameters.AddWithValue("@data10", dgRow.Cells[1].Value);
                            cmd.Parameters.AddWithValue("@data11", dgRow.Cells[2].Value);
                            cmd.Parameters.AddWithValue("@data12", dgRow.Cells[3].Value);
                            cmd.Parameters.AddWithValue("@data13", dgRow.Cells[4].Value);
                            cmd.Parameters.AddWithValue("@data14", dgRow.Cells[5].Value);
                            cmd.Parameters.AddWithValue("@data15", dgRow.Cells[6].Value);
                            cmd.Parameters.AddWithValue("@data16", dgRow.Cells[7].Value);
                            cmd.Parameters.AddWithValue("@data17", dgRow.Cells[8].Value);
                            cmd.Parameters.AddWithValue("@data18", dgRow.Cells[9].Value);
                            cmd.Parameters.AddWithValue("@data19", dgRow.Cells[10].Value);
                            cmd.Parameters.AddWithValue("@data20", dgRow.Cells[11].Value);
                            cmd.Parameters.AddWithValue("@data21", dgRow.Cells[12].Value);
                            cmd.Parameters.AddWithValue("@data22", dgRow.Cells[13].Value);
                            cmd.Parameters.AddWithValue("@data23", dgRow.Cells[14].Value);
                            cmd.Parameters.AddWithValue("@data24", dgRow.Cells[15].Value);
                            cmd.Parameters.AddWithValue("@data25", dgRow.Cells[16].Value);
                            cmd.Parameters.AddWithValue("@data26", dgRow.Cells[17].Value);
                            cmd.Parameters.AddWithValue("@data27", dgRow.Cells[18].Value);
                            cmd.Parameters.AddWithValue("@data28", dgRow.Cells[19].Value);
                            cmd.Parameters.AddWithValue("@data29", dgRow.Cells[20].Value);
                            cmd.Parameters.AddWithValue("@data30", dgRow.Cells[21].Value);
                            cmd.Parameters.AddWithValue("@data31", dgRow.Cells[22].Value);
                            cmd.Parameters.AddWithValue("@data32", dgRow.Cells[23].Value);
                            cmd.ExecuteNonQuery();
                            myConn2.Close();
                            //MessageBox.Show("sucess");


                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Οι παραγγελίες δεν καταχωρήθηκαν επιτυχώς");

                        }
                        count++;
                    }


                }
                int count2 = 1;
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                { count2++; }
                count2 = count2 - 2;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                {
                    if (count3 < count2)
                    {
                        try
                        {
                            count4 = count3 + 1;
                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            string myConnection5 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters
                            string Query5 = "select ERGASIA from evotsis_gspot.InvoiceData1 where AA = '" + MyProperty11 + "' and ID = '" + MyProperty12 + "' and AAP = '" + count4.ToString() + "';";
                            MySqlConnection myConn5 = new MySqlConnection(myConnection5);
                            MySqlCommand cmdDatabase5 = new MySqlCommand(Query5, myConn5);
                            MySqlDataReader myReader5;
                            try
                            {
                                myConn5.Open();
                                myReader5 = cmdDatabase5.ExecuteReader();
                                while (myReader5.Read())
                                {

                                    count5 = 1;
                                    //MessageBox.Show(count5.ToString());
                                }
                                myConn5.Close();

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Cannot connect to database");
                            }
                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            if (count5 == 1)
                            {
                                count5 = 0;
                                string myConnection2 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters
                                                                                                                                      //
                                MySqlConnection myConn2 = new MySqlConnection(myConnection2);


                                MySqlCommand cmd = new MySqlCommand();
                                cmd = myConn2.CreateCommand();
                                myConn2.Open();

                                cmd.CommandText = "UPDATE evotsis_gspot.InvoiceData1 set ERGASIA=@data9,YLIKO=@data10,PRINTSIZE=@data11,PRINTTYPE=@data12,PERIGRAFH=@data13,EPIPLEONERGASIES=@data14,POSOTHTA=@data15,TIMHMONADAS=@data16,KOSTOS=@data17 where AA = '" + MyProperty11 + "' and ID = '" + MyProperty12 + "' and AAP='" + count4.ToString() + "';";
                                //cmd.Parameters.AddWithValue("@data0", MyProperty11);
                                //cmd.Parameters.AddWithValue("@data1", count4.ToString());
                                //cmd.Parameters.AddWithValue("@data2", MyProperty12);
                                cmd.Parameters.AddWithValue("@data9", dgRow.Cells[0].Value);
                                cmd.Parameters.AddWithValue("@data10", dgRow.Cells[1].Value);
                                cmd.Parameters.AddWithValue("@data11", dgRow.Cells[2].Value);
                                cmd.Parameters.AddWithValue("@data12", dgRow.Cells[3].Value);
                                cmd.Parameters.AddWithValue("@data13", dgRow.Cells[4].Value);
                                cmd.Parameters.AddWithValue("@data14", dgRow.Cells[5].Value);
                                cmd.Parameters.AddWithValue("@data15", dgRow.Cells[6].Value);
                                cmd.Parameters.AddWithValue("@data16", dgRow.Cells[7].Value);
                                cmd.Parameters.AddWithValue("@data17", dgRow.Cells[8].Value);

                                cmd.ExecuteNonQuery();
                                myConn2.Close();
                                //MessageBox.Show("sucess");
                                count3++;

                            }
                            else
                            {
                                try
                                {
                                    string myConnection2 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters                                                                                                      //
                                    MySqlConnection myConn2 = new MySqlConnection(myConnection2);
                                    MySqlCommand cmd = new MySqlCommand();
                                    cmd = myConn2.CreateCommand();
                                    myConn2.Open();
                                    cmd.CommandText = @"INSERT INTO evotsis_gspot.InvoiceData1 (AA,AAP,ERGASIA,YLIKO,PRINTSIZE,PRINTTYPE,PERIGRAFH,EPIPLEONERGASIES,POSOTHTA,TIMHMONADAS,KOSTOS,ID) VALUES(@data9,@data11,@data0,@data1,@data2,@data3,@data4,@data5,@data6,@data7,@data8,@data10);";
                                    cmd.Parameters.AddWithValue("@data9", MyProperty11);
                                    cmd.Parameters.AddWithValue("@data11", count4.ToString());
                                    cmd.Parameters.AddWithValue("@data0", dgRow.Cells[0].Value);
                                    cmd.Parameters.AddWithValue("@data1", dgRow.Cells[1].Value);
                                    cmd.Parameters.AddWithValue("@data2", dgRow.Cells[2].Value);
                                    cmd.Parameters.AddWithValue("@data3", dgRow.Cells[3].Value);
                                    cmd.Parameters.AddWithValue("@data4", dgRow.Cells[4].Value);
                                    cmd.Parameters.AddWithValue("@data5", dgRow.Cells[5].Value);
                                    cmd.Parameters.AddWithValue("@data6", dgRow.Cells[6].Value);
                                    cmd.Parameters.AddWithValue("@data7", dgRow.Cells[7].Value);
                                    cmd.Parameters.AddWithValue("@data8", dgRow.Cells[8].Value);
                                    cmd.Parameters.AddWithValue("@data10", MyProperty12);
                                    cmd.ExecuteNonQuery();
                                    myConn2.Close();
                                    //MessageBox.Show("sucess");
                                    count3++;

                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Οι παραγγελίες δεν καταχωρήθηκαν επιτυχώς");

                                }
                            }


                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Οι παραγγελίες δεν καταχωρήθηκαν επιτυχώς");

                        }
                    }
                }


            }
        }

        private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
        {
            try
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
                base.OnKeyDown(e);
            }
            catch (Exception) { }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception)
            { //MessageBox.Show("Υπολογισμός σε άδεια γραμμή δεν επιτρέπεται");
            }
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



        private void dataGridView2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
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
                sum2 = 0;
                foreach (DataGridViewRow dgRow in dataGridView2.Rows)
                {
                    if (dgRow.Cells[8].Value != null) //Check for null reference
                    {
                        if (!string.IsNullOrEmpty(dgRow.Cells[8].Value.ToString())) //Check for empty string
                        {
                            sum2 = sum2 + Convert.ToDouble(dgRow.Cells[8].Value.ToString());/////ΕΔςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςςς
                            textBox2.Text = sum2.ToString();
                            textBox5.Text = ((sum2 * 24) / 100).ToString();
                            flag1 = 1;
                        }
                        else
                        {
                            dgRow.Cells[8].Style.BackColor = Color.Red;
                        }
                    }



                }
            }
            catch (Exception)
            { MessageBox.Show("Κοίτα τα κελιά κάπου έχεις λάθος"); }
            if (flag1 == 1)
            {

                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    sum2 = sum2 - Math.Round(Convert.ToDouble(textBox3.Text),2);/////edwwwwwwwwwwwwwwwwwwww


                }

                foreach (DataGridViewRow dgRow2 in dataGridView1.Rows)
                {
                    for (int i = 0; i < 23; i++)
                    {

                        if (dgRow2.Cells[i].Value != null)
                        {
                            if (!string.IsNullOrEmpty(dgRow2.Cells[i].Value.ToString()))
                            {
                                double sum3 = Convert.ToDouble(dgRow2.Cells[i].Value.ToString());
                                if (sum2 == 0)
                                {
                                    sum2 = sum3;
                                }
                                else
                                {
                                    sum2 = sum2 - Math.Round(sum3,2);
                                }
                                //sum2 = sum2 - Convert.ToDouble(dgRow2.Cells[i].Value.ToString());
                            }
                        }
                        i = i + 1;

                    }
                }
                textBox4.Text = (Math.Round(sum2, 2).ToString());/////////////////////////////////////////////////////////////////////////////////////////////edw itan to lathos

            }

        }

        private void print_button_Click(object sender, EventArgs e)
        {

            try
            {
                button1.PerformClick();
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
            graphic.DrawString(textBox15.Text, new Font("Order", 9), new SolidBrush(Color.Black), startX + offset + 2, 51);



            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            graphic.DrawString("ΕΠΙΘΕΤΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + offset + 3, startY + 60);
            graphic.DrawString(textBox6.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + offset + 3, startY + 80);

            graphic.DrawString("ΟΝΟΜΑ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 280, startY + 60);
            graphic.DrawString(textBox7.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 280, startY + 80);

            graphic.DrawString("ΑΦΜ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 478, startY + 60);
            graphic.DrawString(textBox8.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 478, startY + 80);

            graphic.DrawString("ΠΟΛΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 576, startY + 60);
            graphic.DrawString(textBox10.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 576, startY + 80);

            graphic.DrawString("ΔΙΕΥΘΥΝΣΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 734, startY + 60);
            graphic.DrawString(textBox9.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 734, startY + 80);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            graphic.DrawString("ΤΗΛΕΦΩΝΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + offset + 3, startY + 110);
            graphic.DrawString(textBox11.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + offset + 3, startY + 130);

            graphic.DrawString("ΚΙΝΗΤΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 280, startY + 110);
            graphic.DrawString(textBox12.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 280, startY + 130);

            graphic.DrawString("ΦΑΧ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 478, startY + 110);
            graphic.DrawString(textBox13.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 478, startY + 130);

            graphic.DrawString("EMAIL", new Font("Order", 10), new SolidBrush(Color.Black), startX + 734, startY + 110);
            graphic.DrawString(textBox14.Text, new Font("Order", 8), new SolidBrush(Color.Black), startX + 734, startY + 130);
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
            graphic.DrawRectangle(Pens.Black, startX - 10, startY - 10 + 535, 1320, 125);
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
            graphic.DrawString(dataGridView1.Rows[0].Cells[23].FormattedValue.ToString(), new Font("Order", 5), new SolidBrush(Color.Black), startX + 814, startY + 623);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            graphic.DrawString("ΥΠΟΛΟΙΠΟ ΠΑΡΑΓΓΕΛΙΩΝ ΠΕΛΑΤΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 430, startY + 765);
            graphic.DrawString(textBox17.Text, new Font("Order", 10), new SolidBrush(Color.Red), startX + 480, startY + 785);
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
            graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΔΟΣΗΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX, startY + 752);
            graphic.DrawString(textBox16.Text, new Font("Order", 8), new SolidBrush(Color.Red), startX, startY + 769);
            graphic.DrawString("ΣΥΝΟΛΙΚΟ ΚΟΣΤΟΣ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 754, startY + 668);
            graphic.DrawString(textBox2.Text, new Font("Order", 10), new SolidBrush(Color.Black), startX + 904, startY + 668);
            graphic.DrawString("ΠΡΟΚΑΤΑΒΟΛΗ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 754, startY + 692);
            graphic.DrawString(textBox3.Text, new Font("Order", 10), new SolidBrush(Color.Black), startX + 904, startY + 692);
            graphic.DrawString("ΥΠΟΛΟΙΠΟ", new Font("Order", 10), new SolidBrush(Color.Black), startX + 754, startY + 715);
            graphic.DrawString(textBox4.Text, new Font("Order", 10), new SolidBrush(Color.Red), startX + 904, startY + 712);
            graphic.DrawString("+ ΦΠΑ 24 %", new Font("Order", 9), new SolidBrush(Color.Black), startX + 754, startY + 765);
            graphic.DrawString(textBox5.Text, new Font("Order", 9), new SolidBrush(Color.Black), startX + 904, startY + 765);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewOrder myform = new NewOrder();
            myform.Show();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void dataGridView2_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        void Fillcombo7()
        {
            double sum = 0;
            string myConnection5 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters
            string Query5 = "select * from evotsis_gspot.InvoiceData2 where ID = '" + MyProperty12 + "';";
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
                textBox17.Text = sum.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to database Ypoloipa from InvoiceData2");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Διαγραφή Παραγγελίας?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string myConnection5 = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123;Character Set=utf8";//connection parameters
                string Query5 = "delete from evotsis_gspot.InvoiceData1 where AA = '" + MyProperty11 + "';";
                MySqlConnection myConn5 = new MySqlConnection(myConnection5);
                MySqlCommand cmdDatabase5 = new MySqlCommand(Query5, myConn5);
                MySqlDataReader myReader5;

                try
                {
                    myConn5.Open();
                    myReader5 = cmdDatabase5.ExecuteReader();
                    myConn5.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error on deleting InvoiceData1");
                }


                string Query6 = "delete from evotsis_gspot.InvoiceData2 where AA = '" + MyProperty11 + "';";
                MySqlConnection myConn6 = new MySqlConnection(myConnection5);
                MySqlCommand cmdDatabase6 = new MySqlCommand(Query6, myConn6);
                MySqlDataReader myReader6;

                try
                {
                    myConn6.Open();

                    myReader6 = cmdDatabase6.ExecuteReader();

                    myConn6.Close();



                }
                catch (Exception)
                {
                    MessageBox.Show("Error on deleting InvoiceData2");
                }

                string Query7 = "delete from evotsis_gspot.PLHRWMES where AA = '" + MyProperty11 + "';";
                MySqlConnection myConn7 = new MySqlConnection(myConnection5);
                MySqlCommand cmdDatabase7 = new MySqlCommand(Query7, myConn7);
                MySqlDataReader myReader7;

                try
                {
                    myConn7.Open();

                    myReader7 = cmdDatabase7.ExecuteReader();

                    myConn7.Close();
                    MessageBox.Show("Η παραγγελία διαγράφτηκε επιτυχώς");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error on deleting PLHRWMES");
                }

            }
        
         }

      
    }
}
