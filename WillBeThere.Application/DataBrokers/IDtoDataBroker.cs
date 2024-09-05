﻿using WillBeThere.Application.Responses;
using WillBeThere.Domain.Entities.DbIds;

namespace WillBeThere.Application.DataBrokers
{ 
    public interface IDtoDataBroker<TEntityDto> where TEntityDto : class, new() 
    {
        Task<List<TEntityDto>> SelectAllAsync<TEntity>() where TEntity : class, IDbEntity<TEntity>, new();
        Task<TEntityDto?> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> InsertAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> UpdateAsync<TEntity>(TEntityDto entityDto) where TEntity : class, IDbEntity<TEntity>, new();
        Task<Response> DeleteAsync<TEntity>(Guid id) where TEntity : class, IDbEntity<TEntity>, new();
    }
}
