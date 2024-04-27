using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ComponentFactory.Krypton.Toolkit;

namespace SHIV_ELECTRONICS
{
    public partial class AddProductForm : KryptonForm
    {
        int i = 0;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AddProductForm()
        {
            InitializeComponent();
            label8.Text = DateTime.Now.ToString();
            kryptonButton1.BackColor = Color.Blue;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = i.ToString();
            i = i + 1;
            label8.Text = DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt");
        }
        void resetData()
        {
            
            NametextBox.Clear();
            WithouttextBox.Clear();
            // WithtextBox.Clear();
            WithtextBox.Text = 0.ToString();
            TotaltextBox.Clear();
            DistextBox.Clear();
            NametextBox.Focus();
            
        }
      
        private void WithtextBox_Leave(object sender, EventArgs e)
        {
        //    float n1 = float.Parse(WithouttextBox.Text);
        //    float n2 = float.Parse(WithtextBox.Text);
        //    float n = n1 * n2 / 100;
        //    TotaltextBox.Text = n.ToString();
        }
        private void TotaltextBox_Enter(object sender, EventArgs e)
        {
            float n1 = float.Parse(WithouttextBox.Text);
            float n2 = float.Parse(WithtextBox.Text);
            float n = n1 * n2 / 100;

            float mul = n1 + n;
            TotaltextBox.Text = mul.ToString();
        }
        

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(NametextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER PRODUCT NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NametextBox.Focus();
                
            }
            else if (string.IsNullOrEmpty(WithouttextBox.Text))
            {
                MessageBox.Show("PLEASE ENTE WITHOUT WET PRICE..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                WithouttextBox.Focus();
              
            }
            
            //else if(string.IsNullOrEmpty(WithtextBox.Text))
            //{
            //    WithtextBox.Focus();
            //    errorProvider3.SetError(this.WithtextBox, "Please enter Wet..!!");
            //}
            else if (string.IsNullOrEmpty(DistextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER DISCRIPTION..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DistextBox.Focus();                
            }
            else
            {
                // errorProvider1.Clear();
                // errorProvider2.Clear();
                //// errorProvider3.Clear();
                // errorProvider4.Clear();
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into Product values(@ProductName,@ProductWithoutWet,@ProductWithWet,@ProductTotalPrice,@ProduactDescription)", conn);

                cmd.Parameters.AddWithValue("@ProductName", NametextBox.Text);
                cmd.Parameters.AddWithValue("@ProductWithoutWet", WithouttextBox.Text);
                cmd.Parameters.AddWithValue("@ProductWithWet", WithtextBox.Text);
                cmd.Parameters.AddWithValue("@ProductTotalPrice", TotaltextBox.Text);
                cmd.Parameters.AddWithValue("@ProduactDescription", DistextBox.Text);

                conn.Open();
                //MessageBox.Show("OK");
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                   // MessageBox.Show("ITEM INSERTED..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetData();
                    
                }
                else
                {
                    MessageBox.Show("ITEM NOT INSERTED..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewProductForm vp = new ViewProductForm();
            vp.ShowDialog();
            this.Close();
        }

        private void WithouttextBox_Leave(object sender, EventArgs e)
        {
            if(WithouttextBox.Text=="")
            {
                WithouttextBox.Focus();
            }
        }
    }
}
