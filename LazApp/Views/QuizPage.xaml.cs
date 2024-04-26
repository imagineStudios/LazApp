using LazApp.Base.Models;
using LazApp.ViewModels;

namespace LazApp.Views;

public partial class QuizPage : ContentPage
{
    public QuizPage(AssetService<Question[]> repo)
	{
		InitializeComponent();
		BindingContext = new QuizViewModel(repo["mannschaft"]);
	}
}