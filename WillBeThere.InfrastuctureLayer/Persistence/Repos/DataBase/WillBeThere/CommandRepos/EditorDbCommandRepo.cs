using Microsoft.EntityFrameworkCore;
using Shared.InfrastuctureLayer.Repos.DataBase.Commands;
using WillBeThere.ApplicationLayer.Repos.CommandRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.CommandRepos
{
    public class EditorDbCommandRepo<TDbContext> : BaseCommandDbRepo<TDbContext>, IBaseEditorCommandRepo where TDbContext : DbContext
    {
        public EditorDbCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
