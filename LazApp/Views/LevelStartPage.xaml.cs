namespace LazApp.Views;

[QueryProperty(nameof(Level), "level")]
public partial class LevelStartPage : ContentPage
{
    public LevelStartPage()
	{
		InitializeComponent();
	}

    public string? Level { get; set; }

    private async void AblaufButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"gantt?level={Level}");
    }
}