using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace taskmanagement
{
    public partial class register : Form
    {
        SqlConnection con=new SqlConnection();
        public register()
        {
            InitializeComponent();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox3.Text, "[A-Z]") && Regex.IsMatch(textBox3.Text, "[a-z]") && Regex.IsMatch(textBox3.Text, "[0-9]") && (textBox3.Text.Length>=8))
            {
                connect();
                string sqlstmt = "insert into Users values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlstmt, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Was Saved");
            }
            

        }

        private void connect()
        {

            string constr = "Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI";
            con = new SqlConnection(constr);
            con.Open();
            //  MessageBox.Show("Done");
        }

            private void button2_Click(object sender, EventArgs e)
        {
            Form login = new login();
            login.Show();
        }
    }
}
