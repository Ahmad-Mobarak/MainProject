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
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ahmad_bqh2ijo\source\repos\MainProject\MainProject\Database2.mdf;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select itemid, itemname, catigory, price from items", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            this.Close();
            Form1 ss = new Form1();
            ss.Show();
        }
    }
}
