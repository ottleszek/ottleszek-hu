using Microsoft.EntityFrameworkCore;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.InfrastuctureLayer.Context;
using WillBeThere.InfrastuctureLayer.Helpers.TestData;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Services;

namespace WillBeThereTest.Backend.Services
{
    public class OrganizationProgramServiceFullDatabase
    { 
        private WillBeThereInMemoryContext _context;

        private static DbContextOptions<WillBeThereInMemoryContext> contextOptions = new DbContextOptionsBuilder<WillBeThereInMemoryContext>()
                .UseInMemoryDatabase(databaseName: "WillBeThereTest" + Guid.NewGuid().ToString())
                .Options;


        private IAddressQueryRepo _addressRepo;
        private IOrganizationRepo _organizationRepo;
        private IOrganizationAdminUserRepo _organizationAdminUserRepo;
        private IOrganizationCategoryRepo _organizationCategoryRepo;
        private IOrganizationProgramQueryRepo _organizationProgramRepo;
        private IParticipationRepo _participationRepo;
        private IPublicSpaceRepo _publicSpaceRepo;
        private IRegisteredUserRepo _registeredUserRepo;

        private IWrapRepo _wrapRepo;

        private IOrganizationProgramService _organizationProgramService;
        public OrganizationProgramServiceFullDatabase()
        {
        }
        
        [SetUp]
        public void Setup()
        {
            _context = new WillBeThereInMemoryContext(contextOptions);
            _addressRepo = new AddressRepo<WillBeThereInMemoryContext>(_context);
            _organizationRepo = new OrganiozationRepo<WillBeThereInMemoryContext>(_context);
            _organizationAdminUserRepo = new OrganizationAdminUserRepo<WillBeThereInMemoryContext>(_context);
            _organizationCategoryRepo = new OrganizationCategoryRepo<WillBeThereInMemoryContext>(_context);
            _organizationProgramRepo = new OrganizationProgramQueryRepo<WillBeThereInMemoryContext>(_context);
            _publicSpaceRepo =new PublicSpaceRepo<WillBeThereInMemoryContext>(_context);
            _registeredUserRepo = new RegisteredUserRepo<WillBeThereInMemoryContext>(_context);
            _participationRepo = new ParticipationRepo<WillBeThereInMemoryContext>(_context);

            _wrapRepo = new WrapRepo(
                _addressRepo,
                _organizationRepo,
                _organizationAdminUserRepo,
                _organizationCategoryRepo,
                _organizationProgramRepo,
                _participationRepo,
                _publicSpaceRepo,
                _registeredUserRepo
                );

            _organizationProgramService = new OrganizationProgramService(_wrapRepo);

            _context.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void FullDatabaseTest()
        {
            // Public organization program
            IQueryable<PublicOrganizationProgram>? query = _organizationProgramService.GetPublicOrganizationsPrograms();
            if (query == null)
            {
                Assert.Fail("Jövőbeli programok lekérése null értéket adott, valamelyik repo nem létezik!");
                return; 
            }
            int count = query.Count();
            Assert.That(count, Is.EqualTo(2), "Jövőbeli programok lekérése nem a megfelelő számű eseményt adta!");
            List<PublicOrganizationProgram> list = [.. query];
            // Expected organization program
            Assert.That(list, Has.Some.Matches<PublicOrganizationProgram>(pop => pop.Id == FullDatabase.OrganizationProgramId3),"A jövőbeli programok között nem az elvárt program található!");
            Assert.That(list, Has.Some.Matches<PublicOrganizationProgram>(pop => pop.Id == FullDatabase.OrganizationProgramId4), "A jövőbeli programok között nem az elvárt program található!");

            /*List<OrganizationProgram> expectedList = FullDatabase.OrganizationPrograms.Where(op => op.Id == FullDatabase.OrganizationProgramId3 || op.Id == FullDatabase.OrganizationProgramId4).ToList();*/
            List<OrganizationProgram> expectedList = FullDatabase.OrganizationPrograms.Where(
                op => op.Start > DateTime.Now && op.IsPublic && !op.IsDeffered).ToList();
            // Organization name           
            List<string> expectedOrganizationName = FullDatabase.Organizations.Where(o => expectedList.Select(op => op.OrganizationId).Contains(o.Id)).Select(o  => o.Name).ToList();
            Assert.That(list.Select(pop => pop.Organization), Is.EqualTo(expectedOrganizationName),"A jövőbeli programok szervezői nem a megfelelő szervezetek!");
            // Addresses
            List<Guid> expectedAddressIDs = FullDatabase.Addresses.Where(a => expectedList.Select(op => op.AddressId).Contains(a.Id)).Select(a => a.Id).ToList();
            Assert.That(list.Select(pop => pop.Address.Id), Is.EqualTo(expectedAddressIDs), "A jövőbeli programok címei nem a megfelelőek");
        }
    }
}
