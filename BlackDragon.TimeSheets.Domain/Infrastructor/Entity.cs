using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackDragon.TimeSheets.Domain
{
    public abstract class Entity
    {
        protected Entity()
        {

        }

        protected virtual void Init(string createdBy)
        {
            if (ID > 0)
                throw new DomainException("Persisted cannot be init again.");

            CreatedBy = createdBy;
            CreatedDate = DateTime.Now;
            MarAsUpdate(createdBy);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long ID { get; private set; }

        [MaxLength(50)]
        public virtual string CreatedBy { get; private set; }

        [MaxLength(50)]
        public virtual string UpdatedBy { get; private set; }

        [ConcurrencyCheck]
        [Timestamp]
        public virtual byte[] Version { get; private set; }

        public virtual DateTime CreatedDate { get; private set; }
        public virtual DateTime UpdatedDate { get; private set; }

        public void MarAsUpdate(string updatedBy)
        {
            this.UpdatedBy = updatedBy;
            this.UpdatedDate = DateTime.Now;
        }
    }
}
