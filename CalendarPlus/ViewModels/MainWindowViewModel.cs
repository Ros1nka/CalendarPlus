using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CalendarPlus.Models;

namespace CalendarPlus.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private DateTime _currentMonthDate = DateTime.Today;

    [ObservableProperty]
    private DateTime? _selectedDate = DateTime.Today;

    private ObservableCollection<ObservableCollection<DateCell>> _weeks = new();
    public ObservableCollection<ObservableCollection<DateCell>> Weeks
    {
        get => _weeks;
        set => SetProperty(ref _weeks, value);
    }

    private string _headerText = string.Empty;
    public string HeaderText
    {
        get => _headerText;
        set => SetProperty(ref _headerText, value);
    }

    public MainWindowViewModel()
    {
        GenerateCalendar();
    }

    private void GenerateCalendar()
    {
        var weeks = new ObservableCollection<ObservableCollection<DateCell>>();
        var firstDayOfMonth = new DateTime(CurrentMonthDate.Year, CurrentMonthDate.Month, 1);
        var firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek; // 0=Sunday, 6=Saturday

        var startDate = firstDayOfMonth.AddDays(-firstDayOfWeek);
        var today = DateTime.Today;

        for (int week = 0; week < 6; week++)
        {
            var weekCells = new ObservableCollection<DateCell>();
            for (int day = 0; day < 7; day++)
            {
                var currentDate = startDate.AddDays(week * 7 + day);
                var isCurrentMonth = currentDate.Month == CurrentMonthDate.Month;
                var isToday = currentDate.Date == today.Date;
                var cell = new DateCell(currentDate, isCurrentMonth, isToday);

                if (isToday)
                {
                    cell.IsSelected = true;
                    SelectedDate = currentDate;
                }

                weekCells.Add(cell);
            }
            weeks.Add(new ObservableCollection<DateCell>(weekCells));
        }

        Weeks = weeks;
        HeaderText = CurrentMonthDate.ToString("MMMM yyyy").ToUpper();
    }

    [RelayCommand]
    private void PreviousMonth()
    {
        CurrentMonthDate = CurrentMonthDate.AddMonths(-1);
        GenerateCalendar();
    }

    [RelayCommand]
    private void NextMonth()
    {
        CurrentMonthDate = CurrentMonthDate.AddMonths(1);
        GenerateCalendar();
    }

    [RelayCommand]
    private void SelectDay(DateCell cell)
    {
        foreach (var week in Weeks)
        {
            foreach (var c in week)
            {
                c.IsSelected = false;
            }
        }
        cell.IsSelected = true;
        SelectedDate = cell.CellDate;
    }
}
