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
    public partial class Suppliers2 : Form
    {
        public Suppliers2()
        {
            InitializeComponent();
        }

        private void Suppliers2_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'evotsis_gspotDataSettttt.Suppliers' table. You can move, or remove it, as needed.
                this.suppliersTableAdapter.Fill(this.evotsis_gspotDataSettttt.Suppliers);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση προμηθευτών - Καρτέλα Suppliers2.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }
            

        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.suppliersTableAdapter.Update(this.evotsis_gspotDataSettttt.Suppliers);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση προμηθευτών - Καρτέλα Suppliers2.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Δεν επιτρέπονται κενά κελιά");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Διαγραφή εγγραφής?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.suppliersBindingSource.RemoveCurrent();
                try
                {
                    this.suppliersTableAdapter.Update(this.evotsis_gspotDataSettttt.Suppliers);
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
                this.suppliersBindingSource.EndEdit();
                this.suppliersTableAdapter.Update(this.evotsis_gspotDataSettttt.Suppliers);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }

        private void Suppliers2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
            try
            {
                this.suppliersBindingSource.EndEdit();
                this.suppliersTableAdapter.Update(this.evotsis_gspotDataSettttt.Suppliers);
            }
            catch (Exception)
            {
                MessageBox.Show("Απαγορεύεται η αποθήκευση κενής γραμμής");
            }
        }
    }
  }

