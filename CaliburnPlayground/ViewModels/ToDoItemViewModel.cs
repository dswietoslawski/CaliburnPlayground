using Caliburn.Micro;
using CaliburnPlayground.Messages;
using CaliburnPlayground.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaliburnPlayground.ViewModels
{
    [Export(typeof(ToDoItemViewModel))]
    public class ToDoItemViewModel : BaseTabViewModel, IHandle<SimpleCheckMessage>
    {
        private BindableCollection<ToDoItem> toDoItems;

        public BindableCollection<ToDoItem> ToDoItems
        {
            get { return toDoItems; }
            set
            {
                toDoItems = value;
                NotifyOfPropertyChange(() => ToDoItems);
            }
        }

        public IEnumerable<ToDoItem> ToDoItemsAggr
        {
            get {
                var x = ToDoItems.GroupBy(m => m.Sku + m.Size);
                foreach(var y in x)
                {
                    yield return y.First();
                }
            }
        }

        private ToDoItem _selectedItem;
        public ToDoItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
                _eventAggregator.PublishOnUIThread(new SelectedItemChangedMessage() { toDoItem = _selectedItem });
            }
        }

        [ImportingConstructor]
        public ToDoItemViewModel(IEventAggregator eventAggregator, IWindowManager windowManager) : base("To do items", eventAggregator, windowManager)
        {
            IsEnabled = true;
            ToDoItems = new BindableCollection<ToDoItem>();
        }


        public void Handle(SimpleCheckMessage message)
        {
            MessageBox.Show(DisplayName);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            for (int i = 0; i < 20; i++)
            {
                ToDoItems.Add(new ToDoItem()
                {
                    Name = "Item" + i,
                    Size = i % 2 == 0 ? "Nyan" : "Bark",
                    Sku = i % 3 == 0 ? "piotrek" : "Dupa"
                });
            }

        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            ToDoItems.Clear();
        }
    }
}
