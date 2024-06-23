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
    public partial class Update : Form
    {
        SqlConnection con;
        public Update()
        {
            InitializeComponent();
        }


        private void Update_Load(object sender, EventArgs e)
        {
            display_datagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form task = new Tasks_list();
            task.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Establish a connection to the SQL database
               con = new SqlConnection("Data Source=NUI\\SQLEXPRESS01; Initial Catalog=taskmanagementDB; Integrated Security=SSPI");
                con.Open();

                // Create an update SQL command
                SqlCommand command = new SqlCommand("UPDATE tasks SET Taskname = '" + textBox2.Text + "', DueDate = '" + dateTimePicker1.Value + "', Priority = '" + comboBox1.Text + "', Status = '" + comboBox2.Text + "' WHERE TaskID = " + int.Parse(textBox1.Text), con);

                // Execute the command
                command.ExecuteNonQuery();

                // Inform the user that the data was updated successfully
                MessageBox.Show("Data was updated successfully");

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
    }
}
