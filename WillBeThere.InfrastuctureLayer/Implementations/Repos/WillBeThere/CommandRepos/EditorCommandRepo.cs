using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Repos.Base;
using WillBeThere.DomainLayer.Repos.Base;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class EditorCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IBaseEditorCommandRepo where TDbContext : DbContext
    {
        public EditorCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
