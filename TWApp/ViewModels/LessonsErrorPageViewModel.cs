using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TWApp.Services;

namespace TWApp.ViewModels;

public partial class LessonsErrorPageViewModel : ViewModelBase
{
    private NavigationService Navigation => NavigationService.Instance;

    [ObservableProperty]
    private string _error = LevelsNavigationService.Instance.ErrorText;

    [ObservableProperty]
    private string _logs = LevelsNavigationService.Instance.ErrorLogs;

    [RelayCommand]
    public void OpeHomePage()
    {
        Navigation.NavigateTo<HomePageViewModel>();
    }
}