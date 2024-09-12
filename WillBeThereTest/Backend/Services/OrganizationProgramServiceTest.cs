using Moq;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseRepos;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere;
using WillBeThere.InfrastuctureLayer.Implementations.Services;

namespace WillBeThereTest.Backend.Services
{
    public class OrganizationProgramServiceTest
    {
        private readonly IOrganizationProgramService? _organizationProgramService;
        
        private readonly Mock<IWrapRepo> _mockWrapRepo = new Mock<IWrapRepo>();
        private readonly Mock<IOrganizationRepo> _mockOrganizationRepo = new Mock<IOrganizationRepo>();
        private readonly Mock<IOrganizationProgramRepo> _mockOrganizationProgramRepo = new Mock<IOrganizationProgramRepo>();
        private readonly Mock<IAddressQueryRepo> _mockAddressRepo = new Mock<IAddressQueryRepo>();
        private readonly Mock<IPublicSpaceRepo> _mockPublicSpaceRepo = new Mock<IPublicSpaceRepo>();
        
        public OrganizationProgramServiceTest()
        {
            _organizationProgramService = new OrganizationProgramService(_mockWrapRepo.Object);
        }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        #region EmptyDatabase
        public void EmptyDatabase()        
        {
            _mockOrganizationRepo
                .Setup(mock =>mock.FindAll<Organization>())
                .Returns(Enumerable.Empty<Organization>().AsQueryable());
            _mockOrganizationProgramRepo
                .Setup(mock => mock.FindAll<OrganizationProgram>())
                .Returns(Enumerable.Empty<OrganizationProgram>().AsQueryable());
            _mockAddressRepo
                .Setup(mock => mock.FindAll<Address>())
                .Returns(Enumerable.Empty<Address>().AsQueryable());
            _mockPublicSpaceRepo
                .Setup(mock => mock.FindAll<PublicSpace>())
                .Returns(Enumerable.Empty<PublicSpace>().AsQueryable());



            _mockWrapRepo
                .Setup(mock => mock.OrganizationRepo)
                .Returns(_mockOrganizationRepo.Object);
            _mockWrapRepo
                .Setup(mock => mock.OrganizationProgramRepo)
                .Returns(_mockOrganizationProgramRepo.Object);
            _mockWrapRepo
                .Setup(mock => mock.AddressRepo)
                .Returns(_mockAddressRepo.Object);
            _mockWrapRepo
                .Setup(mock => mock.PublicSpaceRepo)
                .Returns(_mockPublicSpaceRepo.Object);

            if (_organizationProgramService is not null)
            {
                IQueryable<PublicOrganizationProgram>? query = _organizationProgramService.GetPublicOrganizationsPrograms();
                if (query != null)
                    Assert.That(query.Count(), Is.EqualTo(0),$"${_organizationProgramService.GetPublicOrganizationsPrograms()} metódus üres adatbázis esetén adatot talál!");  
            }
        }
        #endregion

        [Test]
        #region PastProgramsNoFuturePrograms
        public void PastProgramsNoFuturePrograms()
        {

            #region Organization progrm test data
            Guid organizationProgramId1 = new Guid();
            Guid organizationProgramId2 = new Guid();

            List<OrganizationProgram> organizationPrograms = new()
            {
                new OrganizationProgram
                {
                    Id = organizationProgramId1,
                    Start=DateTime.Today.AddMonths(-1).AddDays(5).Add(new TimeSpan(20,30,0)),
                    End=null,
                    Title="Title1",
                    Description="Description1.",
                    IsDeffered=false,
                    IsPublic=true,
                },
                new OrganizationProgram
                {
                    Id = organizationProgramId2,
                    Start=DateTime.Today.AddDays(-1).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.Add(new TimeSpan(12,0,0)),
                    Title="Title2",
                    Description="Description2.",
                    IsDeffered=false,
                    IsPublic=true,
                }
            };
            #endregion

            _mockOrganizationRepo
               .Setup(mock => mock.FindAll<Organization>())
               .Returns(Enumerable.Empty<Organization>().AsQueryable());
            _mockOrganizationProgramRepo
                .Setup(mock => mock.FindAll<OrganizationProgram>())
                .Returns(organizationPrograms.AsQueryable());
            _mockAddressRepo
                .Setup(mock => mock.FindAll<Address>())
                .Returns(Enumerable.Empty<Address>().AsQueryable());
            _mockPublicSpaceRepo
                .Setup(mock => mock.FindAll<PublicSpace>())
                .Returns(Enumerable.Empty<PublicSpace>().AsQueryable());



            _mockWrapRepo
                .Setup(mock => mock.OrganizationRepo)
                .Returns(_mockOrganizationRepo.Object);
            _mockWrapRepo
                .Setup(mock => mock.OrganizationProgramRepo)
                .Returns(_mockOrganizationProgramRepo.Object);
            _mockWrapRepo
                .Setup(mock => mock.AddressRepo)
                .Returns(_mockAddressRepo.Object);
            _mockWrapRepo
                .Setup(mock => mock.PublicSpaceRepo)
                .Returns(_mockPublicSpaceRepo.Object);

            if (_organizationProgramService is not null)
            {
                IQueryable<PublicOrganizationProgram>? query = _organizationProgramService.GetPublicOrganizationsPrograms();
                if (query != null)
                    Assert.That(query.Count(), Is.EqualTo(0), $"Jövőben nem létező események esetén a ${_organizationProgramService.GetPublicOrganizationsPrograms()} netódus mégis talált eseményt!");
            }
        }
        #endregion

