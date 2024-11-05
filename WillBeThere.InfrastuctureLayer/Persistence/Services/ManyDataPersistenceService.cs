using Shared.ApplicationLayer.Persistence;
using Shared.DomainLayer.Entities;
using Shared.DomainLayer.Responses;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.InfrastuctureLayer.Persistence.Services
{
    public class ManyDataPersistenceService : IManyDataPersistenceService
    {

        private readonly IManyDataPersistenceService<OrganizationCategory>? _organizationCategoryGenericDataPersistenceSerivce;

        public ManyDataPersistenceService(IManyDataPersistenceService<OrganizationCategory>? organizationCategoryDataPersistenceSerivce)
        {
            _organizationCategoryGenericDataPersistenceSerivce = organizationCategoryDataPersistenceSerivce;
        }

        public Task<Response> UpdateMany<TEntity>(List<TEntity> entities) where TEntity : class, IDbEntity<TEntity>, new()
        {
            if (typeof(TEntity) == typeof(OrganizationCategory))
            {
                try
                {
                    if (_organizationCategoryGenericDataPersistenceSerivce is not null)
                        return _organizationCategoryGenericDataPersistenceSerivce.UpdateMany(entities.Cast<OrganizationCategory>().ToList());
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
