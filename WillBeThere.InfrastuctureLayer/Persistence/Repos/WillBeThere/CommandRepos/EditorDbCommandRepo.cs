using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Persistence.Repos.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class EditorDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IEditorCommandRepo where TDbContext : DbContext
    {
        public EditorDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
