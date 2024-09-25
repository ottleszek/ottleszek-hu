﻿using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos
{
    public class OrganizationEditorQueryRepo<TDbContext> : IncludedQueryRepo<TDbContext>, IOrganizationEditorQueryRepo where TDbContext : DbContext
    {
        public OrganizationEditorQueryRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}