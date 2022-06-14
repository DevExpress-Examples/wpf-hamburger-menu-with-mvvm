using Hamburger.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Hamburger.TemplateSelectors
{
    public class HamburgerMenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemTemplate { get; set; }
        public DataTemplate SubItemTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is HamburgerSubMenuItemViewModel)
                return SubItemTemplate;
            if (item is HamburgerMenuItemViewModel)
                return ItemTemplate;
            return base.SelectTemplate(item, container);
        }
    }
}
