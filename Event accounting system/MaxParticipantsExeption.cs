using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_accounting_system
{
    internal class MaxParticipantsExeption: ArgumentException
    {
        public MaxParticipantsExeption(string message)
            : base(message)
        { }
    }
}
