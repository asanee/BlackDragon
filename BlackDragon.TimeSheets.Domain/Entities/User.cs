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

        public static User Create(IUserInformation information, string createdBy)
        {
            var target = new User();

            target.Init(createdBy);

            target.Circles = new List<Circle>();
            target.OwnCircles = new List<Circle>();

            target.FirstName = information.FirstName;
            target.LastName = information.LastName;

            target.UserName = information.UserName;
            target.Email = information.Email;
            target.Salt = GenerateSalt();
            target.HashPassword = Security.Hash(information.Password + target.Salt);

            return target;
        }

        private static string GenerateSalt()
        {
            return Guid.NewGuid().ToString()
                .Replace("-", string.Empty)
                .Substring(0, 10);
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

        [Required]
        [MaxLength(150)]
        public string Salt { get; set; }

        [Required]
        public string HashPassword { get; set; }

        public bool IsValidPassword(string password)
        {
            return Security.Hash(password + Salt) == HashPassword;
        }

        public void UpdatePassword(string newPassword)
        {
            HashPassword = Security.Hash(newPassword + Salt);
        }
    }
}
