using Caliburn.Micro;
using CaliburnPlayground.Messages;
using System.ComponentModel.Composition;
using System;
using CaliburnPlayground.Models;

namespace CaliburnPlayground.ViewModels
{
    [Export(typeof(DashboardViewModel))]
    public class DashboardViewModel : ViewModelBase, IHandle<SelectedSkuChangedMessage>
    {
        private string name;
        private Sku _toDoItem;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        [ImportingConstructor]
        public DashboardViewModel(IEventAggregator eventAggregator, IWindowManager windowManager) : base(eventAggregator, windowManager)
        {
            DisplayName = "Dashboard";
        }

        public void Handle(SelectedSkuChangedMessage message)
        {
            if (message.Sku != null)
            {
                _toDoItem = message.Sku;
                Name = _toDoItem.Name;
            }
        }

        protected override void OnDeactivate(bool close)
        {
            Name = "";
        }
    }
}