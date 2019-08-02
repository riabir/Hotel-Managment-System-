using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_management
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            textBox2.PasswordChar = '#';
        }

        private void button1_Click(object sender, EventArgs e)
        {
          if (textBox2.Text == "123456")
            {
                this.Hide();
                Form5 ss = new Form5();
                ss.Show();
            }
            else
            {

                MessageBox.Show("Please check your password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
