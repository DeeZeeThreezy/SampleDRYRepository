using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuickRepository.Extension;
using QuickRepository.Exception;

namespace QuickRepository.Cache.Variable
{
    public class VariableCacheRepository<T> : BaseCacheRepository<T> where T : class
    {
        private List<T> _data = null;

        public VariableCacheRepository(Expression<Func<T, dynamic>> tKey, Func<IEnumerable<T>, dynamic> newTKeyHandler, Func<IEnumerable<T>> sourceDataHandler)
            : base(tKey, newTKeyHandler, sourceDataHandler)
        {
            _data = GetSourceData().ToList();
        }

        public override IEnumerable<T> Get()
        {
            return _data;
        }

        public override void Update(T updatedInstance)
        {
            // use lock ?
            var updatedInstanceKey = GetTKey(updatedInstance);
            var updatedInstanceIndex = _data.FindIndex(x => GetTKey(x) == updatedInstanceKey);

            if (updatedInstanceIndex == -1)
            {
                throw new TKeyInstanceNotFound();
            }
            else
            {
                _data[updatedInstanceIndex] = updatedInstance;
            }
        }

        public override void Add(T newInstance)
        {
            // use lock ?
            LambdaExtensions.SetPropertyValue(newInstance, _tKeyExpression, GetNewTKey());

            _data.Add(newInstance);
        }

        public override void Delete(T instance)
        {
            // use lock ?
            var updatedInstanceKey = GetTKey(instance);
            var updatedInstanceIndex = _data.FindIndex(x => GetTKey(x) == updatedInstanceKey);

            if (updatedInstanceIndex == -1)
            {
                throw new TKeyInstanceNotFound();
            }
            else
            {
                _data.RemoveAt(updatedInstanceIndex);
            }
        }
    }
}
