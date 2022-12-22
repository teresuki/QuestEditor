using QuestEditor.Navigators;
using QuestEditor.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace QuestEditor.View
{
    /// <summary>
    /// Interaction logic for QuestUpdateList.xaml
    /// </summary>
    public partial class QuestUpdateList : UserControl
    {
        public static int currentSelectedQuestIndex = -1;

        public QuestUpdateList()
        {
            InitializeComponent();
            QuestListView.SelectedQuestHit += OnSelectedQuestHitHandler;

        }
        public void OnSelectedQuestHitHandler()
        {
            QuestsUpdateListView.SelectedIndex = -1;
        }

        private void QuestsUpdateListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QuestUpdateViewModel selectedQuestUpdate = QuestsUpdateListView.SelectedItem as QuestUpdateViewModel;

            Navigator.CurrentViewModel2 = selectedQuestUpdate;
            //MainViewModel.navigator.CurrentViewModel3 = selectedQuest;
        }

        private void AddUpdateButon_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var newQuestUpdateVM = new QuestUpdateViewModel("New Update", 0, "Update Detail", Model.UpdateType.Paragraph);
            Navigator.CurrentViewModel1.Quests[currentSelectedQuestIndex].Updates.Add(newQuestUpdateVM);
        }

        private void DeleteUpdateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (currentSelectedQuestIndex == -1)
            {
                MessageBox.Show("A quest's must be selected first to be able to delete its update", "Notice");
            }
            else if (QuestsUpdateListView.SelectedIndex == -1 || QuestsUpdateListView.SelectedItems == null)
            {
                MessageBox.Show("A quest's update must be selected to be able to delete it", "Notice");
                return;
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Quest's Update?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    Navigator.CurrentViewModel1.Quests[currentSelectedQuestIndex].Updates.RemoveAt(QuestsUpdateListView.SelectedIndex);

            }
        }
    }
}
