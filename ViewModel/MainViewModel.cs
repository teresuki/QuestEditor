using QuestEditor.Navigators;

namespace QuestEditor.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        //public static Navigator navigator;

        public QuestListViewModel CurrentViewModel1 => Navigator.CurrentViewModel1;
        public BaseViewModel CurrentViewModel2 => Navigator.CurrentViewModel2;
        public BaseViewModel CurrentViewModel3 => Navigator.CurrentViewModel3;

        public MainViewModel()
        {
            //Subscribe to changes in navigator
            Navigator.CurrentViewModel1Changed += OnCurrentViewModel1Changed;
            Navigator.CurrentViewModel2Changed += OnCurrentViewModel2Changed;
            Navigator.CurrentViewModel3Changed += OnCurrentViewModel3Changed;

        }

        public void OnCurrentViewModel1Changed()
        {
            OnPropertyChanged(nameof(CurrentViewModel1));
        }
        private void OnCurrentViewModel2Changed()
        {
            OnPropertyChanged(nameof(CurrentViewModel2));
        }
        private void OnCurrentViewModel3Changed()
        {
            OnPropertyChanged(nameof(CurrentViewModel3));
        }
    }
}
