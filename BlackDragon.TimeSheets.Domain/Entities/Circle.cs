using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BlackDragon.TimeSheets.Shared;

namespace BlackDragon.TimeSheets.Domain
{
    /// <summary>
    /// Social Circle
    /// </summary>
    public class Circle: ActiveEntity, ICircle
    {
        protected Circle()
        {

        }

        public static Circle Create(string name, User owner)
        {
            var target = new Circle();

            target.Init(owner.UserName);
            target.Owner = owner;
            target.Name = name;

            return target;
        }

        [MaxLength(100)]
        [Required]
        public virtual string Name { get; private set; }

        public virtual bool IsPublic { get; set; }

        public virtual User Owner { get; private set; }

        public virtual long OwnerId { get; private set; }

        public virtual IList<User> Users { get; private set; }

        public virtual IList<User> Requestors { get; private set; }

        public virtual ICollection<Document> Documents { get; private set; }
    }
}
