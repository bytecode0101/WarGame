using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using WarGame.Models.Resources;

namespace Curs28WPF.Converters
{
    public class ResourceToColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.Transparent);
            Resource status = (Resource)value;

            switch(status)
            {
                case Resource.Gold:
                    {
                        color.Color = Colors.Gold;
                        break;
                    }
                case Resource.Wood:
                    {
                        color.Color = Colors.Brown;
                        break;
                    }
                case Resource.Iron:
                    {
                        color.Color = Colors.Silver;
                        break;
                    }
                case Resource.Food:
                    {
                        color.Color = Colors.Red;
                        break;
                    }
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
