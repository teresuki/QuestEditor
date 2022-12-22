using QuestEditor.Database;
using QuestEditor.Model;
using QuestEditor.Navigators;
using QuestEditor.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace QuestEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuestViewModel questViewModel;
        public MainWindow()
        {
            InitializeComponent();
            questViewModel = new QuestViewModel();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddQuestButton_Click(object sender, RoutedEventArgs e)
        {

            var newQuestVM = new QuestViewModel("New Quest", "Detail Of The New Quest", 0, 0, new ObservableCollection<QuestUpdateViewModel>());
            Navigator.CurrentViewModel1.Quests.Add(newQuestVM);
        }

        private void SaveQuestButton_Click(object sender, RoutedEventArgs e)
        {
            var questVMData = Navigator.CurrentViewModel1.Quests;
            var quests = new ObservableCollection<QuestModel>();
            foreach (var questVM in questVMData)
            {
                var quest = new QuestModel(questVM.Name, questVM.Detail, questVM.StartID, questVM.EndID);
                foreach (var questUpdateVM in questVM.Updates)
                {
                    quest.Updates.Add(new QuestUpdateModel(questUpdateVM.Name, questUpdateVM.StartID, questUpdateVM.Detail, questUpdateVM.Type));
                }
                quests.Add(quest);
            }

            QuestDB.QuestData = quests;
            QuestDB.WriteJsonFile();
            QuestDB.DeleteRubyFile();
            QuestDB.WriteRubyFile();
            MessageBox.Show("Save File Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        /*        private void QuestListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
                {
                    var selectedQuest = QuestListView.SelectedItem as QuestModel;
                    questViewModel.Name = selectedQuest.Name;


                    if (selectedQuest.Updates == null)
                        return;

                    QuestUpdateListViewModel.QuestUpdates = selectedQuest.Updates;
                }*/
    }
}
