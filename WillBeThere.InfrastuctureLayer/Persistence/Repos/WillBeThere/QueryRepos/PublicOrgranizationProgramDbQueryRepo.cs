﻿using Microsoft.EntityFrameworkCore;
using WillBeThere.ApplicationLayer.Contracts.UnitOfWork;
using WillBeThere.DomainLayer.Entites;
using WillBeThere.DomainLayer.Entites.ResultModels;
using WillBeThere.DomainLayer.Repos;
using WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase.WillBeThere.QueryRepos.WrapRepo;

namespace WillBeThere.InfrastuctureLayer.Persistence.Repos.DataBase
{
    public class PublicOrgranizationProgramDbQueryRepo : IPublicOrgranizationProgramQueryRepo
    {
        private readonly IWillBeThereWrapQueryUnitOfWork _wrapRepo;
        public PublicOrgranizationProgramDbQueryRepo(IWillBeThereWrapQueryUnitOfWork wrapRepo)
        {
            _wrapRepo = wrapRepo ?? throw new ArgumentNullException(nameof(wrapRepo), "{nameof(DbOrganizationProgramRepo)} osztály konstruktorában wrap repo inicizalizálása nem sikerült!");
            if (
                _wrapRepo.OrganizationProgramDbQueryRepo == null ||
                _wrapRepo.AddressDbQueryRepo == null ||
                _wrapRepo.OrganizationDbQueryRepo == null ||
                _wrapRepo.PublicSpaceDbQueryRepo == null ||
                _wrapRepo.OrganizationCategoryDbQueryRepo == null)
            {
                throw new ArgumentNullException(nameof(wrapRepo),$"{nameof(PublicOrgranizationProgramDbQueryRepo)} osztály konstruktorában egy vagy több repo null.");
            }
        }

        public async Task<List<PublicOrganizationProgram>> GetAllPublicOrganizationsProgramsAsync()
        {
            IQueryable<OrganizationProgram>? publicOrganizationPrograms = GetPublicOrganizationsProgramQuery();
            if (publicOrganizationPrograms is null)
                return new();

            var publicOrganizationProgramList= await publicOrganizationPrograms.ToListAsync();
            return publicOrganizationProgramList.Select(p => new PublicOrganizationProgram
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Start = p.Start,
                End = p.End,
                OrganizationId = p.OrganizationId,
                Organization = p.Organization?.Name ?? string.Empty,
                OrganizationCategory = p.Organization?.OrganizationCategory?.Name ?? string.Empty,
                Address = p.Address ?? new Address(),
                PublicSpaceName = p.Address?.PublicSpaceName ?? string.Empty,
            }).ToList(); 
        }

        private IQueryable<OrganizationProgram>? GetPublicOrganizationsProgramQuery()
        {
            if (_wrapRepo is null)
                return null;
            else
            {
                IQueryable<OrganizationProgram>? query = _wrapRepo.OrganizationProgramDbQueryRepo
                                .SelectAll<OrganizationProgram>()
                                .Include(op => op.Address)
                                .Include(op => op.Organization)
#nullable disable
                                .ThenInclude(o => o.OrganizationCategory)
                                .Include(op => op.Address.PublicSpace)
#nullable restore
                                .Where(op => op.Start > DateTime.Now && op.IsPublic && !op.IsDeffered && op.Organization!=null && op.Address != null && op.Address.PublicSpace != null)
                                .OrderBy(op => op.Start);

                return query;
            }
        }
    }
}
