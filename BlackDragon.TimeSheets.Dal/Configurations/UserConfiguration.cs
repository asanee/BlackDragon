using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Dal
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.HasMany(x => x.Circles)
                .WithMany(x => x.Users)
                .Map(x=> x.ToTable("UserCircles"));

            this.HasMany(x => x.OwnCircles)
                .WithRequired(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            this.ToTable("Users");
        }
    }
}
