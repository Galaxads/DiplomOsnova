using System.Collections.Generic;
using System.Collections.ObjectModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Avalonia.Controls;


using LiveChartsCore.Defaults;
using System;
using System.Linq;
using DynamicData;
using LiveChartsCore.VisualElements;
using LiveChartsCore.SkiaSharpView.Drawing;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia;
namespace ЗдоровьеВфокусе;

public partial class OtchetMenu : Window
{ // График изменения веса
    private Axis _xAxis;
    private List<string> _xLabels;
    private List<(string Label, double Value)> _allData;
    private int _currentStartIndex = 0;
    private const int _windowSize = 3; // сколько точек видно одновременно
    public OtchetMenu()
    {
        InitializeComponent();

     
        SetupChart1();
       LoadDataAndSetupChart();

        double height =Convert.ToDouble( SavingDate.bioinfs[SavingDate.bioinfs.Count-1].Rost)/100;
        double bmi = Convert.ToDouble(SavingDate.bioinfs[SavingDate.bioinfs.Count - 1].Ves) / (height * height);
        IMt.Text = $"Ваш ИМТ:{bmi:F2}";
    }
    private void LoadDataAndSetupChart()
    {
        // Преобразуем твои данные в список для отображения
        _allData = SavingDate.bioinfs
            .Select(b => (b.Date.ToString(), Convert.ToDouble(b.Ves)))
            .ToList();

        UpdateChart();
    }

    private void UpdateChart()
    {
        var visibleData = _allData
            .Skip(_currentStartIndex)
            .Take(_windowSize)
            .ToList();

        var points = new ObservableCollection<ObservablePoint>();
        var labels = new List<string>();

        for (int i = 0; i < visibleData.Count; i++)
        {
            points.Add(new ObservablePoint(i, visibleData[i].Value));
            labels.Add(visibleData[i].Label);
        }

        MyChart1.Series = new ISeries[]
        {
            new LineSeries<ObservablePoint>
            {
                Values = points,
                Fill = new SolidColorPaint(SKColors.Transparent),
                Stroke = new SolidColorPaint(SKColors.Red, 2),
                Name = "Вес",
                GeometryFill= new SolidColorPaint(SKColors.Blue),
                GeometryStroke=new SolidColorPaint(SKColors.Gray, 2),
            }
        };

        MyChart1.XAxes = new[]
        {
            new Axis
            {
                Labels = labels,
                LabelsRotation = 0,
                MinStep = 1,
                ForceStepToMin = true
            }
        };

        MyChart1.YAxes = new[] { new Axis { Name = "Вес" } };
    }


    private void DrawBmiChart()
    {
        double bmi = 17.6; // Текущее значение ИМТ
        double scaleMin = 10;
        double scaleMax = 40;

        var bmiRanges = new List<(double Start, double End, SKColor Color)>
            {
                (10.0, 18.5, new SKColor(0, 0, 255, 80)),    // Синий - Недовес
                (18.5, 24.9, new SKColor(0, 255, 0, 80)),   // Зелёный - Норма
                (25.0, 29.9, new SKColor(255, 165, 0, 80)), // Оранжевый - Избыток
                (30.0, 34.9, new SKColor(255, 0, 0, 80)),   // Красный - Ожирение
                (35.0, 40.0, new SKColor(139, 0, 0, 80))    // Тёмно-красный - Тяжёлое ожирение
            };

        var sections = new List<RectangularSection>();

        foreach (var range in bmiRanges)
        {
            sections.Add(new RectangularSection
            {
                Xi = range.Start,
                Xj = range.End,
                Stroke = null,
                Fill = new SolidColorPaint(range.Color)
            });
        }

        // Настройка осей
        
    }

    private void SetupChart1()//обычный график
    {
        _xLabels=SavingDate.bioinfs.Select(x=>((DateOnly)x.Date).ToString()).ToList();
        _xAxis = new Axis
        {
            Name = "День",
            MinStep = 1,
            ForceStepToMin = true,
            MinLimit=0,
            MaxLimit=3,
            LabelsRotation=0,
            Labeler = value=>
            {
                int index = (int)Math.Round(value);
                return index >=0 && index < _xLabels.Count ? _xLabels[index] : "";
            }
        };
        // Задаем оси программно
        //MyChart1.XAxes = new Axis[]
        //{
        //        new Axis { Name="День",MinStep=1,ForceStepToMin=true }
        //};
        MyChart1.XAxes= new[] { _xAxis };

        MyChart1.YAxes = new Axis[]
        {
                new Axis { Name="Вес"  }
        };
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
        Close();
    }

    private void Button_Click_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Spravochnik().Show();
        Close();
    }

    private void Button_Click_6(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new RostAndVesScreen().Show();
        Close();
    }

    private void OnChartScroll(object? sender, Avalonia.Input.PointerWheelEventArgs e)
    {
        Console.WriteLine($"Wheel delta: {e.Delta.Y}"); // для проверки

        var direction = e.Delta.Y > 0 ? -1 : 1;

        int newIndex = _currentStartIndex + direction;

        if (newIndex < 0 || newIndex + _windowSize > _allData.Count)
            return;

        _currentStartIndex = newIndex;
        UpdateChart();

        e.Handled = true;
    }

    private void Button_Click_7(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_currentStartIndex > 0)
        {
            _currentStartIndex--;
            UpdateChart();
        }
    }

    private void Button_Click_8(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_currentStartIndex + _windowSize < _allData.Count)
        {
            _currentStartIndex++;
            UpdateChart();
        }
    }
}




