using AnimatedImage.Avalonia;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using ЗдоровьеВфокусе.Models;
using AnimatedImage.Avalonia;
using System.Speech.Synthesis;
namespace ЗдоровьеВфокусе;

public partial class Uprajnenie : Window
{
    public string MyText { get; set; } = "Привет, Avalonia!";
    private static SpeechSynthesizer synth = new SpeechSynthesizer();

    private List<Exercise> exercises = SavingDate.exercises.Where(x => x.Group == SavingDate.Vseuprgruppa && x.Id==SavingDate.ipupr).OrderBy(x => x.Id).ToList();
    private List<Exercise> exercises1 = SavingDate.exercises.Where(x => x.Group == SavingDate.Vseuprgruppa && x.Id == SavingDate.ipupr &&x.Slojnost==SavingDate.Slojnost).OrderBy(x => x.Id).ToList();
    public Uprajnenie()
    {
        InitializeComponent();
        if (SavingDate.Slojnost=="none")
        {
            Titultext.Text = $"{exercises[0].Name}";
            MyText = $"avares://ЗдоровьеВфокусе/Assets/{exercises[0].Image}";
            DataContext = this; // Привязка к самому окну
            Opis.Text = $"{exercises[0].Description}";
            ColvoPovtor.Text = $"Количество повторений:{exercises[0].Povtorenia}";
            List<Exercise> listprov = SavingDate.exercises.Where(x => x.Group == SavingDate.Vseuprgruppa).ToList();
            if (SavingDate.ipupr == listprov[0].Id)
            {
                Left.IsVisible = false;
            }
            if (SavingDate.ipupr == listprov[listprov.Count - 1].Id)
            {
                Right.IsVisible = false;
            }
        }
        else
        {
            Titultext.Text = $"{exercises1[0].Name}";
            MyText = $"avares://ЗдоровьеВфокусе/Assets/{exercises1[0].Image}";
            DataContext = this; // Привязка к самому окну
            Opis.Text = $"{exercises1[0].Description}";
            ColvoPovtor.Text = $"Количество повторений:{exercises1[0].Povtorenia}";
            List<Exercise> listprov = SavingDate.exercises.Where(x => x.Group == SavingDate.Vseuprgruppa && x.Slojnost == SavingDate.Slojnost).ToList();
            if (SavingDate.ipupr == listprov[0].Id)
            {
                Left.IsVisible = false;
            }
            if (SavingDate.ipupr == listprov[listprov.Count - 1].Id)
            {
                Right.IsVisible = false;
            }
        }
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
        Close(); ;
    }

    private void Button_Click_9(object? sender, Avalonia.Interactivity.RoutedEventArgs e)//Меню со всей статой
    {
        SavingDate.Vseuprgruppa = "none";
        SavingDate.Slojnost = "none";
        new OtchetMenu().Show();
        Close();
    }

    private void Button_Click_10(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if ( SavingDate.ipupr-1!=-1)
        {
            SavingDate.ipupr=SavingDate.ipupr-1;
           new Uprajnenie().Show();
            Close();
        }
    }

    private void Button_Click_11(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SavingDate.ipupr+1!=exercises.Count)
        {
            SavingDate.ipupr = SavingDate.ipupr + 1;
            new Uprajnenie().Show();
            Close();
        }
    }

    private void Button_Click_12(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        synth.SpeakAsync($"{exercises[0].Description}");
    }
}