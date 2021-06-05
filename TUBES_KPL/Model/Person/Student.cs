using System;
using System.Collections.Generic;
using System.Text;

namespace Tubes_KPL.Model.Person
{
    
    using BCrypt.Net;
    using Newtonsoft.Json;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class Student
    {
        private int _studendId;

        private string _studentName, _studentNIM, _studentYear, _studentFaculty,
            _studentProdi, _studentClass, _studentEmail, _studentPassword;

        private readonly Regex regex = new Regex(@"^\d+$");

        public static int GlobalStudentID;

        public Student() { }
        public Student(string studentName, string studentNIM)
        {
            try
            {
                if (String.IsNullOrEmpty(studentNIM) || String.IsNullOrEmpty(studentName))
                    throw new ArgumentNullException("Input should not be blank!");

                if (studentNIM.Length != 10)
                    throw new ArgumentOutOfRangeException("NIM lenght must 10 character");

                _studentName = studentName;
                _studentNIM = studentNIM;
                _studendId = Interlocked.Increment(ref GlobalStudentID);
                CreateAt = DateTime.Now;

            }
            catch(Exception e)
            {
                if(e is ArgumentNullException || e is ArgumentOutOfRangeException)
                    Console.Error.WriteLine(e.Message);
            }
            

            
        }

        


        //Method
        public bool StudentVerifyEmail(string email)
        {
            return email.Equals(StudentEmail);
        }
        public bool StudentVerifyPassword(string password)
        {
            return BCrypt.Verify(password, StudentPassword).Equals(true);
        }
        public bool StudentVerifyAccount(string email, string password)
        {
            return (StudentVerifyEmail(email) && StudentVerifyPassword(password)).Equals(true);
        }



        // Setter Getter
        [JsonProperty(PropertyName = "Id", Order = 1)]
        public int StudentId
        {
            get { return _studendId; }
        }

        [JsonProperty(PropertyName = "Name", Order = 2)]
        public string StudentName
        {
            get { return _studentName; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Student name should not null or empty");

                    _studentName = value;
                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }

            }
        }

        [JsonProperty(PropertyName = "NIM", Order = 3)]
        public string StudentNIM
        {
            get { return _studentNIM; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("NIM should not be blank!");

                    if (value.Length != 10) 
                        throw new ArgumentOutOfRangeException("NIM should has 10 character");

                    _studentNIM = value;
                }
                catch (Exception e)
                {
                    if(e is ArgumentNullException || e is ArgumentOutOfRangeException)
                        Console.Error.WriteLine(e.Message);
                }
                
            }
        }

        [JsonProperty(PropertyName = "Year", Order = 4)]
        public string StudentYear
        {
            get { return _studentYear; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Student year should not null or empty");

                    if (!regex.IsMatch(value))
                        throw new FormatException("Input should be numeric");
                    
                    if (value.Length != 4) 
                        throw new ArgumentOutOfRangeException("Student year should has 4 character");


                    _studentYear = value;
                }
                catch (Exception e)
                {
                    if(e is ArgumentNullException || e is ArgumentOutOfRangeException || e is FormatException)
                        Console.Error.WriteLine(e.Message);
                }
                
            }
        }

        [JsonProperty(PropertyName = "Faculty", Order = 5, NullValueHandling = NullValueHandling.Ignore)]
        public string StudentFaculty
        {
            get { return _studentFaculty; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Faculty should not be blank!");

                    _studentFaculty = value;
                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
            }
        }

        [JsonProperty(PropertyName = "Prodi", Order = 6, NullValueHandling = NullValueHandling.Ignore)]
        public string StudentProdi
        {
            get { return _studentProdi; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Prodi should not be blank!");

                    _studentProdi = value;
                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
            }
        }

        [JsonProperty(PropertyName = "Class", Order = 7, NullValueHandling = NullValueHandling.Ignore)]
        public string StudentClass
        {
            get { return _studentClass; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("NIM should not null or empty");

                    if (value.Length != 8) 
                        throw new ArgumentOutOfRangeException("Class should has 8 character");

                    _studentClass = value;
                }
                catch (Exception e)
                {
                    if(e is ArgumentNullException || e is ArgumentOutOfRangeException)
                        Console.Error.WriteLine(e.Message);
                    
                }
                
            }
        }

        [JsonIgnore]
        public string StudentEmail
        {
            get { return _studentEmail; }
            set
            {
                Regex rgx = new Regex(@"^(?:\S+@student.telkomuniversity\.ac.id )*\S+@student.telkomuniversity\.ac.id");
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Email should not be blank!");

                    if (rgx.IsMatch(value) != true) 
                        throw new ArgumentException("Email domain invalid");

                    _studentEmail = value;

                }
                catch (Exception e)
                {
                    if(e is ArgumentNullException || e is ArgumentException)
                    {
                        Console.Error.WriteLine(e.Message);
                    }
                    
                }
            }
        }


        [JsonIgnore]
        public string StudentPassword
        {
            get { return _studentPassword; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Email should not blank!");

                    _studentPassword = BCrypt.HashPassword(value);

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
