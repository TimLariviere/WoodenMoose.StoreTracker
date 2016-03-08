using System;
using Windows.UI.Xaml.Data;
using WoodenMoose.Helpers;
using WoodenMoose.ViewModels.UserControls;

namespace WoodenMoose.Converters
{
    public class DateAndReviewerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var vm = value as ReviewUserControlViewModel;
            if (vm != null)
            {
                return string.Format(ResourceHelper.GetString("DateAndReviewerConverter_Text", ResourcesFileEnum.MessagesResources), vm.Date, vm.Author);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
