using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.InfrastuctureLayer.Implementations.Repos.WillBeThere.QueryRepos;

namespace WillBeThere.InfrastuctureLayer.Implementations.Services
{
    public class OrganizationProgramService : IOrganizationProgramService
    {
        private readonly IWrapRepos? _wrapRepo;
        public OrganizationProgramService(IWrapRepos? wrapRepo)
        {
            _wrapRepo = wrapRepo;
        }

        public IQueryable<PublicOrganizationProgram>? GetPublicOrganizationsPrograms()
        {
            /* if (_wrapRepo == null || _wrapRepo.OrganizationProgramRepo is null || _wrapRepo.AddressRepo is null || _wrapRepo.OrganizationRepo is null || _wrapRepo.PublicSpaceRepo is null || _wrapRepo.OrganizationCategoryRepo is null)
                 return null;
             else
             {
                 var query = from op in _wrapRepo.OrganizationProgramRepo.FindAll<OrganizationProgram>()
                             join a in _wrapRepo.AddressRepo.FindAll<Address>() on op.AddressId equals a.Id
                             join o in _wrapRepo.OrganizationRepo.FindAll<Organization>() on op.OrganizationId equals o.Id
                             join c in _wrapRepo.OrganizationCategoryRepo.FindAll<OrganizationCategory>() on o.OrganizationCategoryId equals c.Id 
                             join ps in _wrapRepo.PublicSpaceRepo.FindAll<PublicSpace>() on a.PublicScapeId equals ps.Id
                             where op.Start > DateTime.Now && op.IsPublic && !op.IsDeffered              
                             orderby op.Start ascending
                             select new PublicOrganizationProgram
                             {
                                 Id = op.Id,
                                 Title = op.Title,
                                 Description = op.Description,
                                 Start = op.Start,
                                 End = op.End,
                                 OrganizationId = o.Id,
                                 Organization = o.Name,
                                 OrganizationCategory =c.Name,
                                 Address = a,
                                 PublicSpaceName = ps.Name,
                             };
                 return query;

             }
            */
            return null;
        }
    }
}
