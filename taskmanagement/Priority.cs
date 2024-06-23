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
    public partial class Priority : Form
    {
        SqlConnection conn = new SqlConnection("Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI");
        public Priority()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            display_datagrid1();
        }

        private void Priority_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("High");
            comboBox1.Items.Add("Medium");
            comboBox1.Items.Add("Low");
            comboBox1.SelectedIndex = -1; // Optional: This ensures no item is selected initially
        }
        private void display_datagrid1()
        {
            SqlCommand query2 = new SqlCommand("select * from tasks where priority like '%" + comboBox1.Text + "'", conn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form tasks = new Tasks_list();
            tasks.Show();
            this.Hide();
        }
    }
}
