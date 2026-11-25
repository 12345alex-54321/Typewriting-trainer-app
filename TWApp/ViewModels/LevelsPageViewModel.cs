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
        if(number > 0 && number < Service.Levels.Count)
        {
            Service.CurrentLevel = Service.Levels[number];
            Navigation.NavigateTo<LessonPageViewModel>(); 
        }
        else
        {
            Service.ErrorText = "Выбранный уровень не существует!";
            Service.ErrorLogs = "<Key not found exception>";
            Service.HasErrorWhileDeserialize = true;
            Navigation.NavigateTo<LessonsErrorPageViewModel>();
            Service.ErrorText = string.Empty;
            Service.ErrorLogs = string.Empty;
            Service.HasErrorWhileDeserialize = false;
        }
    }

    [RelayCommand]
    public void ToHome()
    {
        Navigation.NavigateTo<HomePageViewModel>();
    }
}