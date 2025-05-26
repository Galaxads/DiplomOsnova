using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using System;
using System.Linq;
using ЗдоровьеВфокусе.Models;

namespace ЗдоровьеВфокусе;

public partial class RostAndVesScreen : Window
{
    public RostAndVesScreen()
    {
        InitializeComponent();
    }
    private int selectedHeight=170;
    private int selectedHeight1=100;

    private void Slider_PropertyChanged(object? sender, Avalonia.AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property == Slider.ValueProperty) 
        {
             selectedHeight = (int)HeightSlider.Value;
            SelectedHeightText.Text = $"Выбранный рост: {selectedHeight} см";
        }
    }

    private void Slider_PropertyChanged_1(object? sender, Avalonia.AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property == Slider.ValueProperty)
        {
           selectedHeight1 = (int)HeightSlider1.Value;
            SelectedHeightText1.Text = $"Выбранный вес: {selectedHeight1} кг";
        }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Bioinf bioinf = new Bioinf();
      
        bioinf.Ves = selectedHeight1;
        bioinf.Rost = selectedHeight;
      
        bioinf.Date= DateOnly.FromDateTime(DateTime.Now);
        Helper.user015Context.Bioinfs.Add(bioinf);
        Helper.user015Context.SaveChanges();
        SavingDate.bioinfs=Helper.user015Context.Bioinfs.OrderBy(x=>x.Id).ToList();
        new OtchetMenu().Show();
        Close();
    }
}
