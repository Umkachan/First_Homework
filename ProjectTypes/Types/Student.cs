using Newtonsoft.Json;
using ProjectTools;
using ProjectTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTypes.Types
{
    public class Student : Person, ITechnicalMethods
    {
        private int _average;

        public int Average { get { return _average; } set { _average = value; } }
        public int NumberOfGroup { get; set; }
        public Student(string name, string surname = "", int age = 0, string phone = "", int average = 0, int numbersOfGroup = 0) : base(name, surname, age, phone)
        {
            Average = average;
            NumberOfGroup = numbersOfGroup;
        }

        public override void Print()
        {
            var currentAge = Age > 0 ? Age.ToString() : string.Empty;
            var currentAverage = Average > 0 ? Average.ToString() : string.Empty;
            var currentNumberOfGroup = NumberOfGroup > 0 ? NumberOfGroup.ToString() : string.Empty;
            var message = $"Name: {Name}\nSurname: {Surname}\n Age: {currentAge}\n Phone: {Phone}\nAverage: {currentAverage}\nNumberOfGroup: {currentNumberOfGroup}";
            ConsoleWorker.ShowMessage(message);
        }

        public override List<Person> GetObjectsFromJson(string json)
        {
            var result = new List<Person>();

            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                  var tempResult = JsonConvert.DeserializeObject<List<Student>>(json);
                  
                    if(tempResult != null && tempResult.Any())
                    {
                        result.AddRange(tempResult);
                    }
                }
                catch (Exception ex)
                {
                    ConsoleWorker.ShowMessage($"Error in Student-GetObjectsFromJson {ex.Message}");
                }
            }

            return result;
        }
    }
}
