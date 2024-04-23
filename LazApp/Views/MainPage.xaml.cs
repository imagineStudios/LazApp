using LazApp.Base.Models;
using System.ComponentModel;

namespace LazApp.Views;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    public MainPage(AssetService<Scenario> a, AssetService<Question[]> b)
    {
        DeviceDisplay.Current.MainDisplayInfoChanged += (s, e) => OnPropertyChanged(nameof(Orientation));
        BindingContext = this;
        InitializeComponent();
    }

    private async void LevelButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.Text is string level)
            await Shell.Current.GoToAsync($"levelstart?level={level}");
    }

    private async void BronzeButton_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"levelstart?level=Bronze");
    }

    private async void SilverButton_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"levelstart?level=Silber");
    }

    private async void GoldButton_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"levelstart?level=Gold");
    }

    public StackOrientation Orientation
        => DeviceDisplay.Current.MainDisplayInfo.Orientation == DisplayOrientation.Portrait
        ? StackOrientation.Vertical : StackOrientation.Horizontal;
}