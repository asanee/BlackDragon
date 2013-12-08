using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Shared
{
    public interface ICircleService
    {
        ICircle Create(string name, string userName);

        CircleFullDto GetCircle(long id, string userName);
    }    
}
