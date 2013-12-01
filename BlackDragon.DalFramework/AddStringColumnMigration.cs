using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Builders;

namespace BlackDragon.DalFramework
{
    public abstract class AddStringColumnMigration<T> : AddColumnMigration<T, string>
    {
        protected override ColumnModel Customize(ColumnBuilder builder, 
            bool isNullable, string defaultValue)
        {
            return builder.String(IsNullable,
                MaxLength, defaultValue: DefaultValue);
        }

        public abstract int? MaxLength { get; }
    }
}
