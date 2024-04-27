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
    public partial class CustomerRegFrom : Form
    {
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public CustomerRegFrom()
        {
            InitializeComponent();
            //bindData();
            ViewCustomer();
        }

        //void bindData()
        //{
        //    SqlConnection conn = new SqlConnection(cs);
        //    SqlCommand cmd = new SqlCommand("select * from A4 ", conn);
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
        void resetData()
        {
            txtName.Clear();
            //LasttextBox.Clear();
            //EmailtextBox.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            cmbGender.SelectedItem = null;
            cmbCountry.SelectedItem = null;
            txtName.Focus();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = i.ToString();
            i = i + 1;
            lblDate.Text = DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt");
            //txtBillno.Text = DateTime.Now.ToString("mmss");
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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT MALE OR FEMALE...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
            }
            else if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER'S MOBILE NO...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER'S ADDRESS..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
            }
            else if (cmbCountry.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT COUNTRY...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCountry.Focus();
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into Customer values(@CustomerName,@CustomerAddress,@CustomerPhone,@CustomerGender,@CustomerCountry,@Date)", conn);
                cmd.Parameters.AddWithValue("@CustomerName", txtName.Text);
                cmd.Parameters.AddWithValue("@CustomerAddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@CustomerPhone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@CustomerGender", cmbGender.SelectedItem);
                cmd.Parameters.AddWithValue("@CustomerCountry", cmbCountry.Text);
                cmd.Parameters.AddWithValue("@Date", lblDate.Text);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    //MessageBox.Show("inserted...");
                    resetData();
                }
                else
                {
                    MessageBox.Show("NOT INSERTED..","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                conn.Close();
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewCustomerFrom vc = new ViewCustomerFrom();
            vc.ShowDialog();
            this.Close();
        }
    }
}
