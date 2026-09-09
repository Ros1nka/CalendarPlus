using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CalendarPlus.Models;

public partial class DateCell : ObservableObject
{
    [ObservableProperty]
    private DateTime _cellDate;

    [ObservableProperty]
    private int _day;

    [ObservableProperty]
    private int _month;

    [ObservableProperty]
    private int _year;

    [ObservableProperty]
    private bool _isCurrentMonth;

    [ObservableProperty]
    private bool _isToday;

    [ObservableProperty]
    private bool _isSelected;

    public DateCell(DateTime date, bool isCurrentMonth, bool isToday)
    {
        _cellDate = date;
        _day = date.Day;
        _month = date.Month;
        _year = date.Year;
        _isCurrentMonth = isCurrentMonth;
        _isToday = isToday;
        _isSelected = false;
    }
}
