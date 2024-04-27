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
    public partial class ViewSellerForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int i;
        public ViewSellerForm()
        {
            InitializeComponent();
            viewData();
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

        void viewData()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("select SellerId 'ID',SellerName 'NAME',SellerAddress 'ADDRESS',SellerState 'STATE',SellerPhone 'PHONE',AadharNo 'AADHAR NO' from Seller", conn);
            DataTable data = new DataTable();
            da.Fill(data);
            kryptonDataGridView1.DataSource = data;
           // this.kryptonDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
           // this.kryptonDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kryptonDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //this.kryptonDataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //this.dataGridView1.BackgroundColor = Color.FromArgb(100,105,105);

        }

        
        void resetData()
        {
            SellertextBox.Clear();
            AddresstextBox.Clear();
            StatecomboBox.SelectedItem=null;
            PhonetextBox.Clear();
            AadhartextBox.Clear();
            SellertextBox.Focus();
        }      

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellertextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER NAME...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SellertextBox.Focus();                
            }
            else if (string.IsNullOrEmpty(AddresstextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER'S ADDRESS...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddresstextBox.Focus();
               
            }
            else if (StatecomboBox.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT STATE...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StatecomboBox.Focus();
               
            }
            else if (string.IsNullOrEmpty(PhonetextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER'S MOBILE NO...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PhonetextBox.Focus();
                
            }
            else if (string.IsNullOrEmpty(AadhartextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER'S AADHAR NO...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AadhartextBox.Focus();
               
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("update Seller set SellerName=@SellerName,SellerAddress=@SellerAddress,SellerState=@SellerState,SellerPhone=@SellerPhone,AadharNo=@AadharNo where SellerId=@SellerId", conn);
                cmd.Parameters.AddWithValue("@SellerId", i);
                cmd.Parameters.AddWithValue("@SellerName", SellertextBox.Text);
                cmd.Parameters.AddWithValue("@SellerAddress", AddresstextBox.Text);
                cmd.Parameters.AddWithValue("@SellerState", StatecomboBox.SelectedItem);
                cmd.Parameters.AddWithValue("@SellerPhone", PhonetextBox.Text);
                cmd.Parameters.AddWithValue("@AadharNo", AadhartextBox.Text);

                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("UPDATE SUCCESSFULL..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewData();
                    resetData();
                }
                else
                {
                    MessageBox.Show("UPDATE FAILED..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                conn.Close();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellertextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER NAME...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SellertextBox.Focus();
            }
            else if (string.IsNullOrEmpty(AddresstextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER'S ADDRESS...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AddresstextBox.Focus();

            }
            else if (StatecomboBox.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT STATE...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StatecomboBox.Focus();

            }
            else if (string.IsNullOrEmpty(PhonetextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER'S MOBILE NO...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PhonetextBox.Focus();

            }
            else if (string.IsNullOrEmpty(AadhartextBox.Text))
            {
                MessageBox.Show("PLEASE ENTER SELLER'S AADHAR NO...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AadhartextBox.Focus();

            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("delete from Seller where SellerId=@SellerId", conn);
                cmd.Parameters.AddWithValue("@SellerId", i);

                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                   // MessageBox.Show("DELETE SUCCESSFULL..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewData();
                    resetData();
                }
                else
                {
                    MessageBox.Show("DELETE FAILED..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
        }

        private void kryptonDataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32(kryptonDataGridView1.SelectedRows[0].Cells[0].Value);
            SellertextBox.Text = kryptonDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            AddresstextBox.Text = kryptonDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            StatecomboBox.SelectedItem = kryptonDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            PhonetextBox.Text = kryptonDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            AadhartextBox.Text = kryptonDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddSellerForm af = new AddSellerForm();
            af.ShowDialog();
        }
    }
}
