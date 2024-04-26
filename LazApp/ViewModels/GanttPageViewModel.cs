namespace LazApp.ViewModels;

public class GanttPageViewModel : ViewModelBase
{
    private double zoom = 2.0;

    public GanttPageViewModel(ScenarioViewModel scenario)
    {
        Scenario = scenario;
    }

    public ScenarioViewModel Scenario { get; }

    public double Zoom
    {
        get => zoom;
        set
        {
            zoom = value;
            OnPropertyChanged();
        }
    }
}
