using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using TWApp.Models;
using TWApp.ViewModels;

namespace TWApp.Services;

public class LevelsNavigationService : ObservableObject
{
    private readonly Uri _levelsRuUri = new("avares://TWApp/Assets/Lessons_RU.json");
    private readonly Uri _levelsEnUri = new("avares://TWApp/Assets/Lessons_EN.json");

    public string ErrorText = string.Empty;
    public string ErrorLogs = string.Empty;

    public bool HasErrorWhileDeserialize = false;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true 
    };

    private static readonly Lazy<LevelsNavigationService> _instance = new(() => new LevelsNavigationService());
    public static LevelsNavigationService Instance => _instance.Value;

    public ObservableCollection<LevelModel> Levels { get; } = new();

    private LevelsNavigationService()
    {
        SettingsService.Instance.Load();
        Load();
        MarkErrorIfError();

        SettingsService.Instance.SettingsSaved += Load;
    }

    public void Load()
    {
        ErrorText = string.Empty;
        ErrorLogs = string.Empty;
        HasErrorWhileDeserialize = false;
        
        try {
            Uri _levelsUri;
            switch(SettingsService.Instance.UsersSettings.CurrentLanguage) 
            {
                case "Русский":
                    _levelsUri = _levelsRuUri;
                    break;
                case "English":
                    _levelsUri = _levelsEnUri;
                    break;
                default:
                    Debug.WriteLine("Выбран неизвестный язык");
                    ErrorText = "Выбран неизвестный язык/Unknown language";
                    _levelsUri = _levelsEnUri;
                    break;
            }

            using Stream stream = AssetLoader.Open(_levelsUri);
            using var reader = new StreamReader(stream, Encoding.UTF8);
            string json = reader.ReadToEnd();

            List<LevelModel>? loadedLevels;
            try
            {
                loadedLevels = JsonSerializer.Deserialize<List<LevelModel>>(
                    json, JsonOptions);

                try
                {
                    Levels.Clear();

                    if (loadedLevels is not null)
                    {
                        foreach (var level in loadedLevels)
                        {
                            Levels.Add(level);
                        }
                    }
                }
                catch(Exception exxx)
                {
                    ErrorText = $"Ошибка при добавлении уровней/Levels loading error";
                    ErrorLogs = exxx.ToString();
                    return;
                }

            }
            catch (Exception exx)
            {
                ErrorText = $"Ошибка при чтении файла/File read error";
                ErrorLogs = exx.ToString();
                return;
            }
        }
        catch(Exception ex)
        {
            ErrorText = $"Ошибка при окрытии файла/Error while open file: {ex.ToString()}";
            ErrorLogs = ex.ToString();
            return;
        }
    }

    public void MarkErrorIfError()
    {
        if (ErrorText != string.Empty)
        {
            HasErrorWhileDeserialize = true;
        }
    }
}