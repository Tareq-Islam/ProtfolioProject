using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFile.Models
{
    public interface IDataManagement<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long? id);
        T Add(T newItem);
        T Update(T ItemVM);
        void Remove(long? id);

    }
}
