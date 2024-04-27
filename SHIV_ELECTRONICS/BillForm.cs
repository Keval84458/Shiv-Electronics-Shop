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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PayPal.Api;

namespace SHIV_ELECTRONICS
{
    public partial class BillForm : Form
    {

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public BillForm()
        {
            InitializeComponent();
            timer1.Start();
            ViewCustomer();
            // viewSeller();
            viewItem();
            DtItemList.ColumnCount = 4;
            DtItemList.Columns[0].Name = "Product Name";
            DtItemList.Columns[1].Name = "Rate";
            DtItemList.Columns[2].Name = "Qty.";
            DtItemList.Columns[3].Name = "Amount";
            this.DtItemList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DtItemList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        void resetAllData()
        {
            cmbCD.SelectedItem = null;

            // cmbCustomerName.SelectedItem = null;
            txtCustomerName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            cmbGender.SelectedItem = null;
            cmbCountry.SelectedItem = null;
            // txtItemName.Clear();
            cmbItemName.SelectedItem = null;
            txtAddPrice.Clear();
            txtQuantity.Clear();
            txtTotalPrice.Clear();
            txtSubTotal.Clear();
            txtTax.Clear();
            txtDis.Clear();
            txtTotalAmount.Clear();
            DtItemList.Rows.Clear();
            cmbCD.Focus();
        }
        private void BillForm_Load(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(cs);
            //SqlCommand cmd = new SqlCommand("select * from Product ", conn);
            ////cmd.Parameters.AddWithValue("@name", CountrycomboBox.SelectedValue);
            //conn.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    string nm = dr.GetString(1);
            //    //double Price = dr.GetDouble(4);
            //    //txtAddPrice.Text = Price.ToString();
            //    // cmbItemCombo.Items.Add(nm);
            //    txtItemName.Text = nm;
            //}
            //conn.Close();        

        }

        void ViewCustomer()
        {

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select *from Customer", conn);
            conn.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                coll.Add(dr.GetString(1));
            }
            txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomerName.AutoCompleteCustomSource = coll;
            conn.Close();

        }

