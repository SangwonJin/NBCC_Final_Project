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
    public partial class Employee_Form : Form
    {
        MainForm main;
        internal Employee employee;
        public Employee_Form(MainForm m)
        {
            main = m;
            InitializeComponent();

            if (main.loggedInEmp.EmployeeType.ToString().ToLower() == "hrsupervisor" || main.loggedInEmp.EmployeeType.ToString().ToLower() == "hremployee")
            {
                btnModify.Visible = true;
            }
            else
            {
                btnModify.Visible = false;
            }
       
            txtPassword.UseSystemPasswordChar = true;
        }

        
    

        internal DataTable getAllDepartments()
        {
            DepartmentService departmentService = new DepartmentService();
            DataTable dataTable = departmentService.GetAllDepartmentLists();
            DataRow row = dataTable.NewRow();
            row["departmentId"] = 0;
            row["Name"] = "Select a Department";
            dataTable.Rows.InsertAt(row, 0);
            return dataTable;
        }

        internal DataTable getAllJobs()
        {
            JobService jobService = new JobService();
            DataTable dataTable = jobService.GetAllJobs();
            DataRow row = dataTable.NewRow();
            row["jobId"] = 0;
            row["Jobtitle"] = "Select a Job";
            dataTable.Rows.InsertAt(row, 0);
            return dataTable;
        }

        internal DataTable getAllSupervisors()
        {
            EmployeeService employeeService = new EmployeeService();
            DataTable dataTable = employeeService.GetAllSupervisors();
            DataRow row = dataTable.NewRow();
            row["EmployeeId"] = 0;
            row["FullName"] = "Select a Supervisor";
            dataTable.Rows.InsertAt(row, 0);
            return dataTable;
        }

        private void getAllEmployeeTypes()
        {
            cmdEmployeeType.DataSource = Enum.GetValues(typeof(EmployeeType));
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                EmployeeService employeeService = new EmployeeService();
                string username = txtUserName.Text;
                int employeeType = cmdEmployeeType.SelectedIndex;
                Employee emp = employeeService.AddEmployee(populateEmployee(),txtPassword.Text);

                if (emp.getErrors().Count != 0)
                {
                    foreach (Error error in emp.getErrors())
                    {
                        msg += error.ErrorDescription + Environment.NewLine;
                    }
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmdDepartment.DataSource = getAllDepartments();
                    cmdDepartment.DisplayMember = "name";
                    cmdDepartment.ValueMember = "departmentId";

                    cmdSupervisor.DataSource = getAllSupervisors();
                    cmdSupervisor.DisplayMember = "FullName";
                    cmdSupervisor.ValueMember = "EmployeeId";

                    MessageBox.Show("New Employee added!! \n EmployeeId: " +emp.EmployeeId, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Employee e = new Employee()
            {
     
                SupervisorId = supervisorid,
                DepartmentId = Convert.ToInt32(cmdDepartment.SelectedValue),
                JobId = jobId,
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                MiddleInitial = txtMI.Text,
                DOB = dtpDob.Value,
                StreetAddress = txtStreetAddress.Text,
                City = txtCity.Text,
                PostalCode = txtPostalCode.Text,
                SIN = txtSIN.Text,
                SeniorityDate = dtpStartDate.Value,
                JobStartDate = dtpJobstart.Value,
                WorkPhone = txtWorkPhone.Text,
                CellPhone = txtCellPhone.Text,
                EmailAddress = txtEmail.Text,
                IsActive = chkIsActive.Checked,
                UserName = txtUserName.Text,
                Type = (EmployeeType)cmdEmployeeType.SelectedIndex
            };
            return e;
        }


        private void Employee_Form_Load(object sender, EventArgs e)
        {
            cmdJob.DataSource = getAllJobs();
            cmdJob.DisplayMember = "Jobtitle";
            cmdJob.ValueMember = "jobId";

            cmdDepartment.DataSource = getAllDepartments();
            cmdDepartment.DisplayMember = "name";
            cmdDepartment.ValueMember = "departmentId";

            cmdSupervisor.DataSource = getAllSupervisors();
            cmdSupervisor.DisplayMember = "FullName";
            cmdSupervisor.ValueMember = "EmployeeId";

            getAllEmployeeTypes();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeService employeeService = new EmployeeService();
                string searchKeyword = txtSearchKeyword.Text;
                if(searchKeyword != "")
                {
                    List<EmployeeLists> employees = employeeService.GetEmployeeLookup(searchKeyword);
                    lstMatchingEmployee.DisplayMember = "FullName";
                    lstMatchingEmployee.ValueMember = "EmployeeId";
                    lstMatchingEmployee.DataSource = employees;
       
                }
                else
                {
                    MessageBox.Show("Please provide search-Key-word", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void DisplayEmployee(Employee e)
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
            if(e.JobId != null)
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
            chkIsActive.Checked = e.IsActive;
            txtUserName.Text = e.UserName;
            cmdEmployeeType.SelectedIndex = Convert.ToInt32(e.Type);
        }

        private void lstMatchingEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMatchingEmployee.SelectedIndex == -1)
                {
                    MessageBox.Show("Please search Employee first then Click on the list box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lbPassword.Visible = false;
                    txtPassword.Visible = false;
                    EmployeeService employeeService = new EmployeeService();
                    employee = employeeService.GetEmployeeOne(Convert.ToInt32(lstMatchingEmployee.SelectedValue));
                    DisplayEmployee(employee);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetForm();
        }
        private void resetForm()
        {
            foreach (Control ctl in grpEmployeeInfo.Controls)
            {
                if (ctl is TextBox)
                {
                    ctl.Name = ctl.Name!= "lblStudentId" ? ctl.Text="":null;
  
                }
                if (ctl is CheckBox)
                {
                    ((CheckBox)ctl).Checked = false;
                }
                if (ctl is DateTimePicker)
                {
                    ((DateTimePicker)ctl).Value = DateTime.Now;
                }
                if(ctl is ComboBox)
                {
                    ((ComboBox)ctl).SelectedIndex = 0;
                }
            }

            lbPassword.Visible = true;
            txtPassword.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (employee != null)
            {
                Modification_Main modification_Main = new Modification_Main(this);
                modification_Main.Show();

            }
            else
            {
                MessageBox.Show("Please select a employee first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
