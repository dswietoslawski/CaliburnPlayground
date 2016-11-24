using Caliburn.Micro;
using CaliburnPlayground.Messages;
using CaliburnPlayground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.ViewModels
{
    public class BaseSkuViewModel : ViewModelBase
    {

        private BindableCollection<BaseSku> _skus;

        public BaseSkuViewModel(IEventAggregator eventAggregator, IWindowManager windowManager) : base(eventAggregator, windowManager)
        {
            Skus = new BindableCollection<BaseSku>();
        }

        public BindableCollection<BaseSku> Skus
        {
            get { return _skus; }
            set
            {
                _skus = value;
                NotifyOfPropertyChange(() => Skus);
            }
        }

        private BaseSku _selectedSku;
        public BaseSku SelectedSku
        {
            get { return _selectedSku; }
            set
            {
                _selectedSku = value;
                NotifyOfPropertyChange(() => SelectedSku);
                _eventAggregator.PublishOnUIThread(new SelectedSkuChangedMessage() { Sku = SelectedSku, Count = 1 });
            }
        }

    }
}
