using Microsoft.EntityFrameworkCore;
using WillBeThere.Shared.Models;

namespace WillBeThere.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        { 
            Guid programCategoryId1 = Guid.NewGuid();
            Guid programCategoryId2 = Guid.NewGuid();
            Guid programCategoryId3 = Guid.NewGuid();
            Guid programCategoryId4 = Guid.NewGuid();
            Guid programCategoryId5 = Guid.NewGuid();

            List<ProgramCategory> programCategories = new()
            {
                new ProgramCategory
                {
                    Id = programCategoryId1,
                    Name="vallás"
                },
                new ProgramCategory
                {
                    Id = programCategoryId2,
                    Name="nevelés"
                },
                new ProgramCategory
                {
                    Id = programCategoryId3,
                    Name="házasság"
                },
                new ProgramCategory
                {
                    Id = programCategoryId4,
                    Name="férfi identitás"
                },
                new ProgramCategory
                {
                    Id = programCategoryId5,
                    Name="ifjúság"
                },
            };
        }
    }
}
