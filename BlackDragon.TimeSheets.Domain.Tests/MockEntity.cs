using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Domain.Tests
{
    public class MockEntity: ActiveEntity
    {
        public void InitAgain(string createdBy)
        {
            Init(createdBy);
        }
    }
}
