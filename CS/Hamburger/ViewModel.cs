using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System;

namespace Hamburger.ViewModel {
    public class MainViewModel : NavigationViewModelBase {
        public HamburgerMenuItemViewModel SelectedItem {
            get { return GetProperty(() => SelectedItem); }
            set { SetProperty(() => SelectedItem, value, OnSelectedItemChanged); }
        }

        public bool IsMenuVisible {
            get { return GetProperty(() => IsMenuVisible); }
            set { SetProperty(() => IsMenuVisible, value); }
        }
        public ObservableCollection<HamburgerMenuItemViewModel> Items {
            get { return GetProperty(() => Items); }
            set { SetProperty(() => Items, value); }
        }
        INavigationService NavigationService { get { return GetService<INavigationService>(); } }
        public MainViewModel() {
            Items = new ObservableCollection<HamburgerMenuItemViewModel>();
            Items.Add(new HamburgerMenuItemViewModel("Main Page", "MainPage"));
            Items.Add(new HamburgerMenuItemViewModel("Simple Page", "SimplePage"));
            SelectedItem = Items[0];
        }
        void OnSelectedItemChanged() {
            if (SelectedItem != null) {
                IsMenuVisible = SelectedItem.Caption != "Simple Page";
            }
        }
    }
    public class HamburgerMenuItemViewModel {
        public string Caption { get; set; }
        public string PageName { get; set; }
        public HamburgerMenuItemViewModel(string caption, string pageName) {
            Caption = caption;
            PageName = pageName;
        }
    }
}

