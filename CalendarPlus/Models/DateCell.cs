using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CalendarPlus.Models;

public partial class DateCell : ObservableObject
{
    public DateTime Date { get; }
    
    public int Day { get; }

    public DayOfWeek DayOfWeek { get; }
    
    public bool IsWeekend => DayOfWeek == DayOfWeek.Saturday || DayOfWeek == DayOfWeek.Sunday;

    [ObservableProperty]
    private bool _isSelected;

    public bool IsCurrentMonth { get; }
    public bool IsToday { get; }

    public DateCell(int day, int month, int year, bool isCurrentMonth, bool isToday)
    {
        Date = new DateTime(year, month, day);
        Day = day;
        DayOfWeek = Date.DayOfWeek;
        IsCurrentMonth = isCurrentMonth;
        IsToday = isToday;
    }
}
