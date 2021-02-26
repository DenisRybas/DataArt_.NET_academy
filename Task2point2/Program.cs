using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2point2
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<DateTime>()
            {
                new DateTime(2021, 1, 12, 12, 0, 0),
                new DateTime(2021, 1, 13, 13, 0, 0),
                new DateTime(2021, 1, 14, 14, 0, 0),
                new DateTime(2021, 1, 15, 15, 0, 0),
            };
            var collectionHandler = new CollectionHandler<DateTime>();
            var newCollection = collectionHandler.Add(collection,
                new DateTime(2021, 1, 14, 15, 0, 0)
            );
            newCollection.ToList().ForEach(i => Console.WriteLine(i.ToString()));
        }
    }
}