using Common.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace XFCustomControlSample.ViewModels
{
    public class ExpandableItemsViewModel : ViewModelBase
    {
        private ProductGroup _selectedGroup = null;
        public ProductGroup SelectedGroup
        {
            get { return _selectedGroup; }
            set {
                _selectedGroup = value;
                OnPropertyChanged("SelectedGroup");
            }
        }


        private ObservableCollection<ProductGroup> _items;
        public ObservableCollection<ProductGroup> Items
        {
            get {
                if (_items == null) Items = new ObservableCollection<ProductGroup>();
                return _items;
            }
            set {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
        
        public override void OnAppeared()
        {
            LoadItems();
        }

        private async Task LoadItems()
        {
            IsLoading = true;
            await Task.Delay(1000);

            IsLoading = false;
        }
    }
}
