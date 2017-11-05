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
    public partial class CurrentMonthOutgoings2 : Form
    {
        double sum = 0;//determine sum of datagridview totalcost column
        DateTimePicker oDateTimePicker3 = new DateTimePicker();//calendar textbox1
        DateTimePicker oDateTimePicker4 = new DateTimePicker();//calendar textbox2
        public CurrentMonthOutgoings2()
        {
            InitializeComponent();
        }

        private void CurrentMonthOutgoings2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'evotsis_gspotDataSet20.Outgoings' table. You can move, or remove it, as needed.
            this.outgoingsTableAdapter.Fill(this.evotsis_gspotDataSet20.Outgoings);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            textBox1.Text = oDateTimePicker3.Text.ToString();
            textBox1ToolStripTextBox.Text = textBox1.Text;
        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker3.Visible = false;
        }

        private void dateTimePicker_OnTextChange2(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            textBox2.Text = oDateTimePicker4.Text.ToString();
            textBox2ToolStripTextBox.Text = textBox2.Text;
        }

        void oDateTimePicker_CloseUp2(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker4.Visible = false;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //Initialized a new DateTimePicker Control  
            oDateTimePicker3 = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            textBox1.Controls.Add(oDateTimePicker3);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker3.Format = DateTimePickerFormat.Short;


            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = textBox1.DisplayRectangle;

            //Setting area for DateTimePicker Control  
            oDateTimePicker3.Size = new Size(oRectangle.Width, oRectangle.Height);

            // Setting Location  
            oDateTimePicker3.Location = new Point(oRectangle.X, oRectangle.Y);

            // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            oDateTimePicker3.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

            // An event attached to dateTimePicker Control which is fired when any date is selected  
            oDateTimePicker3.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

            // Now make it visible  
            oDateTimePicker3.Visible = true;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            //Initialized a new DateTimePicker Control  
            oDateTimePicker4 = new DateTimePicker();

            //Adding DateTimePicker control into DataGridView   
            textBox2.Controls.Add(oDateTimePicker4);

            // Setting the format (i.e. 2014-10-10)  
            oDateTimePicker4.Format = DateTimePickerFormat.Short;


            // It returns the retangular area that represents the Display area for a cell  
            Rectangle oRectangle = textBox2.DisplayRectangle;

            //Setting area for DateTimePicker Control  
            oDateTimePicker4.Size = new Size(oRectangle.Width, oRectangle.Height);

            // Setting Location  
            oDateTimePicker4.Location = new Point(oRectangle.X, oRectangle.Y);

            // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
            oDateTimePicker4.CloseUp += new EventHandler(oDateTimePicker_CloseUp2);

            // An event attached to dateTimePicker Control which is fired when any date is selected  
            oDateTimePicker4.TextChanged += new EventHandler(dateTimePicker_OnTextChange2);

            // Now make it visible  
            oDateTimePicker4.Visible = true;
        }

        
       

        private void button1_Click(object sender, EventArgs e)
        {
            fillBy1ToolStripButton.PerformClick();
            try
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if (row.Cells[4].Value != null) //Check for null reference
                    {
                        if (!string.IsNullOrEmpty(row.Cells[4].Value.ToString())) //Check for empty string
                        {
                           
                            sum = sum + Convert.ToDouble(row.Cells[4].FormattedValue.ToString());
                            //MessageBox.Show(sum.ToString());
                        }
                        else
                        {
                           
                        }
                    }
                   
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Λάθος στον υπολογισμό εξόδων - Πιθανόν δεν έγινε σωστή μετατροπή string σε integer, καλέστε τον administrator");
            }

            textBox3.Text = sum.ToString();
            sum = 0;
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.outgoingsTableAdapter.FillBy1(this.evotsis_gspotDataSet20.Outgoings, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(textBox1ToolStripTextBox.Text, typeof(System.DateTime))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(textBox2ToolStripTextBox.Text, typeof(System.DateTime))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void textBox1ToolStripTextBox_Click(object sender, EventArgs e)
        {

        }

        private void textBox2ToolStripTextBox_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
