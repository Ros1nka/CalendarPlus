using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CalendarPlus.Models;

public partial class MonthData : ObservableObject
{
    [ObservableProperty]
    private string _monthName;
    
    [ObservableProperty]
    private int _firstColumn;
    
    public ObservableCollection<DateCell> Days { get; set; }
    
    public static MonthData Create(int year, int month)
    {
        var firstDay = new DateTime(year, month, 1);
        
        var result = new MonthData
        {
            MonthName = firstDay.ToString("MMMM yyyy"),
            FirstColumn = (int)firstDay.DayOfWeek, // День недели первого дня
            Days = new ObservableCollection<DateCell>()
        };
        
        // Заполнители БОЛЬШЕ НЕ НУЖНЫ!
        
        // Дни месяца
        int daysInMonth = DateTime.DaysInMonth(year, month);
        for (int day = 1; day <= daysInMonth; day++)
        {
            result.Days.Add(new DateCell (day, true, new DateTime(year, month, day) == DateTime.Today)
            { 
                Day = day,
                IsCurrentMonth = true,
                IsToday = new DateTime(year, month, day) == DateTime.Today
            });
        }
        
        return result;
    }
}