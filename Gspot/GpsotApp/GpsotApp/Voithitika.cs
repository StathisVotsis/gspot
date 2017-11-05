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
    public partial class Voithitika : Form
    {
        public Voithitika()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Suppliers2 myform = new Suppliers2();
            myform.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ylika7 myform = new Ylika7();
            myform.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintType myform = new PrintType();
            myform.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintSize2 myform = new PrintSize2();
            myform.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdditionalWorks2 myform = new AdditionalWorks2();
            myform.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StagesOfOrder myform = new StagesOfOrder();
            myform.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           activities myform = new activities();
           myform.Show();
           this.Close();
        }

        private void Voithitika_Load(object sender, EventArgs e)
        {

        }
    }
}
