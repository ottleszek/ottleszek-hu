using Microsoft.EntityFrameworkCore;
using WillBeThere.Shared.Models;

namespace WillBeThere.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            #region Ids
            Guid publicSpace1= Guid.NewGuid();
            Guid publicSpace2 = Guid.NewGuid();
            Guid publicSpace3 = Guid.NewGuid();
            Guid publicSpace4 = Guid.NewGuid();

            Guid programCategoryId1 = Guid.NewGuid();
            Guid programCategoryId2 = Guid.NewGuid();
            Guid programCategoryId3 = Guid.NewGuid();
            Guid programCategoryId4 = Guid.NewGuid();
            Guid programCategoryId5 = Guid.NewGuid();

            Guid organizationId1= Guid.NewGuid();
            Guid organizationId2 = Guid.NewGuid();
            Guid organizationId3 = Guid.NewGuid();
            Guid organizationId4 = Guid.NewGuid();
            Guid organizationId5 = Guid.NewGuid();
            Guid organizationId6 = Guid.NewGuid();
            Guid organizationId7 = Guid.NewGuid();
            Guid organizationId8 = Guid.NewGuid();
            Guid organizationId9 = Guid.NewGuid();
            Guid organizationId10 = Guid.NewGuid();
            Guid organizationId11= Guid.NewGuid();
            Guid organizationId12 = Guid.NewGuid();


            #endregion

            List<PublicSpace> publicSpaces = new()
            #region PublicSpace
            {
                new PublicSpace
                {
                    Id = publicSpace1,
                    Name="utca"
                },
                new PublicSpace
                {
                    Id = publicSpace2,
                    Name="tér"
                },
                new PublicSpace
                {
                    Id = publicSpace3,
                    Name="sugárút"
                },
                new PublicSpace
                {
                    Id = publicSpace4,
                    Name="köz"
                },
            };
            #endregion

            List<ProgramCategory> programCategories = new()
            #region ProgramCategories
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
            #endregion

            List<Organization> organizations = new()
            #region Organizations
            {
                new Organization
                {
                    Id= organizationId1,
                    Name="Gyálaréti Gyuris család",
                    Description="Gyálaréti Gyuris család programnaptára",
                    Url="gyuris.gyalaret.ottleszek.hu"

                },
                new Organization
                {
                    Id= organizationId2,
                    Name="Kikindai Gyuris család",
                    Description="Kikindáról elszármazott Gyuris Család",
                    Url="gyuris.kikinda.ottleszek.hu"
                },
                new Organization
                {
                    Id= organizationId3,
                    Name="Gyálaréti férfi sátor",
                    Description="Gyálaréten működő férfi sátor közösség",
                    Url="ferfisator.filia.gyalaret.ottleszek.hu"
                },
                new Organization
                {
                    Id= organizationId4,
                    Name="Férfi sátor",
                    Description="Magyarorszagi férfi sátor közösség",
                    Url="ferfisator.filia.ottleszek.hu",
                },
                new Organization
                {
                    Id= organizationId5,
                    Name="Gyálaréti meditációs imacsoport",
                    Description="Gyálaréten működő meditációs csoprot amely a Jézus imát gyakorolja",
                    Url="meditacio.filia.gyalaret.ottleszek.hu"
                },                
                new Organization
                {
                    Id= organizationId6,
                    Name="Gyálaréti családcsoport",
                    Description="Gyálaréti filához tartozó csaladcsoport",
                    Url="csaladcsoport.flila.gyalaret.ottleszek.hu"
                },
                new Organization
                {
                    Id= organizationId7,
                    Name="Gyálaréti művelődési ház",
                    Description="Gyálaréti művelődési ház",
                    Url="szeged-gyalaret.muvelodesihaz.ottleszek.hu"
                },
                new Organization
                {
                    Id= organizationId8,
                    Name="Szentmihályi művelődési ház",
                    Description="Szentmihályi művelődési ház",
                    Url="szeged-szentmihaly.muvelodesihaz.ottleszek.hu"
                },
            };
            #endregion

            modelBuilder.Entity<PublicSpace>().HasData(publicSpaces);
            modelBuilder.Entity<ProgramCategory>().HasData(programCategories);
        }
    }
}
