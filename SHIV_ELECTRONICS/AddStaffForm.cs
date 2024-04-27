using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SHIV_ELECTRONICS
{
    public partial class AddStaffForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AddStaffForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text= DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt");
        }
       void resetData()
        {
            txtNametextBox.Clear();
            txtCitytextBox.Clear();
            cmbGendercomboBox.SelectedItem = null;
            txtNametextBox.Focus();
        }
        
      

        private void txtNametextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNametextBox.Text))
            {
                txtNametextBox.Focus();
                errorProvider1.SetError(this.txtNametextBox, "PLEASE ENTER NAME..!!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtCitytextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCitytextBox.Text))
            {
                txtCitytextBox.Focus();
                errorProvider2.SetError(this.txtCitytextBox, "PLEASE ENTER CITY..!!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void cmbGendercomboBox_Leave(object sender, EventArgs e)
        {
            if (cmbGendercomboBox.SelectedItem == null)
            {
                cmbGendercomboBox.Focus();
                errorProvider3.SetError(this.cmbGendercomboBox, "PLEASE SELECT GENDER..!!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNametextBox.Text))
            {
                txtNametextBox.Focus();
                errorProvider1.SetError(this.txtNametextBox, "PLEASE ENTER NAME..!!");
            }
            else if (string.IsNullOrEmpty(txtCitytextBox.Text))
            {
                txtCitytextBox.Focus();
                errorProvider2.SetError(this.txtCitytextBox, "PLEASE ENTER CITY..!!");
            }
            else if (cmbGendercomboBox.SelectedItem == null)
            {
                cmbGendercomboBox.Focus();
                errorProvider3.SetError(this.cmbGendercomboBox, "PLEASE SELECT GENDER..!!");
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into Staff values(@WorkerName,@WorkerCity,@WorkerGender,@WorkerTotalDay,@WorkerJoinDate)", conn);
                cmd.Parameters.AddWithValue("@WorkerName", txtNametextBox.Text);
                cmd.Parameters.AddWithValue("@WorkerCity", txtCitytextBox.Text);
                cmd.Parameters.AddWithValue("@WorkerGender", cmbGendercomboBox.SelectedItem);
                //cmd.Parameters.AddWithValue("@WorkerDay", txtDaytextBox.Text);
                cmd.Parameters.AddWithValue("@WorkerTotalDay", txtTotalDaytextBox.Text);
                cmd.Parameters.AddWithValue("@WorkerJoinDate", lblDate.Text);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                   // MessageBox.Show("WORKER ADDED...");
                    resetData();
                }
                else
                {
                    MessageBox.Show("WORKER NOT ADDED...");
                }
                conn.Close();
            }
        }
    }
}
