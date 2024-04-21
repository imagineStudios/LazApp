using LazApp.Base.Models;

namespace LazApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage(AssetService<Scenario> a, AssetService<Question[]> b)
    {
        InitializeComponent();

        BindingContext = this;
    }

    private async void LevelButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.Text is string level)
            await Shell.Current.GoToAsync($"levelstart?level={level}");
    }
}