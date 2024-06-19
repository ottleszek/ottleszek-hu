using Microsoft.EntityFrameworkCore;
using WillBeThere.Backend.Context;
using WillBeThere.Backend.Repos.WillBeThere;
using WillBeThere.Shared.Models;

namespace WillBeThereTest.Backend.Services
{
    public class OrganizationProgramServiceFullDatabase
    { 
        private WillBeThereInMemoryContext _context;

        private static DbContextOptions<WillBeThereInMemoryContext> contextOptions = new DbContextOptionsBuilder<WillBeThereInMemoryContext>()
                .UseInMemoryDatabase(databaseName: "WillBeThereTest" + Guid.NewGuid().ToString())
                .Options;


        private IAddressRepo _addressRepo;
        public OrganizationProgramServiceFullDatabase()
        {

        }
        
        [SetUp]
        public void Setup()
        {
            _context = new WillBeThereInMemoryContext(contextOptions);
            _addressRepo = new AddressRepo<WillBeThereInMemoryContext>(_context);

            _context.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public void FullDatabase()
        {

        }
    }
}
