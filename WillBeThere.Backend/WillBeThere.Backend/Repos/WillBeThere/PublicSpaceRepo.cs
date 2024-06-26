﻿using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Backend.Repos.WillBeThere
{
    public class PublicSpaceRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IPublicSpaceRepo
        where TDbContext: DbContext
    {
        public PublicSpaceRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
