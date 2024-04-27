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
    public partial class ViewProductForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int i;
        public ViewProductForm()
        {
            InitializeComponent();
            showData();
            viewItem();


        }
        void viewItem()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select * from Product", conn);
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
            string query = "select *from Product where ProductName like @ProductName +'%'";
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.SelectCommand.Parameters.AddWithValue("@ProductName", textBox1.Text.Trim());
            DataTable data = new DataTable();
            ad.Fill(data);
            kryptonDataGridView1.DataSource = data;
            this.kryptonDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        void showData()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("select ProductId 'ID',ProductName 'NAME',ProductWithoutWet 'WITHOUT WET',ProductWithWet 'WITH WET',ProductTotalPrice 'TOTAL PRICE',ProduactDescription 'DESCRIPTION' from Product ", conn);
            DataTable data = new DataTable();
            da.Fill(data);
            kryptonDataGridView1.DataSource = data;

            //this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kryptonDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        void resetData()
        {

            txtName.Clear();
            txtWithoutWet.Clear();
            txtWithWet.Clear();
            TotalPriceBox2.Clear();
            txtDescription.Clear();
            txtName.Focus();
        }   
                          


        private void TotalPriceBox2_Enter(object sender, EventArgs e)
        {
            try
            {
                float n1 = float.Parse(txtWithoutWet.Text);
                float n2 = float.Parse(txtWithWet.Text);
                float n = n1 * n2 / 100;

                float mul = n1 + n;
                TotalPriceBox2.Text = mul.ToString();
            }
            catch
            {
                //MessageBox.Show("Failed..");
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("PLEASE ENTER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtWithoutWet.Text))
            {
                MessageBox.Show("PLEASE ENTER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWithoutWet.Focus();
            }
            //else if(string.IsNullOrEmpty(WithtextBox.Text))
            //{
            //    WithtextBox.Focus();
            //    errorProvider3.SetError(this.WithtextBox, "Please enter Wet..!!");
            //}
            else if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("PLEASE ENTER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("update Product set ProductName=@ProductName,ProductWithoutWet=@ProductWithoutWet,ProductWithWet=@ProductWithWet,ProductTotalPrice=@ProductTotalPrice,ProduactDescription=@ProduactDescription where ProductId=@ProductId", conn);
                cmd.Parameters.AddWithValue("@ProductId", i);
                cmd.Parameters.AddWithValue("@ProductName", txtName.Text);
                cmd.Parameters.AddWithValue("@ProductWithoutWet", txtWithoutWet.Text);
                cmd.Parameters.AddWithValue("@ProductWithWet", txtWithWet.Text);
                cmd.Parameters.AddWithValue("@ProductTotalPrice", TotalPriceBox2.Text);
                cmd.Parameters.AddWithValue("@ProduactDescription", txtDescription.Text);

                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    //MessageBox.Show("ITEM UPDATED..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                    resetData();
                }
                else
                {
                    MessageBox.Show("ITEM NOT UPDATED..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("PLEASE ENTER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtWithoutWet.Text))
            {
                MessageBox.Show("PLEASE ENTER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWithoutWet.Focus();
            }
            //else if(string.IsNullOrEmpty(WithtextBox.Text))
            //{
            //    WithtextBox.Focus();
            //    errorProvider3.SetError(this.WithtextBox, "Please enter Wet..!!");
            //}
            else if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("PLEASE ENTER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("delete from Product where ProductId=@ProductId", conn);
                cmd.Parameters.AddWithValue("@ProductId", i);

                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    //MessageBox.Show("ITEM DELETED..", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                    resetData();

                }
                else
                {
                    MessageBox.Show("ITEM NOT DELETED..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            searchData();
            textBox1.Clear();
            textBox1.Focus();
        }

        private void kryptonDataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtName.Focus();
                i = Convert.ToInt32(kryptonDataGridView1.SelectedRows[0].Cells[0].Value);
                txtName.Text = kryptonDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtWithoutWet.Text = kryptonDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtWithWet.Text = kryptonDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                TotalPriceBox2.Text = kryptonDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtDescription.Text = kryptonDataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            }
            catch
            {
                MessageBox.Show("Failed");
            }
            //finally
            //{
            //    MessageBox.Show("Failed");
            //}
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddProductForm ap = new AddProductForm();
            ap.ShowDialog();
        }
    }
}
