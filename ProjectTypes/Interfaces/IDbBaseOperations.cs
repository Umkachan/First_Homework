using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTypes.Interfaces
{
    public interface IDbBaseOperations<T>
    {
        void Save();
        void Load();
        void Search(T value);
    }
}
