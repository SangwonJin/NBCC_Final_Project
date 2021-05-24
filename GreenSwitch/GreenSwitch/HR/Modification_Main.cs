using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenSwitch.HR
{
    public partial class Modification_Main : Form
    {
        internal Employee_Form employee_Form;
        
        public Modification_Main(Employee_Form form)
        {
            employee_Form = form;
            InitializeComponent();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            Modification_Personal modification_Personal = new Modification_Personal(this);
            modification_Personal.Show();

        }

        private void btnJob_Click(object sender, EventArgs e)
        {
            Modification_Job modification_Job = new Modification_Job(this);
            modification_Job.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEmployment_Click(object sender, EventArgs e)
        {
            Modification_EmploymentStatus modification_EmploymentStatus = new Modification_EmploymentStatus(this);
            modification_EmploymentStatus.Show();
        }
    }
}
