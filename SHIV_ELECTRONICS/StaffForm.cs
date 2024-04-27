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
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
        }

        private void aDDWORKERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStaffForm addworkerForm = new AddStaffForm();
            addworkerForm.ShowDialog();
        }

        private void aTTENDANCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AttendanceForm attendanceForm = new AttendanceForm();
            attendanceForm.ShowDialog();
        }

        private void vIEWWORKERToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
