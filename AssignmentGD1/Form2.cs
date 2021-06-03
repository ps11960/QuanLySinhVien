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
    public partial class Form2 : Form
    {
        public Form2(string x)
        {
            InitializeComponent();
            label9.Text = x;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

        }
        private static DataSet loaddata()
        {
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                data.Open();
                string query = "select top (3) grade.masv, students.hoten, tienganh, tinhoc, gdtc, id from grade join students on grade.masv = students.masv group by grade.masv, students.hoten, tienganh, tinhoc, gdtc, id order by avg(tienganh+tinhoc + gdtc) desc; ";
                SqlDataAdapter cn = new SqlDataAdapter(query, data);
                DataSet dts = new DataSet();
                cn.Fill(dts, "grade");
                cn.SelectCommand.CommandText = "select * from students";
                cn.Fill(dts, "students");
                data.Close();
                return dts;
            }
        }
        private void loadsv()
        {
            DataSet dts = loaddata();
            dataGridView3.DataSource = dts.Tables["grade"];
            dataGridView1.DataSource = dts.Tables["students"];
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadsv();
            if (label9.Text == "qlsv")
            {
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button10.Enabled = false;
            }
        }

        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSet dts = loaddata();
            DataTable dtable = dts.Tables["grade"];
            DataTable svtable = dts.Tables["students"];
            DataRelation relation = new DataRelation
                    ("students_grade", svtable.Columns["masv"], dtable.Columns["masv"]);
            dts.Relations.Add(relation);
            try
            {
                if (dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView3.CurrentRow.Selected = true;
                    textBox3.Text = dataGridView3.Rows[e.RowIndex].Cells["masv"].FormattedValue.ToString();
                    textBox4.Text = dataGridView3.Rows[e.RowIndex].Cells["tienganh"].FormattedValue.ToString();
                    textBox5.Text = dataGridView3.Rows[e.RowIndex].Cells["tinhoc"].FormattedValue.ToString();
                    textBox6.Text = dataGridView3.Rows[e.RowIndex].Cells["gdtc"].FormattedValue.ToString();
                    string x = dataGridView3.Rows[e.RowIndex].Cells["masv"].FormattedValue.ToString();
                    DataRow[] svrow = dtable.Select("masv='" + x + "'");
                    DataRow drow = svrow[0].GetParentRow("students_grade");
                    textBox2.Text = drow["hoten"].ToString();
                    textBox7.Text = ((int.Parse(textBox4.Text)+ int.Parse(textBox5.Text)+ int.Parse(textBox6.Text)) / 3).ToString();
                    textBox8.Text = dataGridView3.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                    comboBox1.DataSource = dts.Tables["students"];
                    comboBox1.DisplayMember = "masv";
                    comboBox1.ValueMember = "masv";
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Chon sai vi tri! \r\n"+x.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(label9.Text);
            frm4.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadsv();
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                string query = "select students.hoten, grade.masv, grade.tienganh, grade.tinhoc, grade.gdtc, grade.id from grade " +
                                    "join students on grade.masv=students.masv where grade.masv=@msv";
                data.Open();
                SqlCommand cn = new SqlCommand(query, data);
                try
                {
                    cn.Parameters.AddWithValue("@msv", textBox1.Text);
                    SqlDataReader read = cn.ExecuteReader();
                while (read.Read())
                {
                    textBox2.Text = read["hoten"].ToString();
                    textBox3.Text = read["masv"].ToString();
                    textBox4.Text = read["tienganh"].ToString();
                    textBox5.Text = read["tinhoc"].ToString();
                    textBox6.Text = read["gdtc"].ToString();
                    textBox7.Text = ((int.Parse(textBox4.Text) + int.Parse(textBox5.Text) + int.Parse(textBox6.Text)) / 3).ToString();
                    textBox8.Text = read["id"].ToString();
                }
                if(textBox3.Text=="") MessageBox.Show("Sinh vien khong ton tai!");
                }
                catch (Exception x)
                {
                    MessageBox.Show("Loi! \r\n" + x.Message);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
                    
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                data.Open();
                string query = "insert into grade(masv,tienganh,tinhoc,gdtc) values (@msv,@ta,@th,@gd);";
                SqlCommand cn = new SqlCommand(query, data);
                try
                {
                    cn.Parameters.AddWithValue("@msv", textBox3.Text);
                    cn.Parameters.AddWithValue("@ta", int.Parse(textBox4.Text));
                    cn.Parameters.AddWithValue("@th", int.Parse(textBox5.Text));
                    cn.Parameters.AddWithValue("@gd", int.Parse(textBox6.Text));
                    MessageBox.Show("Them thanh cong: " + cn.ExecuteNonQuery());
                }
                catch (Exception)
                {
                    MessageBox.Show("Them that bai!\r\n Kiem tra lai MSSV hoac du lieu nhap");
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
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                data.Open();
                string query = "delete grade where id=@check;";
                SqlCommand cn = new SqlCommand(query, data);
                try
                {
                    cn.Parameters.AddWithValue("@check", int.Parse(dataGridView3.CurrentRow.Cells["id"].Value.ToString()));
                    MessageBox.Show("Xoa thanh cong: " + cn.ExecuteNonQuery());
                }
                catch (Exception x)
                {
                    MessageBox.Show("Luu that bai!\r\n Kiem tra ID, MaSV hoac du lieu nhap \r\n" + x.Message);
                }
                finally
                {
                    data.Close();
                    loadsv();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (SqlConnection data = new SqlConnection(@"Data Source=BOSSMTA;Initial Catalog=FPL_daotao;Integrated Security=True"))
            {
                data.Open();
                string query = "update grade set id=@id,masv=@msv,tienganh=@ta,tinhoc=@th,gdtc=@gd where id=@check;";
                SqlCommand cn = new SqlCommand(query, data);
                try
                {
                    cn.Parameters.AddWithValue("@id", int.Parse(textBox8.Text));
                    cn.Parameters.AddWithValue("@msv", textBox3.Text);
                    cn.Parameters.AddWithValue("@ta", int.Parse(textBox4.Text));
                    cn.Parameters.AddWithValue("@th", int.Parse(textBox5.Text));
                    cn.Parameters.AddWithValue("@gd", int.Parse(textBox6.Text));
                    cn.Parameters.AddWithValue("@check", int.Parse(dataGridView3.CurrentRow.Cells["id"].Value.ToString()));
                    MessageBox.Show("Luu thanh cong: " + cn.ExecuteNonQuery());
                }
                catch (Exception x)
                {
                    MessageBox.Show("Luu that bai!\r\n Kiem tra ID, MaSV hoac du lieu nhap \r\n" + x.Message);
                }
                finally
                {
                    data.Close();
                    loadsv();
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var index = dataGridView3.Rows.Count;
            textBox2.Text = dataGridView3.Rows[index - 2].Cells["hoten"].FormattedValue.ToString();
            textBox3.Text = dataGridView3.Rows[index - 2].Cells["masv"].FormattedValue.ToString();
            textBox4.Text = dataGridView3.Rows[index - 2].Cells["tienganh"].FormattedValue.ToString();
            textBox5.Text = dataGridView3.Rows[index - 2].Cells["tinhoc"].FormattedValue.ToString();
            textBox6.Text = dataGridView3.Rows[index - 2].Cells["gdtc"].FormattedValue.ToString();
            textBox8.Text = dataGridView3.Rows[index - 2].Cells["id"].FormattedValue.ToString();
            textBox7.Text = ((int.Parse(textBox4.Text) + int.Parse(textBox5.Text) + int.Parse(textBox6.Text)) / 3).ToString();
            //Thay vi tri con tro va vien trong gridview
            dataGridView3.CurrentCell = dataGridView3.Rows[index - 2].Cells[index - 2];
            dataGridView3.Rows[index - 2].Selected = true;
            dataGridView3.Rows[0].Selected = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var index = dataGridView3.CurrentRow.Index;
            var dem = dataGridView3.Rows.Count;
            if (index < (dem - 2)) {
                dataGridView3.CurrentRow.Selected = false;
                textBox2.Text = dataGridView3.Rows[index + 1].Cells["hoten"].FormattedValue.ToString();
                textBox3.Text = dataGridView3.Rows[index + 1].Cells["masv"].FormattedValue.ToString();
                textBox4.Text = dataGridView3.Rows[index + 1].Cells["tienganh"].FormattedValue.ToString();
                textBox5.Text = dataGridView3.Rows[index + 1].Cells["tinhoc"].FormattedValue.ToString();
                textBox6.Text = dataGridView3.Rows[index + 1].Cells["gdtc"].FormattedValue.ToString();
                textBox8.Text = dataGridView3.Rows[index + 1].Cells["id"].FormattedValue.ToString();
                textBox7.Text = ((int.Parse(textBox4.Text) + int.Parse(textBox5.Text) + int.Parse(textBox6.Text)) / 3).ToString();

                dataGridView3.CurrentCell = dataGridView3.Rows[index + 1].Cells[index + 1];
                dataGridView3.Rows[index + 1].Selected = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var index = dataGridView3.CurrentRow.Index;
            if (index != 0) {
                dataGridView3.CurrentRow.Selected = false;
                textBox2.Text = dataGridView3.Rows[index - 1].Cells["hoten"].FormattedValue.ToString();
                textBox3.Text = dataGridView3.Rows[index - 1].Cells["masv"].FormattedValue.ToString();
                textBox4.Text = dataGridView3.Rows[index - 1].Cells["tienganh"].FormattedValue.ToString();
                textBox5.Text = dataGridView3.Rows[index - 1].Cells["tinhoc"].FormattedValue.ToString();
                textBox6.Text = dataGridView3.Rows[index - 1].Cells["gdtc"].FormattedValue.ToString();
                textBox8.Text = dataGridView3.Rows[index - 1].Cells["id"].FormattedValue.ToString();
                textBox7.Text = ((int.Parse(textBox4.Text) + int.Parse(textBox5.Text) + int.Parse(textBox6.Text)) / 3).ToString();

                dataGridView3.CurrentCell = dataGridView3.Rows[index - 1].Cells[index - 1];
                dataGridView3.Rows[index - 1].Selected = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var index = dataGridView3.Rows.Count;
            textBox2.Text = dataGridView3.Rows[0].Cells["hoten"].FormattedValue.ToString();
            textBox3.Text = dataGridView3.Rows[0].Cells["masv"].FormattedValue.ToString();
            textBox4.Text = dataGridView3.Rows[0].Cells["tienganh"].FormattedValue.ToString();
            textBox5.Text = dataGridView3.Rows[0].Cells["tinhoc"].FormattedValue.ToString();
            textBox6.Text = dataGridView3.Rows[0].Cells["gdtc"].FormattedValue.ToString();
            textBox8.Text = dataGridView3.Rows[0].Cells["id"].FormattedValue.ToString();
            textBox7.Text = ((int.Parse(textBox4.Text) + int.Parse(textBox5.Text) + int.Parse(textBox6.Text)) / 3).ToString();
            dataGridView3.CurrentCell = dataGridView3.Rows[0].Cells[0];
            dataGridView3.Rows[0].Selected = true;
            dataGridView3.Rows[index - 2].Selected = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
