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

namespace MainProject
{
    public partial class Form5 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmad_bqh2ijo\source\repos\MainProject\MainProject\Database2.mdf;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from items", conn);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from items where itemid =" + textBox1.Text + " ", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    textBox3.Text = rdr.GetValue(1).ToString();
                    textBox2.Text = rdr.GetValue(2).ToString();
                    textBox4.Text = rdr.GetValue(3).ToString();
                    textBox5.Text = rdr.GetValue(4).ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Item not found" + ex);
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
            string name = textBox3.Text.ToString();
            string catigory = textBox2.Text.ToString();
            string price = textBox4.Text.ToString();
            string quatity = textBox5.Text.ToString();
            SqlCommand sq = new SqlCommand("insert into items values(" + id + ",'" + name + "','" + catigory + "','" + price + "','" + quatity + "')", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox1.Text.ToString());
            string name = textBox3.Text.ToString();
            string catigory = textBox2.Text.ToString();
            string price = textBox4.Text.ToString();
            string quatity = textBox5.Text.ToString();
            SqlCommand sq = new SqlCommand("update items set itemname ='" + name + "', catigory = '"+ catigory + "', price = '"+price+"' , quantity = '"+quatity+"' where itemid = "+ id + " ", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = Int32.Parse(textBox1.Text.ToString());
            SqlCommand sq = new SqlCommand("delete from items where itemid = " + textBox1.Text + " ", conn);
            sq.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
