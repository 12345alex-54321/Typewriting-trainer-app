using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TWApp.ViewModels;

public partial class HomePageViewModel : ViewModelBase
{
    public NavigationService Navigation => NavigationService.Instance;

    [RelayCommand]
    public void OpenSettings()
    {
        Navigation.NavigateTo<SettingsPageViewModel>();
    }

    [RelayCommand]
    public void OpenLessons() 
    {
        Navigation.NavigateTo<LessonsPageViewModel>();
    }

    [RelayCommand]
    public void OpenAbout() {
        Navigation.NavigateTo<AboutPageViewModel>();
    }
}