using CaliburnPlayground.Helpers;
using CaliburnPlayground.Models;
using CaliburnPlayground.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;
namespace CaliburnPlayground.Services
{
    public class BaseMockSkuService
    {
        public static List<Sku> Skus = new List<Sku>();
        public static ICollection<StoreMarket> StoreMarkets = new List<StoreMarket>();


        static BaseMockSkuService()
        {
            Skus.Add(new Sku() { Model = "UnoModello", Size = "KZ", Part = "BestPart", SkuId = 0 });
            for (int i = 0; i < 30; i++)
            {
                Skus.Add(new Sku() { Model = "Modelia", Size = "L" + i, Part = "OnePart", SkuId = i + 1 });
            }

            StoreMarkets = new List<StoreMarket>();

            int z = 0;

            foreach (var sku in Skus)
            {
                var marketos = MockGenerator.GenerateOf<StoreMarket>(20).ToList();
                foreach (var storeMarket in marketos)
                {
                    storeMarket.Quantity = 3;
                    storeMarket.SkuId = sku.SkuId;
                    storeMarket.CustomerId = storeMarket.CustomerId;
                    storeMarket.DestinationId = storeMarket.DestinationId;
                }

                if (z % 2 == 0)
                    StoreMarkets.AddRange(marketos);
                else
                    StoreMarkets.AddRange(marketos.Take(10));
                z++;
            }

            foreach (var sku in Skus)
            {
                sku.SumQty = StoreMarkets.Where(y => y.SkuId == sku.SkuId).Sum(m => m.Quantity);
            }

        }
    }
}