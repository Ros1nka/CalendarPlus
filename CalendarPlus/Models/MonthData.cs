using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CalendarPlus.Models;

public partial class MonthData : ObservableObject
{
    [ObservableProperty]
    private string _monthName;
    
    [ObservableProperty]
    private string _year;
    
    [ObservableProperty]
    private int _firstColumn;
    
    public ObservableCollection<DateCell> Days { get; set; }
    
    public static MonthData Create(int year, int month)
    {
        var firstDay = new DateTime(year, month, 1);
        
        var result = new MonthData
        {
            MonthName = firstDay.ToString("MMMM"),
            Year = firstDay.ToString("yyyy"),
            FirstColumn = (int)firstDay.DayOfWeek, // День недели первого дня
            Days = new ObservableCollection<DateCell>()
        };
        
        // Дни месяца
        int daysInMonth = DateTime.DaysInMonth(year, month);
        
        bool isCurrent = month == DateTime.Today.Month && year == DateTime.Today.Year;
        int dayOfCurrentMonth = isCurrent ? DateTime.Today.Day : 0;
        
        for (int day = 1; day <= daysInMonth; day++)
        {
            result.Days.Add(new DateCell(day, isCurrent, isCurrent && day == dayOfCurrentMonth));
        }
        
        return result;
    }
}