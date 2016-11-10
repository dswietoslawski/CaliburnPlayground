using CaliburnPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.Messages
{
    public class SelectedSkuChangedMessage
    {
        public Sku Sku { get; set; }
        public int Count { get; set; }

        public bool IsAggregate { get { return Count != 1; } }
    }
}
