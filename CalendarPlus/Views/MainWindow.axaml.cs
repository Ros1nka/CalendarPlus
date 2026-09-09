using Avalonia.Controls;
using Avalonia.Input;
using CalendarPlus.ViewModels;
using CalendarPlus.Models;

namespace CalendarPlus.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void DayCell_Tapped(object? sender, TappedEventArgs e)
    {
        if (DataContext is MainWindowViewModel viewModel && sender is Border border)
        {
            var cell = border.DataContext as DateCell;
            if (cell != null)
            {
                viewModel.SelectDayCommand.Execute(cell);
            }
        }
    }
}
