using ProjectTypes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTypes.Interfaces
{
    public interface ITechnicalMethods
    {
        List<Person> GetObjectsFromJson(string json);
    }
}
