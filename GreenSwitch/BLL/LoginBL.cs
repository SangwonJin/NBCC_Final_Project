using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Type;

namespace BLL
{
    public class LoginBL
    {

        LoginRepo repo = new LoginRepo();

        /// <summary>
        /// Service method to validate if the data entered was correct. Checks for empty string and if user is active or not.
        /// </summary>
        /// <param name="loggedEmp"></param>
        private void IsValidData(Authentication loggedEmp)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(loggedEmp.EmployeeId.ToString(), "[^0-9]"))
            {
                loggedEmp.addError(new Error(100, "UserID should be number"));
            }

            if (String.IsNullOrEmpty(loggedEmp.EmployeeId.ToString()))
            {
                loggedEmp.addError(new Error(100, "UserID cannot be empty."));                          
            }

            if (String.IsNullOrEmpty(loggedEmp.Password))
            {
                loggedEmp.addError(new Error(101, "Password cannot be empty."));
            }
        }

        /// <summary>
        /// Service method to verify a valid login. (Correct username and password)
        /// </summary>
        /// <param name="loggedEmp"></param>
        /// <returns></returns>
        public Authentication GetAuthentication(Authentication loggedEmp)
        {
            IsValidData(loggedEmp);
            if (loggedEmp.getErrors().Count == 0)
            {
                loggedEmp.Password = ComputeStringToSha256Hash(loggedEmp.Password);

                return repo.GetLoginInfo(loggedEmp.EmployeeId, loggedEmp.Password);
            }
            return loggedEmp;
        }
       

        /// <summary>
        /// Service method to retrieve Supervisors full name.
        /// </summary>
        /// <param name="loggedEmp"></param>
        /// <returns></returns>
        public SupervisorViewModel GetSupervisorInfo(Employee loggedEmp)
        {

            return repo.GetSupervisorInfo(loggedEmp.SupervisorId);
        }

        public SupervisorViewModel GetSupervisor(int supervisoirId)
        {

            return repo.GetSupervisorInfo(supervisoirId);
        }

        /// <summary>
        /// Service method to verify if the user is active.
        /// </summary>
        /// <param name="loggedEmp"></param>
        /// <returns></returns>
        public bool IsActiveUser(Authentication loggedEmp)
        {
            LoginRepo repo = new LoginRepo();

            return repo.IsActiveUser(loggedEmp.Username, loggedEmp.Password);
        }

        public bool IsSupervisor(Authentication loggedInEmployee)
        {
            if (loggedInEmployee.EmployeeType == EmployeeType.HrSupervisor || loggedInEmployee.EmployeeType == EmployeeType.RegularSupervisor)
            {
                return true;
            }

            return false;
        }
        private string ComputeStringToSha256Hash(string plainText)
        {
            // Create a SHA256 hash from string   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computing Hash - returns here byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // now convert byte array to a string   
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }

    }
}
