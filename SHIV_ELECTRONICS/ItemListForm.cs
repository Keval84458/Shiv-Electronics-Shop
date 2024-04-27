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
    
    public partial class ItemListForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ItemListForm()
        {
            InitializeComponent();
            viewData();
           
        }
        
        void viewData()
        {
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter ad=new SqlDataAdapter("select Iid 'ID', Iname 'NAME', Price 'PRICE', Other 'OTHER', Spe 'DISCRIPTION', Date 'DATE' from A2", conn);
            DataTable data = new DataTable();
            ad.Fill(data);
            dataGridView1.DataSource = data;
            //this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;           
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }
    }
}
