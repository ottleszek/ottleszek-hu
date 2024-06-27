﻿namespace WillBeThere.Shared.Models.DbIds
{
    public class DbId : IDbId
    {
        public DbId()
        {
            Id = EmptyId;
        }

        public DbId(DbId id)
        {
            Id = id.Id;
        }

        public DbId (Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public Guid EmptyId => Guid.Empty;
        public bool HasId => Id != Guid.Empty;
    }
}
