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
    public partial class Status : Form
    {
        SqlConnection conn = new SqlConnection("Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI");

        public Status()
        {
            InitializeComponent();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Not Started");
            comboBox1.Items.Add("In Progress");
            comboBox1.Items.Add("Completed");
            comboBox1.SelectedIndex = -1; // Optional: This ensures no item is selected initially
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            display_datagrid1();
           
        }
        private void display_datagrid1()
        {
            SqlCommand query2 = new SqlCommand("select * from tasks where status like '%" + comboBox1.Text + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = query2;
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form tasks = new Tasks_list();
            tasks.Show();
            this.Hide();
        }
    }
}
