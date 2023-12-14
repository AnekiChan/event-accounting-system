using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_accounting_system
{
    internal static class EventsRepository
    {
        private static List<OfflineEvent> offlineEvents = new List<OfflineEvent>();
        private static List<OnlineEvent> onlineEvents = new List<OnlineEvent>();

        static EventsRepository() { }

        public static void Add(OfflineEvent singleEvent)
        {
            if (singleEvent != null)
                offlineEvents.Add(singleEvent);
            else
                throw new NullReferenceException($"{nameof(singleEvent)} is null");
        }
        public static void Add(OnlineEvent singeEvent)
        {
            if (singeEvent != null)
                onlineEvents.Add(singeEvent);
            else
                throw new NullReferenceException($"{nameof(singeEvent)} is null");
        }

        public static void Remove(OfflineEvent singeEvent)
        {
            if (singeEvent != null)
                offlineEvents.Remove(singeEvent);
            else
                throw new NullReferenceException($"{nameof(singeEvent)} is null");
        }
        public static void Remove(OnlineEvent singeEvent)
        {
            if (singeEvent != null)
                onlineEvents.Remove(singeEvent);
            else
                throw new NullReferenceException($"{nameof(singeEvent)} is null");
        }

        public static void Replace(OfflineEvent replacingEvent)
        {
            int index = offlineEvents.IndexOf(replacingEvent);
            if (index != -1)
            {
                offlineEvents[index] = replacingEvent;
            }
            else
                throw new ArgumentException("Event not found");
        }
        public static void Replace(OnlineEvent replacingEvent)
        {
            int index = onlineEvents.IndexOf(replacingEvent);
            if (index != -1)
            {
                onlineEvents[index] = replacingEvent;
            }
            else
                throw new ArgumentException("Event not found");
        }

        public static OfflineEvent? FindOfflineEventById(int id)
        {
            foreach (OfflineEvent ev in offlineEvents)
            {
                if (ev.Id == id)
                    return ev;
            }

            return null;
        }

        public static OnlineEvent? FindOnlineEventById(int id)
        {
            foreach (OnlineEvent ev in onlineEvents)
            {
                if (ev.Id == id)
                    return ev;
            }

            return null;
        }

        public static List<OnlineEvent> GetOnlineEvents() => onlineEvents;
        public static List<OfflineEvent> GetOfflineEvents() => offlineEvents;

    }
}
