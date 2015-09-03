using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickRepository.Exception
{
    [Serializable]
    public class TKeyInstanceNotFound : System.Exception
    {
        public TKeyInstanceNotFound() { }
        public TKeyInstanceNotFound(string message) : base(message) { }
        public TKeyInstanceNotFound(string message, System.Exception inner) : base(message, inner) { }
        protected TKeyInstanceNotFound(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
