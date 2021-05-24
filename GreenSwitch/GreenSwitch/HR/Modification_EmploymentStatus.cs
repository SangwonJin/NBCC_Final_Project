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
    public partial class Modification_EmploymentStatus : Form
    {
        Modification_Main modification_Main;
        Employee employee;
        public Modification_EmploymentStatus(Modification_Main m)
        {
            modification_Main = m;
            InitializeComponent();
        }

        private void Modification_EmploymentStatus_Load(object sender, EventArgs e)
        {

            cmdEmpStatus.DataSource = Enum.GetValues(typeof(EmployeeStatus));

            cmdDepartmentE.DataSource = modification_Main.employee_Form.getAllDepartments();
            cmdDepartmentE.DisplayMember = "name";
            cmdDepartmentE.ValueMember = "departmentId";



            cmdJobE.DataSource = modification_Main.employee_Form.getAllJobs();
            cmdJobE.DisplayMember = "Jobtitle";
            cmdJobE.ValueMember = "jobId";



            cmdSupervisorE.DataSource = modification_Main.employee_Form.getAllSupervisors();
            cmdSupervisorE.DisplayMember = "FullName";
            cmdSupervisorE.ValueMember = "EmployeeId";

            getAllEmployeeTypes();
            employee = modification_Main.employee_Form.employee;
            DisplayEmployee(employee);
            FormSetting();

            employee = modification_Main.employee_Form.employee;
            if (employee.Status == 0)
            {
                btnModify.Visible = false;
                dtpLastDay.Value = employee.LastDayOfWork.Value;
            }
            DisplayEmployee(employee);
            FormSetting();
          
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                EmployeeService employeeService = new EmployeeService();
                if (!employeeService.UpdateEmployeeStatus(populateEmployee()) || employee.getErrors().Count != 0)
                {
                    foreach (Error error in employee.getErrors())
                    {
                        msg += error.ErrorDescription + Environment.NewLine;
                    }
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dtpLastDay.Value = employee.LastDayOfWork.Value;
                    if (Convert.ToInt32(employee.Status) == 0)
                    {
                        cmdEmpStatus.Enabled = false;
                        btnModify.Visible = false;
                        dtpLastDay.Value = employee.LastDayOfWork.Value;
                    }
                    MessageBox.Show("Employee Status modified!!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Employee populateEmployee()
        {
            employee.Status = (EmployeeStatus)cmdEmpStatus.SelectedIndex;
            employee.LastDayOfWork = dtpLastDay.Value;
            return employee;
        }
        private void getAllEmployeeTypes()
        {
            cmdEmployeeType.DataSource = Enum.GetValues(typeof(EmployeeType));
        }

        private void getAllEmployeeStatus()
        {
            cmdEmpStatus.DataSource = Enum.GetValues(typeof(EmployeeStatus));
        }
        private void DisplayEmployee(Employee e)
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
            //chkIsActive.Checked = e.IsActive;
            txtUserName.Text = e.UserName;
            cmdEmployeeType.SelectedIndex = Convert.ToInt32(e.Type);

            if (e.Status!= null)
            {
                cmdEmpStatus.SelectedIndex = (int)e.Status;
            }
            else
            {
                cmdEmpStatus.SelectedIndex = 0;

            }
          
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
            //chkIsActive.Enabled = false;
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
