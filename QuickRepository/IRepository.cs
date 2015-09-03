using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        void Update(T updatedInstance);
        void Add(T newInstance);
        void Delete(T instance);
    }
}
