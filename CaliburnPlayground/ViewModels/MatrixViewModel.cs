using Caliburn.Micro;
using CaliburnPlayground.Models;
using CaliburnPlayground.Services;
using CaliburnPlayground.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CaliburnPlayground.ViewModels
{
    public class MatrixViewModel : ViewModelBase
    {
        private BindableCollection<Item> items;
        private SkuService skuService;

        public BindableCollection<Item> Items
        {
            get { return items; }
            set
            {
                items = value;
                NotifyOfPropertyChange();
            }
        }

        private BindableCollection<AggrMarket> aggregatedMarkets;

        public BindableCollection<AggrMarket> AggregatedMarkets
        {
            get { return aggregatedMarkets; }
            set { aggregatedMarkets = value; NotifyOfPropertyChange(); }

        }
        public MatrixViewModel(IEventAggregator eventAggregator, IWindowManager windowManager, IEnumerable<Item> items, Sku selectedSku) : base(eventAggregator, windowManager)
        {
            skuService = new SkuService();
            Items = new BindableCollection<Item>(items);
            foreach (var item in items)
            {
                foreach (var sku in item.Skus)
                {
                    if (sku != selectedSku)
                        sku.StoreMarkets = skuService.GetMarkets(sku);
                }
            }
            AggregatedMarkets = new BindableCollection<AggrMarket>();
            createMatrix(Items);
        }

        private void createMatrix(IEnumerable<Item> items)
        {
            var markets = new List<StoreMarket>();
            items.ForEach(item =>
                item.Skus.ForEach(sku => sku.StoreMarkets.ForEach(store => markets.Add(store))));

            markets.GroupBy(m => m.DestinationId + m.CustomerId)
                .ForEach(m => AggregatedMarkets.Add(new AggrMarket(m)));

            foreach (var item in items)
            {
                foreach (var sku in item.Skus)
                {
                    var tempaLista = new List<StoreMarket>();

                    foreach (var market in AggregatedMarkets)
                    {
                        var tempMarket = sku.StoreMarkets.FirstOrDefault(m => m.CustomerId + m.DestinationId == market.CustomerId + market.DestinationId);
                        if (tempMarket == null)
                            tempMarket = new StoreMarket();
                        tempaLista.Add(tempMarket);
                    }
                    sku.StoreMarkets = tempaLista;
                }
            }
        }

        public void OnLostFocus(object source, StoreMarket storeMarket)
        {
            var t = (source as TextBox);
            var bt = t.GetBindingExpression(TextBox.TextProperty);
            bt.UpdateSource();

            items.ForEach(m => m.Skus.Where(n => n.SkuId == storeMarket.SkuId).FirstOrDefault()?.Recalculate());
            storeMarket.Recalculate();
        }
    }
}