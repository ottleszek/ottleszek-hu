namespace WillBeThere.Shared.Models
{
    public class ProgramCategory : IDbEntity<ProgramCategory>
    {
        public ProgramCategory(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProgramCategory()
        {
            Id = Guid.Empty;
            Name = string.Empty;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OrganizationProgramCategories>? OrganizationPrograms { get; set; }
    }
}
