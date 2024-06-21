using WillBeThere.Shared.Models;

namespace WillBeThere.Shared.Helpers.TestData
{
    public static class FullDatabase
    {
        #region Ids
        static Guid publicSpace1 = Guid.NewGuid();
        static Guid publicSpace2 = Guid.NewGuid();
        static Guid publicSpace3 = Guid.NewGuid();
        static Guid publicSpace4 = Guid.NewGuid();
        static Guid publicSpace5 = Guid.NewGuid();

        static Guid addressId1 = Guid.NewGuid();
        static Guid addressId2 = Guid.NewGuid();
        static Guid addressId3 = Guid.NewGuid();
        static Guid addressId4 = Guid.NewGuid();
        static Guid addressId5 = Guid.NewGuid();
        static Guid addressId6 = Guid.NewGuid();

        static Guid organizationCategoryId1 = Guid.NewGuid();
        static Guid organizationCategoryId2 = Guid.NewGuid();
        static Guid organizationCategoryId3 = Guid.NewGuid();
        static Guid organizationCategoryId4 = Guid.NewGuid();
        static Guid organizationCategoryId5 = Guid.NewGuid();
        static Guid organizationCategoryId6 = Guid.NewGuid();

        static Guid organizationId1 = Guid.NewGuid();
        static Guid organizationId2 = Guid.NewGuid();
        static Guid organizationId3 = Guid.NewGuid();
        static Guid organizationId4 = Guid.NewGuid();
        static Guid organizationId5 = Guid.NewGuid();
        static Guid organizationId6 = Guid.NewGuid();
        static Guid organizationId7 = Guid.NewGuid();
        static Guid organizationId8 = Guid.NewGuid();
        static Guid organizationId9 = Guid.NewGuid();
        static Guid organizationId10 = Guid.NewGuid();
        static Guid organizationId11 = Guid.NewGuid();
        static Guid organizationId12 = Guid.NewGuid();

        static Guid registeredUserId1 = Guid.NewGuid();
        static Guid registeredUserId2 = Guid.NewGuid();
        static Guid registeredUserId3 = Guid.NewGuid();
        static Guid registeredUserId4 = Guid.NewGuid();
        static Guid registeredUserId5 = Guid.NewGuid();
        static Guid registeredUserId6 = Guid.NewGuid();

        static Guid organizationAdminUserId1 = Guid.NewGuid();
        static Guid organizationAdminUserId2 = Guid.NewGuid();
        static Guid organizationAdminUserId3 = Guid.NewGuid();
        static Guid organizationAdminUserId4 = Guid.NewGuid();
        static Guid organizationAdminUserId5 = Guid.NewGuid();
        static Guid organizationAdminUserId6 = Guid.NewGuid();

        public static Guid organizationProgramId1 = Guid.NewGuid();
        public static Guid organizationProgramId2 = Guid.NewGuid();
        public static Guid OrganizationProgramId3 = Guid.NewGuid();
        public static Guid OrganizationProgramId4 = Guid.NewGuid();
        public static Guid organizationProgramId5 = Guid.NewGuid();
        public static Guid organizationProgramId6 = Guid.NewGuid();
        public static Guid organizationProgramId7 = Guid.NewGuid();
        public static Guid organizationProgramId8 = Guid.NewGuid();
        public static Guid organizationProgramId9 = Guid.NewGuid();
        public static Guid organizationProgramId10 = Guid.NewGuid();
        public static Guid organizationProgramId11 = Guid.NewGuid();

        static Guid participationId1 = Guid.NewGuid();
        static Guid participationId2 = Guid.NewGuid();
        static Guid participationId3 = Guid.NewGuid();
        static Guid participationId4 = Guid.NewGuid();
        static Guid participationId5 = Guid.NewGuid();
        #endregion

        #region PublicSpace
        public static List<PublicSpace> PublicSpaces = new()
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

        #region Addresses
        public static List<Address> Addresses = new()
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

