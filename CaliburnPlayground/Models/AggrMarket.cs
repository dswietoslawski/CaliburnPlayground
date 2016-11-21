using System.Collections.Generic;
using System.Linq;

namespace CaliburnPlayground.Models
{
    public class AggrMarket : StoreMarket
    {
        private IEnumerable<StoreMarket> markets;

        public AggrMarket(IEnumerable<StoreMarket> markets)
        {
            this.markets = markets;
            this.CustomerId = markets.First().CustomerId;
            this.DestinationId = markets.First().DestinationId;

            foreach (var market in markets)
                market.MarketGroup = this;

            Recalculate();
        }

        public override void Recalculate()
        {
            SumQty = markets.Sum(m => m.Quantity);
        }

        private int sumQty;

        public int SumQty
        {
            get { return sumQty; }
            set
            {
                sumQty = value;
                NotifyOfPropertyChange();
            }
        }

    }
}
