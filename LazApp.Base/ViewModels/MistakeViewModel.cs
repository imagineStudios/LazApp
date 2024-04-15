using LazApp.Base.Models;

namespace LazApp.Base.ViewModels;

public class MistakeViewModel(Mistake mistake) : ViewModelBase
{
    private readonly Mistake mistake = mistake;

    public string Description => mistake.Description;

    public int Points => mistake.Points;

    public string PointsMulti => mistake.IsMulti ? $"{Points}+" : Points.ToString();
}
