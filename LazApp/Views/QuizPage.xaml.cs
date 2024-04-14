namespace LAZapp;

public partial class QuizPage : ContentPage
{
	public QuizPage(QuestionRepository repo)
	{
		InitializeComponent();
		var questions = repo.GetAll();
		BindingContext = new QuizViewModel();
	}
}