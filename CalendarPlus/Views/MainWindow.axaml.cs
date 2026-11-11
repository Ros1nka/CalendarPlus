using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using CalendarPlus.ViewModels;
using CalendarPlus.Models;

namespace CalendarPlus.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void DayCell_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && 
            button.Tag is DateCell clickedCell &&
            DataContext is MainWindowViewModel vm)
        {
            vm.SelectDayCommand.Execute(clickedCell);
        }
    }
}
