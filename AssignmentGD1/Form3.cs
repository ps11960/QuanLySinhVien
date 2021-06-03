using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentGD1
{
    public partial class Form3 : Form
    {
        public Form3(string x)
        {
            InitializeComponent();
            label8.Text = x;
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadsv()
        {
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                string query = "select * from students";
                SqlDataAdapter cn = new SqlDataAdapter(query, data);
                data.Open();
                DataSet dts = new DataSet();
                cn.Fill(dts, "students");
                dataGridView1.DataSource = dts.Tables["students"];
                data.Close();
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            loadsv();
            if (label8.Text == "qld")
            {
                button7.Enabled = false;
                button1.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int count = 0;
            try 
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView1.CurrentRow.Selected= true;
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["masv"].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["hoten"].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].FormattedValue.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["sodt"].FormattedValue.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["diachi"].FormattedValue.ToString();
                    if (dataGridView1.Rows[e.RowIndex].Cells["hinh"].FormattedValue.ToString() != "") { 
                        Image img = Image.FromFile(dataGridView1.Rows[e.RowIndex].Cells["hinh"].FormattedValue.ToString());
                        pictureBox1.Image = img;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else { count++; }
                    string x = dataGridView1.Rows[e.RowIndex].Cells["gioitinh"].FormattedValue.ToString();
                    if (x == "False") { radioButton1.Checked = false; radioButton2.Checked = true; }
                    else { radioButton2.Checked = false; radioButton1.Checked = true; }
                    dataGridView1.Rows[e.RowIndex].Cells["hinh"].FormattedValue.ToString();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Chon sai vi tri!");
            }
            finally
            {
                if (count > 0) MessageBox.Show("Sinh vien van chua co anh!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(label8.Text);
            frm4.Show();
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //Image img = Image.FromFile();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                data.Open();
                string query = "update students set masv=@msv,hoten=@ht,email=@e,sodt=@sdt,gioitinh=@gt,diachi=@dc,hinh=@hinh where masv=@check";
                SqlCommand cn = new SqlCommand(query, data);
                try
                {
                    if (textBox1.Text!="" && textBox2.Text!="" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "") 
                    { 
                    cn.Parameters.AddWithValue("@msv", textBox1.Text);
                    cn.Parameters.AddWithValue("@ht", textBox2.Text);
                    cn.Parameters.AddWithValue("@e", textBox3.Text);
                    cn.Parameters.AddWithValue("@sdt", textBox4.Text);
                    cn.Parameters.AddWithValue("@dc", textBox5.Text);
                    cn.Parameters.AddWithValue("@check", dataGridView1.CurrentRow.Cells["masv"].Value.ToString());
                    cn.Parameters.AddWithValue("@hinh", label9.Text);
                    if (radioButton2.Checked == true) cn.Parameters.AddWithValue("@gt", false);
                    else cn.Parameters.AddWithValue("@gt", true);
                    MessageBox.Show("Cap nhat thanh cong: " + cn.ExecuteNonQuery());
                    }
                    else { MessageBox.Show("Cap nhat that bai! Khong bo trong"); }
                }
                catch (Exception)
                {
                    MessageBox.Show("Cap nhat that bai!\r\n Kiem tra lai du lieu nhap");
                }
                finally
                {
                    data.Close();
                    loadsv();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                data.Open();
                string query = "insert into students values (@msv,@ht,@e,@sdt,@gt,@dc,@hinh)";
                SqlCommand cn = new SqlCommand(query, data);
                try
                {
                    if(radioButton1.Checked==true || radioButton2.Checked == true) { 
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && label9.Text != "")
                    {
                    cn.Parameters.AddWithValue("@msv", textBox1.Text);
                    cn.Parameters.AddWithValue("@ht", textBox2.Text);
                    cn.Parameters.AddWithValue("@e", textBox3.Text);
                    cn.Parameters.AddWithValue("@sdt", textBox4.Text);
                    cn.Parameters.AddWithValue("@dc", textBox5.Text);
                    cn.Parameters.AddWithValue("@hinh", label9.Text);
                    if (radioButton2.Checked == true) cn.Parameters.AddWithValue("@gt", false);
                    else cn.Parameters.AddWithValue("@gt", true);
                    MessageBox.Show("Them thanh cong: " + cn.ExecuteNonQuery());
                    }
                    else { MessageBox.Show("Luu that bai! Khong bo trong thong tin sv"); }
                    }
                    else { MessageBox.Show("Luu that bai! Khong bo trong gioi tinh"); }
                }
                catch (Exception x)
                {
                    MessageBox.Show("Them that bai!\r\n=" + x.Message);
                }
                finally
                {
                    data.Close();
                    loadsv();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                data.Open();
                string query = "delete from students where masv=@check";
                SqlCommand cn = new SqlCommand(query, data);
                try
                {
                    cn.Parameters.AddWithValue("@check", dataGridView1.CurrentRow.Cells["masv"].Value.ToString());
                    MessageBox.Show("Xoa thanh cong: " + cn.ExecuteNonQuery());
                }
                catch (Exception)
                {
                    MessageBox.Show("Xoa that bai!\r\n Moi chon dong can xoa");
                }
                finally
                {
                    data.Close();
                    loadsv();
                }
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog(); 
            opd.Filter = "Windows Bitmap|*.bmp|JPEG Image|*.jpg|PNG Image|*.png|All file|*.*";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                label9.Text = opd.FileName;
                pictureBox1.Image = Image.FromFile(opd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
