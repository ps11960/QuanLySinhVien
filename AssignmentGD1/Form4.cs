﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentGD1
{
    public partial class Form4 : Form
    {
        public Form4(string checkrole)
        {
            InitializeComponent();
            label2.Text = checkrole;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                Form3 frm3 = new Form3(label2.Text);
                frm3.Show();
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Form2 frm2 = new Form2(label2.Text);
                frm2.Show();
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();
        }
    }
}
