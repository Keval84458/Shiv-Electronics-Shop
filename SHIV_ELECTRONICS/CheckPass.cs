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
using System.Data;
using System.Configuration;

namespace SHIV_ELECTRONICS
{
    public partial class CheckPass : Form
    {
        public CheckPass()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)
            {
                case true:
                    textBox1.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox1.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Enter Old Password...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("select *from Login where (password=@password)", conn);
                cmd.Parameters.AddWithValue("@password", textBox1.Text.Trim());
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("Password")))
                    {
                        // MessageBox.Show("Password is Match..","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        OwnerForm ownerForm = new OwnerForm();
                        ownerForm.ShowDialog();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Password incorrect..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                    textBox1.Focus();
                }
                conn.Close();
            }
        }
    }
}
