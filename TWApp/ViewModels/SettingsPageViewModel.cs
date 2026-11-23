using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using TWApp.Services;
using System.Collections.ObjectModel;
using TWApp.Models;


namespace TWApp.ViewModels;

public partial class SettingsPageViewModel : ViewModelBase
{
    private static readonly List<int> TimeList = [60, 120, 180];

    private NavigationService Navigation => NavigationService.Instance;

    private SettingsService Service => SettingsService.Instance;

    public SettingsModel Model => Service.UsersSettings;

    [RelayCommand]
    public void SaveAndGoToHomePage()
    {
        Service.Save();
        Navigation.NavigateTo<HomePageViewModel>();
    }

    public SettingsPageViewModel() 
    {
        Service.Load();
    }
}