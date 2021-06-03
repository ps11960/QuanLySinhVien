using JMetroTextBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentGD1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var check =MessageBox.Show("Ban co chac muon thoat?","Thong Bao",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                int dem = 0;
                string sentrole="";
                data.Open();
                string query = "select * from users";
                SqlCommand cn = new SqlCommand(query, data);
                SqlDataReader read = cn.ExecuteReader();
                while (read.Read())
                {
                    if (read["username"].ToString() == textBox1.Text && read["password"].ToString() == jMetroTextBox2.TextName)
                    {
                        sentrole = read["role"].ToString();
                        dem++;
                    }
                }
                if (dem ==0)
                { 
                    MessageBox.Show("Sai tai khoan hoac mat khau!", MessageBoxIcon.Error.ToString());
                }
                else
                {
                    MessageBox.Show("Dang nhap thanh cong!");
                    Form4 frm4 = new Form4(sentrole);
                    frm4.Show();
                    data.Close();
                    this.Hide();
                }
            }
        }

        private void jMetroTextBox2_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
