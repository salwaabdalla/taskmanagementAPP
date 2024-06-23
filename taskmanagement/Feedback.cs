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

namespace taskmanagement
{
    public partial class Feedback : Form
    {
        SqlConnection conn = new SqlConnection("Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI");
        public Feedback()
        {
            InitializeComponent();
        }
        string satisfied;
        string expectations;
        private void Feedback_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into feedback values ('" + satisfied + "','" +expectations+ "','" + textBox1.Text + "')", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thank you so much for providing us a feedback!");
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form main = new maindashboard();
            main.Show();
            this.Close();   
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            satisfied = "Best";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            satisfied = "Good";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        { 
            satisfied = "Bad";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            expectations = "Yes";

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            expectations = "No";
        }
    }
}
