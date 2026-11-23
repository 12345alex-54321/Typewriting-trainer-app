using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System;
using TWApp.Models;
using System.Text.Json;
using System.IO;

namespace TWApp.Services;

public class SettingsService 
{
    private readonly string _filepath;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true
    };

    private static readonly Lazy<SettingsService> _instance = new(() => new SettingsService());
    public static SettingsService Instance => _instance.Value;

    public SettingsModel UsersSettings { get; private set; } = new();

    private SettingsService()
    {
    
        string appFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "TWApp"
        );

        _filepath = Path.Combine(appFolder, "Settings.json");
    }

    public void Save()
    {
        string? directory = Path.GetDirectoryName(_filepath);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string settingsJson = JsonSerializer.Serialize(UsersSettings, JsonOptions);
        File.WriteAllText(_filepath, settingsJson, System.Text.Encoding.UTF8);
    }

    public void Load()
    {
        if (File.Exists(_filepath))
        {
            string json = File.ReadAllText(_filepath, System.Text.Encoding.UTF8);

            if (!string.IsNullOrWhiteSpace(json))
            {
                UsersSettings = JsonSerializer.Deserialize<SettingsModel>(json) ?? new SettingsModel();
                return;
            }
        }

        UsersSettings = new SettingsModel();
        Save();
    }
}