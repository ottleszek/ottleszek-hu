using WillBeThere.Infrastucture.Implementations.Repos.WillBeThere;

namespace WillBeThere.Infrastucture.Implementations.Repos.BaseRepos
{
    public class WrapRepo : IWrapRepo
    {
        private readonly IAddressRepo? _addressRepo;
        private readonly IOrganizationRepo? _organizationRepo;
        private readonly IOrganizationAdminUserRepo? _organizationAdminUserRepo;
        private readonly IOrganizationCategoryRepo? _organizationCategoryRepo;
        private readonly IOrganizationProgramRepo? _organizationProgramRepo;
        private readonly IParticipationRepo? _participationRepo;
        private readonly IPublicSpaceRepo? _publicSpaceRepo;
        private readonly IRegisteredUserRepo? _registeredUserRepo;

        public WrapRepo(
            IAddressRepo? addressRepo,
            IOrganizationRepo? organizationRepo,
            IOrganizationAdminUserRepo organizationAdminUserRepo,
            IOrganizationCategoryRepo? organizationCategoryRepo,
            IOrganizationProgramRepo? organizationProgramRepo,
            IParticipationRepo? participationRepo,
            IPublicSpaceRepo? publicSpaceRepo,
            IRegisteredUserRepo? registeredUserRepo
            )
        {
            _addressRepo = addressRepo;
            _organizationRepo = organizationRepo;
            _organizationAdminUserRepo = organizationAdminUserRepo;
            _organizationCategoryRepo = organizationCategoryRepo;
            _organizationProgramRepo = organizationProgramRepo;
            _participationRepo = participationRepo;
            _publicSpaceRepo = publicSpaceRepo;
            _registeredUserRepo = registeredUserRepo;
        }
        public IAddressRepo? AddressRepo => _addressRepo;
        public IOrganizationRepo? OrganizationRepo => _organizationRepo;
        public IOrganizationAdminUserRepo? OrganizationAdminUserRepo => _organizationAdminUserRepo;
        public IOrganizationProgramRepo? OrganizationProgramRepo => _organizationProgramRepo;
        public IOrganizationCategoryRepo? OrganizationCategoryRepo => _organizationCategoryRepo;
        public IParticipationRepo? ParticipationRepo => _participationRepo;
        public IPublicSpaceRepo? PublicSpaceRepo => _publicSpaceRepo;
        public IRegisteredUserRepo? RegisteredUserRepo => _registeredUserRepo;
    }
}
