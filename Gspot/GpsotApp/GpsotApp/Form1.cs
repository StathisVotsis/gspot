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
    public partial class Form1 : Form
    {
        Timer t = new Timer();//initialize clock
        DateTime mydate = DateTime.Now;//create date
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;  //in milliseconds

            t.Tick += new EventHandler(this.t_Tick);

            // start timer when form loads
            t.Start();  //this will use t_Tick() method
            //////////////////////////////
            //Start.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewOrder myform = new NewOrder();
            myform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KartelaPelath myform = new KartelaPelath();
            myform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCustomer myform = new DeleteCustomer();
            myform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Voithitika myform = new Voithitika();
            myform.Show();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            textBox1.Text = time +"  "+mydate.Day.ToString()+"/"+mydate.Month.ToString()+"/"+mydate.Year.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Outgoings2 myform = new Outgoings2();
            myform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Administrator: Stathis Votsis"+"\n\n"+"Contact: 6974090755 or stathisvotsis@gmail.com");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ListaErgasiwn myform = new ListaErgasiwn();
            myform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NewCustomer myform = new NewCustomer();
            myform.Show();
        }
    }
}
