using QuestEditor.Navigators;
using QuestEditor.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace QuestEditor.View
{
    /// <summary>
    /// Interaction logic for QuestListView.xaml
    /// </summary>
    public partial class QuestListView : UserControl
    {
        public static event Action SelectedQuestHit;

        public void OnSelectedQuestHit()
        {
            SelectedQuestHit?.Invoke();
        }
        public QuestListView()
        {
            InitializeComponent();
        }


        private void QuestsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UserViewModel selectedUser = UserListViews.SelectedItem as UserViewModel;
            QuestViewModel selectedQuest = QuestsListView.SelectedItem as QuestViewModel;



            Navigator.CurrentViewModel2 = selectedQuest;
            Navigator.CurrentViewModel3 = selectedQuest;

            QuestUpdateList.currentSelectedQuestIndex = QuestsListView.SelectedIndex;
            OnSelectedQuestHit();

        }

        private void QuestsListView_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //UserViewModel selectedUser = UserListViews.SelectedItem as UserViewModel;
            if (QuestsListView.SelectedItem == null)
                return;
            QuestViewModel selectedQuest = QuestsListView.SelectedItem as QuestViewModel;


            Navigator.CurrentViewModel2 = selectedQuest;
            Navigator.CurrentViewModel3 = selectedQuest;
            QuestUpdateList.currentSelectedQuestIndex = QuestsListView.SelectedIndex;
            OnSelectedQuestHit();


        }

        private void DeleteQuestButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (QuestsListView.SelectedItems == null || QuestsListView.SelectedIndex == -1)
            {
                MessageBox.Show("A quest must be selected to be able to delete it", "Notice");
                return;
            }

            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Quest?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    Navigator.CurrentViewModel1.Quests.RemoveAt(QuestsListView.SelectedIndex);
            }

        }
    }
}
