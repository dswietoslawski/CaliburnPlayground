using Caliburn.Micro;

namespace CaliburnPlayground.ViewModels
{
    public class ViewModelBase : Screen
    {
        protected IWindowManager _windowManager;
        protected IEventAggregator _eventAggregator;

        public ViewModelBase(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
        }
        
        protected override void OnActivate()
        {
            base.OnActivate();
            _eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            _eventAggregator.Unsubscribe(this);
        }
    }
}