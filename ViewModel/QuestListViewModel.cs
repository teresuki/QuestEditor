using QuestEditor.Database;
using System.Collections.ObjectModel;

namespace QuestEditor.ViewModel
{
    public class QuestListViewModel : BaseViewModel
    {
        private ObservableCollection<QuestViewModel> _quests;
        public ObservableCollection<QuestViewModel> Quests
        {
            get { return _quests; }
            set
            {
                _quests = value;
                OnPropertyChanged(nameof(Quests));
            }
        }

        public QuestListViewModel()
        {
            _quests = new ObservableCollection<QuestViewModel>();

            /*for (int i = 0; i < 20; ++i)
            {
                Quests.Add(new QuestViewModel("My Quest number" + i, "Details of the quest" + i, i + 1, i + 10));
                Quests[i].Updates.Add(new QuestUpdateViewModel("My Quest Update number" + i, i + 10, "My Update Detail", UpdateType.Paragraph));
            }*/

            foreach (var quest in QuestDB.QuestData)
            {
                var questUpdateVM = new ObservableCollection<QuestUpdateViewModel>();
                foreach (var questUpdate in quest.Updates)
                {
                    questUpdateVM.Add(new QuestUpdateViewModel(questUpdate.Name, questUpdate.StartID, questUpdate.Detail, questUpdate.Type));
                }
                var questVM = new QuestViewModel(quest.Name, quest.Detail, quest.StartID, quest.EndID, questUpdateVM);
                _quests.Add(questVM);
            }


        }

        //Save to DB then Pass to JSon
    }
}
