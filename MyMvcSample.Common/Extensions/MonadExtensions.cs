using System;

namespace MyMvcSample.Common.Extensions
{
    public static class MonadExtensions
    {
        public static TReturn IfNotNull<TReturn, T>(this T obj, Func<T, TReturn> evaluation, TReturn defaultValue = default(TReturn))
            where T : class
        {
            return (obj != null) ? evaluation(obj) : defaultValue;
        }
    }
}
