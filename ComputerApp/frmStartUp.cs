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
    public partial class frmStartUp : Form
    {
        public Form previousForm;
        public Form nextForm;

        public static void closeAll()
        {
            //FormCollection fc = Application.OpenForms;
            //if (fc.Count > 1)
            //{
            //    for (int i = (fc.Count); i > 1; i--)
            //    {
            //        Form selectedForm = Application.OpenForms[i - 1];
            //        selectedForm.Close();
            //    }
            //}
        }

        public frmStartUp()
        {
            InitializeComponent();
        }

        //NEW BUTTON - IF USER CLICKS FIRST TIME NEW FORM APPEAR ELSE PAGE IN THE BACKGROUND WILL APPEAR
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (nextForm == null)
            {
                frmSelectForm sf = new frmSelectForm();
                sf.previousForm = this;
                sf.Show();
                this.nextForm = sf;
            }
            else
            {
                this.nextForm.Show();
            }
            this.Hide();
        }

        //OPEN SAVED ORDER TEXT FILE
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //StaticVar.OpenMenu();
            if (nextForm == null)
            {
                frmProductInfo fpi = new frmProductInfo();
                frmSelectForm fsl = new frmSelectForm();
                fsl.Show();
                fsl.Hide();
                fpi.ProdPrevForm = fsl;
                fsl.previousForm = this;
                fsl.nextForm = fpi;
                fpi.OpenSave();
                fpi.Show();
            }
            else
            {
                try
                {
                    frmSelectForm fslnew = this.nextForm as frmSelectForm;
                    if (fslnew.nextForm == null)
                    {
                        frmProductInfo fpinew2 = new frmProductInfo();
                        fpinew2.ProdPrevForm = fslnew;
                        fslnew.nextForm = fpinew2;
                        fpinew2.OpenSave();
                        fpinew2.Show();
                    }
                    else
                    {
                        frmProductInfo fpinew = fslnew.nextForm as frmProductInfo;
                        fpinew.OpenSave();
                        fpinew.Show();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStartUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Close();
            ////Applvaication.Exit();
            ////StaticVar.closeAll();
            //closeAll();
        }
    }
}
