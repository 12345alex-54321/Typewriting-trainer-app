using System;

namespace TWApp.Models;

public class LevelData
{
    public string text {get; set;}
    public int time {get; set;}

    public LevelData(string t, int tt)
    {
        this.text = t;
        this.time = tt;
    }
}