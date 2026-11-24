using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TWApp.Services;

namespace TWApp.ViewModels;

public partial class HomePageViewModel : ViewModelBase
{
    public NavigationService Navigation => NavigationService.Instance;

    public SettingsService Settings => SettingsService.Instance;

    [RelayCommand]
    public void OpenSettings()
    {
        Navigation.NavigateTo<SettingsPageViewModel>();
    }

    [RelayCommand]
    public void OpenLessons() 
    {
        Navigation.NavigateTo<LevelsPageViewModel>();

        if(LevelsNavigationService.Instance.HasErrorWhileDeserialize)
        {
            Navigation.NavigateTo<LessonsErrorPageViewModel>();
        }
    }

    [RelayCommand]
    public void OpenAbout() 
    {
        Navigation.NavigateTo<AboutPageViewModel>();
    }
}