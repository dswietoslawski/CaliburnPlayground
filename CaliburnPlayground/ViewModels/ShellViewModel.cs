using Caliburn.Micro;
using CaliburnPlayground.Messages;
using CaliburnPlayground.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.ViewModels
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : Conductor<ConductorBase>
    {
        private IEventAggregator _eventAggregator;

        private GridContainerViewModel _gridContainerVM { get; set; }

        [ImportingConstructor]
        public ShellViewModel(GridContainerViewModel gridContainerVM, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _gridContainerVM = gridContainerVM;
            DisplayName = "Applicationez";
        }

        public void ToggleToDoItems()
        {
            if (ActiveItem == _gridContainerVM)
                DeactivateItem(ActiveItem, true);
            else
                ActivateItem(_gridContainerVM);
        }
        
    }
}
