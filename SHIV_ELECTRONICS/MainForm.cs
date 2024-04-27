using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHIV_ELECTRONICS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
        }        
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("hh:mm");
           
            label5.Text = DateTime.Now.ToString("dd MMM yyyy");
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value < 100)
            {
                progressBar1.Value += 1;

            }
            else
            {
                timer2.Stop();
                LoginForm registrationForm = new LoginForm();
                registrationForm.ShowDialog();
                this.Close();
            }
        }
    }
}
