using BLL;
using Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GreenSwitch.HR
{
    public partial class Department_Form : Form
    {
        private MainForm mainForm;
        Department department = new Department();
        DepartmentService departmentService = new DepartmentService();
        public Department_Form(MainForm m)
        {
            mainForm = m;
            InitializeComponent();

        }

        private void btnAddDepatment_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                DepartmentService departmentService = new DepartmentService();
                PopulateDepartment_Object();
                department = departmentService.CreateDepartment(department);

                if (department.getErrors().Count != 0) { 
                    foreach(Error error in department.getErrors())
                    {
                        msg += error.ErrorDescription + Environment.NewLine;
                    }
           
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    getAllDepartments();
                    MessageBox.Show("New department added!!","Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateDepartment_Object()
        {

            department.Description = txtDescription.Text;
            department.Name = txtName.Text;
            department.CreationDate = dtpDateOfCreation.Value;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Department_Form_Load(object sender, EventArgs e)
        {

            if(mainForm.loggedInEmp.EmployeeType.ToString().ToLower() == "regularsupervisor")
            {
                GetDepartmentBySuperviosr();
                cmdDepartment.Visible = false;
                btnSearchDepartment.Visible = false;
                txtName.Enabled = false;
                dtpDateOfCreation.Enabled = false;
                btnAddDepatment.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                getAllDepartments();
                cmdDepartment.Visible = true;
                btnSearchDepartment.Visible = true;
                txtName.Enabled = true;
                dtpDateOfCreation.Enabled = true;
                btnAddDepatment.Visible = true;
                btnDelete.Visible = true;
            }
            //btnSearchDepartment.Visible = false;
            //cmdDepartment.Visible = false;
            //btnUpdateDepartment.Visible = false;

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

        private void btnSearchDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
   
                department = departmentService.GetDepartmentOne(Convert.ToInt32(cmdDepartment.SelectedValue));

                if (department.getErrors().Count != 0)
                {
                    foreach (Error error in department.getErrors())
                    {
                        msg += error.ErrorDescription + Environment.NewLine;
                    }
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                displayDepartment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateDepartment_Click(object sender, EventArgs e)
        {
            try
            {

                string msg = "";
                PopulateDepartment_Object();
                if (!departmentService.UpdateDepartmentByHr(department) || department.getErrors().Count != 0)
                {
                    foreach (Error error in department.getErrors())
                    {
                        msg += error.ErrorDescription + Environment.NewLine;
                    }
                    getAllDepartments();
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("department Updated!!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetDepartmentBySuperviosr()
        {
            try
            {
                department = new DepartmentService().GetDepartmentBySuperviosr(mainForm.loggedInEmp.EmployeeId);
                displayDepartment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void displayDepartment()
        {
            txtDescription.Text = department.Description;
            txtName.Text = department.Name;
            dtpDateOfCreation.Value = department.CreationDate;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                DepartmentService departmentService = new DepartmentService();
              
                bool result = departmentService.DeleteDepartemnt(Convert.ToInt32(cmdDepartment.SelectedValue));

                if (result)
                {
                  
     
                    getAllDepartments();
                    MessageBox.Show("the department deleted!!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescription.Text = "";
                    txtName.Text = "";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
