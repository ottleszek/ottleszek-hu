﻿using SharedDomainLayer.Entities;

namespace WillBeThere.InfrastuctureLayer.DataBrokers.Queries
{
    public interface IBaseQueryBroker
    {
        Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        Task<bool> IsExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();

    }
}
