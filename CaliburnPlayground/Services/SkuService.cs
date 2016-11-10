using CaliburnPlayground.Models;
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

        public IEnumerable<StoreMarket> GetMarkets(Sku sku)
        {
            return StoreMarkets.Where(m => m.ParentName == sku.Size);
        }
    }
}
