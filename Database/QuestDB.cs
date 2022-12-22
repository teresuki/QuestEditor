using QuestEditor.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace QuestEditor.Database
{
    public class QuestDB
    {
        public static string jsonFileDir = @".\";
        public static string jsonFileName = @"questdata.json";
        public static string rubyFileDir = @".\QuestList\";
        private static ObservableCollection<QuestModel> _questData;

        public static ObservableCollection<QuestModel> QuestData
        {
            get { return _questData; }
            set
            {
                _questData = value;
                OnQuestDataChanged(nameof(QuestData));
            }
        }

        public QuestDB()
        {
            //Test
            QuestData = new ObservableCollection<QuestModel>();
            if (File.Exists(jsonFileDir + jsonFileName))
                ReadJsonFile();

        }

        public static event PropertyChangedEventHandler QuestDataChanged;

        public static void OnQuestDataChanged(string propertyName)
        {
            QuestDataChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        public static void ReadJsonFile()
        {
            var questJson = File.ReadAllText(jsonFileDir + jsonFileName);
            if (questJson != null && questJson != string.Empty)
            {
                QuestData = JsonSerializer.Deserialize<ObservableCollection<QuestModel>>(questJson);
            }
        }

        public static void WriteJsonFile()
        {
            var questJson = JsonSerializer.Serialize(QuestData);
            if (questJson != null)
            {
                File.WriteAllText(jsonFileDir + jsonFileName, questJson);
            }
        }

        public static void DeleteRubyFile()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(rubyFileDir);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static void WriteRubyFile()
        {
            for (int i = 0; i < QuestData.Count; ++i)
            {
                var quest = QuestData[i];
                StringBuilder sb = new StringBuilder();
                sb.Append(@"$quest_list << Quest.new");
                sb.Append(@"(");



                // New Quest
                sb.Append(@"""");
                sb.Append(quest.Name);
                sb.Append(@"""");

                sb.Append(@", ");
                sb.Append(quest.StartID);

                sb.Append(@", ");
                sb.Append(quest.EndID);

                sb.Append(@", ");

                //Replace new line with /n character
                var rubyQuestDetail = quest.Detail.Replace(Environment.NewLine, @" /n ");

                sb.Append(@"""");
                sb.Append(rubyQuestDetail);
                sb.Append(@"""");

                sb.Append(@")");

                foreach (var update in quest.Updates)
                {
                    sb.AppendLine();

                    sb.Append(@"$quest_list");
                    sb.Append(@"[");
                    sb.Append(i);
                    sb.Append(@"]");
                    sb.Append(@".");

                    if (update.Type == UpdateType.Paragraph)
                    {
                        sb.Append(@"update");
                    }
                    else
                    {
                        sb.Append(@"update_page");
                    }

                    sb.Append(@"(");
                    sb.Append(update.StartID);
                    sb.Append(@", ");

                    //Replace new line with /n character
                    var rubyQuestUpdateDetail = update.Detail.Replace(Environment.NewLine, @" /n ");

                    sb.Append(@"""");
                    sb.Append(rubyQuestUpdateDetail);
                    sb.Append(@"""");

                    sb.Append(@")");

                }

                string rubyFileName = "Quest" + i + ".rb";
                File.WriteAllText(rubyFileDir + rubyFileName, sb.ToString());

            }

        }
    }
}
