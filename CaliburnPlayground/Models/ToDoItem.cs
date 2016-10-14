using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.Models
{
    public class ToDoItem : PropertyChangedBase
    {
        private string name;
        private string size;
        private string sku;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
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

        public string Sku
        {
            get { return sku; }
            set
            {
                sku = value;
                NotifyOfPropertyChange(() => Sku);
            }
        }
    }
}
