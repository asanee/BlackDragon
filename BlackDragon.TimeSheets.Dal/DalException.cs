using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Dal
{
    public class DalException: ApplicationException
    {
        public DalException()
        {

        }

        public DalException(string message): base(message)
        {

        }
    }
}
