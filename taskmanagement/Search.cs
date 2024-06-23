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
    public partial class Search : Form
    {
        SqlConnection conn = new SqlConnection("Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI");
        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display_datagrid1();
            if (!TaskExists(textBox1.Text))
            {
                MessageBox.Show($"Task '{textBox1.Text}' does not exist. Please create the task first.");
                return;
            }
        }
        private bool TaskExists(string taskName)
        {
            string connectionString = "Data source = NUI\\SQLEXPRESS01; initial catalog = taskmanagementDB; integrated security = SSPI";
            string query = "SELECT COUNT(*) FROM Tasks WHERE taskname = @taskname";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@taskname", textBox1.Text);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void display_datagrid1()
            {
                SqlCommand query2 = new SqlCommand("select * from tasks where taskname like '%" + textBox1.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = query2;
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        

        private void Search_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form task = new Tasks_list();
            task.Show();
            this.Close();
        }
    }
}
