namespace LazApp.Views;

[QueryProperty(nameof(Level), "level")]
public partial class LevelStartPage : ContentPage
{
    public LevelStartPage()
	{
		InitializeComponent();
	}

    public string? Level { get; set; }

    private async void BrandeinsatzButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"gantt?level={Level}&scenario=Brandeinsatz");
    }

    private async void HilfeleistungButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"gantt?level={Level}&scenario=Hilfeleistung");
    }

    private async void TheorieButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"quiz");
    }
}