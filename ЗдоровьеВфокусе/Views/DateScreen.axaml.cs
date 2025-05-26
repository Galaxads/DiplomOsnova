using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ЗдоровьеВфокусе;

public partial class DateScreen : Window
{
    public DateScreen()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SavingDate.users[0].Gender = 1;
        Helper.user015Context.SaveChanges();
        new RostAndVesScreen().Show();
        Close();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        
        SavingDate.users[0].Gender = 2;
        Helper.user015Context.SaveChanges();
        new RostAndVesScreen().Show();
        Close();
    }
}