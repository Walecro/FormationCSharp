using System;
using System.Globalization;
using System.Windows.Data;

namespace Or.Business
{
    public class TypeTransacConverter : IValueConverter
    {
        private static readonly CultureInfo EuroCulture = new CultureInfo("fr-FR");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is )
            {
                return value;
            } 

;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // Pas besoin en lecture seule
        }
    }
}
