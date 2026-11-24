using System;
using System.Collections;

namespace TWApp.Models;

public class LevelModel
{
    public int Number {get; set;} = 0;

    public string Title {get; set;} = string.Empty;
    public string Text {get; set;} = string.Empty;

    public LevelModel(int n, string t, int tt)
    {
        this.Number = n;
        this.Text = t;
        this.Title = t;
    }

    public LevelModel()
    {
        
    }
}