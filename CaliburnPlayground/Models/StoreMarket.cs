using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.Models
{
    public class StoreMarket : PropertyChangedBase
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

        public string ParentName
        {
            get { return parentName; }
            set
            {
                parentName = value;
                NotifyOfPropertyChange(() => ParentName);
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
    }
}
