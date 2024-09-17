﻿namespace WillBeThere.ApplicationLayer.Contracts.UnitOfWork
{
    public interface IWrapperUnitOfWork : IRepoStore
    {
        void BeginTransaction();
        void Commit();
        public void Rollback();
    }
}
