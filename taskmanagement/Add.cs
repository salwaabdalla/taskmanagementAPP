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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=NUI\\SQLEXPRESS01; Initial Catalog=taskmanagementDB; Integrated Security=SSPI");
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO tasks VALUES('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" +
                                                    dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + comboBox1.Text + "','" + comboBox2.Text + "')", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Data was inserted successfully");
                con.Close();
            }
            catch (Exception ex)
            {
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

        private void Add_Load(object sender, EventArgs e)
        {
            display_datagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form task=new Tasks_list();  
            task.Show();
            this.Close();   
        }
    }
}
