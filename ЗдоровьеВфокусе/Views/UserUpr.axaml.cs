using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using ЗдоровьеВфокусе.Models;

namespace ЗдоровьеВфокусе;

public partial class UserUpr : Window
{
    public string MyText { get; set; } = "Привет, Avalonia!";
    private static SpeechSynthesizer synth = new SpeechSynthesizer();

    private List<Exercise> exercises = SavingDate.exercisesunical.Where(x=>x.Id==SavingDate.ipupr).ToList();
   
    public UserUpr()
    {
        InitializeComponent();
       
            Titultext.Text = $"{exercises[0].Name}";
            MyText = $"avares://ЗдоровьеВфокусе/Assets/{exercises[0].Image}";
            DataContext = this; // Привязка к самому окну
            Opis.Text = $"{exercises[0].Description}";
            ColvoPovtor.Text = $"Количество повторений:{exercises[0].Povtorenia}";
           
           
        
       
    }
    private void Button_Click_6(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Основное меню
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        new Glavnoemenu().Show();
        Close();
    }

    private void Button_Click_7(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всеми упражнениями
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        new VseUprajnenia().Show();
        Close();
    }

    private void Button_Click_8(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всеми достижениями 
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        new Achiv().Show();
        Close();
    }

    private void Button_Click_9(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всей статой
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        new OtchetMenu().Show();
        Close();
    }

  

    private void Button_Click_11(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        List<Exercise> exercises = SavingDate.exercisesunical.Where(x => x.Id == SavingDate.ipupr+1).ToList();

        if ( exercises.Count==1)
        {
            List<Perosnalupr> perosnaluprs = SavingDate.perosnaluprs.Where(x=>x.Idday==SavingDate.day&& x.Idupr ==SavingDate.ipupr).ToList();
            perosnaluprs[0].End = true;
            Helper.user015Context.SaveChanges();
            SavingDate.ipupr = SavingDate.ipupr + 1;
            new UserUpr().Show();
            Close();
        }
        else if ( exercises.Count==0)
        {
            List<Unicalplan> unicalplans= SavingDate.unicalplans.Where(x=>x.Day==SavingDate.day).ToList();
            unicalplans[0].End= true;
            Helper.user015Context.SaveChanges();
            new Glavnoemenu().Show();
            Close   ();

        }
    }

    private void Button_Click_12(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        synth.SpeakAsync($"{exercises[0].Description}");
    }
}