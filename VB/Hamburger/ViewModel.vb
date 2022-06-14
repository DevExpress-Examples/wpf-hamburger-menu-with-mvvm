Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports System

Namespace Hamburger.ViewModel

    Public Class MainViewModel
        Inherits NavigationViewModelBase

        Public Property SelectedItem As HamburgerMenuItemViewModel
            Get
                Return GetProperty(Function() Me.SelectedItem)
            End Get

            Set(ByVal value As HamburgerMenuItemViewModel)
                SetProperty(Function() SelectedItem, value)
            End Set
        End Property

        Public Property IsMenuVisible As Boolean
            Get
                Return GetProperty(Function() Me.IsMenuVisible)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() IsMenuVisible, value)
            End Set
        End Property

        Public Property Items As ObservableCollection(Of HamburgerMenuItemViewModel)
            Get
                Return GetProperty(Function() Me.Items)
            End Get

            Set(ByVal value As ObservableCollection(Of HamburgerMenuItemViewModel))
                SetProperty(Function() Items, value)
            End Set
        End Property

        Public Property SubItems As ObservableCollection(Of HamburgerSubMenuItemViewModel)
            Get
                Return GetProperty(Function() Me.SubItems)
            End Get

            Set(ByVal value As ObservableCollection(Of HamburgerSubMenuItemViewModel))
                SetProperty(Function() SubItems, value)
            End Set
        End Property

        Private ReadOnly Property NavigationService As INavigationService
            Get
                Return GetService(Of INavigationService)()
            End Get
        End Property

        Public Sub New()
            Items = New ObservableCollection(Of HamburgerMenuItemViewModel)()
            Items.Add(New HamburgerSubMenuItemViewModel("Main Page", GetType(MainPage)) With {.SubItems = New ObservableCollection(Of HamburgerSubMenuItemViewModel)() From {New HamburgerSubMenuItemViewModel("SubMenu1", GetType(MainPage)), New HamburgerSubMenuItemViewModel("SubMenu", GetType(MainPage_SubPage))}})
            Items.Add(New HamburgerMenuItemViewModel("Simple Page", GetType(SimplePage)))
            SelectedItem = Items(0)
            IsMenuVisible = True
        End Sub
    End Class

    Public Class HamburgerMenuItemViewModel
        Implements ISupportParentViewModel

        Private _SubItems As ObservableCollection(Of Hamburger.ViewModel.HamburgerSubMenuItemViewModel)

        Public Property Caption As String

        Public Property PageName As Type

        Public Property SubItems As ObservableCollection(Of HamburgerSubMenuItemViewModel)
            Get
                Return _SubItems
            End Get

            Friend Set(ByVal value As ObservableCollection(Of HamburgerSubMenuItemViewModel))
                _SubItems = value
            End Set
        End Property

        Public Property ParentViewModel As Object Implements ISupportParentViewModel.ParentViewModel

        Public Sub New(ByVal caption As String, ByVal pageName As Type)
            Me.Caption = caption
            Me.PageName = pageName
        End Sub
    End Class

    Public Class HamburgerSubMenuItemViewModel
        Inherits HamburgerMenuItemViewModel

        Public Sub New(ByVal caption As String, ByVal pageName As Type)
            MyBase.New(caption, pageName)
        End Sub
    End Class
End Namespace
