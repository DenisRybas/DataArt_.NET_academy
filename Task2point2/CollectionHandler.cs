using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2point2
{
    public class CollectionHandler<T> where T : IComparable
    {
        public IList<T> Add(IList<T> collection, T value)
        {
            var prevElement = collection.FirstOrDefault();
            var isAdded = false;
            for (var i = 0; i < collection.Count; i++)
            {
                if (prevElement != null && prevElement.CompareTo(collection[i]) == 1)
                    throw new InvalidOperationException("The collection is not sorted. " +
                                                        "Sort it before adding new element");
                prevElement = collection[i];
                if (isAdded || collection[i].CompareTo(value) == -1) continue;
                collection.Insert(i, value);
                isAdded = true;
            }

            if (!isAdded)
                collection.Add(value);

            if (collection.Count == 0)
                collection.Add(value);

            return collection;
        }

        public bool IsSorted(IList<T> collection)
        {
            var prevElement = collection.FirstOrDefault();
            foreach (var element in collection)
            {
                if (prevElement != null && prevElement.CompareTo(element) == 1)
                    return false;
                prevElement = element;
            }

            return true;
        }
    }
}