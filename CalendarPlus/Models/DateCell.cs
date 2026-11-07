using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CalendarPlus.Models;

public partial class DateCell : ObservableObject
{
    [ObservableProperty]
    private int _day;

    [ObservableProperty]
    private bool _isCurrentMonth;

    [ObservableProperty]
    private bool _isToday;

    [ObservableProperty]
    private bool _isSelected;

    public DateCell(int day, bool isCurrentMonth, bool isToday)
    {
        _day = day;
        _isCurrentMonth = isCurrentMonth;
        _isToday = isToday;
        _isSelected = false;
    }
}
