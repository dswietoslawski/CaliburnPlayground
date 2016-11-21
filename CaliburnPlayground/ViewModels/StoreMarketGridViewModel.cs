using Caliburn.Micro;
using System.ComponentModel.Composition;
using CaliburnPlayground.Messages;
using CaliburnPlayground.Models;
using System.Windows.Controls;

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
            IsVisible = !message.IsAggregate;
            if (message.Sku == null || (_storeMarkets != null && (message.Sku.Equals(_sku)))) return;
            this._sku = message.Sku;
            refreshStoreMarkets();
            _sku.StoreMarkets = StoreMarkets;
        }

        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }


        private void refreshStoreMarkets()
        {
            StoreMarkets.Clear();
            StoreMarkets.AddRange(_skuService.GetMarkets(_sku));
        }

        public void OnLostFocus(object source, StoreMarket item)
        {
            var t = (source as TextBox);
            var bt = t.GetBindingExpression(TextBox.TextProperty);
            bt.UpdateSource();

            item.Recalculate();
        }
    }
}
