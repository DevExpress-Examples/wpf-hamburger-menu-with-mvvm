using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System;

namespace Hamburger.ViewModel {
    public class MainViewModel : NavigationViewModelBase {
        public HamburgerMenuItemViewModel SelectedItem {
            get { return GetProperty(() => SelectedItem); }
            set { SetProperty(() => SelectedItem, value); }
        }

        public bool IsMenuVisible {
            get { return GetProperty(() => IsMenuVisible); }
            set { SetProperty(() => IsMenuVisible, value); }
        }
        public ObservableCollection<HamburgerMenuItemViewModel> Items {
            get { return GetProperty(() => Items); }
            set { SetProperty(() => Items, value); }
        }
        public ObservableCollection<HamburgerSubMenuItemViewModel> SubItems
        {
            get { return GetProperty(() => SubItems); }
            set { SetProperty(() => SubItems, value); }
        }
        INavigationService NavigationService { get { return GetService<INavigationService>(); } }
        public MainViewModel() {
            Items = new ObservableCollection<HamburgerMenuItemViewModel>();
            Items.Add(new HamburgerSubMenuItemViewModel("Main Page", typeof(MainPage)) {
                SubItems = new ObservableCollection<HamburgerSubMenuItemViewModel>() {
                    new HamburgerSubMenuItemViewModel("SubMenu1", typeof(MainPage)),
                    new HamburgerSubMenuItemViewModel("SubMenu", typeof(MainPage_SubPage))
                }
            });
            Items.Add(new HamburgerMenuItemViewModel("Simple Page", typeof(SimplePage)));
            SelectedItem = Items[0];

            IsMenuVisible = true;
        }
    }
    public class HamburgerMenuItemViewModel : ISupportParentViewModel {
        public string Caption { get; set; }
        public Type PageName { get; set; }
        public ObservableCollection<HamburgerSubMenuItemViewModel> SubItems { get; internal set; }
        public object ParentViewModel { get; set; }

        public HamburgerMenuItemViewModel(string caption, Type pageName) {
            Caption = caption;
            PageName = pageName;
        }
    }

    public class HamburgerSubMenuItemViewModel : HamburgerMenuItemViewModel
    {
        public HamburgerSubMenuItemViewModel(string caption, Type pageName) : base(caption, pageName) {}
    }
}

