using BLL;
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
using Type;

namespace GreenSwitch.HR
{
    public partial class Modification_Job : Form
    {
        Modification_Main modification_Main;
        Employee employee;
        public Modification_Job(Modification_Main m)
        {
            modification_Main = m;
            InitializeComponent();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                EmployeeService employeeService = new EmployeeService();
                if (!employeeService.UpdateJobByHr(populateEmployee()) || employee.getErrors().Count != 0)
                {
                    //cmdDepartment.SelectedIndex,cmdSupervisor.SelectedIndex
                    foreach (Error error in employee.getErrors())
                    {
                        msg += error.ErrorDescription + Environment.NewLine;
                    }
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Job modified!!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Modification_Job_Load(object sender, EventArgs e)
        {
            cmdDepartment.DataSource = modification_Main.employee_Form.getAllDepartments();
            cmdDepartment.DisplayMember = "name";
            cmdDepartment.ValueMember = "departmentId";

            cmdDepartmentE.DataSource = modification_Main.employee_Form.getAllDepartments();
            cmdDepartmentE.DisplayMember = "name";
            cmdDepartmentE.ValueMember = "departmentId";

            cmdJob.DataSource = modification_Main.employee_Form.getAllJobs();
            cmdJob.DisplayMember = "Jobtitle";
            cmdJob.ValueMember = "jobId";

            cmdJobE.DataSource = modification_Main.employee_Form.getAllJobs();
            cmdJobE.DisplayMember = "Jobtitle";
            cmdJobE.ValueMember = "jobId";


            cmdSupervisor.DataSource = modification_Main.employee_Form.getAllSupervisors();
            cmdSupervisor.DisplayMember = "FullName";
            cmdSupervisor.ValueMember = "EmployeeId";

            cmdSupervisorE.DataSource = modification_Main.employee_Form.getAllSupervisors();
            cmdSupervisorE.DisplayMember = "FullName";
            cmdSupervisorE.ValueMember = "EmployeeId";

            getAllEmployeeTypes();
            employee = modification_Main.employee_Form.employee;
            DisplayEmployee(employee);
            FormSetting();
        }

        private void getAllEmployeeTypes()
        {
            cmdEmployeeType.DataSource = Enum.GetValues(typeof(EmployeeType));
        }
        private Employee populateEmployee()
        {
            int? supervisorid = Convert.ToInt32(cmdSupervisor.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cmdSupervisor.SelectedValue);
            int? jobId = Convert.ToInt32(cmdJob.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cmdJob.SelectedValue);
            employee.SupervisorId = supervisorid;
            employee.DepartmentId = Convert.ToInt32(cmdDepartment.SelectedValue);
            employee.JobId = jobId;
            employee.JobStartDate = dtpJobstart.Value;
            return employee;
        }
        internal void DisplayEmployee(Employee e)
        {
            txtEmployeeId.Text = e.EmployeeId.ToString();

            if (e.SupervisorId != null)
            {
                cmdSupervisorE.SelectedValue = e.SupervisorId;
            }
            else
            {
                cmdSupervisorE.SelectedIndex = 0;
            }
            if (e.JobId != null)
            {
                cmdJobE.SelectedValue = e.JobId;
            }
            else
            {
                cmdJobE.SelectedIndex = 0;
            }

            cmdDepartmentE.SelectedValue = e.DepartmentId;
            dtpJobE.Value = e.JobStartDate;
            txtLastName.Text = e.LastName;
            txtFirstName.Text = e.FirstName;
            txtMI.Text = e.MiddleInitial;
            dtpDob.Value = e.DOB;
            txtStreetAddress.Text = e.StreetAddress;
            txtCity.Text = e.City;
            txtPostalCode.Text = e.PostalCode;
            txtSIN.Text = e.SIN;
            dtpStartDate.Value = e.SeniorityDate;
         
            txtWorkPhone.Text = e.WorkPhone;
            txtCellPhone.Text = e.CellPhone;
            txtEmail.Text = e.EmailAddress;
            chkIsActive.Checked = e.IsActive;
            txtUserName.Text = e.UserName;
            cmdEmployeeType.SelectedIndex = Convert.ToInt32(e.Type);
        }
        private void FormSetting()
        {

            txtLastName.Enabled = false;
            txtFirstName.Enabled = false;
            txtMI.Enabled = false;
            dtpDob.Enabled = false;
            txtStreetAddress.Enabled = false;
            txtCity.Enabled = false;
            txtPostalCode.Enabled = false;
            txtSIN.Enabled = false;
            dtpStartDate.Enabled = false;
            dtpJobE.Enabled = false;
            txtWorkPhone.Enabled = false;
            txtCellPhone.Enabled = false;
            txtEmail.Enabled = false;
            chkIsActive.Enabled = false;
            txtUserName.Enabled = false;
            cmdEmployeeType.Enabled = false;
            cmdDepartmentE.Enabled = false;
            cmdSupervisorE.Enabled = false;
            cmdJobE.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
