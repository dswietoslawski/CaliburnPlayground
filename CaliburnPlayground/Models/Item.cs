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
            this.Part = skus.First().Part;
            this.Size = skus.First().Size;
            this.Model = skus.First().Model;
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Aggregate();
        }

        public void Aggregate()
        {
            this.SumQty = AggregatedItems.Sum(m => m.SumQty);
            this.ToDoMarker = AggregatedItems.Any(m => m.ToDoMarker);
        }

        public override int GetHashCode()
        {
            return (Part + Model + Size).GetHashCode();
        }

        internal void changeToDoMarker(bool value)
        {
            foreach (var sku in AggregatedItems)
                sku.ToDoMarker = value;
        }
    }
}