using System;
using System.Windows.Forms;

namespace ComputerApp
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        //WHEN PROGRESS BAR REACHES TO 100 TIMER WILL STOP AND STARTUP FORM WILL LOAD TO SELECT APPROPRIATE OPTIONS
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop(); //TIMER STOP AT PROGRESS BAR REACHES TO 100
                frmStartUp startup = new frmStartUp(); //CREATE INSTANCE OF NEW START UP FORM
                startup.previousForm = this; //SET PREVIOUS FORM OF STARTUP FORM  = SPLASH SCREEN FORM  
                startup.Show(); //LOAD STARTUP FORM TO SELECT APPROPRIATE OPTIONS
                this.Hide(); //HIDE SPLASH FORM
            }
        }
    }
}
