using BLL;
using GreenSwitch.HR;
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

namespace GreenSwitch
{
    public partial class MainForm : Form
    {
        private Profile_Form Profile_Form;
        private Department_Form Department_Form;
        private Employee_Form Employee_Form;

     
        private AboutForm aboutForm;
   
        public Authentication loggedInEmp;
        public Employee empInfo;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            Splash mySplash = new Splash();
            Login myLogin = new Login(this);
            mySplash.ShowDialog();

            if (mySplash.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                myLogin.ShowDialog();
            }

            if (myLogin.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                userPrivileges(Convert.ToInt32(loggedInEmp.EmployeeType));
                this.Show();
            }
        }

        private void sendEmailToSupervisor()
        {
            ReviewReminderService reviewReminderService = new ReviewReminderService();
            EmailService emailService = new EmailService();
            bool Senttoday = reviewReminderService.isValidSentToday(DateTime.Today);
            if (!Senttoday)
            {
                //List<Review> reviews =  reviewReminderService.getReviewBySupervisor(DateTime.Today);
                
                    List<EmployeeLists> reviewNeedingEmp = reviewReminderService.getNeddingEmoloyee();
                List<EmployeeLists> supervisors = reviewReminderService.getSupervisorForReminder();
                List<String> listOfEmp =new List<String>();
                HashSet<int> listOfSupervisorId = new HashSet<int>();



               
                foreach (var supervisor in supervisors)
                {

                    List<EmployeeLists> reviewsByFilter = reviewNeedingEmp.Where(review => review.EmployeeId == supervisor.EmployeeId).ToList();
                    if(reviewsByFilter.Count > 0)
                    {
                        List<EmployeeLists> supervisorsByFilter = supervisors.Where(super => super.EmployeeId == reviewsByFilter[0].EmployeeId).ToList();


                        Email email = new Email();
                        email.To = supervisorsByFilter[0].Email;
                        email.Subject = "Review Reminders";
                        email.Body = "These employees are due for a review this quarter.\nPlease complete these reviews at your earliest opportunity.\n\n";
                        foreach (var review in reviewsByFilter)
                        {
                            email.Body += review.FullName + "\n";

                        }
                        email.Body += "\nThank you for your cooperation";

                        DateTime today = DateTime.Today;

                        if (today.Month == 5 || today.Month == 6 ||
                            today.Month == 8 || today.Month == 9 ||
                            today.Month == 11 || today.Month == 12 ||
                            today.Month == 2 || today.Month == 3 ||
                            (today.Month == 1 && today.Day == 31) ||
                            (today.Month == 7 && today.Day == 31) ||
                            (today.Month == 10 && today.Day == 31))
                        {
                            email.CC = new List<string>();
                            List<EmployeeLists> hrEmps = reviewReminderService.getHRForReminder();
                            foreach (EmployeeLists empEmail in hrEmps)
                            {
                                email.CC.Add(empEmail.Email);
                            }
                        }

                        try
                        {

                            ReviewReminder reviewReminder = new ReviewReminder();
                            reviewReminder.HREmpId = loggedInEmp.EmployeeId;
                            reviewReminder.RecipientSupervisorId = supervisor.EmployeeId;
                            reviewReminder.ReminderDate = DateTime.Today;

                            if (emailService.SendEmail(email) && reviewReminderService.insertReminderData(reviewReminder))
                            {
                                MessageBox.Show($"Email reminder sent to {supervisor.FullName}" +
                               $"\nReminder successfully stored in db.");
                            }
                        }
                        catch (Exception ex)
                        {
                            
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                  

                }

              
            }







        }

        private void close_HR_Privileges()
        {
            picDepartment.Visible = false;
            picEmployee.Visible = false;
            mainMenuHR.Visible = false;
        }

        private void open_HR_Privileges()
        {
            picDepartment.Visible = true;
            picEmployee.Visible = true;
            mainMenuHR.Visible = true;
        }

        private void RegularSupervisorPrivileges()
        {
            btnModifyPO.Visible = true;
            btnProcessPO.Visible = true;
            picDepartment.Visible = true;
            pictureBox1.Visible = true;
            picEmployee.Visible = false;
            picDepartment.Visible = true;
            mnuRegularSupervisor.Visible = true;
            mainMenuHR.Visible = false;
            mnuRegularEmployee.Visible = false;
        }

        private void RegularEmployeePrivileges()
        {
            btnModifyPO.Visible = false;
            pictureBox1.Visible = true;
            btnProcessPO.Visible = false;
            mainMenuHR.Visible = false;
            picEmployee.Visible = false;
            picDepartment.Visible = false;
            mnuRegularSupervisor.Visible = false;
            mnuRegularEmployee.Visible = true;
        }

        private void userPrivileges(int employeeType)
        {
            if (Convert.ToInt32(EmployeeType.HrSupervisor) == employeeType)
            {
                open_HR_Privileges();
                sendEmailToSupervisor();
            }
            else if (Convert.ToInt32(EmployeeType.RegularSupervisor) == employeeType)
            {
                RegularSupervisorPrivileges();
            }
            else if (Convert.ToInt32(EmployeeType.HrEmployee) == employeeType)
            {
                sendEmailToSupervisor();
                open_HR_Privileges();
                btnModifyPO.Visible = false;
                btnProcessPO.Visible = false;
            }
            else if (Convert.ToInt32(EmployeeType.RegularEmployee) == employeeType)
            {
                RegularEmployeePrivileges();
            }
        }

        private void picDepartment_Click(object sender, EventArgs e)
        {
            Department();
        }

        private void Department()
        {
            if (Department_Form == null || Department_Form.IsDisposed)
            {
                Department_Form = new Department_Form(this);
            }
            if (tabControl1.Contains(Department_Form))
            {
                tabControl1.TabPages[Department_Form].Select();
            }
            else
            {
                tabControl1.TabPages.Add(Department_Form);
            }
        }

        private void Employee()
        {
            if (Employee_Form == null || Employee_Form.IsDisposed)
            {
                Employee_Form = new Employee_Form(this);
            }
            if (tabControl1.Contains(Employee_Form))
            {
                tabControl1.TabPages[Employee_Form].Select();
            }
            else
            {
                tabControl1.TabPages.Add(Employee_Form);
            }
        }


        private void Profile()
        {
           
            if (Profile_Form == null || Profile_Form.IsDisposed)
            {
                Profile_Form = new Profile_Form(this);
            }
            if (tabControl1.Contains(Profile_Form))
            {
                tabControl1.TabPages[Profile_Form].Select();
            }
            else
            {
                tabControl1.TabPages.Add(Profile_Form);
            }
        }
    

  

        private void About()
        {
            if (aboutForm == null || aboutForm.IsDisposed)
            {
                aboutForm = new AboutForm();
                aboutForm.Show();
            }
        }

 

        private void picEmployee_Click(object sender, EventArgs e)
        {
            Employee();
        }


        private void menuDepartment_Click(object sender, EventArgs e)
        {
            Department();
        }

        private void menuEmployee_Click(object sender, EventArgs e)
        {
            Employee();
        }




        private void TspAbout_Click(object sender, EventArgs e)
        {
            About();
        }

        private void MnuHelpAbout_Click(object sender, EventArgs e)
        {
            About();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Profile();
        }

  

        private void LogoutToolStrip_Click(object sender, EventArgs e)
        {
            Application.Restart();           
        }


    }
}

