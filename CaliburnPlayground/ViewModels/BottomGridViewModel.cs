using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using CaliburnPlayground.Messages;
using CaliburnPlayground.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace CaliburnPlayground.ViewModels
{
    [Export(typeof(BottomGridViewModel))]
    public class BottomGridViewModel : ViewModelBase, IHandle<SelectedItemChangedMessage>
    {
        private ToDoItem _toDoItem;
        private ObservableCollection<ToDoItemChild> toDoItemChildren;

        public ObservableCollection<ToDoItemChild> ToDoItemChildren
        {
            get { return toDoItemChildren; }
            set
            {
                toDoItemChildren = value;
                NotifyOfPropertyChange(() => ToDoItemChildren);
            }
        }

        [ImportingConstructor]
        public BottomGridViewModel(IEventAggregator eventAggregator, IWindowManager windowManager) : base(eventAggregator, windowManager)
        {
            this.ToDoItemChildren = new ObservableCollection<ToDoItemChild>();
        }


        public void Handle(SelectedItemChangedMessage message)
        {
            this._toDoItem = message.toDoItem;
            ToDoItemChildren.Clear();
            for (int i = 0; i < 20; i++)
            {
                ToDoItemChildren.Add(new ToDoItemChild()
                {
                    Name = "Item" + i,
                    Id = i,
                    ParentName = _toDoItem.Name
                });
            }
        }

        public void OnLostFocus(object source, ToDoItemChild item)
        {
            var t = (source as TextBox);
            var bt = t.GetBindingExpression(TextBox.TextProperty);
            bt.UpdateSource();
        }
    }
}
