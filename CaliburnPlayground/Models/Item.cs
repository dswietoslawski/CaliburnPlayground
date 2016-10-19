using System;
using System.Collections.Generic;
using System.Linq;

namespace CaliburnPlayground.Models
{
    public class Item : Sku, IEquatable<Sku>
    {
        public IEnumerable<Sku> AggregatedItems;

        public Item(IEnumerable<Sku> skus)
        {
            AggregatedItems = skus;
            foreach (var sku in skus)
                sku.PropertyChanged += Item_PropertyChanged;
            Copy(skus);
            Aggregate();
        }

        private void Copy(IEnumerable<Sku> skus)
        {
            this.Size = skus.First().Size;
            this.Name = skus.First().Name;
            this.Model = skus.First().Model;
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Aggregate();
        }

        public void Aggregate()
        {
            this.SumQty = AggregatedItems.Sum(m => m.SumQty);
        }

        public override int GetHashCode()
        {
            return (Size + Model).GetHashCode();
        }
    }
}