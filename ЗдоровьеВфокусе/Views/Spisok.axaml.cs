using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using ЗдоровьеВфокусе.Models;

namespace ЗдоровьеВфокусе;

public partial class Spisok : Window
{
    public Spisok()
    {
        InitializeComponent();
        if (SavingDate.Slojnost=="none")
        {
            if (SavingDate.Vseuprgruppa == "Руки")
            {
                Titultext.Text = "Упражнения на руки и плечи";
                Listins(SavingDate.exercises.Where(x => x.Group == "Руки").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Ноги")
            {
                Titultext.Text = "Упражнения на ноги";
                Listins(SavingDate.exercises.Where(x => x.Group == "Ноги").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Грудь")
            {
                Titultext.Text = "Упражнения на грудь";
                Listins(SavingDate.exercises.Where(x => x.Group == "Грудь").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Пресс")
            {
                Titultext.Text = "Упражнения на пресс";
                Listins(SavingDate.exercises.Where(x => x.Group == "Пресс").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Всетело")
            {
                Titultext.Text = "Упражнения на все тело";
                Listins(SavingDate.exercises.Where(x => x.Group == "Всетело").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Всетелогрудь")
            {
                Titultext.Text = "Упражнения на живот";
                Listins(SavingDate.exercises.Where(x => x.Group == "Всетелогрудь").ToList());
            }
        }
        else
        {
            if (SavingDate.Vseuprgruppa == "Руки" && SavingDate.Slojnost == "Легко")
            {
                Titultext.Text = "Упражнения на руки и плечи";
                Listins(SavingDate.exercises.Where(x => x.Group == "Руки" && x.Slojnost == "Легко").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Руки" && SavingDate.Slojnost == "Средне")
            {
                Titultext.Text = "Упражнения на руки и плечи";
                Listins(SavingDate.exercises.Where(x => x.Group == "Руки" && x.Slojnost == "Средне").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Руки" && SavingDate.Slojnost == "Сложно")
            {
                Titultext.Text = "Упражнения на руки и плечи";
                Listins(SavingDate.exercises.Where(x => x.Group == "Руки" && x.Slojnost == "Сложно").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Ноги" && SavingDate.Slojnost == "Легко")
            {
                Titultext.Text = "Упражнения на ноги";
                Listins(SavingDate.exercises.Where(x => x.Group == "Ноги" && x.Slojnost == "Легко").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Ноги" && SavingDate.Slojnost == "Средне")
            {
                Titultext.Text = "Упражнения на ноги";
                Listins(SavingDate.exercises.Where(x => x.Group == "Ноги" && x.Slojnost == "Средне").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Ноги" && SavingDate.Slojnost == "Сложно")
            {
                Titultext.Text = "Упражнения на ноги";
                Listins(SavingDate.exercises.Where(x => x.Group == "Ноги" && x.Slojnost == "Сложно").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Пресс" && SavingDate.Slojnost == "Легко")
            {
                Titultext.Text = "Упражнения на пресс";
                Listins(SavingDate.exercises.Where(x => x.Group == "Пресс" && x.Slojnost == "Легко").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Пресс" && SavingDate.Slojnost == "Средне")
            {
                Titultext.Text = "Упражнения на пресс";
                Listins(SavingDate.exercises.Where(x => x.Group == "Пресс" && x.Slojnost == "Средне").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Пресс" && SavingDate.Slojnost == "Сложно")
            {
                Titultext.Text = "Упражнения на пресс";
                Listins(SavingDate.exercises.Where(x => x.Group == "Пресс" && x.Slojnost == "Сложно").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Грудь" && SavingDate.Slojnost == "Легко")
            {
                Titultext.Text = "Упражнения на грудь";
                Listins(SavingDate.exercises.Where(x => x.Group == "Грудь" && x.Slojnost == "Легко").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Грудь" && SavingDate.Slojnost == "Средне")
            {
                Titultext.Text = "Упражнения на грудь";
                Listins(SavingDate.exercises.Where(x => x.Group == "Грудь" && x.Slojnost == "Средне").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Грудь" && SavingDate.Slojnost == "Сложно")
            {
                Titultext.Text = "Упражнения на грудь";
                Listins(SavingDate.exercises.Where(x => x.Group == "Грудь" && x.Slojnost == "Сложно").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Всетело" && SavingDate.Slojnost == "Легко")
            {
                Titultext.Text = "Упражнения на все тело";
                Listins(SavingDate.exercises.Where(x => x.Group == "Всетело" && x.Slojnost == "Легко").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Всетело" && SavingDate.Slojnost == "Средне")
            {
                Titultext.Text = "Упражнения на все тело";
                Listins(SavingDate.exercises.Where(x => x.Group == "Всетело" && x.Slojnost == "Средне").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Всетело" && SavingDate.Slojnost == "Сложно")
            {
                Titultext.Text = "Упражнения на все тело";
                Listins(SavingDate.exercises.Where(x => x.Group == "Всетело" && x.Slojnost == "Сложно").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Всетелогрудь" && SavingDate.Slojnost == "Легко")
            {
                Titultext.Text = "Упражнения на снижение веса";
                Listins(SavingDate.exercises.Where(x => x.Group == "Всетелогрудь" && x.Slojnost == "Легко").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Всетелогрудь" && SavingDate.Slojnost == "Средне")
            {
                Titultext.Text = "Упражнения на снижение веса";
                Listins(SavingDate.exercises.Where(x => x.Group == "Всетелогрудь" && x.Slojnost == "Средне").ToList());
            }
            else if (SavingDate.Vseuprgruppa == "Всетелогрудь" && SavingDate.Slojnost == "Сложно")
            {
                Titultext.Text = "Упражнения на снижение веса";
                Listins(SavingDate.exercises.Where(x => x.Group == "Всетелогрудь" && x.Slojnost == "Сложно").ToList());
            }


        }

    }
    
    public void Listins(List<Exercise> exercises)
    {
       SpisokUpr.ItemsSource = exercises.Select(x=>new
       {
           x.Id,
           x.Name,
           x.Description,
           img=$"avares://ЗдоровьеВфокусе/Assets/{x.Image}" ,          
           Slojnost1=$"Сложность:{x.Slojnost}",
           Povtor=$"Сколько выполнять:{x.Povtorenia}"
        
       });
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Переход к конкретному упражнению 
    {
        var btn=sender as Button;
        int id = (int)btn!.Tag!;
        SavingDate.ipupr = id ;
        new Uprajnenie().Show();
        Close();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Основное меню
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        SavingDate.ipupr = - 1;
        new Glavnoemenu().Show();
        Close();
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всеми упражнениями
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost= "none";
        SavingDate.ipupr = -1;
        new VseUprajnenia().Show();
        Close();
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всеми достижениями 
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        SavingDate.ipupr = -1;
        new Achiv().Show();
        Close();
    }

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всей статой
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        SavingDate.ipupr = -1;
        new OtchetMenu().Show();
        Close();
    }
}