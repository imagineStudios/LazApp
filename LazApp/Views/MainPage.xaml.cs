namespace LazApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage(AssetService a)
	{
		InitializeComponent();

        BindingContext = this;
	}

    public List<List<string>> Test { get; } = [["A", "ABC", "Hallo"], ["A", "ABC", "Hallo"]];

    private async void LevelButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.Text is string level)
        await Shell.Current.GoToAsync($"levelstart?level={level}");
    }
}