namespace WillBeThere.Shared.Models
{
    public interface IIdEntity
    {
        public Guid Id { get; set; }
        public bool HasId => Id != Guid.Empty;
    }
}
