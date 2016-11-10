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
            Skus.Add(new Sku() { Model = "UnoModello", Size = "KZ", Part = "BestPart", SumQty = 30 });
            for (int i = 0; i < 30; i++)
            {
                Skus.Add(new Sku() { Model = "Modelia", Size = "L" + i, Part = "OnePart", SumQty = 30 });
            }

            foreach (var sku in Skus)
            {
                var storeMarkets = MockGenerator.GenerateOf<StoreMarket>(10).ToList();

                foreach (var storeMarket in storeMarkets)
                {
                    storeMarket.Quantity = 3;
                    storeMarket.ParentName = sku.Size;
                }

                StoreMarkets.AddRange(storeMarkets);
            }
        }
    }
}