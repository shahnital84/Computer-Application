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

        public Form previousForm;
        public Form nextForm;

        public frmSelectForm()
        {
            InitializeComponent();
        }

        //ON FORM LOAD BIND DATA TO GRID
        private void frmSelectForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = StaticVar.GetProductDetail();  
        }

        public void refershData()
        {
            if (StaticVar.pid != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["productID"].Value.ToString().Equals(StaticVar.pid))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        //NEXT BUTTON - PRODUCT INFORATION PAGE DISPLAY WITH SELECTED RECORD ON GRID
        private void btnNext_Click(object sender, EventArgs e)
        {
            if(nextForm == null)
            {
                //frmProductInfo fpi = new frmProductInfo();
                //fpi.Show();
                frmProductInfo fpi = new frmProductInfo();
                fpi.ProdPrevForm = this;
                this.nextForm = fpi;
                fpi.Show();
                // previousForm.Show();
            }
            else
            {
                this.nextForm.Show();
                try
                {
                    frmProductInfo fpi = this.nextForm as frmProductInfo;
                    fpi.refreshData();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            this.Hide();
        }

        //CANCEL BUTTTON - PREVIOUS FORM SELECT RRODUCT FORM WILL SHOW AND CURRENT WILL HIDE
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Hide();
        }

        //WHEN SELECTION CHANGED TO GRID, CURRENT SELECTED RECORD DATA WILL BE SAVED TO STATIC PUBLIC VARIABLES DECLARED IN STTATIC CLASS FILE
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count==0)
            {
                return;
            }
            StaticVar.pid = dataGridView1.CurrentRow.Cells["productID"].Value.ToString();
            StaticVar.condition = dataGridView1.CurrentRow.Cells["condition"].Value.ToString();
            double cost;
            cost = double.Parse(dataGridView1.CurrentRow.Cells["cost"].Value.ToString());
            StaticVar.cost = cost.ToString("C");
            StaticVar.platform = dataGridView1.CurrentRow.Cells["platform"].Value.ToString();
            StaticVar.manufacturer = dataGridView1.CurrentRow.Cells["manufacturer"].Value.ToString();
            StaticVar.os = dataGridView1.CurrentRow.Cells["OS"].Value.ToString();
            StaticVar.model = dataGridView1.CurrentRow.Cells["model"].Value.ToString();
            StaticVar.memory = dataGridView1.CurrentRow.Cells["RAM_size"].Value.ToString();
            StaticVar.cbrand = dataGridView1.CurrentRow.Cells["CPU_brand"].Value.ToString();
            StaticVar.ctype = dataGridView1.CurrentRow.Cells["CPU_type"].Value.ToString();
            StaticVar.lsize = dataGridView1.CurrentRow.Cells["screensize"].Value.ToString();
            StaticVar.cno = dataGridView1.CurrentRow.Cells["CPU_number"].Value.ToString();
            StaticVar.cspeed = dataGridView1.CurrentRow.Cells["CPU_speed"].Value.ToString();
            StaticVar.hdd = dataGridView1.CurrentRow.Cells["HDD_size"].Value.ToString();
            StaticVar.gputype = dataGridView1.CurrentRow.Cells["GPU_Type"].Value.ToString();
            StaticVar.webcam = dataGridView1.CurrentRow.Cells["webcam"].Value.ToString();

            //PRICE IN FORMAT $ 0:00 (CURRENCY FORMAT)
            txtInfo.Text = StaticVar.manufacturer.ToUpper() + " - " + StaticVar.model.ToUpper() + " - " + "PRICE:" + cost.ToString("C");
        }

        //WHEN USER CLICK ON - X BUTTON ALL PREVIOUS FORMS WILL CLOSE AND APPLICATION TERMINATES
        private void frmSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Close();
        }
    }
}
