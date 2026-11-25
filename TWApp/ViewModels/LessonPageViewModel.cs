using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TWApp.Models;
using TWApp.Services;

namespace TWApp.ViewModels;

public partial class LessonPageViewModel : ViewModelBase
{
    private NavigationService Navigation => NavigationService.Instance;

    [ObservableProperty]
    private LevelModel _current = LevelsNavigationService.Instance.CurrentLevel;

    [RelayCommand]
    public void ToLessons()
    {
        Navigation.NavigateTo<LevelsPageViewModel>();
    }
}