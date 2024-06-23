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
    public partial class reset : Form
    {
        SqlConnection con = new SqlConnection();
        private string userEmail;
        public reset(string email)
        {
            InitializeComponent();
            userEmail = email;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, "[A-Z]") && Regex.IsMatch(textBox1.Text, "[a-z]") && Regex.IsMatch(textBox1.Text, "[0-9]") && (textBox1.Text.Length >= 8))
            {
                con = new SqlConnection("Data Source=NUI\\SQLEXPRESS01; Initial Catalog=taskmanagementDB; Integrated Security=SSPI");
                con.Open();

                if (textBox1.Text == textBox2.Text)
                {
                    SqlCommand command = new SqlCommand("UPDATE users SET Password = '" + textBox1.Text + "' WHERE Email =  '" + userEmail + "'", con);

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Inform the user that the data was updated successfully
                    MessageBox.Show("Password was reserted successfully");
                }
                else
                {
                    MessageBox.Show("Password doesnt match");
                }
            }
            else
                MessageBox.Show("Password must contain mininum one small , capital,digit and also must be more than 8 characters");
            // Close the connection
            con.Close();
        }

        private void reset_Load(object sender, EventArgs e)
        {

        }
    }
}
