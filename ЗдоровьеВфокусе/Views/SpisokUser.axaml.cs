using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using ЗдоровьеВфокусе.Models;

namespace ЗдоровьеВфокусе;

public partial class SpisokUser : Window
{
    public SpisokUser()
    {
        InitializeComponent();
        List<Exercise> exercise = new List<Exercise>();
        List<Perosnalupr> unicalplan = SavingDate.perosnaluprs.Where(x=>x.Idday==SavingDate.day).ToList();
        for (int i = 0; i < unicalplan.Count-1; i++)
        {
            exercise.Add(SavingDate.exercises[((int)unicalplan[i].Idupr)-1]);
        }
        SavingDate.exercisesunical=exercise;
        Listins(exercise);
    }
    public void Listins(List<Exercise> exercises)
    {
        List<Perosnalupr> unicalplanss = SavingDate.perosnaluprs.Where(x=>x.Idday==SavingDate.day).ToList();
        SpisokUpr.ItemsSource = exercises.Select(x => new
        {
            x.Id,
            x.Name,
            x.Description,
            img = $"avares://ЗдоровьеВфокусе/Assets/{x.Image}",
            Slojnost1 = $"Сложность:{x.Slojnost}",
            Povtor = $"Сколько выполнять:{x.Povtorenia}",
            Proverka=prov(x.Id),
            

        });
    }

    private string prov (int id)
    {
        List<Perosnalupr> unicalplanss = SavingDate.perosnaluprs.Where(x => x.Idday == SavingDate.day && x.Idupr==id && x.End==true).ToList();
        if (unicalplanss.Count == 0)
        {
            return "White";
        }
        else
        {
            return "Green";
        }
          
    }
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Переход к конкретному упражнению 
    {
        //var btn = sender as Button;
        //int id = (int)btn!.Tag!;
        //SavingDate.ipupr = id;
        //new UserUpr().Show();
        //Close();
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Основное меню
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        SavingDate.ipupr = -1;
        SavingDate.exercisesunical.Clear();
        new Glavnoemenu().Show();
        Close();
    }

    private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всеми упражнениями
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        SavingDate.ipupr = -1;
        SavingDate.exercisesunical.Clear();
        new VseUprajnenia().Show();
        Close();
    }

    private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всеми достижениями 
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        SavingDate.ipupr = -1;
        SavingDate.exercisesunical.Clear();
        new Achiv().Show();
        Close();
    }

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всей статой
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        SavingDate.ipupr = -1;
        SavingDate.exercisesunical.Clear();
        new OtchetMenu().Show();
        Close();
    }

    private void Button_Click_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var btn = sender as Button;
        List<Perosnalupr> unicalplanss = SavingDate.perosnaluprs.Where(x => x.Idday == SavingDate.day  && x.End == false).ToList();

        //int b = 0;
        //int id = 0;
        //for (bool i = false; i != true || b<=unicalplanss.Count;b++)
        //{
        //    List<Perosnalupr> unicalplans = SavingDate.perosnaluprs.Where(x => x.Idday == SavingDate.day && x.End == true && SavingDate.exercises[b].Id == x.Idupr).ToList();
        //    if (unicalplans.Count == 0)
        //    {
        //        i = false;
        //    }
        //    else
        //    {
        //       i= true;
        //        id= b;
        //    }
        //}
            SavingDate.ipupr =(int) unicalplanss[0].Idupr;
        new UserUpr().Show();
        Close();
    }
}