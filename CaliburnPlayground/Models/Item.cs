using System;
using System.Collections.Generic;
using System.Linq;

namespace CaliburnPlayground.Models
{
    public class Item : Sku, IEquatable<Sku>
    {
        private IEnumerable<Sku> skus;

        public IEnumerable<Sku> Skus
        {
            get { return skus; }
            set
            {
                skus = value;
                NotifyOfPropertyChange();
            }
        }


        public Item(IEnumerable<Sku> skus)
        {
            Skus = skus;
            foreach (var sku in skus)
                sku.Item = this;
            Copy(skus);
            Recalculate();
        }

        private void Copy(IEnumerable<Sku> skus)
        {
            this.Part = skus.First().Part;
            this.Size = skus.First().Size;
            this.Model = skus.First().Model;
        }

        public override void Recalculate()
        {
            this.SumQty = Skus.Sum(m => m.SumQty);
            this.ToDoMarker = Skus.Any(m => m.ToDoMarker);
            this.IsChecked = Skus.Any(m => m.IsChecked);
        }

        public override int GetHashCode()
        {
            return (Part + Model + Size).GetHashCode();
        }

        internal void changeToDoMarker(bool value)
        {
            foreach (var sku in Skus)
                sku.ToDoMarker = value;
        }
    }
}