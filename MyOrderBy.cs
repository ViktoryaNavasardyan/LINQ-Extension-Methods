using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace LINQ_Extension_Methods
{
    class MyOrderBy<TKey, TSource> : IOrderedEnumerable<TSource>
    {
        private IEnumerable<TSource> list;
        public MyOrderBy(IEnumerable<TSource> source)
        {
            list = source;
        }

        //for implementation interface members
        IOrderedEnumerable<TSource> IOrderedEnumerable<TSource>.CreateOrderedEnumerable<TKey1>(Func<TSource, TKey1> keySelector, IComparer<TKey1> comparer, bool descending)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<TSource> GetEnumerator() { return list.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
