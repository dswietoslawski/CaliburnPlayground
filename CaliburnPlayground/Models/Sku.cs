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
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                NotifyOfPropertyChange(() => IsChecked);
            }
        }

        public IEnumerable<StoreMarket> Rodzice;

        public string Size
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Size);
            }
        }

        public string Part
        {
            get { return _size; }
            set
            {
                _size = value;
                NotifyOfPropertyChange(() => Part);
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
            return (Part + Model).GetHashCode();
        }

        public bool Equals(Sku other)
        {
            if (other == null) return false;
            var x = Model.Equals(other.Model) && Part.Equals(other.Part) && Size.Equals(other.Size);
            return x;
        }

        internal void recalculate()
        {
            this.SumQty = Rodzice.Sum(m => m.Quantity);
        }

        public override string ToString()
        {
            return Size;
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

    }
}
