using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LINQ_Extension_Methods
{
    class Grouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        private TKey key;
        private IEnumerable<TSource> elements;
        public TKey Key { get => key; }
        public Grouping(TKey tkey, IEnumerable<TSource> telements)
        {
            key = tkey;
            elements = telements;
        }
        public IEnumerator<TSource> GetEnumerator()
        {
            return elements.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
