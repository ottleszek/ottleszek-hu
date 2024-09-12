﻿using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Queries;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere
{
    public class OrganizationProgramRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationProgramRepo
        where TDbContext : DbContext
    {
        public OrganizationProgramRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            return Enumerable.Empty<TEntity>().AsQueryable();
        }
    }
}
