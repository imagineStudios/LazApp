using LAZapp.Base;
using Microsoft.Maui.Storage;
using SQLite;
using System.Text.Json;

namespace LAZapp;

public class QuestionRepository
{
    private readonly string dbPath;
    private SQLiteConnection conn;

    public QuestionRepository(string path)
    {
        dbPath = path;
        Init();
    }

    public string? StatusMessage { get; private set; }

    public int Add(Question question)
    {
        int result = 0;
        try
        {
            Init();
            result = conn.Insert(question);
        }
        catch
        {
        }
        return result;
    }

    public Question? GetQuestion(int questionId)
    {
        try
        {
            Init();
            return conn.Table<Question>().SingleOrDefault(q => q.Id == questionId);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }
        return null;
    }

    public List<Question> GetAll()
    {
        try
        {
            Init();
            return [.. conn.Table<Question>()];
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Question>();
    }

    private void Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteConnection(dbPath);
        conn.CreateTable<Question>();
        if (!conn.Table<Question>().Any())
        {
            var filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "mannschaft.json");
            var text = File.ReadAllText(filename);
            var questions = JsonSerializer.Deserialize<Question[]>(text);
            foreach (var q in questions)
            {
                var id = Add(q);
                if (id != q.Id)
                {
                    ;
                }
            }
        }
    }
}
