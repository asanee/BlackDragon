using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Domain
{
    public class DomainException: ApplicationException
    {
        public DomainException()
        {

        }

        public DomainException(string message): base(message)
        {

        }
    }
}
