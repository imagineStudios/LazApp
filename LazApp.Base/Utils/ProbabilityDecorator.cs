namespace LAZapp.Base;

public class ProbabilityDecorator<T> : IRandomItem
{
    public ProbabilityDecorator(T item, double probability = 1.0)
    {
        Item = item;
        Probability = probability;
    }

    public double Probability { get; }

    public T Item { get; }
}