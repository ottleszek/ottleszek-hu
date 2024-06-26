﻿using Microsoft.EntityFrameworkCore;

namespace WillBeThere.Backend.Repos.WillBeThere
{
    public class OrganizationAdminUserRepo<TDbContext> : IncludedRepositoryBase<TDbContext>, IOrganizationAdminUserRepo
        where TDbContext : DbContext
    {
        public OrganizationAdminUserRepo(TDbContext? dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<TEntity>? GetAllIncluded<TEntity>()
        {
            throw new NotImplementedException();
        }
    }
}
