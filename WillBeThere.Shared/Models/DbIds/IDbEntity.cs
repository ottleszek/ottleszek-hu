namespace WillBeThere.Shared.Models.DbIds
{
    public interface IDbEntity<TEntity>
        where TEntity : class, new()
    {
        public DbId Id { get; set; }
        public string GetDbSetName() => new TEntity().GetType().Name;

    }
}
