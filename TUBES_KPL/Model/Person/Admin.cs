using Newtonsoft.Json;
using System;

namespace Tubes_KPL.Model.Person
{
    public class Admin: Employee
    {
        private string _AdminNIK;

        public Admin() { }

        public Admin(string employeeName, string employeeAddress) : base(employeeName, employeeAddress)
        {

            EmployeeLevelAccess = 1;
        }
        public Admin(string employeeName, string employeeAddress, string adminNIK) : base(employeeName, employeeAddress)
        {

            AdminNIK = adminNIK;
            EmployeeLevelAccess = 1;
        }


        [JsonProperty(PropertyName = "NIK", Order = 5)]
        public string AdminNIK
        {
            get { return _AdminNIK; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("NIK should not be blank!");

                    _AdminNIK = value;
                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
            }
        }

    }
}
