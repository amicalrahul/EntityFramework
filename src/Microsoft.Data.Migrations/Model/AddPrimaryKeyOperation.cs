﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Migrations.Utilities;
using Microsoft.Data.Relational;
using Microsoft.Data.Relational.Model;

namespace Microsoft.Data.Migrations.Model
{
    public class AddPrimaryKeyOperation : MigrationOperation
    {
        private readonly SchemaQualifiedName _tableName;
        private readonly PrimaryKey _primaryKey;

        public AddPrimaryKeyOperation(SchemaQualifiedName tableName, [NotNull] PrimaryKey primaryKey)
        {
            Check.NotNull(primaryKey, "primaryKey");

            _tableName = tableName;
            _primaryKey = primaryKey;
        }

        public virtual SchemaQualifiedName TableName
        {
            get { return _tableName; }
        }

        public virtual PrimaryKey PrimaryKey
        {
            get { return _primaryKey; }
        }

        public override void Accept([NotNull] MigrationOperationVisitor visitor)
        {
            Check.NotNull(visitor, "visitor");

            visitor.Visit(this);
        }
    }
}
