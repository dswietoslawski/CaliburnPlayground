using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.ViewModels
{
    public class ConductorBase : Conductor<ViewModelBase>.Collection.AllActive
    {
        protected IWindowManager _windowManager;
        protected IEventAggregator _eventAggregator;

        public ConductorBase( IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
        }
    }
}
