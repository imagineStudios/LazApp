using LAZapp.Base;
using Microsoft.Maui.Storage;
using SQLite;
using System.Text.Json;

namespace LAZapp;

public class AnswerRepository
{
    private readonly string dbPath;
    private SQLiteConnection conn;

    public AnswerRepository(string path)
    {
        dbPath = path;
        Init();
    }

    public string? StatusMessage { get; private set; }

    public int Add(Answer anser)
    {
        int result = 0;
        try
        {
            Init();
            result = conn.Insert(anser);
        }
        catch
        {
        }
        return result;
    }

    public Answer? Qet(int id)
    {
        try
        {
            Init();
            return conn.Table<Answer>().SingleOrDefault(q => q.Id == id);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to retrieve data. {ex.Message}";
        }
        return null;
    }

    public List<Answer> GetAll()
    {
        try
        {
            Init();
            return [.. conn.Table<Answer>()];
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Answer>();
    }

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(dbPath);
        conn.CreateTable<Answer>();
        if (!conn.Table<Answer>().Any())
        {
            var filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "mannschaft.json");
            var text = File.ReadAllText(filename);
            var questions = JsonSerializer.Deserialize<Question[]>(text);
            foreach (var q in questions)
            {
                foreach (var a in q.Answers)
                {
                    a.QuestionId = q.Id;
                    conn.Insert(a);
                }
            }

        }
    }
}
