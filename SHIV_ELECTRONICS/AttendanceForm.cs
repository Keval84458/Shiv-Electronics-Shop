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
    public partial class AttendanceForm : Form
    {

        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AttendanceForm()
        {
            InitializeComponent();
            timer1.Start();
            viewData();
        }
        void viewData()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter ad = new SqlDataAdapter("select  WorkerId 'ID',WorkerName 'NAME',WorkerCity 'CITY',WorkerGender 'GENDER',WorkerTotalDay 'TOTAL DAY',WorkerJoinDate 'JOINING DATE' from Staff", conn);
            DataTable data = new DataTable();
            ad.Fill(data);
            kryptonDataGridView1.DataSource = data;
            this.kryptonDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd MMM yyyy hh:mm:ss tt");
        }
        void resetData()
        {
            txtNametextBox.Clear();
            txtCitytextBox.Clear();
            cmbGendercomboBox.SelectedItem = null;
            txtNametextBox.Focus();
        }

      

        private void txtTotalDaytextBox_Enter(object sender, EventArgs e)
        {
            int n1 =Convert.ToInt32( txtTotalDaytextBox.Text);
            int n2 = Convert.ToInt32(txtDaytextBox.Text);
            int n3 = n1 + n2;
            txtTotalDaytextBox.Text = n3.ToString(); 
        }

    

        private void txtNametextBox_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtNametextBox.Text))
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
            if (cmbGendercomboBox.SelectedItem==null)
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
                SqlCommand cmd = new SqlCommand("update Staff set WorkerName=@WorkerName,WorkerCity=@WorkerCity,WorkerGender=@WorkerGender,WorkerTotalDay=@WorkerTotalDay where WorkerId=@WorkerId", conn);
                cmd.Parameters.AddWithValue("@WorkerId", i);
                cmd.Parameters.AddWithValue("@WorkerName", txtNametextBox.Text);
                cmd.Parameters.AddWithValue("@WorkerCity", txtCitytextBox.Text);
                cmd.Parameters.AddWithValue("@WorkerGender", cmbGendercomboBox.SelectedItem);
                //  cmd.Parameters.AddWithValue("@WorkerDay", txtDaytextBox.Text);
                cmd.Parameters.AddWithValue("@WorkerTotalDay", txtTotalDaytextBox.Text);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("PRESENT...");
                    viewData();
                    resetData();
                    int n = 0;
                    txtDaytextBox.Text = n.ToString();
                    txtTotalDaytextBox.Text = n.ToString();
                }
              

                conn.Close();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("delete from Staff where WorkerId=@WorkerId", conn);
                cmd.Parameters.AddWithValue("@WorkerId", i);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                   // MessageBox.Show("DELETED...");
                    viewData();
                    resetData();
                }
                conn.Close();
            }
        }

        private void kryptonDataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32(kryptonDataGridView1.SelectedRows[0].Cells[0].Value);
            txtNametextBox.Text = kryptonDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtCitytextBox.Text = kryptonDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cmbGendercomboBox.SelectedItem = kryptonDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            // txtDaytextBox.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtTotalDaytextBox.Text = kryptonDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtDaytextBox.Clear();
            txtDaytextBox.Focus();
        }
    }
}
