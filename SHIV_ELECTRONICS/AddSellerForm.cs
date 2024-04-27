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
    public partial class AddSellerForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int t;
       public AddSellerForm()
        {
            InitializeComponent();
           // bindData();
           
        }
        //void bindData()
        //{
        //    SqlConnection conn = new SqlConnection(cs);
        //    SqlCommand cmd = new SqlCommand("select * from StateName ", conn);
        //    //cmd.Parameters.AddWithValue("@name", CountrycomboBox.SelectedValue);
        //    conn.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        string nm = dr.GetString(0);
        //        StatecomboBox.Items.Add(nm);
        //    }
        //    conn.Close();

        //}

        
        void resetData()
        {
            SellertextBox.Clear();
            AddresstextBox.Clear();
            StatecomboBox.SelectedItem = null;
            PhonetextBox.Clear();
            AadhartextBox.Clear();
            SellertextBox.Focus();
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = t.ToString();
            t = t + 1;
            label11.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

       

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellertextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SellertextBox.Focus();
            }
            else if (string.IsNullOrEmpty(AddresstextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER'S ADDRESS..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddresstextBox.Focus();
            }
            else if (StatecomboBox.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT SEELER'S STATE ..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StatecomboBox.Focus();

            }
            else if (string.IsNullOrEmpty(PhonetextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER'S MOBILE NO..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PhonetextBox.Focus();
            }
            else if (string.IsNullOrEmpty(AadhartextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER'S AADHAR NO..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AadhartextBox.Focus();
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into Seller values(@SellerName,@SellerAddress,@SellerState,@SellerPhone,@AadharNo)", conn);
                cmd.Parameters.AddWithValue("@SellerName", SellertextBox.Text);
                cmd.Parameters.AddWithValue("@SellerAddress", AddresstextBox.Text);
                cmd.Parameters.AddWithValue("@SellerState", StatecomboBox.SelectedItem);
                cmd.Parameters.AddWithValue("@SellerPhone", PhonetextBox.Text);
                cmd.Parameters.AddWithValue("@AadharNo", AadhartextBox.Text);

                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    //MessageBox.Show("SELLER INSERTED..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetData();
                }
                else
                {
                    MessageBox.Show("SELLER NOT INSERTED..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewSellerForm vs = new ViewSellerForm();
            vs.ShowDialog();
            this.Close();
        }
    }
}
