
using AcademyGroup.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectTools;
using ProjectTools.Helpers;
using ProjectTypes;
using ProjectTypes.Interfaces;
using ProjectTypes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcademyGroup
{
    public class AcademyGroupCommon : IAcademyGroupCommon<Person>
    {
        public List<Person> Persons { get; private set; }
        public int PersonsCount { get { return _personsCount; } private set { _personsCount = value; } }
        private int _personsCount;

        public AcademyGroupCommon()
        {
            Persons = new List<Person>();
        }

        public void Add(Person value)
        {
            if (value != null)
            {
                Persons.Add(value);
            }
        }

        public void Edit(Person value)
        {
            if (value != null && !string.IsNullOrEmpty(value.Name))
            {
                var searchResult = Persons.Single(person => person.Name.Trim().ToLower() == value.Name.Trim().ToLower());

                if (searchResult != null)
                {
                    var index = Persons.IndexOf(searchResult);
                    Persons[index] = searchResult;
                }
            }
        }

        public void Load()
        {
            Persons.Clear();

            foreach (var projectType in ProjectTypes.ProjectTypes.GetProjectPersonTypes())
            {
                var typeName = projectType.GetType().Name;
                var fileFullName = $"{typeName}.{EnumHelper.GetEnumDescription(FileExtentions.JSON)}";

                if (File.Exists(fileFullName))
                {
                    using (var file = File.OpenText(fileFullName))
                    {
                        string json = file.ReadToEnd();

                        var convertResult = projectType.GetObjectsFromJson(json);

                        if (convertResult != null)
                        {
                            Persons.AddRange(convertResult);
                        }
                    }
                }
            }

            Print();
        }

        public void Print()
        {
            foreach (var person in Persons)
            {
                person.Print();
                ConsoleWorker.ShowMessage("-----------------------");
            }
        }

        public void Remove(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var searchResult = Persons.Single(person => person.Name.Trim().ToLower() == id.Trim().ToLower());

                if (searchResult != null)
                {
                    Persons.Remove(searchResult);
                }
            }
        }

        public void Save()
        {
            try
            {
                var groupPersons = Persons.GroupBy(x => x.GetType()).ToList();

                for (int i = 0; i < groupPersons.Count; i++)
                {
                    var typeName = groupPersons[i].Key.Name;
                    var data = groupPersons[i].Select(item => item).ToList();

                    var jsonData = JsonConvert.SerializeObject(data);
                    var ext = EnumHelper.GetEnumDescription(FileExtentions.JSON);
                    var fileFullName = $"{typeName}.{EnumHelper.GetEnumDescription(FileExtentions.JSON)}";
                    File.WriteAllText(fileFullName, jsonData);
                }
            }
            catch (Exception ex)
            {
                ConsoleWorker.ShowMessage($"Error in AcademyGroupCommon-Save: {ex.Message}");
            }
        }

        public void Search(Person searchParams)
        { //Логика не учитывает классы наследники
            var result = Persons.Where(person => (string.IsNullOrEmpty(searchParams.Name) || !string.IsNullOrEmpty(searchParams.Name) && person.Name.Trim().ToLower().Contains(searchParams.Name.Trim().ToLower())) &&
              (string.IsNullOrEmpty(searchParams.Surname) || !string.IsNullOrEmpty(searchParams.Surname) && person.Surname.Trim().ToLower().Contains(searchParams.Surname.Trim().ToLower())) &&
              (string.IsNullOrEmpty(searchParams.Phone) || !string.IsNullOrEmpty(searchParams.Phone) && person.Phone.Trim().ToLower().Contains(searchParams.Phone.Trim().ToLower())) &&
              (searchParams.Age == 0 || searchParams.Age > 0 && searchParams.Age == person.Age));

            foreach (var person in result)
            {
                person.Print();
            }
        }
    }
}
