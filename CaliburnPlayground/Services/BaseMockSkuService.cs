using CaliburnPlayground.Helpers;
using CaliburnPlayground.Models;
using System.Collections.Generic;
using System.Linq;
namespace CaliburnPlayground.Services
{
    public class BaseMockSkuService
    {
        public static List<Sku> Skus = new List<Sku>();
        public static List<StoreMarket> StoreMarkets = new List<StoreMarket>();


        static BaseMockSkuService()
        {
            for (int i = 0; i < 5; i++)
            {
                Skus.Add(new Sku() { Model = "Asfalt", Name = "Korea" + i, Size = "1 inch", SumQty = 30 });
            }
            Skus.Add(new Sku() { Model = "Polska", Name = "BialoCzerwoni", Size = "5 inch", SumQty = 30 });

            foreach (var sku in Skus)
            {
                var storeMarkets = MockGenerator.GenerateOf<StoreMarket>(10).ToList();

                foreach (var storeMarket in storeMarkets)
                {
                    storeMarket.Quantity = 3;
                    storeMarket.ParentName = sku.Name;
                }

                StoreMarkets.AddRange(storeMarkets);
            }
        }
    }
}