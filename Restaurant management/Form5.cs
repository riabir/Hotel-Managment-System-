using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restaurant_management
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=res;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO employee(id,name,street,city,house,schedule,salary) 
 VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Susscefully Save :)");
            Display();
            //Refresh();
        }
        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from employee", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();


            }
        
        }
        void Display1()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from booking", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item[3].ToString();
            }

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Display();
            //Display1();
            Display2();
            Display3();
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM employee WHERE (name = '" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Susscefully Delete...... :)");
            Display();
        }

        private void dataGridView1_Mouseclick(object sender, MouseEventArgs e)
        {

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM booking WHERE (tableNo = '" + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Susscefully Delete...... :)");
            Display2();
        }

        void Display2()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select *from booking", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
             dataGridView2.Rows.Clear();
            
           foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item[3].ToString();
                
            }

        }



        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            /*comboBox1.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
        */}

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //comboBox1.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
           }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select *from booking Where ( name  Like  '%" + textBox9.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView2.Rows[n].Cells[3].Value = item[3].ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE   employee
          SET          id='" + textBox1.Text + "',name='" + textBox2.Text + "',street='" + textBox3.Text + "',city='" + textBox4.Text + "',house='" + textBox5.Text + "',schedule='" + textBox6.Text + "',salary='" + textBox7.Text + "'  WHERE (id = '" + textBox1.Text + "' )", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Susscefully Updated...... :)");
            Display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE   booking
          SET          tableNo='" + textBox1.Text + "',name='" + textBox2.Text + "',PhoneNo='" + textBox3.Text + "',time='" + textBox4.Text + "'  WHERE (tableNo = '" + textBox1.Text + "' )", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Susscefully Updated...... :)");
            Display();
       */
        }
        void Display3()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select *from ord", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.Rows.Clear();

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView3.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView3.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView3.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView3.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView3.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView3.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView3.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridView3.Rows[n].Cells[8].Value = item[8].ToString();
                dataGridView3.Rows[n].Cells[9].Value = item[9].ToString();
                dataGridView3.Rows[n].Cells[10].Value = item[10].ToString();
                


            }

        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            /*comboBox1.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            comboBox3.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            comboBox4.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            textBox6.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            textBox7.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
            textBox8.Text = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();
            textBox9.Text = dataGridView3.SelectedRows[0].Cells[5].Value.ToString();
            textBox10.Text = dataGridView3.SelectedRows[0].Cells[6].Value.ToString();
        */
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM ord WHERE (phoneNo = '" + dataGridView3.SelectedRows[0].Cells[8].Value.ToString() + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Susscefully Delete...... :)");
            Display3();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select *from ord Where ( phoneNo  Like  '%" + textBox10.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView3.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView3.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView3.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView3.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView3.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView3.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView3.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridView3.Rows[n].Cells[8].Value = item[8].ToString();
                dataGridView3.Rows[n].Cells[9].Value = item[9].ToString();
                dataGridView3.Rows[n].Cells[10].Value = item[10].ToString();
                

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select *from employee Where ( name  Like  '%" + textBox8.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