        [Test]
        #region FutureAndPastPrograms
        public void FutureAndPastPrograms()
        {

            #region Organization progrm test data
            Guid organizationProgramId1 = new Guid();
            Guid organizationProgramId2 = new Guid();
            Guid organizationProgramId3 = new Guid();

                    List<OrganizationProgram> organizationPrograms = new()
            {
                new OrganizationProgram
                {
                    Id = organizationProgramId1,
                    Start=DateTime.Today.AddMonths(1).AddDays(5).Add(new TimeSpan(20,30,0)),
                    End=null,
                    Title="Title1",
                    Description="Description1.",
                    IsDeffered=false,
                    IsPublic=true,
                },
                new OrganizationProgram
                {
                    Id = organizationProgramId2,
                    Start=DateTime.Today.AddDays(-1).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.AddDays(-1).Add(new TimeSpan(20,0,0)),
                    Title="Title2",
                    Description="Description2.",
                    IsDeffered=false,
                    IsPublic=true,
                },
                new OrganizationProgram
                {
                    Id = organizationProgramId3,
                    Start=DateTime.Today.AddDays(1).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.AddDays(1).Add(new TimeSpan(20,0,0)),
                    Title="Title2",
                    Description="Description2.",
                    IsDeffered=false,
                    IsPublic=true,
                }
            };
            #endregion

            _mockOrganizationRepo
               .Setup(mock => mock.FindAll<Organization>())
               .Returns(Enumerable.Empty<Organization>().AsQueryable());
            _mockOrganizationProgramRepo
                .Setup(mock => mock.FindAll<OrganizationProgram>())
                .Returns(organizationPrograms.AsQueryable());
            _mockAddressRepo
                .Setup(mock => mock.FindAll<Address>())
                .Returns(Enumerable.Empty<Address>().AsQueryable());
            _mockPublicSpaceRepo
                .Setup(mock => mock.FindAll<PublicSpace>())
                .Returns(Enumerable.Empty<PublicSpace>().AsQueryable());



            _mockWrapRepo
                .Setup(mock => mock.OrganizationRepo)
                .Returns(_mockOrganizationRepo.Object);
            _mockWrapRepo
                .Setup(mock => mock.OrganizationProgramRepo)
                .Returns(_mockOrganizationProgramRepo.Object);
            _mockWrapRepo
                .Setup(mock => mock.AddressRepo)
                .Returns(_mockAddressRepo.Object);
            _mockWrapRepo
                .Setup(mock => mock.PublicSpaceRepo)
                .Returns(_mockPublicSpaceRepo.Object);

            if (_organizationProgramService is not null)
            {
                IQueryable<PublicOrganizationProgram>? query = _organizationProgramService.GetPublicOrganizationsPrograms();
                if (query != null)
                    Assert.That(query.Count(), Is.EqualTo(0), $"Jövőben nem létező események esetén a ${_organizationProgramService.GetPublicOrganizationsPrograms()} netódus mégis talált eseményt!");
            }
        }
        #endregion
    }
}
