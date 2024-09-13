﻿using WillBeThere.DomainLayer.Entities.DbIds;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries
{
    public interface IIncludedQueryRepo : IBaseQueryRepo
    {
        IQueryable<TEntity>? SelectAllInluded<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
    }
}