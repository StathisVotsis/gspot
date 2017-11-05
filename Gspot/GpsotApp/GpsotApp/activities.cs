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
    public partial class activities : Form
    {
        public activities()
        {
            InitializeComponent();
        }

        private void activities_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet8.Work' table. You can move, or remove it, as needed.
            this.workTableAdapter.Fill(this.evotsis_gspotDataSet8.Work);

        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.workTableAdapter.Update(this.evotsis_gspotDataSet8.Work);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση μεγέθη εργασίες - Καρτέλα activities.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Δεν επιτρέπονται κενιά κελιά");
            //e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Διαγραφή εγγραφής?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                //this.printTypeBindingSource.RemoveCurrent();
                this.workBindingSource.RemoveCurrent();
                try
                {
                    this.workTableAdapter.Update(this.evotsis_gspotDataSet8.Work);
                }
                catch (Exception)
                {

                }
            }
        }

        private void activities_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            try
            {
                this.workBindingSource.EndEdit();
                this.workTableAdapter.Update(this.evotsis_gspotDataSet8.Work);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Validate();
            try
            {
                this.workBindingSource.EndEdit();
                this.workTableAdapter.Update(this.evotsis_gspotDataSet8.Work);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
           
        }
    }
}