        //void viewSeller()
        //{
        //    //SqlConnection conn = new SqlConnection(cs);
        //    //SqlCommand cmd = new SqlCommand("select * from Seller", conn);
        //    //conn.Open();
        //    //AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        //    //SqlDataReader dr = cmd.ExecuteReader();
        //    //while (dr.Read())
        //    //{
        //    //    coll.Add(dr.GetString(1));
        //    //}
        //    //txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    //txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    //txtCustomerName.AutoCompleteCustomSource = coll;
        //    //conn.Close();
        //}
        //void viewItem()
        //{
        //    SqlConnection conn = new SqlConnection(cs);
        //    SqlCommand cmd = new SqlCommand("select * from Product", conn);
        //    conn.Open();
        //    AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        coll.Add(dr.GetString(1));
        //    }
        //    txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    txtItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    txtItemName.AutoCompleteCustomSource = coll;
        //    conn.Close();
        //}
        void viewItem()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select *from Product", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string nm = dr.GetString(1);
                cmbItemName.Items.Add(nm);
            }
            conn.Close();

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt");
            Yearlabel.Text = DateTime.Now.ToString("yyyy");
            Daylabel.Text = DateTime.Now.ToString("dddd");
            // TimetextBox.Text = DateTime.Now.ToString("hh:mm:ss tt");
            txtBillno.Text = DateTime.Now.ToString("mmss");
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                txtTotalPrice.ReadOnly = true;
            }
            else
            {
                float n1 = float.Parse(txtAddPrice.Text);
                float n2 = float.Parse(txtQuantity.Text);
                float n = n1 * n2;

                //float mul = n1 + n;
                txtTotalPrice.Text = n.ToString();
            }

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < DtItemList.Rows.Count; ++i)
            {
                sum = sum + Convert.ToDouble(DtItemList.Rows[i].Cells[3].Value);
            }
            txtSubTotal.Text = sum.ToString();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbItemName.SelectedItem.ToString()))
            {
                cmbItemName.Focus();
            }
            else if (string.IsNullOrEmpty(txtAddPrice.Text))
            {
                txtAddPrice.Focus();
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Focus();
            }
            else
            {
                DtItemList.Rows.Add(cmbItemName.SelectedItem, txtAddPrice.Text, txtQuantity.Text, txtTotalPrice.Text);
                cmbItemName.SelectedItem = null;
                txtAddPrice.Clear();
                txtQuantity.Clear();
                txtTotalPrice.Clear();
                cmbItemName.Focus();
                txtQuantity.Text = 1.ToString();
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (cmbCD.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT CASH OR DEBIT..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCD.Focus();
            }
            else if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
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
                SqlCommand cmd = new SqlCommand("insert into Customer values(@CustomerName,@CustomerAddress,@CustomerPhone,@CustomerGender,@CustomerCountry,@Date)", conn);
                cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@CustomerAddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@CustomerPhone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@CustomerGender", cmbGender.SelectedItem);
                cmd.Parameters.AddWithValue("@CustomerCountry", cmbCountry.Text);
                cmd.Parameters.AddWithValue("@Date", lblDate.Text);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                   // MessageBox.Show("INSERTED...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // printBill();
                    resetAllData();
                }
                else
                {
                    MessageBox.Show("NOT INSERTED...", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
        }


        private void txtTotalAmount_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubTotal.Text))
            {
                txtSubTotal.Focus();
            }
            else
            {
                float Sub = float.Parse(txtSubTotal.Text);
                float tax = float.Parse(txtTax.Text);
                float dis = float.Parse(txtDis.Text);
                float n = Sub + (Sub * tax / 100);
                float result = n - dis;
                txtTotalAmount.Text = result.ToString();
            }

        }
        void printBill()
        {
            if (cmbCD.SelectedItem == null)
            {
                MessageBox.Show("PLEASE SELECT CASH OR DEBIT..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCD.Focus();
            }
            else if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("PLEASE ENTER CUSTOMER NAME..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
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
                BillDataSet1 cbd = new BillDataSet1();
                for (int i = 0; i < DtItemList.Rows.Count; i++)
                {

                    DataRow dr = cbd.Tables["DataTable1"].NewRow();
                    //dr["ITEM"] = DtItemList.Rows[i].Cells["Item"].Value.ToString();
                    //dr["PRICE"] = DtItemList.Rows[i].Cells["Price"].Value.ToString();

                    // MessageBox.Show(DtItemList.Rows[i].Cells["Item"].Value.ToString());
                    dr["Product Name"] = DtItemList.Rows[i].Cells["Product Name"].Value;
                    dr["Rate"] = DtItemList.Rows[i].Cells["Rate"].Value;
                    dr["QTY."] = DtItemList.Rows[i].Cells["Qty."].Value;
                    dr["Amount"] = DtItemList.Rows[i].Cells["Amount"].Value;
                    cbd.Tables["DataTable1"].Rows.Add(dr);

                }

                CrystalReportForm f = new CrystalReportForm();
                CrystalReport1 cr = new CrystalReport1();
                TextObject CD = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["Text9"];
                CD.Text = cmbCD.SelectedItem.ToString();

                TextObject name = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["Text10"];
                name.Text = txtCustomerName.Text;

                TextObject address = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["Text11"];
                address.Text = txtAddress.Text;

                TextObject bill = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["Text12"];
                bill.Text = txtBillno.Text;

                TextObject date = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["Text13"];
                date.Text = lblDate.Text;

                TextObject sub = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["Text14"];
                sub.Text = txtSubTotal.Text;

                TextObject tax = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["Text15"];
                tax.Text = txtTax.Text;

                TextObject dis = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["Text16"];
                dis.Text = txtDis.Text;

                TextObject total = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["Text17"];
                total.Text = txtTotalAmount.Text;

                cr.SetDataSource(cbd);
                f.Report1.ReportSource = cr;
                DialogResult BillDr = f.ShowDialog();
                this.Close();
            }
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            printBill();
        }

        private void txtAddPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddPrice.Text))
            {
                txtAddPrice.Focus();
            }
        }

        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemName.SelectedItem != null)
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("select *from Product where ProductName=@Pname", conn);
                cmd.Parameters.AddWithValue("@Pname", cmbItemName.SelectedItem);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtAddPrice.Text = dr["ProductTotalPrice"].ToString();
                    dr.Close();
                }
                conn.Close();

            }
        }
    }
}
