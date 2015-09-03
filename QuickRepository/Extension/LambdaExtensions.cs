using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickRepository.Extension
{
    public static class LambdaExtensions
    {
        public static void SetPropertyValue<T>(this T target, Expression<Func<T, dynamic>> memberLamda, dynamic value)
        {
            // TODO: clean

            var propertyName = memberLamda.Body.ToString().Split('.').Last().TrimEnd(')');
            var wrapper = FastMember.ObjectAccessor.Create(target);

            wrapper[propertyName] = value;

            // Source: http://stackoverflow.com/a/9601914/5071208
            //var thing = memberLamda.Body as UnaryExpression;

            //while (thing.CanReduce)
            //{
            //    thing = thing.Reduce() as UnaryExpression;
            //}
            //var memberSelectorExpression = memberLamda.Body as MemberExpression;
            //if (memberSelectorExpression != null)
            //{
            //    var property = memberSelectorExpression.Member as PropertyInfo;
            //    if (property != null)
            //    {
            //        property.SetValue(target, value, null);
            //    }
            //}
        }
    }
}
