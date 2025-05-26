using Avalonia.Controls;

namespace ЗдоровьеВфокусе.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //ShowWelcomeScreen();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SavingDate.bioinfs.Count > 1)
        {
           new OtchetMenu().Show();
         // new DateScreen().Show();

            Close();
        }
        else
        {
            new DateScreen().Show();
            Close();
        }
          
    }

    //public void ShowWelcomeScreen()
    //{
    //    MainContent.Content = new WelcomeScreen();

    //}
    //public void ShowInputScreen()
    //{
    //    MainContent.Content = new InputScreen();
    //}
}
