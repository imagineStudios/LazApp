using LazApp.Base.Models;

namespace LazApp.Base.ViewModels;

public class MistakeViewModel(Mistake mistake) : ViewModelBase
{
    private readonly Mistake mistake = mistake;
    private int count;

    public string Description => mistake.Description;

    public int Points => mistake.Points * Count;

    public bool IsMulti => mistake.IsMulti;

    public string PointsMulti => IsMulti ? $"{mistake.Points}+" : mistake.Points.ToString();

    public int Count
    {
        get => count;
        set => count = value > 1 && !IsMulti ? 1 : value;
    }
}
