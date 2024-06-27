using WillBeThere.Shared.Models.DbIds;

namespace WillBeThere.Shared.Models
{
    public class PublicSpace : IDbEntity<PublicSpace>
    {
        public PublicSpace() 
        {
            Id=new DbId();
            Name = string.Empty;
        }
        public PublicSpace(DbId id, string nameOfPublicSpace) 
        {
            Id=id;
            Name = nameOfPublicSpace;
        }

        public DbId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual List<Address>? Addresses { get; set; }

    }
}
