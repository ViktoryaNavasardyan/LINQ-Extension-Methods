# LINQ-Extension-Methods
Create a library which implements the following LINQ extension methods
SelectExt method which projects the elements into a new form. IEnumerable<TResult> SelectExt <TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
WhereExt method filters elements from a collection based on a predicate. IEnumerable<TSource> WhereExt<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
GroupByExt method groups the elements of a sequence according to a specified key selector function. IEnumerable<IGrouping<TKey, TSource>> GroupByExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
ToListExt which returns a collection as a List. List<TSource> ToListExt<TSource>(this IEnumerable<TSource> source)
OrderByExt sorts the elements of a collection in a particular direction (ascending, descending) according to a key. This methods has 2 overloads. IOrderedEnumerable<TSource> OrderByExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
ToDictionaryExt method converts a collection into a dictionary according to a specified key selector function. Dictionary<TKey, TSource> ToDictionaryExt<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
