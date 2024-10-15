using SharedApplicationLayer.Transformers;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;
using WillBeThere.ApplicationLayer.Transformers.Assemblers;
using WillBeThere.DomainLayer.Entites;

namespace WillBeThere.ApplicationLayer.Transformers.Converters
{
    public class OrganizationCategoryDomainDtoConverter : DomainDtoConverter<OrganizationCategory, OrganizationCategoryDto, OrganizationCategoryAssembler>
    {
        public OrganizationCategoryDomainDtoConverter(OrganizationCategoryAssembler assembler) : base(assembler)
        {
        }
    }
}
