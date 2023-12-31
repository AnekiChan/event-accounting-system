﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Event_accounting_system
{
    internal static class SaveManager
    {

        private static string offlineEventsPath = "offlineEvents.txt";
        private static string onlineEventsPath = "onlineEvents.txt";

        private static string usersPath = "users.txt";

        public static void SaveEvents(List<OfflineEvent> offlineEvents, List<OnlineEvent> onlineEvents)
        {
            using (StreamWriter writer = new StreamWriter(offlineEventsPath, false))
            {
                foreach(OfflineEvent offlineEvent in offlineEvents)
                {
                    writer.WriteLine(offlineEvent.ToString());
                }
            }

            using (StreamWriter writer = new StreamWriter(onlineEventsPath, false))
            {
                foreach (OnlineEvent onlineEvent in onlineEvents)
                {
                    writer.WriteLine(onlineEvent.ToString());
                }
            }
        }

        public static List<OfflineEvent> LoadOfflineEvents()
        {
            List<OfflineEvent> newOfflineEvents = new List<OfflineEvent>();
            string[] lines;

            using (StreamReader reader = new StreamReader(offlineEventsPath))
            {
                lines = reader.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string line in lines)
            {
                if (line != "\r")
                {
                    string[] values = line.Split(new char[] { ';' });
                    OfflineEvent newEvent = new OfflineEvent(Int32.Parse(values[0]), values[1], values[2], DateTime.Parse(values[3]), values[4], Int32.Parse(values[5]), values[6]);
                    newOfflineEvents.Add(newEvent);
                }
            }

            return newOfflineEvents;
        }

        public static List<OnlineEvent> LoadOnlineEvents()
        {
            List<OnlineEvent> newOfflineEvents = new List<OnlineEvent>();
            string[] lines;

            using (StreamReader reader = new StreamReader(onlineEventsPath))
            {
                lines = reader.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string line in lines)
            {
                if (line != "\r")
                {
                    string[] values = line.Split(new char[] { ';' });
                    OnlineEvent newEvent = new OnlineEvent(Int32.Parse(values[0]), values[1], values[2], DateTime.Parse(values[3]), values[4], Int32.Parse(values[5]), values[6]);
                    newOfflineEvents.Add(newEvent);
                }
            }

            return newOfflineEvents;
        }

        public static void SaveUsers(List<User> users)
        {
            using (StreamWriter writer = new StreamWriter(offlineEventsPath, false))
            {
                foreach (User user in users)
                {
                    writer.WriteLine(user.ToString());
                }
            }
        }

        public static List<User> LoadUsers()
        {
            List<User> allUsers = new List<User>();
            string[] lines;

            using (StreamReader reader = new StreamReader(onlineEventsPath))
            {
                lines = reader.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string line in lines)
            {
                if (line != "\r")
                {
                    string[] values = line.Split(new char[] { ':' });
                    List<int> ids = new List<int>();
                    foreach(string id in values[1].Split(new char[] { ';' }))
                    {
                        ids.Add(int.Parse(id));
                    }

                    allUsers.Add(new User(values[0], ids));
                }
            }

            return allUsers;
        }
    }
}
