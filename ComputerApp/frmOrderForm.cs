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
        public frmOrderForm()
        {
            InitializeComponent();
        }

       

        private void frmOrderForm_Load(object sender, EventArgs e)
        {
            txtCondition.Text = frmSelectForm.condition;
            txtManufacturer.Text = frmSelectForm.manufacturer;
            txtPlatform.Text = frmSelectForm.platform;
            txtModel.Text = frmSelectForm.model;
            txtLCDSize.Text = frmSelectForm.lsize;
            txtMemory.Text = frmSelectForm.memory;
            txtCBrand.Text = frmSelectForm.cbrand;
            txtCType.Text = frmSelectForm.ctype;
            txtCNo.Text = frmSelectForm.cno;
            txtCSpeed.Text = frmSelectForm.cspeed;
            txtHDD.Text = frmSelectForm.hdd;
            txtGType.Text = frmSelectForm.gputype;
            txtWebCam.Text = frmSelectForm.webcam;
            txtOS.Text = frmSelectForm.os;
            //txtPrice.Text = frmSelectForm.cost;
            
            double tax, price , total;
            price = double.Parse(frmSelectForm.cost);
            tax = price*0.13;
            total = price + tax;
            txtPrice.Text = price.ToString("C");
            txtTax.Text = tax.ToString("C");
            txtTotal.Text = total.ToString("C");
        }
    }
}
