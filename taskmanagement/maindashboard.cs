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
using System.Windows.Forms.VisualStyles;

namespace taskmanagement
{
    public partial class maindashboard : Form
    {
        SqlConnection conn =new SqlConnection("Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI");
        public maindashboard()
        {
            InitializeComponent();
        }
      
       

       

        private void button4_Click(object sender, EventArgs e)
        {
            Form taskslist = new Tasks_list();
            taskslist.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form notes = new Notes();
            notes.Show();
            
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
        private void maindashboard_Load(object sender, EventArgs e)
        {
            display_datagrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form about = new About();
            about.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form cp = new Changepass();
            cp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form login = new login();
            login.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form fd = new Feedback();
            fd.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
