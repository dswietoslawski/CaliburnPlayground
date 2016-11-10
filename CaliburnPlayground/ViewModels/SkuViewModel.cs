using Caliburn.Micro;
using CaliburnPlayground.Messages;
using CaliburnPlayground.Models;
using CaliburnPlayground.Services;
using CaliburnPlayground.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CaliburnPlayground.ViewModels
{
    [Export(typeof(SkuViewModel))]
    public class SkuViewModel : ViewModelBase
    {
        private BindableCollection<Sku> _skus;

        public BindableCollection<Sku> Skus
        {
            get { return _skus; }
            set
            {
                _skus = value;
                NotifyOfPropertyChange(() => Skus);
            }
        }

        private BindableCollection<Item> _items;
        public BindableCollection<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                NotifyOfPropertyChange(() => Items);
            }
        }

        private Sku _selectedSku;
        public Sku SelectedSku
        {
            get { return _selectedSku; }
            set
            {
                _selectedSku = value;
                NotifyOfPropertyChange(() => SelectedSku);
                _eventAggregator.PublishOnUIThread(new SelectedSkuChangedMessage() { Sku = SelectedSku, Count = 1 });
            }
        }

        private Item _selectedItem;
        private SkuService skuService;

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
                _eventAggregator.PublishOnUIThread(new SelectedSkuChangedMessage() { Sku = SelectedItem.AggregatedItems.First(), Count = SelectedItem.AggregatedItems.Count() });
            }
        }

        [ImportingConstructor]
        public SkuViewModel(IEventAggregator eventAggregator, IWindowManager windowManager) : base(eventAggregator, windowManager)
        {
            Skus = new BindableCollection<Sku>();
            Items = new BindableCollection<Item>();
            skuService = new SkuService();
        }

        protected override void OnActivate()
        {
            Skus.AddRange(skuService.Get());
            var groupedItems = Skus.GroupBy(m => m.Model + m.Part);
            foreach (var y in groupedItems)
                Items.Add(new Item(y));
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            Skus.Clear();
            base.OnDeactivate(close);
        }

        public void OnItemsLoaded()
        {
            if (SelectedSku != null)
                SelectedItem = Items.First(m => m.Model == SelectedSku.Model && m.Part == SelectedSku.Part);
        }

        public void OnSkusLoaded()
        {
            if (SelectedItem != null)
                SelectedSku = Skus.First(m => m.Model == SelectedItem.Model && m.Part == SelectedItem.Part);
        }

        public void CheckAllSkus(bool value)
        {
            Skus.ForEach(m => m.IsChecked = value);
            NotifyOfPropertyChange(() => CanAddSkuToCart);
        }

        public void AddSkuToCart()
        {

        }

        public void CheckSku(bool value, Sku sku)
        {
            NotifyOfPropertyChange(() => CanAddSkuToCart);
        }

        public bool CanAddSkuToCart
        {
            get { return Skus.Any(m => m.IsChecked); }
        }

        public void CheckItemMarker(bool value, Item item)
        {
            item.changeToDoMarker(value);
        }
    }
}