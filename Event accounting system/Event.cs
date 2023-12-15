using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Event_accounting_system
{
    internal class Event
    {
        private int id;
        public int Id { get; }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                if (value != null && value != "") 
                    title = value;
                else 
                    throw new ArgumentNullException(nameof(Title));
            }
        }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                if (value != null && value != "")
                    description = value;
                else
                    throw new ArgumentNullException(nameof(Description));
            }
        }

        private DateTime? date;
        public DateTime? Date
        {
            get => date;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Date));
                else
                    date = value;
            }
        }

        private string organizer;
        public string Organizer
        {
            get => organizer;
            set
            {
                if (value != null && value != "")
                    organizer = value;
                else
                    throw new ArgumentNullException(nameof(Organizer));
            }
        }

        private int maxParticipants;
        public int MaxParticipants
        {
            get => maxParticipants;
            set
            {
                if (value > 0)
                    maxParticipants = value;
                else
                    throw new ArgumentException($"The value of the {nameof(MaxParticipants)} must be greater than zero");
            }
        }

        private int participants = 0;
        public int Participants
        {
            get => participants;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"The value of the {nameof(Participants)} must be zero or greater than zero");
                else if (value > participants)
                    throw new MaxParticipantsExeption("The value of participants must be less than or equal to the maximum number of participants");
            }
        }

        public Event(string eventTitle, string eventDescription, DateTime? eventDate, string eventOrganizer, int maxParticipants)
        {
            int tick = Environment.TickCount;
            Id = Interlocked.Increment(ref tick);
            Title = eventTitle;
            Description = eventDescription;
            Date = eventDate;
            Organizer = eventOrganizer;
            MaxParticipants = maxParticipants;
        }

        public void Edit(string eventTitle, string eventDescription, DateTime? eventDate, string eventOrganizer, int maxParticipants)
        {
            Title = eventTitle;
            Description = eventDescription;
            Date = eventDate;
            Organizer = eventOrganizer;
            MaxParticipants = maxParticipants;
        }
        public Event(int _id, string eventTitle, string eventDescription, DateTime? eventDate, string eventOrganizer, int maxParticipants)
        {
            id = _id;
            Title = eventTitle;
            Description = eventDescription;
            Date = eventDate;
            Organizer = eventOrganizer;
            MaxParticipants = maxParticipants;
        }

        public override string ToString()
        {
            return $"{Id};{Title};{Description};{Date};{Organizer};{MaxParticipants}";
        }

    }
}
