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
    public partial class Forgetpass : Form
    {
        SqlConnection con=new SqlConnection();
        public Forgetpass()
        {
            InitializeComponent();
        }

        private void Forgetpass_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            connect();
            string stmt = "select * from users where Email ='" + textBox1.Text + "' and city='" + textBox2.Text + "' and favmovie='" + textBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(stmt, con);
            SqlDataReader x = cmd.ExecuteReader();
            if (x.Read())
            {
                Form reset = new reset(textBox1.Text);
                reset.Show();
                this.Close();   
            }
            else
                MessageBox.Show("Invalid Data");
        }
        private void connect()
        {
            string constr = "Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI";
            con = new SqlConnection(constr);
            con.Open();
        }
    }
}
