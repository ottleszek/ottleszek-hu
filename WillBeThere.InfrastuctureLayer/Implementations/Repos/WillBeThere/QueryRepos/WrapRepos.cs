using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Interfaces;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos.Repos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos
{
    public class WrapRepos<TDbContext> : WrapperUnitOfWork<TDbContext>, IWrapRepos where TDbContext : DbContext
    {
        private IAddressQueryRepo _addressQueryRepo;
        public WrapRepos
            (
                TDbContext context,
                IAddressQueryRepo addressQueryRepo
            ) 
            : base(context)
        {
            _addressQueryRepo = AddRepository<IAddressQueryRepo,Address>(addressQueryRepo) ?? new AddressQueryRepo<TDbContext>(context);
        }

        public IAddressQueryRepo addressQueryRepo => _addressQueryRepo;
    }
}
