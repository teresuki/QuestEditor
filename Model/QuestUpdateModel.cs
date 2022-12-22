namespace QuestEditor.Model
{
    public enum UpdateType
    {
        Paragraph,
        Page
    }

    public class QuestUpdateModel
    {
        public string Name { get; set; }
        public int StartID { get; set; }
        public string Detail { get; set; }
        public UpdateType Type { get; set; }

        public QuestUpdateModel(string Name, int StartID, string Detail, UpdateType Type)
        {
            this.Name = Name;
            this.StartID = StartID;
            this.Detail = Detail;
            this.Type = Type;
        }

    }
}
