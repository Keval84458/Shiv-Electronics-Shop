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
    public partial class ViewCustomerFrom : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int i;
        public ViewCustomerFrom()
        {
            InitializeComponent();
            //bindData();
            viewData();
            ViewCustomer();
        }
        void ViewCustomer()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select * from Customer", conn);
            conn.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                coll.Add(dr.GetString(1));
            }
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtName.AutoCompleteCustomSource = coll;
            conn.Close();
        }
        void searchData()
        {
            SqlConnection conn = new SqlConnection(cs);
            string query = "select CustomerId 'Id',CustomerName 'Name',CustomerAddress 'Address',CustomerPhone 'Mobile',CustomerGender 'Gender',CustomerCountry 'Country',Date 'Date' from Customer where CustomerName like @CustomerName +'%'";
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.SelectCommand.Parameters.AddWithValue("@CustomerName", txtSearch.Text.Trim());
            DataTable data = new DataTable();
            ad.Fill(data);
            kryptonDataGridView1.DataSource = data;
            this.kryptonDataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        void resetData()
        {
            
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cmbGender.SelectedItem = null;
            cmbCountry.SelectedItem = null;
            txtName.Focus();
           
        }
        void viewData()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter ad = new SqlDataAdapter("select CustomerId 'Id',CustomerName 'Name',CustomerAddress 'Address',CustomerPhone 'Mobile',CustomerGender 'Gender',CustomerCountry 'Country',Date 'Date' from Customer", conn);
            DataTable data = new DataTable();
            ad.Fill(data);
            kryptonDataGridView1.DataSource = data;
            //this.kryptonDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kryptonDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        //void bindData()
        //{
        //    SqlConnection conn = new SqlConnection(cs);
        //    SqlCommand cmd = new SqlCommand("select * from Customer ", conn);
        //    //cmd.Parameters.AddWithValue("@name", CountrycomboBox.SelectedValue);
        //    conn.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        string nm = dr.GetString(1);
        //        CountrycomboBox.Items.Add(nm);
        //    }
        //    conn.Close();

        //}    




        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER'S ADDRESS..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER'S MOBILE NO...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
            }
            else if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT MALE OR FEMALE...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
            }
            else if (cmbCountry.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT COUNTRY...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCountry.Focus();
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("update Customer set CustomerName=@CustomerName,CustomerAddress=@CustomerAddress,CustomerPhone=@CustomerPhone,CustomerGender=@CustomerGender,CustomerCountry=@CustomerCountry where CustomerId=@CustomerId", conn);
                cmd.Parameters.AddWithValue("@CustomerId", i);
                cmd.Parameters.AddWithValue("@CustomerName", txtName.Text);
                cmd.Parameters.AddWithValue("@CustomerAddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@CustomerPhone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@CustomerGender", cmbGender.SelectedItem);
                cmd.Parameters.AddWithValue("@CustomerCountry", cmbCountry.SelectedItem);

                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("CUSTOMER UPDATED..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewData();
                    resetData();
                }
                else
                {
                    MessageBox.Show("CUSTOMER NOT UPDATED..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER'S ADDRESS..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER'S MOBILE NO...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
            }
            else if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT MALE OR FEMALE...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
            }
            else if (cmbCountry.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT COUNTRY...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCountry.Focus();
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("delete from Customer where CustomerId=@CustomerId", conn);
                cmd.Parameters.AddWithValue("@CustomerId", i);


                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                   // MessageBox.Show("CUSTOMER DELETED..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewData();
                    resetData();
                }
                else
                {
                    MessageBox.Show("CUSTOMER NOT DELETED..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            searchData();
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void kryptonDataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32(kryptonDataGridView1.SelectedRows[0].Cells[0].Value);           
            txtName.Text = kryptonDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text = kryptonDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtPhone.Text = kryptonDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cmbGender.SelectedItem = kryptonDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            cmbCountry.SelectedItem = kryptonDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerRegFrom cr = new CustomerRegFrom();
            cr.ShowDialog();

        }
    }
}
