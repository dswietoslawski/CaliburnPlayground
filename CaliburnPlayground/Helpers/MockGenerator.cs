using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.Helpers
{
    public static class MockGenerator
    {
        public static IEnumerable<T> GenerateOf<T>(int howMany)
        {
            return Builder<T>.CreateListOfSize(howMany).Build();
        }

        public static ICollection<T> GenerateCollectionOf<T>(int howMany)
        {
            return Builder<T>.CreateListOfSize(howMany).Build();
        }

        private static readonly Random randomNumber = new Random();
        public static T GiveMeOne<T>(params T[] fromThis)
        {
            return fromThis[randomNumber.Next(fromThis.Length)];
        }
        public static IEnumerable<T> GiveMeALot<T>(int amount, params T[] fromThis)
        {
            for (int i = 0; i < amount; i++)
            {
                yield return fromThis[randomNumber.Next(fromThis.Length)];
            }
        }

        public static Dictionary<T, ICollection<T1>> GenerateDictionaryOf<T, T1>(int howManySubElements, params T[] fromThis)
        {
            Dictionary<T, ICollection<T1>> result = new Dictionary<T, ICollection<T1>>();
            var items = GiveMeALot(20, fromThis);

            foreach (var item in items)
            {
                var subItems = Builder<T1>.CreateListOfSize(howManySubElements).Build();
                if (!result.Keys.Contains(item))
                    result.Add(item, subItems);
            }
            return result;
        }
    }
}
