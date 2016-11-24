using Caliburn.Micro;

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
