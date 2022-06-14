Imports Hamburger.ViewModel
Imports System.Windows
Imports System.Windows.Controls

Namespace Hamburger.TemplateSelectors

    Public Class HamburgerMenuItemTemplateSelector
        Inherits DataTemplateSelector

        Public Property ItemTemplate As DataTemplate

        Public Property SubItemTemplate As DataTemplate

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            If TypeOf item Is HamburgerSubMenuItemViewModel Then Return SubItemTemplate
            If TypeOf item Is HamburgerMenuItemViewModel Then Return ItemTemplate
            Return MyBase.SelectTemplate(item, container)
        End Function
    End Class
End Namespace
