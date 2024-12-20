﻿using Microsoft.EntityFrameworkCore;
using Shared.ApplicationLayer.Repos;

namespace WillBeThere.InfrastuctureLayer.Persistence.UnifOfWorks
{
    public class QueryUnitOfWork<TDbContext> : UnitOfWork<TDbContext> where TDbContext : DbContext
    {
        public QueryUnitOfWork(TDbContext context) : base(context)
        {
        }

        public override void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public override Task<int> SaveChangesAsync()
        {
            Commit();
            return Task.FromResult(0);
        }
    }
}
