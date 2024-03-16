using ProjectTypes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTypes
{
    public static class ProjectTypes
    {
        public static List<Person> GetProjectPersonTypes()
        {
            var projectTypes = new List<Person>() {
            new Student(""),
            new Person("")
            };

            return projectTypes;
        }
    }
}
