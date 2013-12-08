using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using BlackDragon.TimeSheets.Domain;

namespace BlackDragon.TimeSheets.Dal.Configurations
{
    public class DocumentConfiguration : EntityTypeConfiguration<Document>
    {
        public DocumentConfiguration()
        {
            ToTable("Documents");

            this.HasRequired(x => x.Circle).WithMany(x => x.Documents);
        }
    }
}
