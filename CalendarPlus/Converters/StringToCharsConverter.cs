using System;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace CalendarPlus.Converters;

public class StringToCharsConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value?.ToString()?.ToCharArray() ?? Array.Empty<char>();

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}