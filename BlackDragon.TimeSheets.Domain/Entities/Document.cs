using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlackDragon.TimeSheets.Domain
{
    public class Document: ActiveEntity
    {
        protected Document()
        {

        }

        public virtual Circle Circle { get; private set; }

        public virtual long CircleId { get; private set; }

        [StringLength(50)]
        [Required]
        public virtual string Name { get; private set; }

        public virtual int Size { get; private set; }
    }
}
