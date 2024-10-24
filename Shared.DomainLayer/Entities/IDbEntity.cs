namespace Shared.DomainLayer.Entities
{
    public interface IDbEntity<TEntity> where TEntity : class, new()
    {
        public Guid Id { get; set; }
        public bool HasId => Id != Guid.Empty;
        public string GetDbSetName() => new TEntity().GetType().Name;


    }
}
