using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.Models
{
    public class Sku : Recalculatable, IEquatable<Sku>
    {
        private string size;
        private string part;
        private string model;
        private bool isChecked;
        private int sumQty;
        
        public int SkuId;

        public int SumQty
        {
            get { return sumQty; }
            set
            {
                sumQty = value;
                NotifyOfPropertyChange();
            }
        }


        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
            }
        }

        private ICollection<StoreMarket> storeMarkets;

        public ICollection<StoreMarket> StoreMarkets
        {
            get { return storeMarkets; }
            set
            {
                storeMarkets = value;
                NotifyOfPropertyChange();
            }
        }


        public string Size
        {
            get { return size; }
            set
            {
                size = value;
                NotifyOfPropertyChange(() => Size);
            }
        }

        public string Part
        {
            get { return part; }
            set
            {
                part = value;
                NotifyOfPropertyChange(() => Part);
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                NotifyOfPropertyChange(() => Model);
            }
        }

        public override int GetHashCode()
        {
            return (Part + Model).GetHashCode();
        }

        public bool Equals(Sku other)
        {
            if (other == null) return false;
            var x = Model.Equals(other.Model) && Part.Equals(other.Part) && Size.Equals(other.Size);
            return x;
        }

        public override string ToString()
        {
            return Size;
        }

        public override void Recalculate()
        {
            SumQty = storeMarkets.Sum(m => m.Quantity);
            Item.Recalculate();
        }

        private bool toDoMarker;

        public bool ToDoMarker
        {
            get { return toDoMarker; }
            set
            {
                toDoMarker = value;
                NotifyOfPropertyChange(() => ToDoMarker);
            }
        }

        public Item Item { get; internal set; }
    }
}
