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
            Operation op = Tools.TypeTransaction(((Models.Transaction)value).Expediteur, ((Models.Transaction)value).Destinataire);
            string ret = "Error";
            if (value is Models.Transaction)
            {
                switch (op){
                    case Operation.RetraitSimple:
                        ret = "Retrait";
                        break;
                    case Operation.DepotSimple:
                        ret = "Dépôt";
                        break;
                    case Operation.InterCompte:
                        ret = "Virement";
                        break;
                    default:
                        break;
                }

            }
            return ret;
           

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // Pas besoin en lecture seule
        }
    }
}
