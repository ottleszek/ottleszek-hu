using Microsoft.EntityFrameworkCore;
using System.Data;
using WillBeThere.Shared.Helpers.TestData;
using WillBeThere.Shared.Models;

namespace WillBeThere.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<PublicSpace>().HasData(FullDatabase.PublicSpaces);
            modelBuilder.Entity<Address>().HasData(FullDatabase.Addresses);
            modelBuilder.Entity<OrganizationCategory>().HasData(FullDatabase.ProgramCategories);
            modelBuilder.Entity<Organization>().HasData(FullDatabase.Organizations);
            modelBuilder.Entity<RegisteredUser>().HasData(FullDatabase.RegisteredUsers);
            modelBuilder.Entity<ProgramOwner>().HasData(FullDatabase.ProgramOwners);
            modelBuilder.Entity<OrganizationProgram>().HasData(FullDatabase.OrganizationPrograms);
            modelBuilder.Entity<Participation>().HasData(FullDatabase.Participations);
            modelBuilder.Entity<Editor>().HasData(FullDatabase.Editors);
            modelBuilder.Entity<OrganizationEditor>().HasData(FullDatabase.OrganizationEditors);
        }
    }
}
