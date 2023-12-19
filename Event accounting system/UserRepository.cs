using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_accounting_system
{
    internal static class UserRepository
    {
        private static List<User> users = new List<User>();
        private static User currentUser;

        public static User CurrentUser
        {
            get => currentUser;
            set
            {
                if (currentUser == null)
                    throw new ArgumentNullException(nameof(CurrentUser));

                else if (users.IndexOf(value) == -1)
                        currentUser = value;
                else
                    currentUser = users[users.IndexOf(value)];
            }
        }

        public static void AddListOfUser(List<User> usersList)
        {
            users = usersList;
        }

        public static void AddNewEventToCurrentUser(int id)
        {
            currentUser.AddEventId(id);
        }
    }
}
