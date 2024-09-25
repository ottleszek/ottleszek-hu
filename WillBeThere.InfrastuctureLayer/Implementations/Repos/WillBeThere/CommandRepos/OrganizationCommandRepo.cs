﻿using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class OrganizationCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IOrganizationCommandRepo where TDbContext : DbContext
    {
        public OrganizationCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}