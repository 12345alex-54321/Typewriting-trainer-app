using System;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using TWApp.ViewModels;

namespace TWApp;

public partial class NavigationService : ObservableObject
{   
    [ObservableProperty]
    private ViewModelBase _currentBase;

    public static NavigationService Instance = new NavigationService();

    private NavigationService()
    {
        _currentBase = new HomePageViewModel();
    }

    public void NavigateTo<T>() where T : ViewModelBase, new()
    {
        CurrentBase = new T();
    }
}