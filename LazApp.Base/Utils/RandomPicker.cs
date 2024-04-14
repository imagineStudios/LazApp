using System;
using System.Collections.Generic;
using System.Linq;

namespace LazApp.Base;

public class RandomPicker<T>
        where T : IRandomItem
{
    private readonly List<T> list;
    private readonly Random rand;
    private double maxProb;

    public RandomPicker(IEnumerable<T> items)
    {
        list = [.. items.OrderByDescending(x => x.Probability)];
        maxProb = list.Sum(x => x.Probability);
        rand = new Random(Guid.NewGuid().GetHashCode());
    }

    public static IEnumerable<T> Draw(IEnumerable<T> items, int count)
    {
        var rp = new RandomPicker<T>(items);
        for (var i = 0; i < count; i++)
        {
            yield return rp.Draw();
        }
    }

    public T Draw()
    {
        var result = DrawNext();
        list.Remove(result);
        maxProb -= result.Probability;
        return result;
    }

    private T DrawNext()
    {
        var val = rand.NextDouble() * maxProb;
        var accu = 0.0;
        foreach (var item in list)
        {
            accu += item.Probability;
            if (val <= accu)
            {
                return item;
            }
        }

        return list[^1];
    }
}
