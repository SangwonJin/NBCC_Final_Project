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
    public partial class Modification_Personal : Form
    {
        Modification_Main modification_Main;
        Employee employee;
        public Modification_Personal(Modification_Main form)
        {
            modification_Main = form;
            InitializeComponent();
        }


        private void Modification_Personal_Load(object sender, EventArgs e)
        {
       
            cmdEmployeeType.DataSource = Enum.GetValues(typeof(EmployeeType));
            
            cmdDepartment.DataSource = modification_Main.employee_Form.getAllDepartments();
            cmdDepartment.DisplayMember = "name";
            cmdDepartment.ValueMember = "departmentId";

            cmdJob.DataSource = modification_Main.employee_Form.getAllJobs();
            cmdJob.DisplayMember = "Jobtitle";
            cmdJob.ValueMember = "jobId";


            cmdSupervisor.DataSource = modification_Main.employee_Form.getAllSupervisors();
            cmdSupervisor.DisplayMember = "FullName";
            cmdSupervisor.ValueMember = "EmployeeId";

            employee = modification_Main.employee_Form.employee;
            DisplayEmployee(employee);
            FormSetting();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                EmployeeService employeeService = new EmployeeService();
                if (!employeeService.UpdateEmployeeByHr(populateEmployee()) || employee.getErrors().Count != 0)
                {
                    foreach (Error error in employee.getErrors())
                    {
                        msg += error.ErrorDescription + Environment.NewLine;
                    }
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Information modified!!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Employee populateEmployee()
        {
            int? supervisorid = Convert.ToInt32(cmdSupervisor.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cmdSupervisor.SelectedValue);
            int? jobId = Convert.ToInt32(cmdJob.SelectedValue) == 0 ? (int?)null : Convert.ToInt32(cmdJob.SelectedValue);
            employee.SupervisorId = supervisorid;
            employee.DepartmentId = Convert.ToInt32(cmdDepartment.SelectedValue);
            employee.JobId = jobId;
            employee.LastName = txtLastName.Text;
            employee.FirstName = txtFirstName.Text;
            employee.MiddleInitial = txtMI.Text;
            employee.DOB = dtpDob.Value;
            employee.StreetAddress = txtStreetAddress.Text;
            employee.City = txtCity.Text;
            employee.PostalCode = txtPostalCode.Text;
            employee.SIN = txtSIN.Text;
            employee.SeniorityDate = dtpStartDate.Value;
            employee.JobStartDate = dtpJobstart.Value;
            employee.WorkPhone = txtWorkPhone.Text;
            employee.CellPhone = txtCellPhone.Text;
            employee.EmailAddress = txtEmail.Text;
          
            employee.UserName = txtUserName.Text;
            employee.Type = (EmployeeType)cmdEmployeeType.SelectedIndex;
            return employee;
        }

        private void DisplayEmployee(Employee e)
        {
            txtEmployeeId.Text = e.EmployeeId.ToString();
            if (e.SupervisorId != null)
            {
                cmdSupervisor.SelectedValue = e.SupervisorId;

            }
            else
            {
                cmdSupervisor.SelectedIndex = 0;
            }

            if (e.JobId != null)
            {
                cmdJob.SelectedValue = e.JobId;

            }
            else
            {
                cmdJob.SelectedIndex = 0;
            }

            cmdDepartment.SelectedValue = e.DepartmentId;
  
            txtLastName.Text = e.LastName;
            txtFirstName.Text = e.FirstName;
            txtMI.Text = e.MiddleInitial;
            dtpDob.Value = e.DOB;
            txtStreetAddress.Text = e.StreetAddress;
            txtCity.Text = e.City;
            txtPostalCode.Text = e.PostalCode;
            txtSIN.Text = e.SIN;
            dtpStartDate.Value = e.SeniorityDate;
            dtpJobstart.Value = e.JobStartDate;
            txtWorkPhone.Text = e.WorkPhone;
            txtCellPhone.Text = e.CellPhone;
            txtEmail.Text = e.EmailAddress;
            txtUserName.Text = e.UserName;
            cmdEmployeeType.SelectedIndex = Convert.ToInt32(e.Type);
        }

        private void FormSetting()
        {
            cmdDepartment.Enabled = false;
            cmdJob.Enabled = false;
            cmdSupervisor.Enabled = false;
            cmdEmployeeType.Enabled = false;
            txtSIN.Enabled = false;
            dtpJobstart.Enabled = false;
            dtpStartDate.Enabled = false;
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
