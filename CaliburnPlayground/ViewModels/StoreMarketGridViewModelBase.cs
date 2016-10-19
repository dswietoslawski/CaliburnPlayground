using Caliburn.Micro;
using CaliburnPlayground.Models;
using CaliburnPlayground.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace CaliburnPlayground.ViewModels
{
    public class StoreMarketGridViewModelBase : ViewModelBase
    {
        protected Sku _sku;
        protected BindableCollection<StoreMarket> _storeMarkets;
        protected SkuService _skuService;


        public BindableCollection<StoreMarket> StoreMarkets
        {
            get { return _storeMarkets; }
            set
            {
                _storeMarkets = value;
                NotifyOfPropertyChange(() => StoreMarkets);
            }
        }

        public StoreMarketGridViewModelBase(IEventAggregator eventAggregator, IWindowManager windowManager) : base(eventAggregator, windowManager)
        {
            this.StoreMarkets = new BindableCollection<StoreMarket>();
            _skuService = new SkuService();
            
        }
    }
}
