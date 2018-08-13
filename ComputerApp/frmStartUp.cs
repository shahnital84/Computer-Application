using System;
using System.Windows.Forms;

namespace ComputerApp
{
    public partial class frmStartUp : Form
    {
        public Form previousForm; //DECLARE pREVIOUS fORM VARIABLE OF FORM TYPE TO SET NEXT FORM FOR START_UP FORM
        public Form nextForm; ////DECLARE NEXT FORM VARIABLE OF FORM TYPE TO SET PREVIOUS FORM FOR START_UP FORM

        public frmStartUp()
        {
            InitializeComponent();
        }

        //START NEW ORDER BUTTON - IF USER CLICKS FIRST TIME NEW FORM APPEAR ELSE PAGE IN THE BACKGROUND WILL APPEAR
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (nextForm == null) //WILL CHECK IF USER CLICK FIRST TIME ON THE NEXT BUTTON
            {
                frmSelectForm sf = new frmSelectForm(); //IF YES, WILL CREATE OBJECT OF SELECT FORM TO SELECT NEW RECORD
                sf.previousForm = this; //SET PREVIOUS FORM OF SELECT FORM = START UP FORM
                sf.Show(); // SHOW SELECT FORM TO SELECT NEW RECORD
                this.nextForm = sf; //SET NEXT FORM OF START UP FORM = SELECT FORM
            }
            else
            {
                this.nextForm.Show(); //IF SELECT FORM ALREADY OPEN IN BACKGROUND - WILL LOAD SELECT FORM TO SELECT NEW RECORD
            }
            this.Hide(); //HIDE START UP FORM WHEN LOAD SELECT FORM 
        }

        //OPEN SAVED ORDER 
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (nextForm == null)  //WILL CHECK IF USER CLICK FIRST TIME ON THE NEXT BUTTON
            {
                frmProductInfo fpi = new frmProductInfo(); //IF YES, WILL CREATE OBJECT OF PRODUCT INFORMATION FORM TO DISPLAY DATA FROM SAVED FILE
                frmSelectForm fsl = new frmSelectForm(); // WILL CREATE OBJECT OF SELECT FORM, IF USER CLICK BACK BUTTON OF PRODUCT INFO FORM, AND IF SELECT FORM IS NOT LOADED, WILL OPEN FIRST TIME 
                fsl.Show(); //LOAD SELECT FORM
                fsl.Hide(); //HIND SELECT FORM
                fpi.ProdPrevForm = fsl; //SET PREVIOUS FORM OF PRODUCT INFO FORM = SELECT FORM
                fsl.previousForm = this; //SET PREVIOUS FORM OF SELECT FORM = START UP FORM
                fsl.nextForm = fpi; // SET NEXT FORM OF SELECT FORM = PRODUCT INFORMATION FORM
                fpi.OpenSave(); //FUNCTION CALL FROM PRODUCT INFORMATION FORM TO DISPLAY PRODUCT INFORMATION OF SAVED FILE
                fpi.Show(); // PRODUCT INFORMATION FORM WILL SHOW PRODUCT INFORMATION OF SAVED FILE
            }
            else //IF FORMS ARE ALREADY OPEN IN MEMORY
            {
                try
                {
                    frmSelectForm fslnew = this.nextForm as frmSelectForm; // WILL OPEN SELECT FORM AS NEXT FORM WHICH IS ALREADY IN MEMORY
                    if (fslnew.nextForm == null) //BUT IF SELECT FORM IS NOT IN MEMORY - MEANS USER DID NOT TRY TO BACK AND FORTH
                    {
                        frmProductInfo fpinew2 = new frmProductInfo(); //
                        fpinew2.ProdPrevForm = fslnew; // SET PREVIOUS FORM OF PRODUCT INFO FORM = SELECT FORM
                        fslnew.nextForm = fpinew2; // SET NEXT FORM OF SELECT FORM = PRODUCT INFORMATION FORM
                        fpinew2.OpenSave(); //FUNCTION CALL FROM PRODUCT INFORMATION FORM TO DISPLAY PRODUCT INFORMATION OF SAVED FILE
                        fpinew2.Show(); //PRODUCT INFORMATION FORM WILL SHOW PRODUCT INFORMATION OF SAVED FILE
                    }
                    else
                    {
                        frmProductInfo fpinew = fslnew.nextForm as frmProductInfo; // WILL OPEN PRODUCT INFORMATION FORM AS NEXT FORM WHICH IS ALREADY IN MEMORY
                        fpinew.OpenSave(); //FUNCTION CALL FROM PRODUCT INFORMATION FORM TO DISPLAY PRODUCT INFORMATION OF SAVED FILE
                        fpinew.Show(); //PRODUCT INFORMATION FORM WILL SHOW PRODUCT INFORMATION OF SAVED FILE
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex); //GIVES ERROR IF PROBLEM ARISE
                }
            }
            this.Hide(); // HIDE START UP FORM
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStartUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Close(); // WHEN USER CLICKS ON X-CLOSE BUTTON, ALL FORMS OPEN IN MEMORY, ALL WILL BE CLOSED           
        }
    }
}
