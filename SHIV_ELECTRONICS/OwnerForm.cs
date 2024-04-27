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
    public partial class OwnerForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public OwnerForm()
        {
            InitializeComponent();
            viewData();
        }

      
        void resetData()
        {
            UsertextBox.Clear();
            PasstextBox.Clear();
            UsertextBox.Focus();
        }
        void viewData()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("select Username 'USERNAME',Password 'PASSWORD'from Login", conn);
            DataTable data = new DataTable();
            da.Fill(data);
            kryptonDataGridView1.DataSource = data;
            this.kryptonDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kryptonDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kryptonDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           // dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Pink;

            //dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Gold;
            //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Firebrick;

        }

       
      

      
        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            if (UsertextBox.Text == "" && PasstextBox.Text == "")
            {
                MessageBox.Show("BOTH FIELD ARE REQUIRED..!!", "Worn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UsertextBox.Focus();
            }
            else
            {
                SqlConnection conn = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("insert into Login values(@Username,@Password)", conn);
                cmd.Parameters.AddWithValue("@Username", UsertextBox.Text);
                cmd.Parameters.AddWithValue("@Password", PasstextBox.Text);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    //MessageBox.Show("Insertion Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    viewData();
                    resetData();
                }
                else
                {
                    MessageBox.Show("Insertion Failed...", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UsertextBox.Focus();
                }
                conn.Close();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("delete from Login where Username=@Username and Password=@Password", conn);
            cmd.Parameters.AddWithValue("@Username", UsertextBox.Text);
            cmd.Parameters.AddWithValue("@Password", PasstextBox.Text);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
               // MessageBox.Show("Deletion Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewData();
                resetData();
            }
            else
            {
                MessageBox.Show("Deletion Failed...", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UsertextBox.Focus();
            }
            conn.Close();
        }

        private void kryptonDataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UsertextBox.Text = kryptonDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            PasstextBox.Text = kryptonDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
    }

}
