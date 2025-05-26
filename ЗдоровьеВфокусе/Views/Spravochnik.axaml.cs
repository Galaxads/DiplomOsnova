using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ЗдоровьеВфокусе;

public partial class Spravochnik : Window
{
    public Spravochnik()
    {
        InitializeComponent();
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new VseUprajnenia().Show();
        Close();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Glavnoemenu().Show();
        Close();
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Achiv().Show();
        Close();
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new OtchetMenu().Show();
        Close();
    }

}