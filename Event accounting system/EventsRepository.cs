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

        static EventsRepository() { }

        public void Add(T singleEvent)
        {
            if (singleEvent != null)
                events.Add(singleEvent);
            else
                throw new NullReferenceException($"{nameof(singleEvent)} is null");
        }

        public void Remove(T singeEvent)
        {
            if (singeEvent != null)
                events.Remove(singeEvent);
            else
                throw new NullReferenceException($"{nameof(singeEvent)} is null");
        }

        public void Replace(int id, string eventTitle, string eventDescription, DateTime? eventDate, string eventOrganizer, int maxParticipants)
        {
            bool isReplaced = true;
            foreach (T e in events)
            {
                if (e.Id == id)
                {
                    e.Title = eventTitle;
                    e.Description = eventDescription;
                    e.Date = eventDate;
                    e.Organizer = eventOrganizer;
                    e.MaxParticipants = maxParticipants;
                        
                    break;
                }
            }

            if (!isReplaced)
                throw new ArgumentException("Event not found");
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

    }
}
