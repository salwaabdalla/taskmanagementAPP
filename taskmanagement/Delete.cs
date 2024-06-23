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

namespace taskmanagement
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Establish a connection to the SQL database
                SqlConnection con = new SqlConnection("Data Source=NUI\\SQLEXPRESS01; Initial Catalog=taskmanagementDB; Integrated Security=SSPI");
                con.Open();

                // Create a delete SQL command
                SqlCommand command = new SqlCommand("DELETE FROM tasks WHERE TaskID= " + int.Parse(textBox1.Text), con);

                // Execute the command
                command.ExecuteNonQuery();

                // Inform the user that the data was deleted successfully
                MessageBox.Show("Data was deleted successfully");

                // Close the connection
                con.Close();
            }
            catch (Exception ex)
            {
                // Show an error message if something goes wrong
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void display_datagrid()
        {
            SqlConnection con = new SqlConnection("Data Source=NUI\\SQLEXPRESS01; Initial Catalog=taskmanagementDB; Integrated Security=SSPI");
            SqlCommand query2 = new SqlCommand("select * from tasks ", con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = query2;
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form tasks = new Tasks_list();
            tasks.Show();
            this.Close();   
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            display_datagrid();
        }
    }
}
