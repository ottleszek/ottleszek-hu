using Microsoft.EntityFrameworkCore;
using System.Data;
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
            Guid publicSpace5 = Guid.NewGuid();

            Guid addressId1 = Guid.NewGuid();
            Guid addressId2 = Guid.NewGuid();
            Guid addressId3 = Guid.NewGuid();
            Guid addressId4 = Guid.NewGuid();
            Guid addressId5 = Guid.NewGuid();
            Guid addressId6 = Guid.NewGuid();

            Guid organizationCategoryId1 = Guid.NewGuid();
            Guid organizationCategoryId2 = Guid.NewGuid();
            Guid organizationCategoryId3 = Guid.NewGuid();
            Guid organizationCategoryId4 = Guid.NewGuid();
            Guid organizationCategoryId5 = Guid.NewGuid();
            Guid organizationCategoryId6 = Guid.NewGuid();

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

            Guid OrganizationProgramCategoryId1 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId2 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId3 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId4 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId5 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId6 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId7 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId8 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId9 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId10 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId11 = Guid.NewGuid();
            Guid OrganizationProgramCategoryId12 = Guid.NewGuid();

            Guid registeredUserId1 = Guid.NewGuid();
            Guid registeredUserId2 = Guid.NewGuid();
            Guid registeredUserId3 = Guid.NewGuid();
            Guid registeredUserId4 = Guid.NewGuid();
            Guid registeredUserId5 = Guid.NewGuid();

            Guid organizationAdminUserId1=Guid.NewGuid();
            Guid organizationAdminUserId2 = Guid.NewGuid();
            Guid organizationAdminUserId3 = Guid.NewGuid();
            Guid organizationAdminUserId4 = Guid.NewGuid();

            Guid organizationProgramId1 = Guid.NewGuid();
            Guid organizationProgramId2 = Guid.NewGuid();
            Guid organizationProgramId3 = Guid.NewGuid();
            Guid organizationProgramId4 = Guid.NewGuid();

            Guid participationId1= Guid.NewGuid();
            Guid participationId2 = Guid.NewGuid();
            Guid participationId3 = Guid.NewGuid();
            Guid participationId4 = Guid.NewGuid();
            Guid participationId5 = Guid.NewGuid();            
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
                new PublicSpace
                {
                    Id = publicSpace5,
                    Name="út"
                },
            };
            #endregion

            List<Address> addresses = new()
            #region Addresses
            {
                new Address
                {
                    Id =addressId1,
                    PostalCode=6757,
                    Locality="Szeged",
                    PublicScapeID=publicSpace1,
                    PublicSpaceName = "Napraforgó utca",
                    House=1,
                },
                new Address
                {
                    Id =addressId2,
                    PostalCode=6757,
                    Locality="Szeged",
                    PublicScapeID=publicSpace1,
                    PublicSpaceName = "Koszorú utca",
                    House=49,
                },
                new Address
                {
                    Id =addressId3,
                    PostalCode=6757,
                    Locality="Szeged",
                    PublicScapeID=publicSpace1,
                    PublicSpaceName = "Koszorú utca",
                    House=33,
                },
                new Address
                {
                    Id =addressId4,
                    PostalCode=6710,
                    Locality="Szeged",
                    PublicScapeID=publicSpace4,
                    PublicSpaceName = "Kapisztrán",
                    House=50,
                },
                new Address
                {
                    Id =addressId5,
                    PostalCode=6720,
                    Locality="Szeged",
                    PublicScapeID=publicSpace2,
                    PublicSpaceName = "Dugonics",
                    House=12,
                },
            };
            #endregion

            List<OrganizationCategory> programCategories = new()
            #region OrganizationCategies
            {
                new OrganizationCategory
                {
                    Id = organizationCategoryId1,
                    Name="vallás"
                },
                new OrganizationCategory
                {
                    Id = organizationCategoryId2,
                    Name="nevelés"
                },
                new OrganizationCategory
                {
                    Id = organizationCategoryId3,
                    Name="házasság"
                },
                new OrganizationCategory
                {
                    Id = organizationCategoryId4,
                    Name="férfi identitás"
                },
                new OrganizationCategory
                {
                    Id = organizationCategoryId5,
                    Name="ifjúság"
                },
                new OrganizationCategory
                {
                    Id = organizationCategoryId6,
                    Name="művelődés"
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
                    Url="gyuris.gyalaret.ottleszek.hu",
                    OrganizationCategoryId=null,                   
                },
                new Organization
                {
                    Id= organizationId2,
                    Name="Kikindai Gyuris család",
                    Description="Kikindáról elszármazott Gyuris Család",
                    Url="gyuris.kikinda.ottleszek.hu",
                    OrganizationCategoryId=null,
                },
                new Organization
                {
                    Id= organizationId3,
                    Name="Gyálaréti férfi sátor",
                    Description="Gyálaréten működő férfi sátor közösség",
                    Url="ferfisator.filia.szeged-gyalaret.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId4,
                },
                new Organization
                {
                    Id= organizationId4,
                    Name="Férfi sátor",
                    Description="Magyarorszagi férfi sátor közösség",
                    Url="ferfisator.filia.szeged-gyalaret.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId4,
                },
                new Organization
                {
                    Id= organizationId5,
                    Name="Gyálaréti meditációs imacsoport",
                    Description="Gyálaréten működő meditációs csoprot amely a Jézus imát gyakorolja",
                    Url="meditacio.filia.szeged-gyalaret.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId1,
                },                
                new Organization
                {
                    Id= organizationId6,
                    Name="Gyálaréti családcsoport",
                    Description="Gyálaréti filához tartozó csaladcsoport",
                    Url="csaladcsoport.flila.szeged-gyalaret.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId1,
                },
                new Organization
                {
                    Id= organizationId7,
                    Name="Gyálaréti művelődési ház",
                    Description="Gyálaréti művelődési ház",
                    Url="szeged-gyalaret.szeged-gyalaret.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId6,
                },
                new Organization
                {
                    Id= organizationId8,
                    Name="Szentmihályi művelődési ház",
                    Description="Szentmihályi művelődési ház",
                    Url="muvelodesihaz.szeged-szentmihaly.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId6,
                },
                new Organization
                {
                    Id= organizationId9,
                    Name="Szeged-Csanád egyházmegye Pasztorális helynökség",
                    Description="Szeged-Csanád egyházmegye Pasztorális helynöksége",
                    Url="pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId1,
                },
                new Organization
                {
                    Id= organizationId10,
                    Name="Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció",
                    Description="Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció, ",
                    Url="pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId1,
                },
                new Organization
                {
                    Id= organizationId11,
                    Name="Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség",
                    Description="Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség",
                    Url="korhazi-lelekszseg.pasztoralis-helynokseg.szeged-csanádi - egyhazmegye.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId1,
                },
                new Organization
                {
                    Id= organizationId12,
                    Name="Munkáasmisszió",
                    Description="Munkásmisszió, vezetői kör",
                    Url="vezetok.munkasmisszio.ottleszek.hu",
                    OrganizationCategoryId=organizationCategoryId1,
                },
            };
            #endregion

            List<RegisteredUser> registeredUsers = new()
            #region RegisteredUsers
            {
                new RegisteredUser 
                {
                    Id=registeredUserId1,
                    FirstName="Csaba",
                    LastName="Gyuris",                    
                },
                new RegisteredUser
                {
                    Id=registeredUserId2,
                    FirstName="Balázs",
                    LastName="Szászi",
                },
                new RegisteredUser
                {
                    Id=registeredUserId3,
                    FirstName="Katalin",
                    LastName="Gyurisné Hutter",
                },
                
                new RegisteredUser
                {
                    Id=registeredUserId4,
                    FirstName="Jenei",
                    LastName="Kornél",
                },                
                new RegisteredUser
                {
                    Id=registeredUserId5,
                    FirstName="Anikó",
                    LastName="Szászi",
                },
            };
            #endregion

            List<OrganizationProgram> organizationPrograms = new()
            #region OrganizationProgram
            {
                new OrganizationProgram
                {
                    Id = organizationProgramId1,
                    Start=DateTime.Today.AddMonths(-1).AddDays(5).Add(new TimeSpan(20,30,0)),
                    End=null,
                    Title="Meditáció",
                    IsDeffered=false,
                    IsPublic=true,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId5,
                    ProgramOwnerId=organizationAdminUserId1,                                        
                },
                new OrganizationProgram
                {
                    Id = organizationProgramId2,
                    Start=DateTime.Today.AddDays(-1).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.Add(new TimeSpan(12,0,0)),
                    Title="Lelkigyakorlat",
                    IsDeffered=false,
                    IsPublic=true,
                    AddressId=addressId5,
                    OrganizationOwnerId=organizationId11,
                    ProgramOwnerId=organizationAdminUserId2,
                },
                new OrganizationProgram
                {
                    Id = organizationProgramId3,
                    Start=DateTime.Today.AddDays(5).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.AddDays(5).Add(new TimeSpan(20,0,0)),
                    Title="Férfi sátor tréning",
                    IsDeffered=false,
                    IsPublic=true,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId3,
                    ProgramOwnerId=organizationAdminUserId3,
                },
            };
            #endregion

            List<OrganizationAdminUser> organizationAdminUsers = new()
            #region OrganizationAdminUsers
            {
                new OrganizationAdminUser
                {
                    Id=organizationAdminUserId1,
                    OrganizationId=organizationId11,
                    AdminId = registeredUserId2,
                },
                new OrganizationAdminUser
                {
                    Id=organizationAdminUserId2,
                    OrganizationId=organizationId5,
                    AdminId = registeredUserId3,
                },
                new OrganizationAdminUser
                {
                    Id=organizationAdminUserId3,
                    OrganizationId=organizationId4,
                    AdminId = registeredUserId1,
                },
            };
            #endregion

            List<Participation> participations = new()
            #region Participations
            {
                new Participation
                {
                    Id=participationId1,
                    OrganizationProgramId=organizationProgramId1,
                    RegisteredUserId=registeredUserId1,
                    Evaluation=9,
                },
                new Participation
                {
                    Id=participationId2,
                    OrganizationProgramId=organizationProgramId1,
                    RegisteredUserId=registeredUserId2,
                    Evaluation=9,
                },
                new Participation
                {
                    Id=participationId3,
                    OrganizationProgramId=organizationProgramId2,
                    RegisteredUserId=registeredUserId3,
                },
                new Participation
                {
                    Id=participationId4,
                    OrganizationProgramId=organizationProgramId2,
                    RegisteredUserId=registeredUserId2,
                },
                new Participation
                {
                    Id=participationId5,
                    OrganizationProgramId=organizationProgramId3,
                    RegisteredUserId=registeredUserId3,
                },
            };
            #endregion

            modelBuilder.Entity<PublicSpace>().HasData(publicSpaces);
            modelBuilder.Entity<Address>().HasData(addresses);
            modelBuilder.Entity<OrganizationCategory>().HasData(programCategories);
            modelBuilder.Entity<Organization>().HasData(organizations);
            modelBuilder.Entity<RegisteredUser>().HasData(registeredUsers);
            modelBuilder.Entity<OrganizationAdminUser>().HasData(organizationAdminUsers);
            modelBuilder.Entity<OrganizationProgram>().HasData(organizationPrograms);
            modelBuilder.Entity<Participation>().HasData(participations);
        }
    }
}
