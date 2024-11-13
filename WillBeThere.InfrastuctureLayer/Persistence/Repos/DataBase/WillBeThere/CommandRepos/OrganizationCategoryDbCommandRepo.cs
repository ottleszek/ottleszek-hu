using Microsoft.EntityFrameworkCore;
using Shared.DomainLayer.Responses;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;
using WillBeThere.DomainLayer.Entites;


namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class OrganizationCategoryDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IOrganizationCategoryCommandRepo where TDbContext : DbContext
    {
        public OrganizationCategoryDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
