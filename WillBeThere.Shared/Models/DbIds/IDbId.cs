﻿namespace WillBeThere.Shared.Models.DbIds   
{
    internal interface IDbId
    {
        public Guid Id { get; set; }
        public Guid EmptyId => Guid.Empty;
        public bool Exsist => Id != Guid.Empty;
    }
}
