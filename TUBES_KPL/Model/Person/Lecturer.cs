using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tubes_KPL.Model.Person
{
    public class Lecturer: Employee
    {
        private string _lecturerNIDN, _lecturerHomeBase, _lecturerFaculty;
        private List<string> _lecturerEducation;
        private readonly Regex regex = new Regex(@"^\d+$");


        public Lecturer() { }
        public Lecturer(string employeeName, string employeeAddress) : base(employeeName, employeeAddress) { }
        public Lecturer(string employeeName, string employeeAddress,
            string lecturerNIDN) : base(employeeName, employeeAddress)
        {
            try
            {
                if (String.IsNullOrEmpty(lecturerNIDN))
                    throw new ArgumentNullException("NIDN should not be blank");

                if (!regex.IsMatch(lecturerNIDN))
                    throw new FormatException("NIDN is not numeric!");

                _lecturerNIDN = lecturerNIDN;

                _lecturerEducation = new List<string>();

            }
            catch (Exception e)
            {
                if (e is ArgumentNullException || e is FormatException)
                    Console.Error.WriteLine(e.Message);
            }
        }

        //Method
        public void AddDataEducation(params string[] DataInput)
        {
            try
            {
                foreach (String Item in DataInput)
                {
                    if (String.IsNullOrEmpty(Item) == true) 
                        throw new ArgumentNullException("The input should not null or empty");
                }

                LecturerEducation.AddRange(DataInput);

            }
            catch (ArgumentNullException e)
            {
                Console.Error.WriteLine(e.ParamName);
            }

        }

        public string GetDataEducation(string DataInput)
        {
            foreach (string Item in LecturerEducation)
            {
                if (Item == DataInput) return Item;
            }
            return null;
        }

        public void DeleteDataEducation(string DataInput)
        {
            try
            {
                if (String.IsNullOrEmpty(DataInput))
                    throw new ArgumentNullException("Input should not be blank!");

                bool IsExist = _lecturerEducation.Exists(Item => 
                                    Item.Contains(DataInput, StringComparison.OrdinalIgnoreCase)
                                );

                if(IsExist == true)
                {
                    _lecturerEducation.Remove(DataInput);

                    Console.WriteLine("Data deleted successfully");
                }
                else
                {
                    Console.WriteLine("Data not found");
                }
                

            }
            catch (ArgumentNullException e)
            {
                Console.Error.Write(e.ParamName);
            }
            
        }

        public void DeleteAllDataEducation()
        {
            LecturerEducation.Clear();
            Console.WriteLine("All data deleted successfully");

        }

        public void UpdateDataEducation(string DataInput, string DataUpdate)
        {
            int index = LecturerEducation.FindIndex(
                            Item => Item.Contains(DataInput, StringComparison.OrdinalIgnoreCase)
                        );

            _lecturerEducation[index] = DataUpdate;

        }


        //Setter Getter
        [JsonProperty(PropertyName = "NIDN", Order = 5, NullValueHandling = NullValueHandling.Ignore)]
        public string LecturerNIDN
        {
            get { return _lecturerNIDN; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("NIDN should not null or empty");

                    if (value.Length != 10) 
                        throw new ArgumentOutOfRangeException("NIDN length must 10 character");

                    _lecturerNIDN = value;

                }
                catch (Exception e)
                {
                    if (e is ArgumentNullException || e is ArgumentOutOfRangeException)
                        Console.Error.WriteLine(e.Message);                   
                }
                
            }
        }

        [JsonProperty(PropertyName = "Prodi", Order = 6, NullValueHandling = NullValueHandling.Ignore)]
        public string LecturerHomeBase
        {
            get { return _lecturerHomeBase; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value))
                        throw new ArgumentNullException("Lecturer's prodi should not null or empty");

                    _lecturerHomeBase = value;

                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
            }
        }

        [JsonProperty(PropertyName = "Faculty", Order = 7, NullValueHandling = NullValueHandling.Ignore)]
        public string LecturerFaculty
        {
            get { return _lecturerFaculty; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value)) 
                        throw new ArgumentNullException("Lecturer's faculty should not null or empty");

                    _lecturerFaculty = value;

                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
            }
        }

        [JsonProperty(PropertyName = "Education", Order = 8, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> LecturerEducation
        {
            get { return _lecturerEducation; }

        }

    }
}
