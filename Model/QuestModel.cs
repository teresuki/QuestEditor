using System.Collections.ObjectModel;

namespace QuestEditor.Model
{
    public class QuestModel
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public int StartID { get; set; }
        public int EndID { get; set; }
        public ObservableCollection<QuestUpdateModel> Updates { get; set; }

        public QuestModel(string name, string detail, int startID, int endID)
        {
            Name = name;
            Detail = detail;
            StartID = startID;
            EndID = endID;
            Updates = new ObservableCollection<QuestUpdateModel>();
        }


    }
}
