using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_accounting_system
{
    internal class EventsRepository<T>
        where T : Event
    {
        List<T> events = new List<T>();

        public EventsRepository() { }

        public void Add(T singeEvent)
        {
            if (singeEvent != null)
                events.Add(singeEvent);
            else
                throw new NullReferenceException($"{nameof(singeEvent)} is null");
        }

        public void Remove(T singeEvent)
        {
            if (singeEvent != null)
                events.Remove(singeEvent);
            else
                throw new NullReferenceException($"{nameof(singeEvent)} is null");
        }

        public void Replace(T replacingEvent)
        {
            int index = events.IndexOf(replacingEvent);
            if (index != -1)
            {
                events[index] = replacingEvent;
            }
            else
                throw new ArgumentException("Event not found");
        }
    }
}
