using LazApp.ViewModels;

namespace LazApp.Views;

public partial class TrainingPage : ContentPage
{ 
	public TrainingPage(TrainingViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}
