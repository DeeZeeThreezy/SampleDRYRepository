using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuickRepository.Cache.MemoryCache
{
    public class MemoryCacheRepository<T> : BaseCacheRepository<T> where T : class
    {
        public MemoryCacheRepository(Expression<Func<T, dynamic>> tKey, Func<IEnumerable<T>, dynamic> newTKeyHandler, Func<IEnumerable<T>> sourceDataHandler)
            : base(tKey, newTKeyHandler, sourceDataHandler)
        {

        }


        public override IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public override void Update(T updatedInstance)
        {
            throw new NotImplementedException();
        }

        public override void Add(T newInstance)
        {
            throw new NotImplementedException();
        }

        public override void Delete(T instance)
        {
            throw new NotImplementedException();
        }
    }
}
