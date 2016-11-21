using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaliburnPlayground.ViewModels;

namespace CaliburnPlayground.Models
{
    public class StoreMarket : Recalculatable
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        public int SkuId { get; set; }

        public Sku Sku { get; set; }

        private int id;
        private string parentName;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        public string Size
        {
            get { return parentName; }
            set
            {
                parentName = value;
                NotifyOfPropertyChange(() => Size);
            }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyOfPropertyChange(() => Quantity);
            }
        }

        private string destinationId;

        public string DestinationId
        {
            get { return destinationId; }
            set { destinationId = value; }
        }

        private string customerId;

        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public AggrMarket MarketGroup { get; internal set; }

        public override void Recalculate()
        {
            Sku?.Recalculate();
            MarketGroup?.Recalculate();
        }
    }
}
