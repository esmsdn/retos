namespace SudokuApp.Views.Converters
{
    using System;
    using Windows.UI.Xaml.Data;

    /// <summary>
    /// Conversor necesario para que un data binding a un valor nulable funcione bien en modo 'TwoWay'
    /// </summary>
    public class NullableValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string s = value as string;

            int result;
            if (!string.IsNullOrWhiteSpace(s) && int.TryParse(s, out result))
            {
                return result;
            }

            return null;
        }
    }
}
