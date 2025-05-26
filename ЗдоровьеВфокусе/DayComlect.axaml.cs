using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using ЗдоровьеВфокусе.Models;

namespace ЗдоровьеВфокусе;

public partial class DayComlect : Window
{
    public DayComlect()
    {
        InitializeComponent();
        if (SavingDate.unicalplans.Count != 0)
        {
            int days = (int)SavingDate.unicalplans[SavingDate.unicalplans.Count - 1].Day;
            for (int i = 1; i <= days; i++)
            {
                var border = this.FindControl<Border>($"Bordername{i}");
                List<Unicalplan> unils = SavingDate.unicalplans.Where(x => x.Day == i).ToList();
                if (unils[0].End == true)
                {
                   
                    if (border != null)
                    {
                        border.Background = Brushes.Green;
                    }
                }
                else
                {
                    border.Background= Brushes.Yellow;
                }
                
            }
            //Bordername8.Background
        }
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

    private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int day = 0;
        if (SavingDate.unicalplans.Count==0)//если это первый день то создаем его
        {
            Unicalplan unicalplan = new Unicalplan();
            unicalplan.Day = 1;
            unicalplan.End = false;
            Helper.user015Context.Unicalplans.Add(unicalplan);
            Helper.user015Context.SaveChanges();
            SavingDate.unicalplans=Helper.user015Context.Unicalplans.OrderBy(x => x.Id).ToList();
            day = 1;
            SavingDate.day=day;
            metodupr(day);
            new SpisokUser().Show();
            Close();
        }
        else 
        {
            List<Unicalplan> unical= SavingDate.unicalplans.Where(x=>x.End==false).ToList();//если все дни завершены то создается следующий
            if (unical.Count==0)
            {
                 day=(int)SavingDate.unicalplans[(int)SavingDate.unicalplans.Count-1].Day+1;
                Unicalplan unicalplan = new Unicalplan();
                unicalplan.Day = day;
                unicalplan.End = false;
                Helper.user015Context.Unicalplans.Add(unicalplan);
                Helper.user015Context.SaveChanges();
                SavingDate.unicalplans = Helper.user015Context.Unicalplans.OrderBy(x => x.Id).ToList();
                metodupr(day);
                SavingDate.day = day;
                new SpisokUser().Show();
                Close();
            }
            else
            {
                day =(int)unical[0].Day;//если день не завершен то переходим к незавершенному
                SavingDate.day = day;
                new SpisokUser().Show();
                Close();
            }
        }

    }
    private void metodupr(int day)
    {
        string gender = "";
        if (SavingDate.users[0].Gender==1)
        {
            gender = "Мужчина";
        }
        else
        {
            gender = "Женщина";
        }
        float ind1 =(float)(SavingDate.bioinfs[SavingDate.bioinfs.Count-1].Rost * SavingDate.bioinfs[SavingDate.bioinfs.Count-1].Rost)/1000;
        float ind2 =(float) SavingDate.bioinfs[SavingDate.bioinfs.Count-1].Ves/ind1 ;//Узнаем индекс массы тела
        if (ind2<18.5) //Если у нас нехватка веса
        {
            if (day==1 | day==5 | day == 9 | day == 13 | day == 17 | day == 21 | day == 25 | day == 28) //дни когда упражнения будут на все тело
            {
                if (day == 1 | day == 5 | day == 9)
                {  
                    List<Exercise> exceptions =SavingDate.exercises.Where(x=>x.Slojnost=="Легко" && x.Group=="Всетело").ToList();
                    for(int i=0;i<exceptions.Count;i++ )//добавляем все упражнения на все тело
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End=false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x=>x.Id).ToList();
                    }
                }
                else if (day == 13 | day == 17 | day == 21) // Руки
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Всетело").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions1 = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Руки").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions1[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions2 = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Пресс").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions2[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions3 = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions3[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions4 = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions4[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }


                }
                else if (day == 25 | day == 28) // финальные дни
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Всетело").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions1 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Руки").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions1[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions2 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Пресс").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions2[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions3 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions3[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions4 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions4[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            else if (day==2 | day==6 | day==10 | day==14 | day==18 | day==22 | day==26)
            {
                if (day == 2 | day == 6 | day == 10)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day==14 | day==18)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 22 | day == 26)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            else if (day == 3 | day == 7 | day == 11 | day == 15 | day == 19 | day == 23 | day == 27)
            {
                if (day == 3 | day == 7 | day == 11)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 15 | day == 19)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 23 | day == 27)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            else if (day == 4 | day == 8 | day == 12 | day == 16 | day == 20 | day == 24)
            {
                if (day == 2 | day == 6 | day == 10)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 14 | day == 18)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 22 | day == 26)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            {
                if (day == 4 | day == 8 | day == 12)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 16 | day == 20)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 24)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }

        }
        else if (ind2 < 26.5) //Если у нас нехватка веса
        {
            if (day == 1 | day == 5 | day == 9 | day == 13 | day == 17 | day == 21 | day == 25 | day == 28) //дни когда упражнения будут на все тело
            {
                if (day == 1 | day == 5 | day == 9)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Всетело").ToList();
                    for (int i = 0; i < exceptions.Count; i++)//добавляем все упражнения на все тело
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 13 | day == 17 | day == 21) // Руки
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Всетело").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions1 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Руки").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions1[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions2 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Пресс").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions2[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions3 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions3[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions4 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions4[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }


                }
                else if (day == 25 | day == 28) // финальные дни
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Всетело").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions1 = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions1[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions2 = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Пресс").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions2[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions3 = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions3[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions4 = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions4[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            else if (day == 2 | day == 6 | day == 10 | day == 14 | day == 18 | day == 22 | day == 26)
            {
                if (day == 2 | day == 6 | day == 10)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 14 | day == 18)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 22 | day == 26)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            else if (day == 3 | day == 7 | day == 11 | day == 15 | day == 19 | day == 23 | day == 27)
            {
                if (day == 3 | day == 7 | day == 11)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 15 | day == 19)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 23 | day == 27)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            else if (day == 4 | day == 8 | day == 12 | day == 16 | day == 20 | day == 24)
            {
                if (day == 2 | day == 6 | day == 10)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 14 | day == 18)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 22 | day == 26)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            {
                if (day == 4 | day == 8 | day == 12)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 16 | day == 20)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 24)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }

        }
        else if ( 26.5<ind2) //Если у нас нехватка веса
        {
            if (day == 1 | day == 5 | day == 9 | day == 13 | day == 17 | day == 21 | day == 25 | day == 28) //дни когда упражнения будут на все тело
            {
                if (day == 1 | day == 5 | day == 9)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Всетелогрудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)//добавляем все упражнения на все тело
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 13 | day == 17 | day == 21) // Руки
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Легко" && x.Group == "Всетелогрудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions1 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Руки").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions1[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions2 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Пресс").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions2[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions3 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions3[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions4 = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions4[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }


                }
                else if (day == 25 | day == 28) // финальные дни
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Всетелогрудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions1 = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions1[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions2 = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Пресс").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions2[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions3 = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions3[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                    List<Exercise> exceptions4 = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions4[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            else if (day == 2 | day == 6 | day == 10 | day == 14 | day == 18 | day == 22 | day == 26)
            {
                if (day == 2 | day == 6 | day == 10)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 14 | day == 18)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 22 | day == 26)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            else if (day == 3 | day == 7 | day == 11 | day == 15 | day == 19 | day == 23 | day == 27)
            {
                if (day == 3 | day == 7 | day == 11)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 15 | day == 19)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 23 | day == 27)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Грудь").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            else if (day == 4 | day == 8 | day == 12 | day == 16 | day == 20 | day == 24)
            {
                if (day == 2 | day == 6 | day == 10)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 14 | day == 18)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 22 | day == 26)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Руки").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }
            {
                if (day == 4 | day == 8 | day == 12)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Средне" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 16 | day == 20)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
                else if (day == 24)
                {
                    List<Exercise> exceptions = SavingDate.exercises.Where(x => x.Slojnost == "Сложно" && x.Group == "Ноги").ToList();
                    for (int i = 0; i < exceptions.Count; i++)
                    {
                        Perosnalupr perosnalupr = new Perosnalupr();
                        perosnalupr.Idupr = exceptions[i].Id;
                        perosnalupr.Idday = day;
                        perosnalupr.End = false;
                        Helper.user015Context.Perosnaluprs.Add(perosnalupr);
                        Helper.user015Context.SaveChanges();
                        SavingDate.perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
                    }
                }
            }

        }
    }
}