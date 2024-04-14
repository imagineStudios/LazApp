using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LAZapp.Base;

public class Quiz
{
    public Quiz()
    {
        var json = File.ReadAllText(Path.Combine("mannschaft.json"));
        if (JsonSerializer.Deserialize<Quiz>(json) is null)
        {
            throw new Exception("Error parsing question list!");
        }
    }

    public List<Question> questions;
}
