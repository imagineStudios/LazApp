using SQLite;

namespace LazApp;

public class Repository<T>
    where T : new()
{
    private readonly string dbPath;
    private readonly SQLiteConnection conn;

    public Repository(string path)
    {
        dbPath = path;
        conn = new SQLiteConnection(dbPath);
        conn.CreateTable<T>();
    }

    public string? StatusMessage { get; private set; }

    public int Add(IEnumerable<T> items) => conn.InsertAll(items);

    public int Add(T item) => conn.Insert(item);

    public int Update(T item) => conn.Update(item);

    public T? Get(Predicate<T> predicate)
    {
        try
        {
            return conn.Table<T>().SingleOrDefault(i => predicate(i));
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }
        return default;
    }

    public List<T> GetAll()
    {
        try
        {
            return [.. conn.Table<T>()];
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to retrieve data. {ex.Message}";
        }

        return [];
    }

    public List<T> GetAll(Func<T, bool> predicate)
    {
        try
        {
            return [.. conn.Table<T>().Where(predicate)];
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to retrieve data. {ex.Message}";
        }

        return [];
    }

    //if (!conn.Table<Question>().Any())
    //{
    //    var filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "mannschaft.json");
    //    var text = File.ReadAllText(filename);
    //    var questions = JsonSerializer.Deserialize<Question[]>(text);
    //    foreach (var q in questions)
    //    {
    //        var id = Add(q);
    //        if (id != q.Id)
    //        {
    //            ;
    //        }
    //    }
    //}
}

