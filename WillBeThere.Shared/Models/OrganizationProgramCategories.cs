
namespace WillBeThere.Shared.Models
{
    public class OrganizationProgramCategories : IDbEntity<OrganizationProgramCategories>
    {
        public OrganizationProgramCategories()
        {
            Id = Guid.Empty;
            OrganizationProgramId = Guid.Empty;
            CategoryId = Guid.Empty;
            OrganizationProgram= new OrganizationProgram();
            ProgramCategory = new ProgramCategory();
        }

        public OrganizationProgramCategories(Guid id, Guid organizationProgramId, Guid categoryId)
        {
            Id = id;
            OrganizationProgramId = organizationProgramId;
            CategoryId = categoryId;
            OrganizationProgram = new OrganizationProgram();
            ProgramCategory = new ProgramCategory();
        }

        public Guid Id { get; set; }
        public Guid OrganizationProgramId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual OrganizationProgram OrganizationProgram { get; set; }
        public virtual ProgramCategory ProgramCategory { get; set; }


    }
}
