Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports System

Namespace Hamburger.ViewModel
    Public Class MainViewModel
        Inherits NavigationViewModelBase

        Public Property SelectedItem() As HamburgerMenuItemViewModel
            Get
                Return GetProperty(Function() SelectedItem)
            End Get
            Set(ByVal value As HamburgerMenuItemViewModel)
                SetProperty(Function() SelectedItem, value, AddressOf OnSelectedItemChanged)
            End Set
        End Property

        Public Property IsMenuVisible() As Boolean
            Get
                Return GetProperty(Function() IsMenuVisible)
            End Get
            Set(ByVal value As Boolean)
                SetProperty(Function() IsMenuVisible, value)
            End Set
        End Property
        Public Property Items() As ObservableCollection(Of HamburgerMenuItemViewModel)
            Get
                Return GetProperty(Function() Items)
            End Get
            Set(ByVal value As ObservableCollection(Of HamburgerMenuItemViewModel))
                SetProperty(Function() Items, value)
            End Set
        End Property
        Private ReadOnly Property NavigationService() As INavigationService
            Get
                Return GetService(Of INavigationService)()
            End Get
        End Property
        Public Sub New()
            Items = New ObservableCollection(Of HamburgerMenuItemViewModel)()
            Items.Add(New HamburgerMenuItemViewModel("Main Page", "MainPage"))
            Items.Add(New HamburgerMenuItemViewModel("Simple Page", "SimplePage"))
            SelectedItem = Items(0)
        End Sub
        Private Sub OnSelectedItemChanged()
            If SelectedItem IsNot Nothing Then
                IsMenuVisible = SelectedItem.Caption <> "Simple Page"
            End If
        End Sub
    End Class
    Public Class HamburgerMenuItemViewModel
        Public Property Caption() As String
        Public Property PageName() As String
        Public Sub New(ByVal caption As String, ByVal pageName As String)
            Me.Caption = caption
            Me.PageName = pageName
        End Sub
    End Class
End Namespace

