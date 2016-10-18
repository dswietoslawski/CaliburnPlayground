using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayground.ViewModels
{
    [Export(typeof(GridContainerViewModel))]
    public class GridContainerViewModel : ConductorBase
    {
        public ToDoItemViewModel ToDoItemVM { get; set; }
        public DashboardViewModel Dashboard { get; set; }
        public ObservableCollection<BaseTabViewModel> Tabs { get; set; }
        public BottomGridViewModel BottomGrid { get; set; }

        [ImportingConstructor]
        public GridContainerViewModel(ToDoItemViewModel toDoItemVM, BottomGridViewModel bottomGrid, DashboardViewModel dashboard, IEventAggregator eventAggregator, IWindowManager windowManager) : base(eventAggregator, windowManager)
        {
            ToDoItemVM = toDoItemVM;
            Dashboard = dashboard;
            BottomGrid = bottomGrid;
        }


        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            foreach (var item in Items)
                DeactivateItem(item, true);
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            ActivateItem(ToDoItemVM);
            ActivateItem(Dashboard);
            ActivateItem(BottomGrid);
        }

    }
}
