using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_accounting_system
{
    class User
    {
        private string fullName;
        public string FullName
        {
            get => fullName;
            set
            {
                if (value != null && value != "")
                    fullName = value;
                else
                    throw new ArgumentNullException(nameof(FullName));
            }
        }

        private List<int> EventsId = new List<int>();

        public User(string fullname)
        {
            FullName = fullname;
        }

        public User(string fullname, List<int> ids)
        {
            FullName = fullname;
            EventsId = ids;
        }

        public void AddFullname(string fullname)
        {
            FullName = fullname;
        }
        public void AddList(List<int> eventsId)
        {
            EventsId = eventsId;
        }

        public void AddEventId(int id)
        {
            EventsId.Add(id);
        }

        public void Remove(int id)
        {
            EventsId.Remove(id);
        }

        public override string ToString()
        {
            return $"{FullName}:{string.Join(';', EventsId)}";
        }

    }
}
