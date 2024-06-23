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
    public partial class Notes : Form
    {
        SqlConnection conn = new SqlConnection("Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI");
        public Notes()
        {
            InitializeComponent();
        }
        private void display_datagrid()
        {
            SqlCommand query2 = new SqlCommand("select * from note", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = query2;
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Notes_Load(object sender, EventArgs e)
        {
            display_datagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string taskName = textBox1.Text;
            string note = textBox2.Text;

            if (string.IsNullOrWhiteSpace(taskName) || string.IsNullOrWhiteSpace(note))
            {
                MessageBox.Show("Please enter both task name and note.");
                return;
            }
            if (!TaskExists(taskName))
            {
                MessageBox.Show($"Task '{taskName}' does not exist. Please create the task first.");
                return;
            }

            string connectionString = "Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI";
            string query = "INSERT INTO note (taskname, note) VALUES (@taskName, @note)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskname", taskName);
                cmd.Parameters.AddWithValue("@note", note);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Note saved successfully.");
            display_datagrid();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["taskname"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["note"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }

            string taskName = dataGridView1.CurrentRow.Cells["taskname"].Value.ToString();
            string connectionString = "Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI";
            string query = "DELETE FROM note WHERE taskname = @taskName";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskname", taskName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Note was deleted successfully.");
            display_datagrid();
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private bool TaskExists(string taskName)
        {
            string connectionString = "Data source = NUI\\SQLEXPRESS01; initial catalog = taskmanagementDB; integrated security = SSPI";
            string query = "SELECT COUNT(*) FROM Tasks WHERE taskname = @taskname";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskname", taskName);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form tasks = new maindashboard();
            tasks.Show();
            this.Hide();    
        }
    }
}
