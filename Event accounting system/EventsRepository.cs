using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_accounting_system
{
    internal class EventsRepository<T> where T : Event
    {
        private static List<T> events = new List<T>();
        private static SaveManager saveManager = new SaveManager();

        public EventsRepository()
        {
            saveManager.Load();
        }

        public void AddEventsList(List<T> list)
        {
            foreach (T item in list)
            {
                events.Add(item);
            }
        }

        public void AddEvent(T singleEvent)
        {
            if (singleEvent != null)
            {
                events.Add(singleEvent);
                saveManager.Save();
            }
                
            else
                throw new NullReferenceException($"{nameof(singleEvent)} is null");
        }

        public void Remove(T singeEvent)
        {
            if (singeEvent != null)
            {
                events.Remove(singeEvent);
                saveManager.Save();
            }
                
            else
                throw new NullReferenceException($"{nameof(singeEvent)} is null");
        }

        public void Replace(int id, string eventTitle, string eventDescription, DateTime? eventDate, string eventOrganizer, int maxParticipants)
        {
            foreach (T e in events)
            {
                if (e.Id == id)
                {
                    e.Title = eventTitle;
                    e.Description = eventDescription;
                    e.Date = eventDate;
                    e.Organizer = eventOrganizer;
                    e.MaxParticipants = maxParticipants;

                    saveManager.Save();
                    break;
                }
            }
        }

        public T? FindEventById(int id)
        {
            foreach (T ev in events)
            {
                if (ev.Id == id)
                    return ev;
            }

            return null;
        }

        public List<T> GetEvents() => events;

        public string GetAllEvents()
        {
            string allEvents = "";
            foreach (T ev in events)
                allEvents += ev.ToString() + "\n";

            return allEvents;
        }
    }
}
