namespace WillBeThere.Shared.Models
{
    public interface IDbEntity<TEntity> : IIdEntity 
        where TEntity : class, new()
    {
        public string GetDbSetName() => new TEntity().GetType().Name;

    }
}
