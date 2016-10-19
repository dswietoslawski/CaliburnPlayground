using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.Models
{
    public class Sku : PropertyChangedBase, IEquatable<Sku>
    {
        private string _name;
        private string _size;
        private string _model;
        private int _sumQty;

        public IEnumerable<StoreMarket> Rodzice;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
                NotifyOfPropertyChange(() => Size);
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                NotifyOfPropertyChange(() => Model);
            }
        }

        public int SumQty
        {
            get { return _sumQty; }
            set
            {
                _sumQty = value;
                NotifyOfPropertyChange(() => SumQty);
            }
        }

        public override int GetHashCode()
        {
            return (Size + Model).GetHashCode();
        }

        public bool Equals(Sku other)
        {
            if (other == null) return false;
            var x = Model.Equals(other.Model) && Size.Equals(other.Size);
            return x;
        }

        internal void recalculate()
        {
            this.SumQty = Rodzice.Sum(m => m.Quantity);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
