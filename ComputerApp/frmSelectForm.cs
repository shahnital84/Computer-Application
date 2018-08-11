using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;



namespace ComputerApp
{
    public partial class frmSelectForm : Form
    {
        public static string pid, condition, cost, platform, manufacturer, os, model, memory, cbrand, ctype, lsize, cno, cspeed, hdd, gputype, webcam;

        public frmSelectForm()
        {
            InitializeComponent();
        }

        private void frmSelectForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetProductDetail();
        }

        private DataTable GetProductDetail()
        {
            DataTable dt = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con1 = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products",con1);
            if (con1.State ==ConnectionState.Closed)
            {
                con1.Open();
            }
            SqlDataReader dr= cmd.ExecuteReader();
            dt.Load(dr);
            con1.Close();
            return dt;
            

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            //fpi.ProductIdTextBox.text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            // pid= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            pid = dataGridView1.CurrentRow.Cells["productID"].Value.ToString();
            condition = dataGridView1.CurrentRow.Cells["condition"].Value.ToString();
            cost = dataGridView1.CurrentRow.Cells["cost"].Value.ToString();
            platform = dataGridView1.CurrentRow.Cells["platform"].Value.ToString();
            manufacturer = dataGridView1.CurrentRow.Cells["manufacturer"].Value.ToString();
            os = dataGridView1.CurrentRow.Cells["OS"].Value.ToString();
            model = dataGridView1.CurrentRow.Cells["model"].Value.ToString();
            memory = dataGridView1.CurrentRow.Cells["RAM_size"].Value.ToString();
            cbrand = dataGridView1.CurrentRow.Cells["CPU_brand"].Value.ToString();
            ctype = dataGridView1.CurrentRow.Cells["CPU_type"].Value.ToString();
            lsize = dataGridView1.CurrentRow.Cells["screensize"].Value.ToString();
            cno = dataGridView1.CurrentRow.Cells["CPU_number"].Value.ToString();
            cspeed = dataGridView1.CurrentRow.Cells["CPU_speed"].Value.ToString();
            hdd = dataGridView1.CurrentRow.Cells["HDD_size"].Value.ToString();
            gputype = dataGridView1.CurrentRow.Cells["GPU_Type"].Value.ToString();
            webcam = dataGridView1.CurrentRow.Cells["webcam"].Value.ToString();
            frmProductInfo fpi = new frmProductInfo();
            fpi.Show();
        }
    }
}
