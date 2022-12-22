using QuestEditor.Database;
using QuestEditor.Navigators;
using QuestEditor.ViewModel;
using System.Windows;

namespace QuestEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Create a Database & Read From Json File
            new QuestDB();

            //Create a Navigator To Navigate Between Views


            Navigator.CurrentViewModel1 = new QuestListViewModel();
            Navigator.CurrentViewModel2 = new QuestEmptyViewModel();
            Navigator.CurrentViewModel3 = new QuestUpdateEmptyViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };





            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
