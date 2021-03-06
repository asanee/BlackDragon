﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using System.Linq.Expressions;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Builders;

namespace BlackDragon.DalFramework
{
    public abstract class AddNullableBoolColumnMigration<T> : AddColumnMigration<T, bool?>
    {
        protected override ColumnModel Customize(ColumnBuilder builder, bool isNullable, bool? defaultValue)
        {
            return builder.Boolean(IsNullable, DefaultValue);
        }
    }
}
