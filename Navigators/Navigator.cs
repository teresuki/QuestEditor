using QuestEditor.ViewModel;
using System;

namespace QuestEditor.Navigators
{
    public static class Navigator
    {
        public static event Action CurrentViewModel1Changed;
        public static event Action CurrentViewModel2Changed;
        public static event Action CurrentViewModel3Changed;


        private static QuestListViewModel _currentViewModel1;
        private static BaseViewModel _currentViewModel2;
        private static BaseViewModel _currentViewModel3;
        public static QuestListViewModel CurrentViewModel1
        {
            get => _currentViewModel1;
            set
            {
                _currentViewModel1 = value;
                OnCurrentViewModel1Changed();
            }
        }
        public static BaseViewModel CurrentViewModel2
        {
            get => _currentViewModel2;
            set
            {
                _currentViewModel2 = value;
                OnCurrentViewModel2Changed();
            }
        }
        public static BaseViewModel CurrentViewModel3
        {
            get => _currentViewModel3;
            set
            {
                _currentViewModel3 = value;
                OnCurrentViewModel3Changed();
            }
        }

        private static void OnCurrentViewModel1Changed()
        {
            CurrentViewModel1Changed?.Invoke();
        }
        private static void OnCurrentViewModel2Changed()
        {
            CurrentViewModel2Changed?.Invoke();
        }
        private static void OnCurrentViewModel3Changed()
        {
            CurrentViewModel3Changed?.Invoke();
        }


    }
}
