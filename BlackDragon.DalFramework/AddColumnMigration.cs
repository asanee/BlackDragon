using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Builders;

namespace BlackDragon.DalFramework
{
    public abstract class AddColumnMigration<T, TProperty> : DbMigration
    {
        protected virtual bool AutoIncludeDbo { get { return true; } }

        protected virtual string TableName
        {
            get
            {
                return typeof(T).Name + "s";
            }
        }

        protected abstract Expression<Func<T, TProperty>> Property { get; }

        protected virtual string ColumnName
        {
            get
            {
                return Property.FindProperty().Name;
            }
        }

        protected virtual bool IsNullable
        {
            get
            {
                var propertyType = typeof(TProperty);

                return propertyType.IsSubclassOf(typeof(Nullable<>)) || 
                    propertyType.IsClass;
            }
        }

        protected virtual TProperty DefaultValue
        {
            get
            {
                return default(TProperty);
            }
        }

        public override void Up()
        {
            AddColumn(AutoIncludeDbo ? "dbo." : string.Empty + TableName,
                ColumnName, x => Customize(x, IsNullable, DefaultValue));
        }

        public override void Down()
        {
            DropColumn(AutoIncludeDbo ? "dbo." : string.Empty + TableName, 
                ColumnName);
        }

        protected abstract ColumnModel Customize(ColumnBuilder builder,
            bool isNullable, TProperty defaultValue);
    }
}
