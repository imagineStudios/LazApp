using LazApp.ViewModels;

namespace LazApp.Views;

[QueryProperty(nameof(Level), "level")]
public partial class GanttPage : ContentPage
{
    private string? level;

    public GanttPage()
	{
		InitializeComponent();
	}

    public string? Level
    {
        get => level;
        set
        {
            level = value;
            BindingContext = new GanttPageViewModel(level);
        }
    }
}