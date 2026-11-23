using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TWApp.Models;

namespace TWApp.Services;

public class LevelsNavigationService : ObservableObject
{
    
    private Lazy<LevelsNavigationService> _instance = new Lazy<LevelsNavigationService>(() =>
    {
        return new LevelsNavigationService();
    });

    public LevelsNavigationService Instance => _instance.Value;

    public ObservableCollection<LevelData> Levels {get; } = new();

    private LevelsNavigationService()
    {
        Levels = new()
        {
            
        };
    }

}