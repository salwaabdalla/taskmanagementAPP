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

namespace taskmanagement
{
    public partial class Changepass : Form
    {
        SqlConnection con = new SqlConnection();
        public Changepass()
        {
            InitializeComponent();
        }



        private void connect()
        {
            string constr = "Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI";
            con = new SqlConnection(constr);
            con.Open();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == textBox4.Text)
            {
                connect();
                string stmt = "select * from Users Where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(stmt, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (Regex.IsMatch(textBox3.Text, "[A-Z]") && Regex.IsMatch(textBox3.Text, "[a-z]") && Regex.IsMatch(textBox3.Text, "[0-9]") && (textBox3.Text.Length >= 8))
                    {
                        dr.Close();
                        string str = "update users set Password='" + textBox3.Text + "' where Username='" + textBox1.Text + "'";
                        SqlCommand cm = new SqlCommand(str, con);
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Password Was Changed");
                        this.Close();
                        Form login = new login();
                        login.Show();
                    }
                    else
                        MessageBox.Show("Password must contain mininum one small , capital,digit and also must be more than 8 characters");


                }
                else
                    MessageBox.Show("Invalid Username Or Password");

            }
            else
                MessageBox.Show("Mismatch");

        }
    }
}
