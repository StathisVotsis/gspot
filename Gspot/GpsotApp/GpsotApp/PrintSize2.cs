using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GpsotApp
{
    public partial class PrintSize2 : Form
    {
        public PrintSize2()
        {
            InitializeComponent();
        }

        private void PrintSize2_Load(object sender, EventArgs e)
        {
            
            try
            {
                // TODO: This line of code loads data into the 'evotsis_gspotDataSett.PrintSize' table. You can move, or remove it, as needed.
                this.printSizeTableAdapter.Fill(this.evotsis_gspotDataSett.PrintSize);

            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση εξόδων - Καρτέλα printSize2.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }

        }


        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                this.printSizeTableAdapter.Update(this.evotsis_gspotDataSett.PrintSize);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση εξόδων - Καρτέλα printSize2.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Διαγραφή εγγραφής?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.printSizeBindingSource.RemoveCurrent();
                try
                {
                    this.printSizeTableAdapter.Update(this.evotsis_gspotDataSett.PrintSize);
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
                this.printSizeBindingSource.EndEdit();
                this.printSizeTableAdapter.Update(this.evotsis_gspotDataSett.PrintSize);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Δεν επιτρέπονται κενά κελιά");
        }

        private void PrintSize2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            try
            {
                this.printSizeBindingSource.EndEdit();
                this.printSizeTableAdapter.Update(this.evotsis_gspotDataSett.PrintSize);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }
    }
}
