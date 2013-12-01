using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon.TimeSheets.Domain
{
    public abstract class ActiveEntity: Entity
    {
        protected ActiveEntity()
        {

        }

        protected override void Init(string createdBy)
        {
            base.Init(createdBy);

            IsActive = true;
        }

        public virtual void MarAsDeleted(string updatedBy)
        {            
            IsDeleted = true;
            IsActive = false;

            this.MarAsUpdate(updatedBy);
        }

        public virtual bool IsDeleted { get; protected set; }

        public virtual bool IsActive { get; protected set; }
    }
}