        #region OrganizationCategies
        public static List<OrganizationCategory> ProgramCategories = new()
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

        #region Organizations
        public static List<Organization> Organizations = new()
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

        #region RegisteredUsers
        public static List<RegisteredUser> RegisteredUsers = new()
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
                new RegisteredUser
                {
                    Id=registeredUserId6,
                    FirstName="Zsuzsanna",
                    LastName="Szabóné",
                },
            };
        #endregion

        #region OrganizationProgram
        public static List<OrganizationProgram> OrganizationPrograms = new()
            {
                #region Public program
                // Egy hónappal ezelőtt
                new OrganizationProgram
                {
                    Id = organizationProgramId1,
                    Start=DateTime.Today.AddMonths(-1).AddDays(5).Add(new TimeSpan(20,30,0)),
                    End=null,
                    Title="Meditáció",
                    Description="Csendes ima.",
                    IsDeffered=false,
                    IsPublic=true,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId5,
                    ProgramOwnerId=organizationAdminUserId4,
                },
                //Egy nappal ezelőtt
                new OrganizationProgram
                {
                    Id = organizationProgramId2,
                    Start=DateTime.Today.AddDays(-1).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.Add(new TimeSpan(12,0,0)),
                    Title="Lelkigyakorlat",
                    Description="Csendes lelkigyakorlat felnőtteknek.",
                    IsDeffered=false,
                    IsPublic=true,
                    AddressId=addressId5,
                    OrganizationOwnerId=organizationId11,
                    ProgramOwnerId=organizationAdminUserId6,
                },
                // Öt nap mulva
                new OrganizationProgram
                {
                    Id = OrganizationProgramId3,
                    Start=DateTime.Today.AddDays(5).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.AddDays(5).Add(new TimeSpan(20,0,0)),
                    Title="Férfi sátor tréning",
                    Description="Apasebek tréning.",
                    IsDeffered=false,
                    IsPublic=true,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId3,
                    ProgramOwnerId=organizationAdminUserId1,
                },
                // Két hónap múlva
                new OrganizationProgram
                {
                    Id = OrganizationProgramId4,
                    Start=DateTime.Today.AddMonths(2).AddDays(15).Add(new TimeSpan(15,0,0)),
                    End=DateTime.Today.AddMonths(2).AddDays(15).Add(new TimeSpan(21,0,0)),
                    Title="Ciklus show",
                    Description="Lányoknak...",
                    IsDeffered=false,
                    IsPublic=true,
                    AddressId=addressId5,
                    OrganizationOwnerId=organizationId9,
                    ProgramOwnerId=organizationAdminUserId3,
                },
                // Épp most
                new OrganizationProgram
                {
                    Id = organizationProgramId5,
                    Start=DateTime.Today.AddHours(-3).Add(new TimeSpan(0,0,0)),
                    End=DateTime.Today.AddHours(2).Add(new TimeSpan(0,30,0)),
                    Title="Táncház",
                    Description="Délalföldi",
                    IsDeffered=false,
                    IsPublic=true,
                    AddressId=addressId3,
                    OrganizationOwnerId=organizationId7,
                    ProgramOwnerId=organizationAdminUserId5,
                },
                #endregion
                // Nem publikius programok
                // Két hónappal ezelőtt
                new OrganizationProgram
                {
                    Id = organizationProgramId6,
                    Start=DateTime.Today.AddMonths(-2).AddDays(5).Add(new TimeSpan(18,0,0)),
                    End=null,
                    Title="Férfi sátor",
                    Description="Férfiaknak",
                    IsDeffered=false,
                    IsPublic=false,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId4,
                    ProgramOwnerId=organizationAdminUserId1,
                },
                // Egy hónappal ezelőtt
                new OrganizationProgram
                {
                    Id = organizationProgramId7,
                    Start=DateTime.Today.AddMonths(-1).AddDays(1).Add(new TimeSpan(18,0,0)),
                    End=null,
                    Title="Férfi sátor",
                    Description="Férfiaknak",
                    IsDeffered=false,
                    IsPublic=false,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId4,
                    ProgramOwnerId=organizationAdminUserId1,
                },
                // Egy hét múlva
                new OrganizationProgram
                {
                    Id = organizationProgramId8,
                    Start=DateTime.Today.AddDays(7).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.AddDays(7).Add(new TimeSpan(21,0,0)),
                    Title="Férfi sátor",
                    Description="Férfiaknak",
                    IsDeffered=false,
                    IsPublic=false,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId4,
                    ProgramOwnerId=organizationAdminUserId1,
                },
                // Éppen most
                new OrganizationProgram
                {
                    Id = organizationProgramId9,
                    Start=DateTime.Today.AddHours(-3).Add(new TimeSpan(0,0,0)),
                    End=DateTime.Today.AddHours(1).Add(new TimeSpan(0,30,0)),
                    Title="Családcsoport",
                    Description="Családoknak",
                    IsDeffered=false,
                    IsPublic=false,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId6,
                    ProgramOwnerId=organizationAdminUserId6,
                },
                // Elhalasztott publikus
                new OrganizationProgram
                {
                    Id = organizationProgramId10,
                    Start=DateTime.Today.AddDays(20).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.AddDays(20).Add(new TimeSpan(20,0,0)),
                    Title="Férfi sátor tréning",
                    Description="Apasebek tréning.",
                    IsDeffered=true,
                    IsPublic=true,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId3,
                    ProgramOwnerId=organizationAdminUserId1,
                },
                // Elhalasztott nem publikus
                new OrganizationProgram
                {
                    Id = organizationProgramId11,
                    Start=DateTime.Today.AddDays(10).Add(new TimeSpan(18,0,0)),
                    End=DateTime.Today.AddDays(10).Add(new TimeSpan(21,0,0)),
                    Title="Férfi sátor",
                    Description="Férfiaknak",
                    IsDeffered=true,
                    IsPublic=false,
                    AddressId=addressId2,
                    OrganizationOwnerId=organizationId4,
                    ProgramOwnerId=organizationAdminUserId1,
                },
            };
        #endregion

