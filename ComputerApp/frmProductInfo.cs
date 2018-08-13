using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void OpenSave()
        {
            openToolStripMenuItem.PerformClick();
        }

        //FORM LOAD - DATA SAVED TO TEXT BOX 
        private void frmProductInfo_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        public void refreshData()
        {

            //PRICE IN FORMAT $ 0:00
            CostTextBox.Text = StaticVar.cost;
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
            if(newForm == null)
            {
                frmOrderForm fo = new frmOrderForm();
                fo.pform = this;
                this.newForm = fo;
                fo.refreshData();
                fo.Show();
            }
            else
            {
                this.newForm.Show();
                try
                {
                    frmOrderForm frmOrder = this.newForm as frmOrderForm;
                    frmOrder.refreshData();
                }catch(Exception ex)
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
                frmSelectForm frmnew = this.ProdPrevForm as frmSelectForm;
                frmnew.refershData();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            this.ProdPrevForm.Show();
            this.Hide();
        }


        //private void frmProductInfo_Deactivate(object sender, EventArgs e)
        //{
        //    this.Close();
        //}


        //CANCEL BUTTTON - PREVIOUS FORM SELECT RRODUCT FORM WILL SHOW AND CURRENT WILL HIDE
        private void CancelButton_Click(object sender, EventArgs e)
        {
            //frmStartUp formstart = new frmStartUp();
            //formstart.Show();
            this.ProdPrevForm.Show();
            this.Hide();
            //Application.Exit();
          
        }

        //save menu FILE
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDig = new SaveFileDialog();
            saveDig.Filter = "Text Files|*.txt";
            filedata = (StaticVar.pid + "|" + StaticVar.condition + "|" + CostTextBox.Text + "|" + StaticVar.platform + "|" + StaticVar.manufacturer + "|" + StaticVar.os + "|" + StaticVar.model + "|" + StaticVar.memory + "|" + StaticVar.cbrand + "|" + StaticVar.ctype + "|" + StaticVar.lsize
                 + "|" + StaticVar.cno + "|" + StaticVar.cspeed + "|" + StaticVar.hdd + "|" + StaticVar.gputype + "|" + StaticVar.webcam);

            if (saveDig.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveDig.FileName, filedata);


            }
            MessageBox.Show("File Saved");
        }

        //OPEN FILE
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDig = new OpenFileDialog();
            openDig.Filter = "Text Files|*.txt";
            if (openDig.ShowDialog() == DialogResult.OK)
            {
                filedata = System.IO.File.ReadAllText(openDig.FileName);
                Console.WriteLine(filedata);
                string[] data = filedata.Split('|');
                foreach (string i in data)
                {
                    string getdata = i;
                    Console.WriteLine(i);
                }
                StaticVar.pid = data[0];
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
                CPUNumberTextBox.Text = StaticVar.cno;
                CPUSpeedTextBox.Text = StaticVar.cspeed;
                HDDTextBox.Text = StaticVar.hdd;
                GPUTypeTextBox.Text = StaticVar.gputype;
                WebCamTextBox.Text = StaticVar.webcam;
            }
            ////StaticVar.OpenMenu();
            //ProductIdTextBox.Text = StaticVar.pid;
            //ConditionTextBox.Text = StaticVar.condition;
            //CostTextBox.Text = StaticVar.cost;
            //PlatformTextBox.Text = StaticVar.platform;
            //ManufacturerTextBox.Text = StaticVar.manufacturer;
            //OSTextBox.Text = StaticVar.os;
            //ModelTextBox.Text = StaticVar.model;
            //MemoryTextBox.Text = StaticVar.memory;
            //CPUBrandTextBox.Text = StaticVar.cbrand;
            //CPUTypeTextBox.Text = StaticVar.ctype;
            //LCDSizeTextBox.Text = StaticVar.lsize;
            //CPUNumberTextBox.Text = StaticVar.cno;
            //CPUSpeedTextBox.Text = StaticVar.cspeed;
            //HDDTextBox.Text = StaticVar.hdd;
            //GPUTypeTextBox.Text = StaticVar.gputype;
            //WebCamTextBox.Text = StaticVar.webcam;

        }

        private void frmProductInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ProdPrevForm.Close();
        }

        private void TechSpecsGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
