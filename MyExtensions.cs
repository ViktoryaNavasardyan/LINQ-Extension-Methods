using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;



namespace LINQ_Extension_Methods
{
    public static class MyExtensions
    {
        // projects the elements into a new form
        public static IEnumerable<TResult> SelectExt<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source is null || !source.Any())
            {
                throw new InvalidOperationException("Cannot compute SelectExt for a null or empty set.");
            }
            var collection = new TResult[source.Count()];
            int i = 0;
            foreach (TSource s in source)
            {
                collection[i] = selector(s);
                i++;
            }
            return collection;
        }

        // filters elements from a collection based on a predicate
        public static IEnumerable<TSource> WhereExt<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is null || !source.Any())
            {
                throw new InvalidOperationException("Cannot compute WhereExt for a null or empty set.");
            }
            var collection = new TSource[source.Count()];
            int i = 0;
            foreach (TSource s in source)
            {
                if (predicate(s))
                {
                    collection[i] = s;
                    i++;
                }
            }
            return collection;
        }

        //returns a collection as a List
        public static List<TSource> ToListExt<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null || !source.Any())
            {
                throw new InvalidOperationException("Cannot compute ToListExt for a null or empty set.");
            }
            return source.SelectExt(item => item).ToList();
        }

        //groups the elements of a sequence according to a specified key selector function
        public static IEnumerable<IGrouping<TKey, TSource>> GroupByExt<TSource, TKey>(this IEnumerable<TSource> source,
                 Func<TSource, TKey> keySelector)
        {
            if (source is null || !source.Any())
            {
                throw new InvalidOperationException("Cannot compute GroupByExt for a null or empty set.");
            }

            List<TKey> keys_list = new List<TKey>();
            Dictionary<TKey, List<TSource>> container_dictonory = new Dictionary<TKey, List<TSource>>();

            foreach (TSource s in source)
            {
                TKey key = keySelector(s);
                if (!container_dictonory.ContainsKey(key))
                {
                    container_dictonory.Add(key, new List<TSource> { s });
                    keys_list.Add(key);
                }
                else
                {
                    container_dictonory[key].Add(s);
                }
            }

            foreach (var key in keys_list)
            {
                yield return new Grouping<TKey, TSource>(key, container_dictonory[key]);
            }
        }

        //sorts the elements of a collection in a particular direction (ascending, descending) according to a key
        public static IOrderedEnumerable<TSource> OrderByExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var result = new SortedList<TKey, TSource>();
            foreach (TSource s in source)
            {
                result.Add(keySelector(s), s);
            }
            return new MyOrderBy<TKey, TSource>(result.Values);
        }
        //descending
        public static IOrderedEnumerable<TSource> OrderByDescExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var result = new SortedList<TKey, TSource>();
            foreach (TSource s in source)
            {
                result.Add(keySelector(s), s);
            }

            var descResult = new List<TSource>();
            for (int i = result.Count-1; i >= 0 ; i--)
            {
                descResult.Add(result.Values[i]);
            }
            return new MyOrderBy<TKey, TSource>(descResult);
        }

        //converts a collection into a dictionary according to a specified key selector function
        public static Dictionary<TKey, TSource> ToDictionaryExt<TSource, TKey>(this IEnumerable<TSource> source,
                 Func<TSource, TKey> keySelector)
        {
            var container_dictonory = new Dictionary<TKey, TSource>();
            foreach (TSource s in source)
            {
                var key = keySelector(s);
                try
                {
                    container_dictonory.Add(key, s);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return container_dictonory;
        }
    }
}



