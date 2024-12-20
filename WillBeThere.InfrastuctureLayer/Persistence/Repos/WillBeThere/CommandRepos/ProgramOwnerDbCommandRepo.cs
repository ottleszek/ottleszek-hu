﻿using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Persistence.Repos.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class ProgramOwnerDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IProgamOwnerCommandRepo where TDbContext : DbContext
    {
        public ProgramOwnerDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
