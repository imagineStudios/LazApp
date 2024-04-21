using LazApp.Base.ViewModels;

namespace LazApp.Views;

public class TimeLineView : ContentView
{
    private readonly AbsoluteLayout layout;
    private double scaleX = 2;
    private double scaleY = 1;

    public TimeLineView()
    {
        layout = new AbsoluteLayout();
        Content = layout;
        BindingContextChanged += TimeLineView_BindingContextChanged;
    }

    private void TimeLineView_BindingContextChanged(object? sender, EventArgs e)
    {
        if (BindingContext is TimeLineViewModel tlvm)
        {
            foreach (var vm in tlvm.Quests)
            {
                var button = new Button()
                {
                    Text = vm.Name,
                    CornerRadius = 0,
                };
                button.Clicked += Button_Clicked;

                layout.Children.Add(button);
                Position(button, new Rect(vm.StartTime, 30, vm.Duration, 40));
            }
        }
    }

    //public static readonly BindableProperty TimeLineProperty = BindableProperty.Create(nameof(Quests), typeof(TimeLineViewModel), typeof(TimeLineView), null, propertyChanged: TimeLineChanged);


    //public TimeLineViewModel Quests
    //{
    //    get => (TimeLineViewModel)GetValue(TimeLineProperty);
    //    set => SetValue(TimeLineProperty, value);
    //}

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        var timeLine = (BindingContext as TimeLineViewModel)?.Name;
        var quest = (sender as Button)?.Text;
        await Shell.Current.GoToAsync($"quest?timeline={timeLine}&questname={quest}");
    }

    private void Position(BindableObject obj, Rect rect)
    {
        var r = new Rect(rect.X * scaleX, rect.Y * scaleY, rect.Width * scaleX - 1, rect.Height * scaleY);
        AbsoluteLayout.SetLayoutBounds(obj, r);
    }
}