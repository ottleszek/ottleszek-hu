using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WrapRepos
{
    public class WrapCommandRepo<TDbContext> : IWrapCommandRepo where TDbContext : DbContext
    {
        private IUnitOfWork? _unitOfWork;

        /*private readonly IAddressQueryRepo? _addressRepo;
        private readonly IOrganizationCategoryRepo? _organizationCategoryRepo;
        private readonly IOrganizationRepo? _organizationRepo;
        */
        private readonly IOrganizationProgramCommandRepo? _organizationProgramRepo;

        public IOrganizationProgramCommandRepo? OrganizationProgramRepo => _organizationProgramRepo;

        /*private readonly IParticipationRepo? _participationRepo;
private readonly IPublicSpaceRepo? _publicSpaceRepo;
private readonly IRegisteredUserRepo? _registeredUserRepo;
*/

        public WrapCommandRepo(
            IUnitOfWork? unitOfWork,
            /*  IAddressQueryRepo? addressRepo,
              IOrganizationRepo? organizationRepo,
              IOrganizationCategoryRepo? organizationCategoryRepo,
            */
            IOrganizationProgramCommandRepo? organizationProgramRepo
            /*
            IParticipationRepo? participationRepo,
            IPublicSpaceRepo? publicSpaceRepo,
            IRegisteredUserRepo? registeredUserRepo
            */

            )
        {
            _organizationProgramRepo = organizationProgramRepo;
            _unitOfWork = unitOfWork;
            if (_unitOfWork is not null)
            {
                _unitOfWork.AddRepository<OrganizationProgramCommandRepo<TDbContext>, OrganizationProgram>((OrganizationProgramCommandRepo<TDbContext>?)_organizationProgramRepo);
            }




            //_commandRepo.
            /*
            if (addressRepo is not null)
                _unitOfWork?.AddRepository<IAddressQueryRepo, Address>(addressRepo);
           
            if (_organizationProgramRepo is not null)
                _unitOfWork?.AddRepository<IOrganizationProgramRepo,OrganizationProgram>(organizationProgramRepo);
            if (participationRepo is not null)
                _unitOfWork?.AddRepository<IParticipationRepo,Participation>(participationRepo);
            if (publicSpaceRepo is not null)
                _unitOfWork?.AddRepository<IPublicSpaceRepo,PublicSpace>(publicSpaceRepo);
            if (registeredUserRepo is not null)
                _unitOfWork?.AddRepository<IRegisteredUserRepo,RegisteredUser>(registeredUserRepo);
            if (organizationCategoryRepo is not null)
                _unitOfWork?.AddRepository<IOrganizationCategoryRepo,OrganizationCategory>(organizationCategoryRepo);
            if ()

            /*_addressRepo = addressRepo;
            _organizationRepo = organizationRepo;
            _organizationAdminUserRepo = organizationAdminUserRepo;
            _organizationCategoryRepo = organizationCategoryRepo;
            _organizationProgramRepo = organizationProgramRepo;
            _participationRepo = participationRepo;
            _publicSpaceRepo = publicSpaceRepo;
            _registeredUserRepo = registeredUserRepo;*/
        }

        /*
        public IAddressQueryRepo? AddressRepo => _addressRepo;
        public IOrganizationRepo? OrganizationRepo => _organizationRepo;
        public IOrganizationAdminUserRepo? OrganizationAdminUserRepo => _organizationAdminUserRepo;
        public IOrganizationProgramRepo? OrganizationProgramRepo => _organizationProgramRepo;
        public IOrganizationCategoryRepo? OrganizationCategoryRepo => _organizationCategoryRepo;
        public IParticipationRepo? ParticipationRepo => _participationRepo;
        public IPublicSpaceRepo? PublicSpaceRepo => _publicSpaceRepo;
        public IRegisteredUserRepo? RegisteredUserRepo => _registeredUserRepo;
        */
    }
}
