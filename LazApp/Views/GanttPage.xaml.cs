using LazApp.ViewModels;

namespace LazApp.Views;

[QueryProperty(nameof(Level), "level")]
public partial class GanttPage : ContentPage
{
    private readonly AssetService assetService;
    private string? level;

    public GanttPage(AssetService assetService)
	{
        this.assetService = assetService;
		InitializeComponent();
	}

    public string? Level
    {
        get => level;
        set
        {
            level = value;
            BindingContext = new GanttPageViewModel(level, assetService);
        }
    }
}