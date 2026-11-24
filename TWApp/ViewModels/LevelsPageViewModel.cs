using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TWApp.Services;

namespace TWApp.ViewModels;

public partial class LevelsPageViewModel : ViewModelBase
{
    public NavigationService Navigation => NavigationService.Instance;

    public LevelsNavigationService Service => LevelsNavigationService.Instance;

    [RelayCommand]
    public void SelectItem(int number)
    {
        System.Console.WriteLine(number);
    }

    [RelayCommand]
    public void ToHome()
    {
        Navigation.NavigateTo<HomePageViewModel>();
    }
}