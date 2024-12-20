﻿using MediatR;
using WillBeThere.ApplicationLayer.Contracts.Dtos.OrganizationCategories;

namespace WillBeThere.ApplicationLayer.Queries.OrganizationCategories
{
    public class GetOrganizationsCategoriesListQuery : IRequest<List<OrganizationCategoryDto>> { }

}
