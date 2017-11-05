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
    public partial class PrintType : Form
    {

        public PrintType()
        {
            InitializeComponent();
        }

        private void PrintType_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'evotsis_gspotDataSet.PrintType' table. You can move, or remove it, as needed.
                this.printTypeTableAdapter.Fill(this.evotsis_gspotDataSet.PrintType);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση μεγέθη εκτύπωσης - Καρτέλα PrintType.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }


        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.printTypeTableAdapter.Update(this.evotsis_gspotDataSet.PrintType);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση μεγέθη εκτύπωσης - Καρτέλα PrintType.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            if (MessageBox.Show("Διαγραφή εγγραφής?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.printTypeBindingSource.RemoveCurrent();
                try
                {
                    this.printTypeTableAdapter.Update(this.evotsis_gspotDataSet.PrintType);
                }
                catch (Exception)
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Validate();
            try
            {
                this.printTypeBindingSource.EndEdit();
                this.printTypeTableAdapter.Update(this.evotsis_gspotDataSet.PrintType);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Δεν επιτρέπονται κενιά κελιά");
            //e.Cancel = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PrintType_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            try
            {
                this.printTypeBindingSource.EndEdit();
                this.printTypeTableAdapter.Update(this.evotsis_gspotDataSet.PrintType);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }
    }
}
