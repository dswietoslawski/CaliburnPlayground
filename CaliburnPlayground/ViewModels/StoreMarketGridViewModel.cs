using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using CaliburnPlayground.Messages;
using CaliburnPlayground.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using CaliburnPlayground.Services;

namespace CaliburnPlayground.ViewModels
{
    [Export(typeof(StoreMarketGridViewModel))]
    public class StoreMarketGridViewModel : StoreMarketGridViewModelBase, IHandle<SelectedSkuChangedMessage>
    {
        [ImportingConstructor]
        public StoreMarketGridViewModel(IEventAggregator eventAggregator, IWindowManager windowManager) : base(eventAggregator, windowManager)
        {

        }

        public void Handle(SelectedSkuChangedMessage message)
        {
            if (message.Sku == null || (_storeMarkets != null && (message.Sku.Equals(StoreMarkets)))) return;

            var qt = message.Sku.SumQty;
            if (message.Sku != null)
            {
                this._sku = message.Sku;
                StoreMarkets.Clear();
                StoreMarkets.AddRange(_skuService.GetMarkets(_sku));
            }
            _sku.Rodzice = StoreMarkets;
        }

        public void OnLostFocus(object source, StoreMarket item)
        {
            var t = (source as TextBox);
            var bt = t.GetBindingExpression(TextBox.TextProperty);
            bt.UpdateSource();

            _sku.recalculate();
        }
    }
}
