using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Shared;
using System.ComponentModel.DataAnnotations;

namespace BlackDragon.TimeSheets.Domain
{
    public class User : ActiveEntity
    {
        protected User()
        {

        }

        public static User Create(string username, 
            string email, string createdBy)
        {
            var target = new User();

            target.Init(createdBy);

            target.Circles = new List<Circle>();
            target.OwnCircles = new List<Circle>();

            target.UserName = username;
            target.Email = email;

            return target;
        }

        [MaxLength(150)]
        public virtual string FirstName { get; set; }

        [MaxLength(150)]
        public virtual string LastName { get; set; }

        [Required]
        [MaxLength(150)]
        public virtual string UserName { get; private set; }

        [Email]
        [Required]
        public virtual string Email { get; set; }

        public virtual IList<Circle> Circles { get; private set; }
        public virtual IList<Circle> OwnCircles { get; private set; }
    }
}
