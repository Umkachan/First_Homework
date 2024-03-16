using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTypes.Interfaces
{
    public interface IBasePersonOperations<T, I>
    {
        void Add(T value);
        void Remove(I id);
        void Edit(T value);
    }
}
