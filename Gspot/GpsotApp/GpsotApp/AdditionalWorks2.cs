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
    public partial class AdditionalWorks2 : Form
    {
        public AdditionalWorks2()
        {
            InitializeComponent();
        }

        private void AdditionalWorks2_Load(object sender, EventArgs e)
        {
            
            try
            {
                // TODO: This line of code loads data into the 'evotsis_gspotDataSettt.AdditionalWorks' table. You can move, or remove it, as needed.
                this.additionalWorksTableAdapter.Fill(this.evotsis_gspotDataSettt.AdditionalWorks);

            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση επιπλέον εργασίες - Καρτέλα AdditionalWorks2.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }

        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                this.additionalWorksTableAdapter.Update(this.evotsis_gspotDataSettt.AdditionalWorks);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση επιπλέον εργασίες - Καρτέλα AdditionalWorks2.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            if (MessageBox.Show("Διαγραφή εγγραφής?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.additionalWorksBindingSource.RemoveCurrent();
                try
                {
                    this.additionalWorksTableAdapter.Update(this.evotsis_gspotDataSettt.AdditionalWorks);
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
                this.additionalWorksBindingSource.EndEdit();
                this.additionalWorksTableAdapter.Update(this.evotsis_gspotDataSettt.AdditionalWorks);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Δεν επιτρέπονται κενιά κελιαά");
        }

        private void AdditionalWorks2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            try
            {
                this.additionalWorksBindingSource.EndEdit();
                this.additionalWorksTableAdapter.Update(this.evotsis_gspotDataSettt.AdditionalWorks);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }
    }
}
