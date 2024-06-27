﻿using System.Linq.Expressions;
using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Backend.Repos.WillBeThere
{
    public interface IRepositoryBase
    {
        IQueryable<TEntity> FindAll<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        IQueryable<TEntity> FindByCondition<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
