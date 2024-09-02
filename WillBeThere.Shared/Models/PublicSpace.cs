using WillBeThere.Shared.Models.Guids;

namespace WillBeThere.Shared.Models
{
    public class PublicSpace : IDbEntity<PublicSpace>
    {
        public PublicSpace() 
        {
            Id=Guid.Empty;
            Name = string.Empty;
        }
        public PublicSpace(Guid id, string nameOfPublicSpace) 
        {
            Id=id;
            Name = nameOfPublicSpace;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public virtual List<Address>? Addresses { get; set; }

    }
}
