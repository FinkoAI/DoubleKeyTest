using System;
using System.Globalization;
using System.Windows.Data;

namespace TestApplication.UI.Content.Converters
{
    [ValueConversion(typeof(Enum), typeof(bool))]
    public class EnumToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Возвращает соответствующий выбранному RadioButton enum
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            string enumValue = value.ToString();
            string targetValue = parameter.ToString();
            bool outputValue = enumValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);
            return outputValue;
        }

        /// <summary>
        /// Выбирает RadioButton в зависимости от enum параметра
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return null;
            bool useValue = (bool)value;
            string targetValue = parameter.ToString();
            if (useValue) return Enum.Parse(targetType, targetValue);
            return null;
        }
    }
}
