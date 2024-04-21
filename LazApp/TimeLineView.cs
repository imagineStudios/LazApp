//using SkiaSharp;
//using SkiaSharp.Views.Maui;
//using SkiaSharp.Views.Maui.Controls;
//using SkiaSharp.Views.Maui.Handlers;

//using Microsoft.UI.Xaml.Controls;

//namespace LazApp;

//public class TimeLineView : SKCanvasView
//{
//    public float Progress
//    {
//        get => (float)GetValue(ProgressProperty);
//        set => SetValue(ProgressProperty, value);
//    }

//    public Color ProgressColor
//    {
//        get => (Color)GetValue(ProgressColorProperty);
//        set => SetValue(ProgressColorProperty, value);
//    }

//    public Color BaseColor
//    {
//        get => (Color)GetValue(BaseColorProperty);
//        set => SetValue(BaseColorProperty, value);
//    }

//    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(
//        nameof(Progress), typeof(float), typeof(TimeLineView), 0.0f, propertyChanged: OnBindablePropertyChanged);

//    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(
//        nameof(ProgressColor), typeof(Color), typeof(TimeLineView), Colors.Orange, propertyChanged: OnBindablePropertyChanged);

//    public static readonly BindableProperty BaseColorProperty = BindableProperty.Create(
//        nameof(BaseColor), typeof(Color), typeof(TimeLineView), Colors.LightGray, propertyChanged: OnBindablePropertyChanged);

//    // actual canvas instance to draw on
//    private SKCanvas _canvas;

//    protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
//    {
//        base.OnPaintSurface(e);

//        _canvas = e.Surface.Canvas;
//        _canvas.Clear(); // clears the canvas for every frame
//        var drawRect = new SKRect(0, 0, e.Info.Width, e.Info.Height);

//        DrawBase(drawRect);
//        DrawProgress(drawRect);
//    }

//    private static void OnBindablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
//    {
//        ((TimeLineView)bindable).InvalidateSurface();
//    }

//    private void DrawBase(SKRect drawRect)
//    {
//        using var basePath = new SKPath();

//        basePath.AddRect(drawRect);

//        _canvas.DrawPath(basePath, new SKPaint
//        {
//            Style = SKPaintStyle.Fill,
//            Color = BaseColor.ToSKColor(),
//            IsAntialias = true
//        });
//    }

//    private void DrawProgress(SKRect drawRect)
//    {
//        using var progressPath = new SKPath();

//        var progressRect = new SKRect(0, 0, drawRect.Width * Progress, drawRect.Height);

//        progressPath.AddRect(progressRect);

//        _canvas.DrawPath(progressPath, new SKPaint
//        {
//            Style = SKPaintStyle.Fill,
//            IsAntialias = true,
//            Color = ProgressColor.ToSKColor()
//        });
//    }
//}

//public static class Registration
//{
//    public static MauiAppBuilder UseTimeLine(this MauiAppBuilder builder)
//    {
//        builder.ConfigureMauiHandlers(h =>
//        {
//            h.AddHandler<TimeLineView, SKCanvasViewHandler>();
//        });

//        return builder;
//    }
//}
