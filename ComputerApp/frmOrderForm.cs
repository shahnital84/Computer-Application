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
    public partial class frmOrderForm : Form
    {
        public Form pform;

        //public static void closeAll()
        //{
        //    FormCollection fc = Application.OpenForms;
        //    if (fc.Count > 1)
        //    {
        //        for (int i = (fc.Count); i > 1; i--)
        //        {
        //            Form selectedForm = Application.OpenForms[i - 1];
        //            selectedForm.Close();
        //        }
        //    }
        //}

        public frmOrderForm()
        {
            InitializeComponent();
        }

       //PAGE LOAD - DATA DISPLAYS IN TEXT BOX OF CURRENT SELECTED RECORDD FROM GRID
        private void frmOrderForm_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        public void refreshData()
        {
            txtCondition.Text = StaticVar.condition;
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
            txtPrice.Text = price.ToString("C");
            txtTax.Text = tax.ToString("C");
            txtTotal.Text = total.ToString("C");
        }

        //BACK BUTTON - PRODUCT INFO PAGE DISPLAYS
        private void btnBack_Click(object sender, EventArgs e)
        {
            //if (newForm == null)
            //{
            //    frmProductInfo fpi = new frmProductInfo();

            //    fpi.preForm = this;
            //    fpi.Show();
            //    this.newForm = fpi;
            //}
            //else
            //{
            //    this.newForm.Show();
            //}
            //this.Hide();

            //Form fc = Application.OpenForms["frmProductInfo"];
            //if (fc != null)
            //    fc.Close();

            //fc.Show();
            this.pform.Show();
            this.Hide();
        }

        //CANCEL - APPLICATION TEMINATES
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //StaticVar.closeAll();
            //closeAll();
            this.Close();
        }

        //display messahe - record successfully
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Thanks for your order.Your order will be processed in 7-10 business days.", "Order Information", MessageBoxButtons.OK))
            {
                this.Close();
            }
            //Application.Exit();
        }

        private void frmOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.pform.Close();
        }
    }
}
