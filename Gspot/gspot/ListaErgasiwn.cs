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
    public partial class ListaErgasiwn : Form
    {
        int flag = 0;
        int count = 0;
        int offset2 = 180;
        int i;
        public ListaErgasiwn()
        {
            InitializeComponent();
            Fillcombo1();
        }

        DataTable dbdataset;
        DataTable dt = new DataTable();

        private void ListaErgasiwn_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet70.StagesOfOrder' table. You can move, or remove it, as needed.
            this.stagesOfOrderTableAdapter.Fill(this.evotsis_gspotDataSet70.StagesOfOrder);
           
            try
            {
                Fillcombo1();
            }
            catch (Exception)
            {
                MessageBox.Show("Το σύστημα δεν μπορεί να συνδεθεί στη βάση δεδομένων InvoiceData2");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("SURNAME LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = DV;
        }

        void Fillcombo1()
        {
            string myConnection = "datasource=192.168.1.23;port=3306;username=root;password=gspot@123";//connection parameters
            string Query = "select AA,PARATHRHSEIS,STADIOPARAGGELIAS,HMEROMHNIAPARAGGELIAS,PROKATAVOLH,YPOLOIPO,ID,SYNOLIKOKOSTOS,SURNAME from evotsis_gspot.InvoiceData2 ;";
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
                dataGridView1.Columns[1].Width = 300;
                //dataGridView1.Columns[2].Width = 200;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView1.Columns[3].Width = 100;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[0].HeaderText = "A/A";
                dataGridView1.Columns[1].HeaderText = "ΠΕΡΙΓΡΑΦΗ ΠΑΡΑΓΓΕΛΙΑΣ";
                dataGridView1.Columns[2].HeaderText = "ΣΤΑΔΙΟ ΠΑΡΑΓΓΕΛΙΑΣ";
                dataGridView1.Columns[3].HeaderText = "ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΓΓΕΛΙΑΣ";
                dataGridView1.Columns[4].HeaderText = "ΠΡΟΚΑΤΑΒΟΛΗ";
                dataGridView1.Columns[5].HeaderText = "ΥΠΟΛΟΙΠΟ";
                dataGridView1.Columns[6].HeaderText = "ID ΠΕΛΑΤΗ";
                dataGridView1.Columns[7].HeaderText = "ΣΥΝΟΛΙΚΟ ΚΟΣΤΟΣ";
                dataGridView1.Columns[8].HeaderText = "ΠΕΛΑΤΗΣ";

            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to database InvoiceData2");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("STADIOPARAGGELIAS LIKE '%{0}%'", comboBox1.Text);
            dataGridView1.DataSource = DV;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string string1 = row.Cells["AA"].Value.ToString();
                string string2 = row.Cells["ID"].Value.ToString();
                SpecificOrder frm4 = new SpecificOrder();
                frm4.MyProperty11 = string1;
                frm4.MyProperty12 = string2;
                frm4.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet70.StagesOfOrder' table. You can move, or remove it, as needed.
            this.stagesOfOrderTableAdapter.Fill(this.evotsis_gspotDataSet70.StagesOfOrder);

            try
            {
                Fillcombo1();
            }
            catch (Exception)
            {
                MessageBox.Show("Το σύστημα δεν μπορεί να συνδεθεί στη βάση δεδομένων InvoiceData2");
            }
        }

        private void print_button_Click(object sender, EventArgs e)
        {
            try
            {
                PrintReceipt();
                //button1.PerformClick();
                this.Close();

            }
            catch (Exception) { MessageBox.Show("Error"); }
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
            if (flag == 0)
            {
                graphic.DrawString("ΛΙΣΤΑ ΕΡΓΑΣΙΩΝ", new Font("Order", 18), new SolidBrush(Color.Black), 450, 4);
                graphic.DrawString("DROPDOWN", new Font("Order", 11), new SolidBrush(Color.Black), startX + offset, 33);
                graphic.DrawString(comboBox1.Text, new Font("Order", 9), new SolidBrush(Color.Black), startX + offset + 2, 51);

                graphic.DrawString("ΠΕΡΙΓΡΑΦΗ ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX, startY + 160);
                graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 270, startY + 160);
                graphic.DrawString("ΠΡΟΚΑΤΑΒΟΛΗ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 470, startY + 160);
                graphic.DrawString("ΥΠΟΛΟΙΠΟ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 618, startY + 160);
                graphic.DrawString("Σ.ΚΟΣΤΟΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 740, startY + 160);
                graphic.DrawString("ΠΕΛΑΤΗΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 855, startY + 160);
            }
            else
            {
                graphic.DrawString("ΠΕΡΙΓΡΑΦΗ ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX, startY + 20);
                graphic.DrawString("ΗΜΕΡΟΜΗΝΙΑ ΠΑΡΑΓΓΕΛΙΑΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 270, startY + 20);
                graphic.DrawString("ΠΡΟΚΑΤΑΒΟΛΗ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 470, startY + 20);
                graphic.DrawString("ΥΠΟΛΟΙΠΟ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 618, startY + 20);
                graphic.DrawString("ΣΥΝΟΛΙΚΟ ΚΟΣΤΟΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 740, startY + 20);
                graphic.DrawString("ΠΕΛΑΤΗΣ", new Font("Order", 9), new SolidBrush(Color.Black), startX + 855, startY + 20);


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
                graphic.DrawString(dataGridView1.Rows[i].Cells[3].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 290, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[4].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 477, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[5].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 618, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[7].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Red), startX + 750, startY + offset2);
                graphic.DrawString(dataGridView1.Rows[i].Cells[8].FormattedValue.ToString(), new Font("Order", 7), new SolidBrush(Color.Black), startX + 855, startY + offset2);

                offset2 += 35;
                if (offset2 >= startY + 745) { offset2 = 50; count = i; flag = 1; e.HasMorePages = true; return; } else { e.HasMorePages = false; }
                //
            }
        }
    }
}
