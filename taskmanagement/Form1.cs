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

namespace taskmanagement
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection();
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
           // this.AcceptButton = button1;
            textBox2.PasswordChar = '*';
             button5.Text = "Show";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect();
            string stmt = "select * from Users where UserName ='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(stmt, con);
            SqlDataReader x = cmd.ExecuteReader();
            if (x.Read())
            {
             
                Form main = new maindashboard();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                
            }
           
        }
        private void connect()
        {
            string constr = "Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI";
            con = new SqlConnection(constr);
            con.Open();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0'; // Show password
                button5.Text = "Hide";
            }
            else
            {
                textBox2.PasswordChar = '*'; // Hide password
                button5.Text = "Show";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form fg = new Forgetpass();
            fg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form regis = new register();
            regis.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
