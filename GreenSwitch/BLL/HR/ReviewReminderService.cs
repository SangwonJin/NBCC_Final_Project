using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReviewReminderService
    {
        ReviewReminderRepository reviewReminderRepository = new ReviewReminderRepository();
        public bool isValidSentToday(DateTime today)
        {
            bool result;
            result = reviewReminderRepository.isValidSentToday(today);

            return result;
        }
        public List<Review> getReviewBySupervisor(DateTime today)
        {
            List<Review> reviews = new List<Review>();
            DateTime startQauterDate = getStartQuaterDate(today);
            DateTime endQauterDate = getEndQuaterDate(today);
            reviews = reviewReminderRepository.GetReviewsBySupervisorWithQuater(startQauterDate, endQauterDate);

            return reviews;

        }
        public bool insertReminderData(ReviewReminder reviewReminder)
        {
            bool result = reviewReminderRepository.insertReminderData(reviewReminder);
            return result;
        }

        public List<EmployeeLists> getNeddingEmoloyee()
        {
            EmployeeRepository employeeRepo = new EmployeeRepository();
            return employeeRepo.GetAllneedingEmployee();
        }

        public List<EmployeeLists> getSupervisorForReminder()
        {
            EmployeeRepository employeeRepo = new EmployeeRepository();
            return employeeRepo.GetAllSupervisorForReminder();
        }

        public List<EmployeeLists> getHRForReminder()
        {
            EmployeeRepository employeeRepo = new EmployeeRepository();
            return employeeRepo.GetAllHrForReminder();
        }
        private DateTime getStartQuaterDate(DateTime today)
        {
            DateTime startQuaterDate = today;

       if(today.Month >= 9)
            {
                startQuaterDate = Convert.ToDateTime(today.Year.ToString()+ "/09/01" );
            }

            else if (today.Month >= 6)
            {
                startQuaterDate = Convert.ToDateTime(today.Year.ToString() + "/06/01");
            }

            else if (today.Month >= 4)
            {
                startQuaterDate = Convert.ToDateTime(today.Year.ToString() + "/03/01");
            }
            else if (today.Month <= 3)
            {
                startQuaterDate = Convert.ToDateTime(today.AddYears(-1).ToString() + "/12/01");
            }

            return startQuaterDate;
        }

        private DateTime getEndQuaterDate(DateTime today)
        {
            DateTime endQuaterDate = today;

            if (today.Month >= 9)
            {
                endQuaterDate = Convert.ToDateTime(today.Year.ToString() + "/11/" + DateTime.DaysInMonth(today.Year,11));
            }

            else if (today.Month >= 6)
            {
                endQuaterDate = Convert.ToDateTime(today.Year.ToString() + "/08/" + DateTime.DaysInMonth(today.Year, 8));
            }

            else if (today.Month >= 4)
            {
                endQuaterDate = Convert.ToDateTime(today.Year.ToString() + "/05/" + DateTime.DaysInMonth(today.Year, 5));
            }
            else if (today.Month <= 3)
            {
                endQuaterDate = Convert.ToDateTime(today.Year.ToString() + "/02/" + DateTime.DaysInMonth(today.Year, 2));
            }

            return endQuaterDate;
        }
    }
}
