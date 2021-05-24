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
    public partial class Profile_Form : Form
    {
        MainForm main;
        Employee emp;
        public Profile_Form(MainForm m)
        {
            this.main = m;
            InitializeComponent();
        }

        private void getAllDepartments()
        {
            DepartmentService departmentService = new DepartmentService();
            DataTable dataTable = departmentService.GetAllDepartmentLists();
            DataRow row = dataTable.NewRow();
            row["departmentId"] = 0;
            row["Name"] = "Select a Department";
            dataTable.Rows.InsertAt(row, 0);

            cmdDepartment.DataSource = dataTable;
            cmdDepartment.DisplayMember = "name";
            cmdDepartment.ValueMember = "departmentId";

        }

        private void getAllJobs()
        {
            JobService jobService = new JobService();
            DataTable dataTable = jobService.GetAllJobs();
            DataRow row = dataTable.NewRow();
            row["jobId"] = 0;
            row["Jobtitle"] = "Select a Job";
            dataTable.Rows.InsertAt(row, 0);

            cmdJob.DataSource = dataTable;
            cmdJob.DisplayMember = "Jobtitle";
            cmdJob.ValueMember = "jobId";
        }

        private void getAllSupervisors()
        {
            EmployeeService employeeService = new EmployeeService();
            DataTable dataTable = employeeService.GetAllSupervisors();
            DataRow row = dataTable.NewRow();
            row["EmployeeId"] = 0;
            row["FullName"] = "Select a Supervisor";
            dataTable.Rows.InsertAt(row, 0);

            cmdSupervisor.DataSource = dataTable;
            cmdSupervisor.DisplayMember = "FullName";
            cmdSupervisor.ValueMember = "EmployeeId";
        }

        private void getAllEmployeeTypes()
        {

            cmdEmployeeType.DataSource = Enum.GetValues(typeof(EmployeeType));
        }

        private void SetForm()
        {
            foreach (Control ctl in grpPersonalInfo.Controls)
            {
                if (ctl is TextBox)
                {
                    ctl.Enabled = false;

                }
                if (ctl is CheckBox)
                {
                    ((CheckBox)ctl).Enabled = false;
                }
                if (ctl is DateTimePicker)
                {
                    ((DateTimePicker)ctl).Enabled = false;
                }
                if (ctl is ComboBox)
                {
                    ((ComboBox)ctl).Enabled = true;
                }
            }
            txtCellPhone.Enabled = true;
            txtWorkPhone.Enabled = true;
            txtStreetAddress.Enabled = true;
            txtCity.Enabled = true;
            txtPostalCode.Enabled = true;

        }
        private void DisplayEmployee(Employee e)
        {
            txtEmployeeId.Text = e.EmployeeId.ToString();
            cmdSupervisor.SelectedValue = e.SupervisorId;
            cmdDepartment.SelectedValue = e.DepartmentId;
            cmdJob.SelectedValue = e.JobId;
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
            chkIsActive.Checked = e.IsActive;
            cmdEmployeeType.SelectedIndex = (int)e.Type;
        }
        private void GetProfile(int id)
        {
            try
            {
                EmployeeService employeeService = new EmployeeService();
                emp = (employeeService.GetEmployeeOne(id));
                DisplayEmployee(emp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Profile_Form_Load(object sender, EventArgs e)
        {
            getAllJobs();
            getAllDepartments();
            getAllSupervisors();
            getAllEmployeeTypes();
            GetProfile(main.loggedInEmp.EmployeeId);
            SetForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                EmployeeService employeeService = new EmployeeService();
                Employee emp = employeeService.UpdateEmployee(populateEmployee());

                if (emp.getErrors().Count!=0)
                {
                    foreach (Error error in emp.getErrors())
                    {
                        msg += error.ErrorDescription + Environment.NewLine;
                    }
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(" Personal Info Modified!!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Employee populateEmployee()
        {
            emp.StreetAddress = txtStreetAddress.Text;
            emp.City = txtCity.Text;
            emp.PostalCode = txtPostalCode.Text;
            emp.WorkPhone = txtWorkPhone.Text;
            emp.CellPhone = txtCellPhone.Text;

            return emp;
        }
    }
}
