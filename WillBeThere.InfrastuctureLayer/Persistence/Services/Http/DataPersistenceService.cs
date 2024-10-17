using SharedApplicationLayer.Contracts.Persistence;
using SharedDomainLayer.Entities;
using SharedDomainLayer.Responses;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services.Http
{
    public class DataPersistenceService : IDataPersistenceService
    {

        IDataPersistenceService<OrganizationCategory>? _organizationCategoryDataPersistenceSerivce;

        public DataPersistenceService(IDataPersistenceService<OrganizationCategory>? organizationCategoryDataPersistenceSerivce)
        {
            _organizationCategoryDataPersistenceSerivce = organizationCategoryDataPersistenceSerivce;
        }

        public Task<Response> SaveMany<TEntity>(List<TEntity> entities) where TEntity: class, IDbEntity<TEntity>,new ()
        {
            if (typeof(TEntity) == typeof(OrganizationCategory))
            {
                try
                {
                    if (_organizationCategoryDataPersistenceSerivce is not null)
                        return _organizationCategoryDataPersistenceSerivce.SaveMany(entities.Cast<OrganizationCategory>().ToList());
                } 
                catch (InvalidCastException e)
                {
                    Task.FromResult(new Response($"A {nameof(OrganizationCategory)} típus esetén nem lehetséges az adatok együttes mentése!"));
                }
                catch (Exception e) 
                {
                    Task.FromResult(new Response($"A {nameof(OrganizationCategory)} típus esetén hiba történt!"));
                }
            }
            return Task.FromResult(new Response($"A {nameof(TEntity)} típus esetén nem lehetséges az adatok együttes mentése!"));
        }
    }
}
