﻿using SharedApplicationLayer.Contracts.Persistence;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http
{
    public class DataPersistenceService : IDataPersistenceService
    {

        IDataPersistenceService<OrganizationCategory>? _organizationCategoryGenericDataPersistenceSerivce;

        public DataPersistenceService(IDataPersistenceService<OrganizationCategory>? organizationCategoryDataPersistenceSerivce)
        {
            _organizationCategoryGenericDataPersistenceSerivce = organizationCategoryDataPersistenceSerivce;
        }

        public Task<Response> UpdateMany<TEntity>(List<TEntity> entities) where TEntity: class, IDbEntity<TEntity>,new ()
        {
            if (typeof(TEntity) == typeof(OrganizationCategory))
            {
                try
                {
                    if (_organizationCategoryGenericDataPersistenceSerivce is not null)
                        return _organizationCategoryGenericDataPersistenceSerivce.SaveMany(entities.Cast<OrganizationCategory>().ToList());
                } 
                catch (InvalidCastException)
                {
                    Task.FromResult(new Response($"A {nameof(OrganizationCategory)} típus esetén nem lehetséges az adatok együttes mentése!"));
                }
                catch (Exception) 
                {
                    Task.FromResult(new Response($"A {nameof(OrganizationCategory)} típus esetén hiba történt!"));
                }
            }
            return Task.FromResult(new Response($"A {nameof(TEntity)} típus esetén nem lehetséges az adatok együttes mentése!"));
        }
    }
}
