using System.Collections.ObjectModel;

namespace QuestEditor.ViewModel
{
    public class QuestViewModel : BaseViewModel
    {
        private string _name;
        private string _detail;
        private int _startID;
        private int _endID;

        private ObservableCollection<QuestUpdateViewModel> _updates;
        public ObservableCollection<QuestUpdateViewModel> Updates
        {
            get { return _updates; }
            set
            {
                _updates = value;
                OnPropertyChanged(nameof(Updates));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));

            }
        }

        public string Detail
        {
            get { return _detail; }
            set
            {
                _detail = value;
                OnPropertyChanged(nameof(Detail));
            }
        }

        public int StartID
        {
            get { return _startID; }
            set
            {
                _startID = value;
                OnPropertyChanged(nameof(StartID));
            }
        }

        public int EndID
        {
            get { return _endID; }
            set
            {
                _endID = value;
                OnPropertyChanged(nameof(EndID));
            }
        }

        public QuestViewModel() { }

        public QuestViewModel(string name, string detail, int startID, int endID, ObservableCollection<QuestUpdateViewModel>? updates)
        {
            Name = name;
            Detail = detail;
            StartID = startID;
            EndID = endID;
            Updates = new ObservableCollection<QuestUpdateViewModel>();
            if (updates != null)
                Updates = updates;

            //navigator.CurrentViewModel2Changed += OnVM2ChangedToQuestVM;
        }


    }
}
