using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Event_accounting_system
{
    internal class OnlineEvent: Event
    {
        private string url;
        public string Url
        {
            get => url;
            set
            {
                if (value != null && value != "")
                    url = value;
                else
                    throw new ArgumentNullException(nameof(Url));
            }
        }

        public OnlineEvent(string eventTitle, string eventDescription, DateTime? eventDate, string eventOrganizer, int maxParticipants, string url) 
            : base(eventTitle, eventDescription, eventDate, eventOrganizer, maxParticipants)
        {
            Url = url;
        }
    }
}
