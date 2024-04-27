using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHIV_ELECTRONICS
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
            timer1.Start();
        }








        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void addSellersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToString("hh:mm");
            label11.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewProductForm viewProductForm = new ViewProductForm();
            viewProductForm.ShowDialog();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddSellerForm addSellerForm = new AddSellerForm();
            addSellerForm.ShowDialog();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewSellerForm viewSellerForm = new ViewSellerForm();
            viewSellerForm.ShowDialog();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerRegFrom customerRegFrom = new CustomerRegFrom();
            customerRegFrom.ShowDialog();
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ViewCustomerFrom viewCustomerFrom = new ViewCustomerFrom();
            viewCustomerFrom.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUsForm aboutUsForm = new AboutUsForm();
            aboutUsForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            BillForm billForm = new BillForm();
            billForm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CustomerRegFrom customerRegFrom = new CustomerRegFrom();
            customerRegFrom.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CheckPass checkPass = new CheckPass();
            checkPass.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            StaffForm staffForm = new StaffForm();
            staffForm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }
    }
}
