using System.Globalization;

namespace LazApp.Converters
{
    public class MultiplicationConverter : IMarkupExtension, IValueConverter
    {
        public static MultiplicationConverter Instance = new();

        public object Convert(object? values, Type targetType, object? parameter, CultureInfo culture)
        {
            //var product = values.Select(v => double.Parse(v.ToString())).Prod();
            var product = double.Parse(values?.ToString() ?? "0") * double.Parse(parameter?.ToString() ?? "1");

            switch (targetType.Name)
            {
                case "Double": return product;
                case "Int": return (int)product;
                case "Thickness": return new Thickness(product, 0, 0, 0);
                default: throw new NotImplementedException();
            }
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider) => Instance;
    }
}
