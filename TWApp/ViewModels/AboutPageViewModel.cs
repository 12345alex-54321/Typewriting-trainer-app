using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TWApp.Services;

namespace TWApp.ViewModels;

public partial class AboutPageViewModel : ViewModelBase 
{
    private NavigationService Navigation => NavigationService.Instance;

    [RelayCommand]
    public void ToHomePage()
    {
        Navigation.NavigateTo<HomePageViewModel>();
    }
}