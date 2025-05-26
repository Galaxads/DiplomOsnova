using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;

namespace ЗдоровьеВфокусе;

public partial class VseUprajnenia : Window
{
    public VseUprajnenia()
    {
        InitializeComponent();
        Руки.Text = $"Упражнений {SavingDate.exercises.Where(x=>x.Group=="Руки").ToList().Count}";
        Ноги.Text= $"Упражнений {SavingDate.exercises.Where(x => x.Group == "Ноги").ToList().Count}";
        Грудь.Text = $"Упражнений {SavingDate.exercises.Where(x => x.Group == "Грудь").ToList().Count}";
        Пресс.Text = $"Упражнений {SavingDate.exercises.Where(x => x.Group == "Пресс").ToList().Count}";
        ВсеТело.Text = $"Упражнений {SavingDate.exercises.Where(x => x.Group == "Всетело").ToList().Count}";
        Живот.Text = $"Упражнений {SavingDate.exercises.Where(x => x.Group == "Всетелогрудь").ToList().Count}";
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Руки и плечи набор масссы
    {
        SavingDate.Vseuprgruppa = "Руки";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Ноги набор масссы
    {
        SavingDate.Vseuprgruppa = "Ноги";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Грудь набор масссы
    {
        SavingDate.Vseuprgruppa = "Грудь";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Пресс набор массы
    {
        SavingDate.Vseuprgruppa = "Пресс";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Все тело снижение веса
    {
        SavingDate.Vseuprgruppa = "Всетело";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Грудь снижение веса
    {
        SavingDate.Vseuprgruppa = "Всетелогрудь";
        new Spisok().Show();
        Close();
    }
    private void Button_Click_6(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Основное меню
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.ipupr = -1;
        new Glavnoemenu().Show();
        Close();
    }

    private void Button_Click_7(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всеми упражнениями
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.ipupr = -1;
        new VseUprajnenia().Show();
        Close();
    }

    private void Button_Click_8(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всеми достижениями 
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.ipupr = -1;
        new Achiv().Show();
        Close();
    }

    private void Button_Click_9(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всей статой
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.ipupr = -1;
        new OtchetMenu().Show();
        Close();
    }
}