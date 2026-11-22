using CommunityToolkit.Mvvm.ComponentModel;

namespace TWApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    public NavigationService Navigation => NavigationService.Instance;
    
    public MainViewModel()
    {
        Navigation.NavigateTo<HomePageViewModel>();
    }
}
