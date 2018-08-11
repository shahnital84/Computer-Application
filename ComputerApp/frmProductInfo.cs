using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerApp
{
    public partial class frmProductInfo : Form
    {
        public frmProductInfo()
        {
            InitializeComponent();
        }

        private void frmProductInfo_Load(object sender, EventArgs e)
        {
            ProductIdTextBox.Text = frmSelectForm.pid;
            ConditionTextBox.Text = frmSelectForm.condition;
            CostTextBox.Text = frmSelectForm.cost;
            PlatformTextBox.Text = frmSelectForm.platform;
            ManufacturerTextBox.Text = frmSelectForm.manufacturer;
            OSTextBox.Text = frmSelectForm.os;
            ModelTextBox.Text = frmSelectForm.model;
            MemoryTextBox.Text = frmSelectForm.memory;
            CPUBrandTextBox.Text = frmSelectForm.cbrand;
            CPUTypeTextBox.Text = frmSelectForm.ctype;
            LCDSizeTextBox.Text = frmSelectForm.lsize;
            CPUNumberTextBox.Text = frmSelectForm.cspeed;
            CPUSpeedTextBox.Text = frmSelectForm.cno;
            HDDTextBox.Text = frmSelectForm.hdd;
            GPUTypeTextBox.Text = frmSelectForm.gputype;
            WebCamTextBox.Text = frmSelectForm.webcam;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ModelTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            frmOrderForm fo = new frmOrderForm();
            fo.ShowDialog();
        }
    }
}
