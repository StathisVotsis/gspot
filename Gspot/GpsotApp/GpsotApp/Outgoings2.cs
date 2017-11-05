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
    public partial class Outgoings2 : Form
    {
        DateTimePicker oDateTimePicker;
        DateTimePicker oDateTimePicker2;
        public Outgoings2()
        {
            InitializeComponent();
        }

        private void Outgoings2_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'evotsis_gspotDataSet19.Suppliers' table. You can move, or remove it, as needed.
                this.suppliersTableAdapter.Fill(this.evotsis_gspotDataSet19.Suppliers);
                // TODO: This line of code loads data into the 'evotsis_gspotDataSet18.Outgoings' table. You can move, or remove it, as needed.
                this.outgoingsTableAdapter.Fill(this.evotsis_gspotDataSet18.Outgoings);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν φορτώνει η βάση outgoings - Καρτέλα Outgoings2.cs" + "\n" + "Επανεκκίνηση προγράμματος ή καλέστε τον administrator");
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
                this.outgoingsTableAdapter.Update(this.evotsis_gspotDataSet18.Outgoings);
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
                this.outgoingsBindingSource.EndEdit();
                this.outgoingsTableAdapter.Update(this.evotsis_gspotDataSet18.Outgoings);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν επιτρέπονται κενά κελιά στην στήλη ΑΑ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Διαγραφή εγγραφής?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.outgoingsBindingSource.RemoveCurrent();
                try
                {
                    this.outgoingsTableAdapter.Update(this.evotsis_gspotDataSet18.Outgoings);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void Outgoings2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Validate();
                this.outgoingsBindingSource.EndEdit();
                this.outgoingsTableAdapter.Update(this.evotsis_gspotDataSet18.Outgoings);
            }
            catch (Exception)
            {
                MessageBox.Show("Δεν επιτρέπονται κενά κελιά στην στήλη ΑΑ");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 1)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                oDateTimePicker.Visible = true;
            }

            if (e.ColumnIndex == 5)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker2 = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dataGridView1.Controls.Add(oDateTimePicker2);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker2.Format = DateTimePickerFormat.Short;


                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

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
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        private void dateTimePicker_OnTextChange2(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView1.CurrentCell.Value = oDateTimePicker2.Text.ToString();
        }

        void oDateTimePicker_CloseUp2(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker2.Visible = false;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            CurrentMonthOutgoings2 currentmonthoutgoings2 = new CurrentMonthOutgoings2();
            currentmonthoutgoings2.Show();
        }
    }
}
