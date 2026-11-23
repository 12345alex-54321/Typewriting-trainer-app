using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using HarfBuzzSharp;

namespace TWApp.Models;

public partial class SettingsModel : ObservableObject
{
    [ObservableProperty]
    private bool _isStrictMode = true;

    private List<int> Seconds = [60, 120, 180];

    [ObservableProperty]
    private int _difficultyIndex;

    public ObservableCollection<string> Languages {get; } = ["Русский", "English"];

    [ObservableProperty]
    private string _currentLanguage;

    public SettingsModel()
    {
        IsStrictMode = true;
        DifficultyIndex = Seconds[1];
        CurrentLanguage = Languages[0];
    }
}