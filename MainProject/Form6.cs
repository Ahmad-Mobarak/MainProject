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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MainProject
{
    public partial class Form6 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmad_bqh2ijo\source\repos\MainProject\MainProject\Database1.mdf;Integrated Security=TrueData Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmad_bqh2ijo\source\repos\MainProject\MainProject\Database1.mdf;Integrated Security=True");
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from loginu where Id =" + textBox1.Text + " ", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBox3.Text = rdr.GetValue(1).ToString();
                }
                conn.Close();
                conn.Open ();
                SqlCommand cqwe = new SqlCommand("Select * from login where Id =" + textBox1.Text + " ", conn);
                SqlDataReader qwe = cqwe.ExecuteReader();
                while (qwe.Read())
                {
                    textBox3.Text = qwe.GetValue(1).ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("id not found" + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox1.Text.ToString());
            string pass = textBox3.Text.ToString();
            SqlCommand sq = new SqlCommand("insert into loginu values(" + id + ",'" + pass + "')", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox1.Text.ToString());
            string Pass = textBox3.Text.ToString();
            SqlCommand sq = new SqlCommand("update loginu set password ='" + Pass + "' where Id = " + id + " ", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("do want to delet this user", "Delet !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                conn.Open();
                int id = Int32.Parse(textBox1.Text.ToString());
                SqlCommand sq = new SqlCommand("delete from loginu where Id = " + textBox1.Text + " ", conn);
                sq.ExecuteNonQuery();
                conn.Close();
                textBox1.Clear();
                textBox3.Clear();
            }
            else
            {
                this.Show();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from loginu", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 ss = new Form2();
            ss.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from login", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("do want to delet this admin", "Delet !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                conn.Open();
                int id = Int32.Parse(textBox1.Text.ToString());
                SqlCommand sq = new SqlCommand("delete from login where Id = " + textBox1.Text + " ", conn);
                sq.ExecuteNonQuery();
                conn.Close();
                textBox1.Clear();
                textBox3.Clear();
            }
            else
            {
                this.Show();
            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox1.Text.ToString());
            string Pass = textBox3.Text.ToString();
            SqlCommand sq = new SqlCommand("update login set password ='" + Pass + "' where Id = " + id + " ", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox3.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox1.Text.ToString());
            string pass = textBox3.Text.ToString();
            SqlCommand sq = new SqlCommand("insert into login values(" + id + ",'" + pass + "')", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox3.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
