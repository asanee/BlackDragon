using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Dal
{
    public class CircleConfiguration : EntityTypeConfiguration<Circle>
    {
        public CircleConfiguration()
        {
            this.ToTable("Circles");
        }
    }
}
