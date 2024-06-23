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
    public partial class Tasks_list : Form
    {
        SqlConnection conn = new SqlConnection("Data source=NUI\\SQLEXPRESS01; initial catalog=taskmanagementDB;integrated security=SSPI");
        public Tasks_list()
        {
            InitializeComponent();
        }
        private void display_datagrid1()
        {
            SqlCommand query2 = new SqlCommand("select * from tasks ",conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable(); 
            da.SelectCommand = query2;
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource= dt;   
        }
       
        private void Tasks_list_Load(object sender, EventArgs e)
        {
     
            display_datagrid1();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Form add = new Add();
            add.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form update = new Update();
            update.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form main = new maindashboard();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form delete = new Delete();
            delete.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form search = new Search();
            search.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form pr = new Priority();
            pr.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form st = new Status();
            st.Show();
            this.Hide();
        }
    }
}
