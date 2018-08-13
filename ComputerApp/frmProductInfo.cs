using System;
using System.Windows.Forms;

namespace ComputerApp
{
    public partial class frmProductInfo : Form
    {
        public Form ProdPrevForm;
        public Form newForm;
        string filedata;

        public frmProductInfo()
        {
            InitializeComponent();
        }

        public void OpenSave() //PUBLIC FUNCTION OPENSAVE TO CALL OPEN MENU (CAN ACCESS FROM START UP FORM - OPEN SAVED RECORD)
        {
            openToolStripMenuItem.PerformClick(); //OPEN DIALOG BOX 
        }

        //FORM LOAD - DATA SAVED TO TEXT BOX 
        private void frmProductInfo_Load(object sender, EventArgs e)
        {
            refreshData(); //ON PAGE LOAD-DATA WILL REFRESH ON FORM
        }

        public void refreshData() // PUBLIC FUNCTION TO REFRESH PAGE DATA
        {
            CostTextBox.Text = StaticVar.cost; //STATIC VARIABLE DECLARED IN CLASS FILE
            ProductIdTextBox.Text = StaticVar.pid;
            ConditionTextBox.Text = StaticVar.condition;
            PlatformTextBox.Text = StaticVar.platform;
            ManufacturerTextBox.Text = StaticVar.manufacturer;
            OSTextBox.Text = StaticVar.os;
            ModelTextBox.Text = StaticVar.model;
            MemoryTextBox.Text = StaticVar.memory;
            CPUBrandTextBox.Text = StaticVar.cbrand;
            CPUTypeTextBox.Text = StaticVar.ctype;
            LCDSizeTextBox.Text = StaticVar.lsize;
            CPUNumberTextBox.Text = StaticVar.cspeed;
            CPUSpeedTextBox.Text = StaticVar.cno;
            HDDTextBox.Text = StaticVar.hdd;
            GPUTypeTextBox.Text = StaticVar.gputype;
            WebCamTextBox.Text = StaticVar.webcam;
        }
        //NEXT BUTTON - SELECTED DATA WILL MOVE TO ORDER PAGE       
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (newForm == null)
            {
                frmOrderForm fo = new frmOrderForm(); //IF USER CLICKS FRIST TIME ON NEXT BUTTON
                fo.pform = this; //ORDER PREVIOUS FORM  = PRODUCT INFO 
                this.newForm = fo; //PRODUCT NEXT FORM = ORDER FORM
                fo.refreshData(); //REFRESH FORM TO LOAD CURENT DATA
                fo.Show(); //SHOW ORDER FORM
            }
            else
            {
                this.newForm.Show(); //FORM ALREADY OPEN IN MEMORY, PRODUCT INFO NEXT FORM SHOW
                try
                {
                    frmOrderForm frmOrder = this.newForm as frmOrderForm; //CREate PRODUCT INFO NEW FORM = Orderform
                    frmOrder.refreshData(); //REFRSH FORM
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            this.Hide();
        }

        //SELECT ANOTHER PRUDUCT - IF USER CLICKS FIRST TIME NEW FORM APPEAR ELSE PAGE IN THE BACKGROUND WILL APPEAR
        private void SelectAnotherProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                frmSelectForm frmnew = this.ProdPrevForm as frmSelectForm; // ISELECT ANOTHER PRODUCT - IF SELECT FORM NOT OPEN ==>  OPEN PRODUCT PREVIOUS FORM - SELECT FORM AS NEW FORM
                frmnew.refershData(); //REFRESH PAGE
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            this.ProdPrevForm.Show(); //ELSE IF ALREADY OPEN , OPEN PRODUCT PREVIOUS FORM - SELECT FORM
            this.Hide();
        }

        //CANCEL BUTTTON - PREVIOUS FORM SELECT RRODUCT FORM WILL SHOW AND CURRENT WILL HIDE
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.ProdPrevForm.Show(); //SEELCT FORM WILL SHOW
            this.Hide(); //PRODUCT INFO PAGE WILL HIDE
        }

        //save menu FILE
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDig = new SaveFileDialog(); //SAVE DIALOG BOX
            saveDig.Filter = "Text Files|*.txt"; //FILTER DEFAULT .TXT FILES
            filedata = (StaticVar.pid + "|" + StaticVar.condition + "|" + CostTextBox.Text + "|" + StaticVar.platform + "|" + StaticVar.manufacturer + "|" + StaticVar.os + "|" + StaticVar.model + "|" + StaticVar.memory + "|" + StaticVar.cbrand + "|" + StaticVar.ctype + "|" + StaticVar.lsize
                 + "|" + StaticVar.cno + "|" + StaticVar.cspeed + "|" + StaticVar.hdd + "|" + StaticVar.gputype + "|" + StaticVar.webcam); //DATA SAVED TO FILEDATA VARIABLE WITH '|' DELOMETER

            if (saveDig.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveDig.FileName, filedata);//WHEN USER CLICKON OK, FILE DATA SAVED


            }
            MessageBox.Show("File Saved");
        }

        //OPEN FILE
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDig = new OpenFileDialog(); //OPEN DIALOG BOX
            openDig.Filter = "Text Files|*.txt"; //CHECK FOR .TXT FILES
            if (openDig.ShowDialog() == DialogResult.OK) //IF USER CLICK ON OK BUTTON
            {
                filedata = System.IO.File.ReadAllText(openDig.FileName); //READ DATA FROM FILE
                string[] data = filedata.Split('|'); //DATA STORED TO DATA ARRAY[] BY SPLITING WITH DELIMETER '|'
                foreach (string i in data)
                {
                    string getdata = i;
                }
                StaticVar.pid = data[0]; //ARRAY DATA STORED TO STATIC VARIABLES ALL TIME USER CHANGE RECORDS, DATA GETS REFRESHED
                StaticVar.condition = data[1];
                StaticVar.cost = data[2];
                StaticVar.platform = data[3];
                StaticVar.manufacturer = data[4];
                StaticVar.os = data[5];
                StaticVar.model = data[6];
                StaticVar.memory = data[7];
                StaticVar.cbrand = data[8];
                StaticVar.ctype = data[9];
                StaticVar.lsize = data[10];
                StaticVar.cno = data[11];
                StaticVar.cspeed = data[12];
                StaticVar.hdd = data[13];
                StaticVar.gputype = data[14];
                StaticVar.webcam = data[15];
                ProductIdTextBox.Text = StaticVar.pid;  //ASSIGN STATIC VALUES TO TEXT BOX
                ConditionTextBox.Text = StaticVar.condition;
                PlatformTextBox.Text = StaticVar.platform;
                ManufacturerTextBox.Text = StaticVar.manufacturer;
                OSTextBox.Text = StaticVar.os;
                ModelTextBox.Text = StaticVar.model;
                MemoryTextBox.Text = StaticVar.memory;
                CPUBrandTextBox.Text = StaticVar.cbrand;
                CPUTypeTextBox.Text = StaticVar.ctype;
                LCDSizeTextBox.Text = StaticVar.lsize;
                CPUNumberTextBox.Text = StaticVar.cno;
                CPUSpeedTextBox.Text = StaticVar.cspeed;
                HDDTextBox.Text = StaticVar.hdd;
                GPUTypeTextBox.Text = StaticVar.gputype;
                WebCamTextBox.Text = StaticVar.webcam;
            }
        }

        //ON FORM CLOSE, CLOSE ALL PREVIOUS FORMS AS A CHAIN
        private void frmProductInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ProdPrevForm.Close();
        }
    }
}
