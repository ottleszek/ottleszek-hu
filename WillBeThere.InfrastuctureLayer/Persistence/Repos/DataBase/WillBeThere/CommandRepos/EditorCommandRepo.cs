using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class EditorCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseEditorCommandRepo where TDbContext : DbContext
    {
        public EditorCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
