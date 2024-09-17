using Microsoft.EntityFrameworkCore;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.BaseCqrsRepos.Commands;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.CommandRepos
{
    public class EditorCommandRepo<TDbContext> : BaseCommandRepo<TDbContext>, IEditorCommandRepo where TDbContext : DbContext
    {
        public EditorCommandRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
