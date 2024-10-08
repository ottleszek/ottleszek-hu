﻿using Microsoft.EntityFrameworkCore;
using SharedDomainLayer.Entities;
using WillBeThere.InfrastuctureLayer.DataBrokers.Queries;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.Base
{
    public class BaseQueryRepo<TDbContext> : RepositoryBase<DbContext>, IBaseQueryBroker where TDbContext : DbContext
    {

        public BaseQueryRepo(DbContext? dbContext) : base(dbContext) { }

        public async Task<List<TEntity>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new() => await FindAll<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new() => await FindByCondition<TEntity>(entity => entity.Id == id).FirstOrDefaultAsync();

        public async Task<bool> IsExsistAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new()
        {
            DbSet<TEntity>? dbSet = GetDbSet<TEntity>();
            if (dbSet is null)
                return false;
            else
                return await dbSet.AnyAsync(entity => entity.Id == id);
        }
    }
}
