using System.Windows.Data;
using System.Windows.Media;
using System;

namespace WPFLab.Extension
{
    public class PriceToBackgroundConverter : IValueConverter
    {
        public decimal MinimumPriceToHighlight
        {
            get;
            set;
        }
        public Brush HighlightBrush
        {
            get;
            set;
        }
        public Brush DefaultBrush
        {
            get;
            set;
        }
        public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            decimal price = (decimal)value;
            if (price >= MinimumPriceToHighlight)
                return HighlightBrush;
            else
                return DefaultBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
