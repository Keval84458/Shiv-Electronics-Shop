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

namespace SHIV_ELECTRONICS
{
    public partial class LoginForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)
            {
                case true:
                    PasstextBox.UseSystemPasswordChar = false;
                    break;
                default:
                    PasstextBox.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(UsertextBox.Text))
            {
                UsertextBox.Focus();
                errorProvider1.SetError(this.UsertextBox, "PLEASE ENTER USERNAME");
                // MessageBox.Show("PLEASE ENTER USERNAME..!!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(PasstextBox.Text))
            {
                PasstextBox.Focus();
                errorProvider2.SetError(this.PasstextBox, "PLEASE ENTER PASSWORD");
                // MessageBox.Show("PLEASE ENTER PASSWORD..!!","",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("select *from Login where Username=@Username and Password=@Password", conn);
                cmd.Parameters.AddWithValue("@Username", UsertextBox.Text);
                cmd.Parameters.AddWithValue("@Password", PasstextBox.Text);
                conn.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    // MessageBox.Show("Log In Successful..", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    MDIForm F4 = new MDIForm();
                    this.Close();
                    F4.ShowDialog();

                }

                else
                {
                    //MessageBox.Show("Log In Failed..", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    PasstextBox.Focus();

                }
                conn.Close();
            }
        }

        

        private void UsertextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsertextBox.Text))
            {
                UsertextBox.Focus();
                errorProvider1.SetError(this.UsertextBox, "PLEASE ENTER USERNAME");
               // MessageBox.Show("PLEASE ENTER USERNAME..!!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void PasstextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PasstextBox.Text))
            {
                PasstextBox.Focus();
                errorProvider2.SetError(this.PasstextBox, "PLEASE ENTER PASSWORD");
               // MessageBox.Show("PLEASE ENTER PASSWORD..!!","",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
            else
            {
                errorProvider2.Clear();
            }
        }      

        
    }
}
