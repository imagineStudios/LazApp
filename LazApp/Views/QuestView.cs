using LazApp.ViewModels;
using Microsoft.Maui.Controls.Shapes;

namespace LazApp.Views;

public class QuestView : Grid
{
    private static readonly Geometry? commandGeometry = new PathGeometryConverter().ConvertFrom("M 2 0 C 0.9 0 0 0.9 0 2 L 0 19 L 0 25 C 0 25 1 21 5 21 L 28 21 C 29 21 30 20 30 19 L 30 2 C 30 0.9 29 0 28 0 L 2 0 z M 13.646195 2.9744954 L 16.289445 2.9744954 L 16.289445 12.82299 L 13.646195 12.82299 L 13.646195 2.9744954 z M 13.646195 14.356746 L 16.289445 14.356746 L 16.289445 17 L 13.646195 17 L 13.646195 14.356746 z") as Geometry;
    private static readonly Geometry? reportGeometry = new PathGeometryConverter().ConvertFrom("M 2 0 C 0.9 0 0 0.9 0 2 L 0 19 C 0 20 0.9 21 2 21 L 25 21 C 29 21 30 25 30 25 L 30 19 L 30 2 C 30 0.9 29 0 28 0 L 2 0 z M 22 4.2653727 L 24 5.7345337 L 15.224394 17.814417 L 8.1989827 11.961027 L 9.8009521 10.039181 L 14.775326 14.18363 L 21.988322 4.2653727 z") as Geometry;
    private readonly QuestViewModel viewModel;

    public QuestView(QuestViewModel vm)
    {
        viewModel = vm;
        var button = new Button() { Text = viewModel.Name };
        button.Clicked += Button_Clicked;
        Children.Add(button);

        if (!string.IsNullOrEmpty(vm.Command))
        {
            var tap = new TapGestureRecognizer();
            tap.Tapped += Command_Tapped;
            var commandBubble = new Microsoft.Maui.Controls.Shapes.Path(commandGeometry)
            {
                Fill = Brush.Orange,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                GestureRecognizers = { tap },
            };
            Children.Add(commandBubble);
        }

        if (!string.IsNullOrEmpty(vm.Report))
        {
            var tap = new TapGestureRecognizer();
            tap.Tapped += Report_Tapped;
            var reportBubble = new Microsoft.Maui.Controls.Shapes.Path(reportGeometry)
            {
                Fill = Brush.Green,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Start,
                GestureRecognizers = { tap },
            };
            Children.Add(reportBubble);
        }
    }

    private async void Command_Tapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.CurrentPage.DisplayAlert("Kommando", viewModel.Command, "Schließen");
    }

    private async void Report_Tapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.CurrentPage.DisplayAlert("Meldung", viewModel.Report, "Schließen");
    }

    public double StartTime => viewModel.StartTime;

    public double Duration => viewModel.Duration;

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        var timeLine = viewModel.Timeline.Name;
        var scenario = viewModel.Timeline.ScenarioName.Replace(" ", "");
        var quest = viewModel.Name;
        await Shell.Current.GoToAsync($"quest?scenario={scenario}&questname={quest}&timeline={timeLine}");
    }

    internal void Position(TimeLineView view)
    {
        view.SetLayoutBounds(this, new Rect(StartTime, 0, Duration, 100));
    }
}