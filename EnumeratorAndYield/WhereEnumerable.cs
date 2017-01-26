using System;
using System.Collections.Generic;

namespace EnumeratorAndYield
{
    static class WhereEnumerable
    {
        //public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        //{
        //    return WhereImpl(source, predicate);
        //}

        private static IEnumerable<T> WhereImpl<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach(var value in source)
            {
                if (predicate(value))
                    yield return value;
            }
        }
    }
}
