using Caliburn.Micro;
using CaliburnPlayground.Messages;
using System.ComponentModel.Composition;
using System;
using CaliburnPlayground.Models;

namespace CaliburnPlayground.ViewModels
{
    [Export(typeof(DashboardViewModel))]
    public class DashboardViewModel : ViewModelBase, IHandle<SelectedItemChangedMessage>
    {
        private string name;
        private ToDoItem _toDoItem;

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

        public void Handle(SelectedItemChangedMessage message)
        {
            _toDoItem = message.toDoItem;
            Name = _toDoItem.Name;
        }

        protected override void OnDeactivate(bool close)
        {
            Name = "";
        }
    }
}