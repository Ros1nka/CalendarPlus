using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CalendarPlus.Models;

public partial class MonthData : ObservableObject
{
    [ObservableProperty]
    private DateTime _date;
    
    [ObservableProperty]
    private string _monthName = string.Empty;
    
    [ObservableProperty]
    private string _year  = string.Empty;
    
    [ObservableProperty]
    private int _firstColumn;
    
    public ObservableCollection<DateCell> Days { get; } = []; 
    
    public static MonthData Create(int year, int month)
    {
        var firstDay = new DateTime(year, month, 1);
        
        var monthString = firstDay.ToString("MMMM");
        var name = char.ToUpper(monthString[0]) + monthString[1..];
        
        int dayOfWeek = (int)firstDay.DayOfWeek;
        int firstColumn = dayOfWeek == 0 ? 6 : dayOfWeek - 1;
        
        var result = new MonthData
        {
            Date = firstDay,
            MonthName = name,
            Year = firstDay.ToString("yyyy"),
            FirstColumn = firstColumn
        };
        
        // Дни месяца
        int daysInMonth = DateTime.DaysInMonth(year, month);
        
        bool isCurrent = month == DateTime.Today.Month && year == DateTime.Today.Year;
        int dayOfCurrentMonth = isCurrent ? DateTime.Today.Day : 0;
        
        for (int day = 1; day <= daysInMonth; day++)
        {
            result.Days.Add(new DateCell(
                day, 
                month, 
                year,
                isCurrent, 
                isCurrent && day == dayOfCurrentMonth
            ));
        }
        
        return result;
    }
}