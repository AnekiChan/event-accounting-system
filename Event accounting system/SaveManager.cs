using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Event_accounting_system
{
    internal class SaveManager
    {
        private EventsRepository<OfflineEvent> offlineEvents = new EventsRepository<OfflineEvent>();
        private EventsRepository<OnlineEvent> onlineEvents = new EventsRepository<OnlineEvent>();

        private string offlineEventsPath = "offlineEvents.txt";
        private string onlineEventsPath = "onlineEvents.txt";

        public SaveManager() { }
        public void Save()
        {
            using (StreamWriter writer = new StreamWriter(offlineEventsPath, false))
            {
                writer.WriteLine(offlineEvents.GetAllEvents());
            }

            using (StreamWriter writer = new StreamWriter(onlineEventsPath, false))
            {
                writer.WriteLine(onlineEvents.GetAllEvents());
            }
        }

        public void Load()
        {
            List<OfflineEvent> newOfflineEvents = new List<OfflineEvent>();
            using (StreamReader reader = new StreamReader(offlineEventsPath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "\n" || line == string.Empty)
                        continue;

                    string[] values = line.Split(';');
                    OfflineEvent offlineEvent = new OfflineEvent(Int32.Parse(values[0]), values[1], values[2], DateTime.Parse(values[3]), values[4], Int32.Parse(values[5]), values[6]);
                    newOfflineEvents.Add(offlineEvent);
                }
                offlineEvents.AddEventsList(newOfflineEvents);
            }
            /*
            using (StreamReader reader = new StreamReader(onlineEventsPath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "\n" || line == string.Empty)
                        continue;

                    string[] values = line.Split(';');
                    OnlineEvent onlineEvent = new OnlineEvent(Int32.Parse(values[0]), values[1], values[2], DateTime.Parse(values[3]), values[4], Int32.Parse(values[5]), values[6]);
                    onlineEvents.Add(onlineEvent);
                }
            } */
        }
    }
}
