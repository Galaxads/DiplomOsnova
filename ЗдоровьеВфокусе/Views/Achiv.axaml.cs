using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using ЗдоровьеВфокусе.Models;

namespace ЗдоровьеВфокусе;

public partial class Achiv : Window
{
    public Achiv()
    {
        InitializeComponent();
        for (int i = 0;i<SavingDate.achivkas.Count ;i++)
        {
            if (i == 0 && SavingDate.bioinfs.Count>0)
            {
                SavingDate.achivkas[i].End = true;
                Helper.user015Context.SaveChanges();
            }
            else if (i == 1 &&SavingDate.unicalplans.Count!=0)
            {
                SavingDate.achivkas[i].End = true;
                Helper.user015Context.SaveChanges();
            }
            else if (i == 2 && SavingDate.unicalplans.Count == 28)
            {
                SavingDate.achivkas[i].End = true;
                Helper.user015Context.SaveChanges();
            }
            else if (i == 3 && SavingDate.bioinfs.Count>4)
            {
                SavingDate.achivkas[i].End = true;
                Helper.user015Context.SaveChanges();
            }
        }
        Listins(SavingDate.achivkas.ToList());
    }
    public void Listins(List<Achivka> exercises)
    {
        SpisokUpr.ItemsSource = exercises.Select(x => new
        {
            x.Id,
            x.Name,
            x.Description,
            Background= x.End ==false ? "White" : "Green",
            Title=$"{x.Name} {x.Description}"
          

        });
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Переход к конкретному упражнению 
    {
        var btn = sender as Button;
        int id = (int)btn!.Tag!;
        SavingDate.ipupr = id;
        new Uprajnenie().Show();
        Close();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Основное меню
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        SavingDate.ipupr = -1;
        new Glavnoemenu().Show();
        Close();
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всеми упражнениями
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
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