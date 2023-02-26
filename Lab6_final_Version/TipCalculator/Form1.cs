using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tip_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Bill_box(object sender, EventArgs e)
        {
            string con = sender.ToString();
            double input = Double.Parse(con);
            input = input * 0.2;
            string final_ans= input.ToString();
            Console.WriteLine(final_ans);
            

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void amount_box_TextChanged(object sender, EventArgs e)
        {
            Bill_box(sender, e);

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
