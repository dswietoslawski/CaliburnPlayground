using CaliburnPlayground.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CaliburnPlayground.Helpers
{
    public class SingleToEnumerableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Sku sku = value as Sku;
            List<Sku> skus = new List<Sku>();
            skus.Add(sku);

            return skus;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return value;
        }
    }
}
