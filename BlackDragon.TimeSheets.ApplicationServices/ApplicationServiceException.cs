using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Applications
{
    public class ApplicationServiceException: ApplicationException
    {
        public ApplicationServiceException()
        {

        }

        public ApplicationServiceException(string message): base(message)
        {

        }
    }
}
