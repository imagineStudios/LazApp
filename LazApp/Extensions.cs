public static class Extensions

{
    public static Color OverlayOnto(this Color a, Color b)
    {
        var alphaC = a.Alpha + (1 - a.Alpha) * b.Alpha;
        return new Color(
            1 / alphaC * (a.Alpha * a.Red + (1 - a.Alpha) * b.Alpha * b.Red),
            1 / alphaC * (a.Alpha * a.Green + (1 - a.Alpha) * b.Alpha * b.Green),
            1 / alphaC * (a.Alpha * a.Blue + (1 - a.Alpha) * b.Alpha * b.Blue),
            alphaC
            );
    }
}