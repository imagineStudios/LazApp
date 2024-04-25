using LazApp.Base.ViewModels;

namespace LazApp.Views;

public class TimeLineView : AbsoluteLayout
{
    private readonly List<Button> buttons = [];

    public static readonly BindableProperty MyScaleXProperty = BindableProperty.Create(nameof(MyScaleX), typeof(double), typeof(TimeLineView), 1.0, propertyChanged: ScalingChanged);

    public TimeLineView()
    {
        BindingContextChanged += TimeLineView_BindingContextChanged;
    }

    public double MyScaleX
    {
        get => (double)GetValue(MyScaleXProperty);
        set => SetValue(MyScaleXProperty, value);
    }

    private static void ScalingChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as TimeLineView)?.Position();
    }

    private void TimeLineView_BindingContextChanged(object? sender, EventArgs e)
    {
        buttons.Clear();
        Children.Clear();
        if (BindingContext is TimeLineViewModel tlvm)
        {
            foreach (var vm in tlvm.Quests)
            {
                var button = new Button()
                {
                    Text = vm.Name,
                    CornerRadius = 0,
                    BindingContext = vm,
                };
                button.Clicked += Button_Clicked;

                Children.Add(button);
                buttons.Add(button);
            }
            Position();
        }
    }

    private void Position()
    {
        buttons.ForEach(b =>
        {
            var vm = b.BindingContext as QuestViewModel;
            Position(b, new Rect(vm.StartTime, 30, vm.Duration, 40));
        });
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        var scenario = (BindingContext as TimeLineViewModel)?.ScenarioName.Replace(" ", "");
        var timeLine = (BindingContext as TimeLineViewModel)?.Name;
        var quest = (sender as Button)?.Text;
        await Shell.Current.GoToAsync($"quest?scenario={scenario}&questname={quest}&timeline={timeLine}");
    }

    private void Position(BindableObject obj, Rect rect)
    {
        var r = new Rect(rect.X * MyScaleX, rect.Y, rect.Width * MyScaleX - 1, rect.Height);
        SetLayoutBounds(obj, r);
    }
}