        #region OrganizationAdminUsers
        public static List<OrganizationAdminUser> OrganizationAdminUsers = new()
            {
                new OrganizationAdminUser
                {
                    // Gyálaréti Fréfi sátor - Jenei Kornél
                    Id = organizationAdminUserId1,
                    OrganizationId = organizationId3,
                    AdminId = registeredUserId4,
                },
                new OrganizationAdminUser
                {
                    // Magyarországi Férfi sátor
                    Id=organizationAdminUserId2,
                    OrganizationId=organizationId4,
                    AdminId = registeredUserId4,
                },
                new OrganizationAdminUser
                {
                    // Családpaszoráció - Gyurisné Hutter Katalin
                    Id=organizationAdminUserId3,
                    OrganizationId=organizationId10,
                    AdminId = registeredUserId3,
                },
                new OrganizationAdminUser
                {
                    // Gyálaréti meditációs csoport - Szászi Balázs
                    Id=organizationAdminUserId4,
                    OrganizationId=organizationId5,
                    AdminId = registeredUserId3,
                },
                new OrganizationAdminUser
                {
                    // Gyálaréti művelődési ház - Jenei Kornél
                    Id = organizationAdminUserId5,
                    OrganizationId = organizationId7,
                    AdminId = registeredUserId4,
                },
                new OrganizationAdminUser
                {
                    // Családcsoport - Szabóné Zsuzsa
                    Id = organizationAdminUserId6,
                    OrganizationId = organizationId6,
                    AdminId = registeredUserId6,
                },

            };
        #endregion

        #region Participations
        public static List<Participation> Participations = new()
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
                    OrganizationProgramId=OrganizationProgramId3,
                    RegisteredUserId=registeredUserId3,
                },
            };
        #endregion
    }
}
