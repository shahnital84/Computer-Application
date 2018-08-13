using System;
using System.Windows.Forms;

namespace ComputerApp
{
    public partial class frmSelectForm : Form
    {

        public Form previousForm; //DECLARE previousForm VARIABLE OF FORM TYPE TO SET PREVIOUS FORM
        public Form nextForm; //DECLARE nextform VARIABLE OF FORM TYPE TO SET NEXT FORM

        public frmSelectForm()
        {
            InitializeComponent();
        }

        //ON FORM LOAD BIND DATA TO GRID
        private void frmSelectForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = StaticVar.GetProductDetail();  //DATA BINDING - FUNTION CALL FROM CLASS FILE
        }

        //PUBLIC FUNCTION TO REFRESH FORM TO LOAD SELECTED DATA FROM GRID
        public void refershData()
        {
            if (StaticVar.pid != null) // IF RECORD ALREADY SELECTED FROM PRODUCT INFORMATION PAGE , FOR EXAMPLE IF PRODUCT ID = 7
            {
                foreach (DataGridViewRow row in dataGridView1.Rows) //THEN CHECK ALL ROWS IN GRID 
                {
                    if (row.Cells["productID"].Value.ToString().Equals(StaticVar.pid)) // WHEN FINDS PRODUCT ID = 7
                    {
                        row.Selected = true; //WILL SELECT RECORD OF PRODUCT ID = 7
                    }
                }
            }
        }

        //NEXT BUTTON - PRODUCT INFORATION PAGE DISPLAY WITH SELECTED RECORD ON GRID
        private void btnNext_Click(object sender, EventArgs e) 
        {
            if(nextForm == null) //IF USER CLICKS FRIST TIME ON NEXT BUTTON -
            {
                frmProductInfo fpi = new frmProductInfo(); //IF YES, CREATE NEW INSTANCE OF FORM PRODUCT INFO
                fpi.ProdPrevForm = this; //SET PREVIOUS FORM_PRODUCT INFO = SELECT FORM
                this.nextForm = fpi; //SET NEXT FOEM_SELECT FORM = PRODUCT INFO FORM 
                fpi.Show(); //PRODUCT INFO FORM SHOW
            }
            else
            {
                this.nextForm.Show(); //IF PRODUCT FORM ALREADY OPEN IN MEMORY, PRODUCT FORM WILL SHOW
                try
                {
                    frmProductInfo fpi = this.nextForm as frmProductInfo; //SET NEXT FOEM_SELECT FORM = PRODUCT INFO FORM 
                    fpi.refreshData(); //FUNCTION CALL TO REFRESH FORM TO LOAD CURRENT SELECTED DATA ON PRODUCT INFO PAGE
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
            StaticVar.cost = cost.ToString("C"); //COST CURRENCY FORMAT
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
