﻿using WillBeThere.Shared.Assemblers;
using WillBeThere.Shared.Models.Guids;
using WillBeThere.Shared.Responses;

namespace WillBeThere.HttpService.DataService
{
    public interface IBaseDataService<TEntity, TEntityDto, TAssembler> 
        where TEntity : class, IDbEntity<TEntity>, new()
        where TEntityDto : class, new()
        where TAssembler : class, IAssembler<TEntity, TEntityDto>
    {
        public Task<List<TEntity>> SelectAsync();
        public Task<TEntity?> GetByIdAsync(Guid id);
        public Task<Response> UpdateAsync(TEntity entity);
        public Task<Response> DeleteAsync(TEntity entity);
        public Task<Response> DeleteAsync(Guid id);
        public Task<Response> InsertAsync(TEntity entity);
    }
}
