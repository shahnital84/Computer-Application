using System;
using System.Windows.Forms;

namespace ComputerApp
{
    public partial class frmOrderForm : Form
    {
        public Form pform;
        public frmOrderForm()
        {
            InitializeComponent();
        }

        //PAGE LOAD - DATA DISPLAYS IN TEXT BOX OF CURRENT SELECTED RECORDD FROM GRID
        private void frmOrderForm_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        //REFRESH PAGE LOAD
        public void refreshData()
        {
            txtCondition.Text = StaticVar.condition; //ASSIGN CURRENT SELECTED VALUES TO TEXT BOX TO DISPLAY
            txtManufacturer.Text = StaticVar.manufacturer;
            txtPlatform.Text = StaticVar.platform;
            txtModel.Text = StaticVar.model;
            txtLCDSize.Text = StaticVar.lsize;
            txtMemory.Text = StaticVar.memory;
            txtCBrand.Text = StaticVar.cbrand;
            txtCType.Text = StaticVar.ctype;
            txtCNo.Text = StaticVar.cno;
            txtCSpeed.Text = StaticVar.cspeed;
            txtHDD.Text = StaticVar.hdd;
            txtGType.Text = StaticVar.gputype;
            txtWebCam.Text = StaticVar.webcam;
            txtOS.Text = StaticVar.os;

            double tax, price, total;
            price = double.Parse(StaticVar.cost.Substring(1));
            tax = price * 0.13;
            total = price + tax;
            txtPrice.Text = price.ToString("C"); //CURRENCY FORMAYT
            txtTax.Text = tax.ToString("C");
            txtTotal.Text = total.ToString("C");
        }

        //BACK BUTTON - PRODUCT INFO PAGE DISPLAYS
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.pform.Show(); //PREVIOUS FORM - PRODUCT INFO WILL LOAD
            this.Hide(); //ORDER FORM HIDE
        }

        //CANCEL - APPLICATION TEMINATES
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //display messahe - record successfully
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Thanks for your order.Your order will be processed in 7-10 business days.", "Order Information", MessageBoxButtons.OK))
            {
                this.Close(); //CLOSE APPLICATION
            }
        }

        private void frmOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.pform.Close(); //ON FORM CLOASE AL LPREVIOUS FORM WILL CLOSE 
        }
    }
}
