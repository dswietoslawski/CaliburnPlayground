﻿using Caliburn.Micro;
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
        public SkuViewModel SkuGrid { get; set; }
        public StoreMarketGridViewModel StoreMarketGrid { get; set; }

        [ImportingConstructor]
        public GridContainerViewModel(SkuViewModel skuGrid, StoreMarketGridViewModel storeMarketGrid, IEventAggregator eventAggregator, IWindowManager windowManager) : base(eventAggregator, windowManager)
        {
            SkuGrid = skuGrid;
            StoreMarketGrid = storeMarketGrid;
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

            ActivateItem(SkuGrid);
            ActivateItem(StoreMarketGrid);
        }

    }
}
