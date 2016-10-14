using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.ViewModels
{
    public class BaseTabViewModel : ViewModelBase
    {
        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                NotifyOfPropertyChange(() => IsEnabled);
            }
        }

        public BaseTabViewModel(string displayName, IEventAggregator eventAggregator, IWindowManager windowManager) : base(eventAggregator, windowManager)
        {
            DisplayName = displayName;
        }
    }
}
