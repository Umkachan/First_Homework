using ProjectTypes.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTypes.Interfaces
{
    public interface IAcademyGroupCommon<T> : IPrinterMethods, IBasePersonOperations<Person, string>, IDbBaseOperations<Person>
    {
        public List<T> Persons { get; }
        public int PersonsCount { get; }
    }
}
