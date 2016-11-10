using Caliburn.Micro;
using CaliburnPlayground.Models;
using CaliburnPlayground.Services;


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
