using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CalendarPlus.Models;
using SkiaSharp;

namespace CalendarPlus.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<MonthData> _months = [];
    [ObservableProperty] private DateCell? _selectedCell;
    [ObservableProperty] private DateTime _currentDate = DateTime.Now;

    public MainWindowViewModel()
    {
        LoadInitialMonths();
    }

    private void LoadInitialMonths()
    {
        Months.Clear();
        
        DateTime startDate = CurrentDate.AddMonths(-1);

        for (int i = 0; i < 5; i++)
        {
            DateTime targetDate = startDate.AddMonths(i);
            
            Months.Add(MonthData.Create(targetDate.Year, targetDate.Month));
        }
    }

    [RelayCommand]
    private void PreviousMonth()
    {
        // Берем самый первый месяц и отнимаем 1 месяц
        var newMonthDate = Months.First().Date.AddMonths(-1);
        
        Months.Insert(0, MonthData.Create(newMonthDate.Year, newMonthDate.Month));
        
        // Оптимизация: Удаляем последний месяц, чтобы коллекция не росла бесконечно (держим 3 месяца)
        if (Months.Count > 8)
        {
            Months.RemoveAt(Months.Count - 1);
        }
    }

    [RelayCommand]
    private void NextMonth()
    {
        // Берем последний месяц и прибавляем 1 месяц.
        var newMonthDate = Months.Last().Date.AddMonths(1);
        
        Months.Add(MonthData.Create(newMonthDate.Year, newMonthDate.Month));
        
        // Оптимизация: Удаляем первый месяц, чтобы коллекция не росла бесконечно
        if (Months.Count > 8)
        {
            Months.RemoveAt(0);
        }
    }

    [RelayCommand]
    private void SelectDay(DateCell cell)
    {
        // Если ячейка уже выбрана, ничего не делаем
        if (SelectedCell == cell) return;

        // Снимаем выделение только с предыдущей выбранной ячейки (O(1) вместо O(N))
        if (SelectedCell != null)
        {
            SelectedCell.IsSelected = false;
        }

        // Выделяем новую и запоминаем её
        cell.IsSelected = true;
        SelectedCell = cell;
        
        // Опционально: обновляем текущую дату вьюмодели для заголовка или других нужд
        // CurrentDate = new DateTime(...); 
    }
}