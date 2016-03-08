using System;
using Windows.UI.Xaml.Data;
using WoodenMoose.Helpers;

namespace WoodenMoose.Converters
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string result = string.Empty;

            var param = parameter as string;
            if (value != null && param != null)
            {
                if (param.StartsWith("Resources\\"))
                {
                    var translationKey = param.Remove(0, "Resources\\".Length);
                    result = string.Format(ResourceHelper.GetString(translationKey), value);
                }
                else
                {
                    result = string.Format(param, value);
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
