using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using LazApp.Base;

namespace LazApp.Converters
{
    public class MultiplicationConverter : MarkupExtension, IMultiValueConverter
    {
        public static MultiplicationConverter Instance = new MultiplicationConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var product = values.Select(v => double.Parse(v.ToString())).Prod();
            switch (targetType.Name)
            {
                case "Double": return product;
                case "Int": return (int)product;
                case "Thickness": return new Thickness(product, 0, 0, 0);
                default: throw new NotImplementedException();
            }
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => Instance;
    }
}
