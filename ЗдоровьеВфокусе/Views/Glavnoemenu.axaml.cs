using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Linq;

namespace ЗдоровьеВфокусе;

public partial class Glavnoemenu : Window
{
    public Glavnoemenu()
    {
        InitializeComponent();
        Ruki1.Text = $"Упражнений:{SavingDate.exercises.Where(x=>x.Group=="Руки"&& x.Slojnost=="Легко").ToList().Count}";
        Ruki2.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Руки" && x.Slojnost == "Средне").ToList().Count}";
        Ruki3.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Руки" && x.Slojnost == "Сложно").ToList().Count}";
        grudi1.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Грудь" && x.Slojnost == "Легко").ToList().Count}";
        grudi2.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Грудь" && x.Slojnost == "Средне").ToList().Count}";
        grudi3.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Грудь" && x.Slojnost == "Сложно").ToList().Count}";
        press1.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Пресс" && x.Slojnost == "Легко").ToList().Count}";
        press2.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Пресс" && x.Slojnost == "Средне").ToList().Count}";
        ress3.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Пресс" && x.Slojnost == "Сложно").ToList().Count}";
        nogi1.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Ноги" && x.Slojnost == "Легко").ToList().Count}";
        nogi2.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Ноги" && x.Slojnost == "Средне").ToList().Count}";
        nogi3.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Ноги" && x.Slojnost == "Сложно").ToList().Count}";
        vsetelo1.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Всетело" && x.Slojnost == "Легко").ToList().Count}";
        vsetelo2.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Всетело" && x.Slojnost == "Средне").ToList().Count}";
        vsetelo3.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Всетело" && x.Slojnost == "Сложно").ToList().Count}";
        pohud1.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Всетелогрудь" && x.Slojnost == "Легко").ToList().Count}";
        pohud2.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Всетелогрудь" && x.Slojnost == "Средне").ToList().Count}";
        pohud3.Text = $"Упражнений:{SavingDate.exercises.Where(x => x.Group == "Всетелогрудь" && x.Slojnost == "Сложно").ToList().Count}";
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

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//личный план
    {
        new DayComlect().Show();
        Close ();
    }

    private void Button_Click_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//руки легко 
    {
        SavingDate.Vseuprgruppa = "Руки";
        SavingDate.Slojnost = "Легко";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_6(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//руки средне 
    {
        SavingDate.Vseuprgruppa = "Руки";
        SavingDate.Slojnost = "Средне";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_7(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//руки сложно
    {
        SavingDate.Vseuprgruppa = "Руки";
        SavingDate.Slojnost = "Сложно";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_8(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//грудь легко
    {
        SavingDate.Vseuprgruppa = "Грудь";
        SavingDate.Slojnost = "Легко";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_9(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//грудь средне
    {
        SavingDate.Vseuprgruppa = "Грудь";
        SavingDate.Slojnost = "Средне";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_10(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//грудь сложно
    {
        SavingDate.Vseuprgruppa = "Грудь";
        SavingDate.Slojnost = "Сложно";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_11(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//пресс легко
    {
        SavingDate.Vseuprgruppa = "Сложно";
        SavingDate.Slojnost = "Легко";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_12(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//пресс средно
    {
        SavingDate.Vseuprgruppa = "Пресс";
        SavingDate.Slojnost = "Средне";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_13(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//пресс сложно
    {
        SavingDate.Vseuprgruppa = "Пресс";
        SavingDate.Slojnost = "Сложно";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_14(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//ноги легко
    {
        SavingDate.Vseuprgruppa = "Ноги";
        SavingDate.Slojnost = "Легко";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_15(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//ноги средне
    {
        SavingDate.Vseuprgruppa = "Ноги";
        SavingDate.Slojnost = "Средне";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_16(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//ноги сложно
    {
        SavingDate.Vseuprgruppa = "Ноги";
        SavingDate.Slojnost = "Сложно";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_17(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//все тело легко
    {
        SavingDate.Vseuprgruppa = "Всетело";
        SavingDate.Slojnost = "Легко";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_18(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//все тело средне
    {
        SavingDate.Vseuprgruppa = "Всетело";
        SavingDate.Slojnost = "Средне";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_19(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//все тело сложно
    {
        SavingDate.Vseuprgruppa = "Всетело";
        SavingDate.Slojnost = "Сложно";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_20(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//снижение веса легко
    {
        SavingDate.Vseuprgruppa = "Всетелогрудь";
        SavingDate.Slojnost = "Легко";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_21(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//снижение веса средне
    {
        SavingDate.Vseuprgruppa = "Всетелогрудь";
        SavingDate.Slojnost = "Средне";
        new Spisok().Show();
        Close();
    }

    private void Button_Click_22(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//снижение веса сложно
    {
        SavingDate.Vseuprgruppa = "Всетелогрудь";
        SavingDate.Slojnost = "Сложно";
        new Spisok().Show();
        Close();
    }
}