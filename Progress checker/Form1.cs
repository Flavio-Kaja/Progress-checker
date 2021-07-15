using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progress_checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username=="student" && password=="password")
            {
                menuStrip1.Visible=true;
                panel1.Visible = false;
                pictureBox5.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid username or password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            pictureBox5.Visible = false;
        }

        private void newSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_session window = new New_session();
            window.Visible = true;
        }

        private void progressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Progress window = new Progress();
            window.Visible = true;
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Languages window = new Languages();
            window.Visible= true;
        }
    }
}
