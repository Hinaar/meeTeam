using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Client
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        private static T mConverter = null; //xamlbe ezt


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T()); //ha meg nincs letrehoz egy ujat belole(adott converterboll)
        }



        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
