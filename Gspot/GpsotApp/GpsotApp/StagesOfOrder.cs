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
    public partial class StagesOfOrder : Form
    {
        public StagesOfOrder()
        {
            InitializeComponent();
        }

        private void StagesOfOrder_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'evotsis_gspotDataSetttt.StagesOfOrder' table. You can move, or remove it, as needed.
                this.stagesOfOrderTableAdapter.Fill(this.evotsis_gspotDataSetttt.StagesOfOrder);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση Stages of orders - Καρτέλα StagesOfOrders.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                this.stagesOfOrderTableAdapter.Update(this.evotsis_gspotDataSetttt.StagesOfOrder);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση Stages of orders - Καρτέλα StagesOfOrders.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            if (MessageBox.Show("Διαγραφή εγγραφής?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.stagesOfOrderBindingSource.RemoveCurrent();
                try
                {
                    this.stagesOfOrderTableAdapter.Update(this.evotsis_gspotDataSetttt.StagesOfOrder);
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
                this.stagesOfOrderBindingSource.EndEdit();
                this.stagesOfOrderTableAdapter.Update(this.evotsis_gspotDataSetttt.StagesOfOrder);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Δεν επιτρέπονται κενιά κελιά");
        }

        private void StagesOfOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            try
            {
                this.stagesOfOrderBindingSource.EndEdit();
                this.stagesOfOrderTableAdapter.Update(this.evotsis_gspotDataSetttt.StagesOfOrder);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }
    }
}
