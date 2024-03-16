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
    public class Person : IAcademyPeople, IPrinterMethods, ITechnicalMethods
    {
        private string _name;
        private string _surname = string.Empty;
        private int _age;
        private string _phone;
        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }

        public Person(string name, string surname = "", int age = 0, string phone = "")
        {
            Name = name;
            Surname = surname;
            Age = age;
            Phone = phone;
        }

        public virtual void Print()
        {
            var currentAge = _age > 0 ? _age.ToString() : string.Empty;
            var message = $"Name: {_name}\nSurname: {_surname}\n Age: {currentAge}\n Phone: {_phone}";
            ConsoleWorker.ShowMessage(message);
        }

        public virtual List<Person> GetObjectsFromJson(string json)
        {
            List<Person> result = null;

            if(!string.IsNullOrEmpty(json))
            {
                try
                {
                    result = JsonConvert.DeserializeObject<List<Person>>(json);
                }
                catch (Exception ex)
                {
                    ConsoleWorker.ShowMessage($"Error in Person-GetObjectsFromJson {ex.Message}");
                }
            }

            return result;
        }

        public virtual IEnumerable<Person> GetSearchParams<T>(IEnumerable<T> data, T searchParams) where T : Person
        {
            return data.Where(person => (string.IsNullOrEmpty(searchParams.Name) || !string.IsNullOrEmpty(searchParams.Name) && person.Name.Trim().ToLower().Contains(searchParams.Name.Trim().ToLower())) &&
            (string.IsNullOrEmpty(searchParams.Surname) || !string.IsNullOrEmpty(searchParams.Surname) && person.Surname.Trim().ToLower().Contains(searchParams.Surname.Trim().ToLower())) &&
            (string.IsNullOrEmpty(searchParams.Phone) || !string.IsNullOrEmpty(searchParams.Phone) && person.Phone.Trim().ToLower().Contains(searchParams.Phone.Trim().ToLower())) &&
            (searchParams.Age == 0 || searchParams.Age > 0 && searchParams.Age == person.Age));
        }
    }
}
