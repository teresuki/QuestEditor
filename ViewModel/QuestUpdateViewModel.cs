using QuestEditor.Model;

namespace QuestEditor.ViewModel
{
    public class QuestUpdateViewModel : BaseViewModel
    {
        private string _name;
        private string _detail;
        private int _startID;
        private bool _isPage; //Paragraph Then Page
        private UpdateType _type;

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
        public UpdateType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public bool IsPage
        {
            get { return _isPage; }
            set
            {
                _isPage = value;
                this.Type = (_isPage) ? UpdateType.Page : UpdateType.Paragraph;
                OnPropertyChanged(nameof(IsPage));
            }
        }

        public QuestUpdateViewModel() { }

        public QuestUpdateViewModel(string Name, int StartID, string Detail, UpdateType Type)
        {
            this.Name = Name;
            this.StartID = StartID;
            this.Detail = Detail;
            this.IsPage = (Type == UpdateType.Page) ? true : false;

        }
    }
}
