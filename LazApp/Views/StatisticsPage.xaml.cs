using LazApp.Base.ViewModels;

namespace LazApp.Views;

public partial class StatisticsPage : ContentPage
{ 
    private readonly StatisticsViewModel viewModel;
	public StatisticsPage(StatisticsViewModel vm)
	{
        viewModel = vm;
        BindingContext = viewModel;
		InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await viewModel.InitAsync();
    }
}
