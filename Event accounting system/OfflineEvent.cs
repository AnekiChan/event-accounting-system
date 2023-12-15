﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_accounting_system
{
    internal class OfflineEvent : Event
    {
        private string address;
        public string? Address
        {
            get => address; set
            {
                if (value != null && value != "")
                    address = value;
                else
                    throw new ArgumentNullException(nameof(Address));
            }
        }

        public OfflineEvent(string eventTitle, string eventDescription, DateTime? eventDate, string eventOrganizer, int maxParticipants, string address)
            : base(eventTitle, eventDescription, eventDate, eventOrganizer, maxParticipants)
        {
            Address = address;
        }

        public void EditAddress(OfflineEvent offlineEvent)
        {
            Address = offlineEvent.Address;
        }
    }
}
