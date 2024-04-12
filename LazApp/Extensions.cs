namespace LazApp;

public static class Extensions
{
    public static double Prod(this IEnumerable<double> values)
    {
        var prod = 1.0;
        foreach (var value in values)
        {
            prod *= value;
        }
        return prod;
    }

    public static IEnumerable<int> AppendZero(this IEnumerable<int> e) => e.Concat([0]);

    public static IEnumerable<T> Concat<T>(this IEnumerable<T> e, T? element)
        where T : class
    {
        return element == null
            ? e
            : e.Concat([element]);
    }

}
