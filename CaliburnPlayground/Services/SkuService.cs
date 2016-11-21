using CaliburnPlayground.Models;
using CaliburnPlayground.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.Services
{
    public class SkuService : BaseMockSkuService
    {
        public IEnumerable<Sku> Get()
        {
            return Skus;
        }

        public ICollection<StoreMarket> GetMarkets(Sku sku)
        {
            var result = StoreMarkets.Where(m => m.SkuId == sku.SkuId).ToList();
            result.ForEach(m => m.Sku = sku);

            return result;
        }
    }
}
