using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gspot
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();//initialize clock
        DateTime mydate = DateTime.Now;//create date
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Administrator: Stathis Votsis" + "\n\n" + "Contact: 6974090755 or stathisvotsis@gmail.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewOrder myform = new NewOrder();
            myform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NewCustomer myform = new NewCustomer();
            myform.Show();
        }
    }
}
