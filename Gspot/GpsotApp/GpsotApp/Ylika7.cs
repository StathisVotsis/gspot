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
    public partial class Ylika7 : Form
    {
        public Ylika7()
        {
            InitializeComponent();
        }

        private void Ylika7_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'evotsis_gspotDataSet27.Suppliers' table. You can move, or remove it, as needed.
                this.suppliersTableAdapter.Fill(this.evotsis_gspotDataSet27.Suppliers);
                // TODO: This line of code loads data into the 'evotsis_gspotDataSet26.Ylika7' table. You can move, or remove it, as needed.
                this.ylika7TableAdapter.Fill(this.evotsis_gspotDataSet26.Ylika7);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση yλικών - Καρτέλα Ylika7.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
            }

        }

       

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Δεν επιτρέπονται κενά κελιά στην στήλη ΑΑ");
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.ylika7TableAdapter.Update(this.evotsis_gspotDataSet26.Ylika7);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν επιτρέπονται κενά κελιά στην στήλη ΑΑ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.ylika7BindingSource.EndEdit();
                this.ylika7TableAdapter.Update(this.evotsis_gspotDataSet26.Ylika7);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν επιτρέπονται στην στήλη ΑΑ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Διαγραφή εγγραφής?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.ylika7BindingSource.RemoveCurrent();
                try
                {
                    this.ylika7TableAdapter.Update(this.evotsis_gspotDataSet26.Ylika7);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void Ylika7_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Validate();
                this.ylika7BindingSource.EndEdit();
                this.ylika7TableAdapter.Update(this.evotsis_gspotDataSet26.Ylika7);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν επιτρέπονται στην στήλη ΑΑ");
            }
        }
    }
}
