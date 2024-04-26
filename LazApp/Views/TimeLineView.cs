using LazApp.ViewModels;

namespace LazApp.Views;

public class TimeLineView : AbsoluteLayout
{
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

    public new void SetLayoutBounds(IView view, Rect bounds)
    {
        var scaledBounds = new Rect(bounds.X * MyScaleX, bounds.Y, bounds.Width * MyScaleX - 1, bounds.Height);
        base.SetLayoutBounds(view, scaledBounds);
    }

    private static void ScalingChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as TimeLineView)?.Position();
    }

    private void TimeLineView_BindingContextChanged(object? sender, EventArgs e)
    {
        Children.Clear();
        if (BindingContext is TimeLineViewModel tlvm)
        {
            foreach (var vm in tlvm.Quests)
            {
                Children.Add(new QuestView(vm));
            }
            Position();
        }
    }

    private void Position()
    {
        Children.OfType<QuestView>().ToList().ForEach(q => q.Position(this));
    }
}