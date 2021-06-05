using System;
using System.Collections.Generic;
using System.Text;

namespace Tubes_KPL.Model.Person
{
    using BCrypt.Net;
    using Newtonsoft.Json;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class Employee
    {
        private int _employeeId, _employeeLevelAccess;
        private String _employeeName, _employeeAddress, _employeeEmail, _employeePassword;
        public static int GlobalEmployeeID;

        public Employee() { }
        public Employee(string employeeName, string employeeAddress)
        {
            try
            {
                if ((String.IsNullOrEmpty(employeeName)) || (String.IsNullOrEmpty(employeeAddress)))
                    throw new ArgumentNullException("Input should not be blank!");

                _employeeName = employeeName;
                _employeeAddress = employeeAddress;
                _employeeId = Interlocked.Increment(ref GlobalEmployeeID);
                _employeeLevelAccess = 0;
                CreateAt = DateTime.Now;
            }
            catch (ArgumentNullException e)
            {
                Console.Error.WriteLine(e.ParamName);
            }
            
        }




        // Setter Getter
        [JsonProperty(PropertyName = "Id", Order = 1)]
        public int EmployeeId
        {
            get { return _employeeId; }

        }

        [JsonProperty(PropertyName = "Name", Order = 2)]
        public String EmployeeName
        {
            get { return _employeeName; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Name should not be blank!");

                    _employeeName = value;

                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
            }
        }

        [JsonProperty(PropertyName = "Address", Order = 3)]
        public String EmployeeAddress
        {
            get { return _employeeAddress; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Address should not be blank!");

                    _employeeAddress = value;

                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
            }
        }

        [JsonProperty(PropertyName = "Level_Access", Order = 4)]
        public int EmployeeLevelAccess
        {
            get { return _employeeLevelAccess; }
            set
            {
                try
                {
                    if ((value >= 0) || (value <= 1)) 
                        throw new ArgumentException("The input should greater or equal than 0, or less or equal than 1");

                    _employeeLevelAccess = value;
                }
                catch (ArgumentException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
            }

        }

        [JsonIgnore]
        public string EmployeeEmail
        {
            get { return _employeeEmail; }
            set
            {
                Regex rgx = new Regex(@"^(?:\S+@telkomuniversity\.ac.id )*\S+@telkomuniversity\.ac.id");
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Email should not null or empty");

                    if (rgx.IsMatch(value) != true) 
                        throw new ArgumentException("Email domain invalid");

                    _employeeEmail = value;

                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
                catch (ArgumentException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
            }
        }

        [JsonIgnore]
        public string EmployeePassword
        {
            get { return _employeePassword; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Email should not null or empty");

                    _employeePassword = BCrypt.HashPassword(value);

                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }

            }
        }

        [JsonProperty(PropertyName = "CreateAt", Order = 10)]
        public readonly DateTime CreateAt;


    }
}
