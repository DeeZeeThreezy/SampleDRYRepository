using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuickRepository.Cache
{
    public abstract class BaseCacheRepository<T> : IRepository<T> where T : class
    {
        // TODO: Restrict TKey to struct and class (in seperate classes) or remove unnecessary lambda/delegates if sticking with dynamic
        protected readonly Expression<Func<T, dynamic>> _tKeyExpression;
        protected readonly Func<T, dynamic> _tKeyHandler;
        protected readonly Func<IEnumerable<T>, dynamic> _newTKeyHandler;
        protected readonly Func<IEnumerable<T>> _sourceDataHandler;


        public BaseCacheRepository(Expression<Func<T, dynamic>> tKey, Func<IEnumerable<T>, dynamic> newTKeyHandler, Func<IEnumerable<T>> sourceDataHandler)
        {
            _tKeyExpression = tKey;
            _tKeyHandler = tKey.Compile();
            _newTKeyHandler = newTKeyHandler;
            _sourceDataHandler = sourceDataHandler;
        }

        public abstract IEnumerable<T> Get();

        public abstract void Update(T updatedInstance);

        public abstract void Add(T newInstance);

        public abstract void Delete(T instance);


        protected dynamic GetTKey(T instance)
        {
            return _tKeyHandler(instance);
        }

        protected dynamic GetNewTKey()
        {
            return _newTKeyHandler(Get());
        }

        protected IEnumerable<T> GetSourceData()
        {
            return _sourceDataHandler();
        }
    }
}
