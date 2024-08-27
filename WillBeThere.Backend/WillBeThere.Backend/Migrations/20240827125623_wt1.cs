using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WillBeThere.Backend.Migrations
{
    /// <inheritdoc />
    public partial class wt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationCategory", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicSpace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSpace", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegisteredUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUser", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false),
                    Website = table.Column<string>(type: "longtext", nullable: false),
                    OrganizationCategoryId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_OrganizationCategory_OrganizationCategoryId",
                        column: x => x.OrganizationCategoryId,
                        principalTable: "OrganizationCategory",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    PublicScapeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PublicSpaceName = table.Column<string>(type: "longtext", nullable: false),
                    Locality = table.Column<string>(type: "longtext", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Door = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_PublicSpace_PublicScapeId",
                        column: x => x.PublicScapeId,
                        principalTable: "PublicSpace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationAdminUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AdminId = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationId1 = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAdminUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAdminUser_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationAdminUser_Organization_OrganizationId1",
                        column: x => x.OrganizationId1,
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationAdminUser_RegisteredUser_AdminId",
                        column: x => x.AdminId,
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrgranizationProgram",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeffered = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrganizationOwnerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ProgramOwnerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgranizationProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgranizationProgram_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrgranizationProgram_OrganizationAdminUser_OrganizationOwner~",
                        column: x => x.OrganizationOwnerId,
                        principalTable: "OrganizationAdminUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgranizationProgram_Organization_OrganizationOwnerId",
                        column: x => x.OrganizationOwnerId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RegisteredUserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationProgramId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Evaluation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participation_OrgranizationProgram_OrganizationProgramId",
                        column: x => x.OrganizationProgramId,
                        principalTable: "OrgranizationProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participation_RegisteredUser_RegisteredUserId",
                        column: x => x.RegisteredUserId,
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "Description", "Name", "OrganizationCategoryId", "Url", "Website" },
                values: new object[,]
                {
                    { new Guid("040d98bb-febb-4678-a6e5-aa25056c1ad7"), "Gyálaréti Gyuris család programnaptára", "Gyálaréti Gyuris család", null, "gyuris.gyalaret.ottleszek.hu", "" },
                    { new Guid("af1b2a4c-cfa4-4954-85e2-f51bf40df9c9"), "Kikindáról elszármazott Gyuris Család", "Kikindai Gyuris család", null, "gyuris.kikinda.ottleszek.hu", "" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("285caea5-9bdf-4686-92d6-21d52716c01c"), "művelődés" },
                    { new Guid("52f9efbf-1831-416f-9a85-b318daf6eac6"), "házasság" },
                    { new Guid("6f100476-a6eb-4e11-8f53-f9fa90227829"), "ifjúság" },
                    { new Guid("773239aa-a499-478a-baf6-29ff5091dd54"), "vallás" },
                    { new Guid("9d6c9520-cce8-4bb8-bab0-a53cb44c2b12"), "férfi identitás" },
                    { new Guid("bb92e05b-f13b-42bb-83fe-4fb3670aeab7"), "nevelés" }
                });

            migrationBuilder.InsertData(
                table: "PublicSpace",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5ddedfac-4be9-4f68-aa5f-de047ec8c7da"), "utca" },
                    { new Guid("6c57cf20-2c5e-4317-b302-9e0d5dec7f5b"), "köz" },
                    { new Guid("a2223b11-620c-46d2-84ab-fe3ff3c911f8"), "sugárút" },
                    { new Guid("b246ee2f-9832-4101-a482-793edb873dbc"), "út" },
                    { new Guid("c2168001-7620-476d-bfee-21992ef29900"), "tér" }
                });

            migrationBuilder.InsertData(
                table: "RegisteredUser",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("56f06676-61a1-4051-b64c-aa08297f4d5d"), "Csaba", "Gyuris" },
                    { new Guid("7a7f25c9-dc60-4687-b9fc-c1ce3dca0e4c"), "Anikó", "Szászi" },
                    { new Guid("be338220-cf5a-4a2b-af3e-a067e665e01f"), "Zsuzsanna", "Szabóné" },
                    { new Guid("ca005c1a-d39e-4454-9c3d-9f311a28d0ee"), "Balázs", "Szászi" },
                    { new Guid("e7f454a0-790f-42b9-8941-87bb81c7d64c"), "Katalin", "Gyurisné Hutter" },
                    { new Guid("fae831a1-49d5-4383-b99a-3f30cbe590cc"), "Jenei", "Kornél" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "Door", "Floor", "House", "Locality", "PostalCode", "PublicScapeId", "PublicSpaceName" },
                values: new object[,]
                {
                    { new Guid("1e1f7336-023b-4875-aa7a-ef4ded39bf9d"), -1, -1, 50, "Szeged", 6710, new Guid("6c57cf20-2c5e-4317-b302-9e0d5dec7f5b"), "Kapisztrán" },
                    { new Guid("27f280a3-dc44-4063-9a6d-2aa0d52366b2"), -1, -1, 12, "Szeged", 6720, new Guid("c2168001-7620-476d-bfee-21992ef29900"), "Dugonics" },
                    { new Guid("8b790354-8119-460a-b553-71e49648c5c8"), -1, -1, 33, "Szeged", 6757, new Guid("5ddedfac-4be9-4f68-aa5f-de047ec8c7da"), "Koszorú utca" },
                    { new Guid("d16fc281-4643-4248-87a3-309daff0cf12"), -1, -1, 1, "Szeged", 6757, new Guid("5ddedfac-4be9-4f68-aa5f-de047ec8c7da"), "Napraforgó utca" },
                    { new Guid("daba959d-3db1-40d6-b381-b07cf2dcf399"), -1, -1, 49, "Szeged", 6757, new Guid("5ddedfac-4be9-4f68-aa5f-de047ec8c7da"), "Koszorú utca" }
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "Description", "Name", "OrganizationCategoryId", "Url", "Website" },
                values: new object[,]
                {
                    { new Guid("1026f88c-41fd-474b-adbb-394d1834c5da"), "Gyálaréti filához tartozó csaladcsoport", "Gyálaréti családcsoport", new Guid("773239aa-a499-478a-baf6-29ff5091dd54"), "csaladcsoport.flila.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("348770fe-e026-4aae-bb91-08129b3c26ff"), "Munkásmisszió, vezetői kör", "Munkáasmisszió", new Guid("773239aa-a499-478a-baf6-29ff5091dd54"), "vezetok.munkasmisszio.ottleszek.hu", "" },
                    { new Guid("44bd17ff-e349-4314-af43-1cf630605048"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", new Guid("773239aa-a499-478a-baf6-29ff5091dd54"), "korhazi-lelekszseg.pasztoralis-helynokseg.szeged-csanádi - egyhazmegye.ottleszek.hu", "" },
                    { new Guid("4affe914-9898-436c-b4dc-e4341af28bb6"), "Szeged-Csanád Egyházmegye Pasztorális helynöksége", "Szeged-Csanád Egyházmegye Pasztorális helynökség", new Guid("773239aa-a499-478a-baf6-29ff5091dd54"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("7775f90e-7554-499c-894f-e9f3dd802f3d"), "Magyarorszagi férfi sátor közösség", "Férfi sátor", new Guid("9d6c9520-cce8-4bb8-bab0-a53cb44c2b12"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("810ca225-66ae-4b28-b7aa-6b927d688b2a"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció, ", "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció", new Guid("773239aa-a499-478a-baf6-29ff5091dd54"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("9a3453f4-1e98-4bc6-8e79-77369ddc41e0"), "Szentmihályi művelődési ház", "Szentmihályi művelődési ház", new Guid("285caea5-9bdf-4686-92d6-21d52716c01c"), "muvelodesihaz.szeged-szentmihaly.ottleszek.hu", "" },
                    { new Guid("b4f997ae-41ea-4d69-9c9f-17042257d438"), "Gyálaréten működő meditációs csoprot amely a Jézus imát gyakorolja", "Gyálaréti meditációs imacsoport", new Guid("773239aa-a499-478a-baf6-29ff5091dd54"), "meditacio.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("ccfac23e-c28a-453a-970c-68c2f1e8a530"), "Gyálaréten működő férfi sátor közösség", "Gyálaréti férfi sátor", new Guid("9d6c9520-cce8-4bb8-bab0-a53cb44c2b12"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("d86887a2-b2f2-4433-b260-7bb81135f0e6"), "Gyálaréti művelődési ház", "Gyálaréti művelődési ház", new Guid("285caea5-9bdf-4686-92d6-21d52716c01c"), "szeged-gyalaret.szeged-gyalaret.ottleszek.hu", "" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationAdminUser",
                columns: new[] { "Id", "AdminId", "OrganizationId", "OrganizationId1" },
                values: new object[,]
                {
                    { new Guid("1a72dfab-75d5-46e1-9396-f46a6d62dbd5"), new Guid("fae831a1-49d5-4383-b99a-3f30cbe590cc"), new Guid("ccfac23e-c28a-453a-970c-68c2f1e8a530"), null },
                    { new Guid("204f931e-d0e2-4e68-aaf3-fe0cf4666972"), new Guid("fae831a1-49d5-4383-b99a-3f30cbe590cc"), new Guid("d86887a2-b2f2-4433-b260-7bb81135f0e6"), null },
                    { new Guid("27e18359-c00e-4d00-b133-88bba17073cc"), new Guid("e7f454a0-790f-42b9-8941-87bb81c7d64c"), new Guid("810ca225-66ae-4b28-b7aa-6b927d688b2a"), null },
                    { new Guid("33e1b05d-05e4-43c5-93da-8660f415455e"), new Guid("fae831a1-49d5-4383-b99a-3f30cbe590cc"), new Guid("7775f90e-7554-499c-894f-e9f3dd802f3d"), null },
                    { new Guid("cad700ff-782e-4541-b103-a66e05dfba7b"), new Guid("e7f454a0-790f-42b9-8941-87bb81c7d64c"), new Guid("b4f997ae-41ea-4d69-9c9f-17042257d438"), null },
                    { new Guid("e86814dd-5c1f-40ff-bbb9-feaa32767eea"), new Guid("be338220-cf5a-4a2b-af3e-a067e665e01f"), new Guid("1026f88c-41fd-474b-adbb-394d1834c5da"), null }
                });

            migrationBuilder.InsertData(
                table: "OrgranizationProgram",
                columns: new[] { "Id", "AddressId", "Description", "End", "IsDeffered", "IsPublic", "OrganizationOwnerId", "ProgramOwnerId", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("457899d7-4c68-4c7f-9944-45589c87f3df"), new Guid("daba959d-3db1-40d6-b381-b07cf2dcf399"), "Férfiaknak", null, false, false, new Guid("7775f90e-7554-499c-894f-e9f3dd802f3d"), new Guid("1a72dfab-75d5-46e1-9396-f46a6d62dbd5"), new DateTime(2024, 7, 2, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("6db6b90e-63eb-4443-91ff-12c685aa971b"), new Guid("daba959d-3db1-40d6-b381-b07cf2dcf399"), "Apasebek tréning.", new DateTime(2024, 9, 16, 20, 0, 0, 0, DateTimeKind.Local), true, true, new Guid("ccfac23e-c28a-453a-970c-68c2f1e8a530"), new Guid("33e1b05d-05e4-43c5-93da-8660f415455e"), new DateTime(2024, 9, 16, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" },
                    { new Guid("739efdcd-2dbd-4617-afe5-69529d740bd1"), new Guid("8b790354-8119-460a-b553-71e49648c5c8"), "Délalföldi", new DateTime(2024, 8, 27, 2, 30, 0, 0, DateTimeKind.Local), false, true, new Guid("d86887a2-b2f2-4433-b260-7bb81135f0e6"), new Guid("204f931e-d0e2-4e68-aaf3-fe0cf4666972"), new DateTime(2024, 8, 26, 21, 0, 0, 0, DateTimeKind.Local), "Táncház" },
                    { new Guid("7e598d28-848b-45af-9048-7bdbfbfdd9a0"), new Guid("daba959d-3db1-40d6-b381-b07cf2dcf399"), "Csendes ima.", null, false, true, new Guid("b4f997ae-41ea-4d69-9c9f-17042257d438"), new Guid("cad700ff-782e-4541-b103-a66e05dfba7b"), new DateTime(2024, 8, 1, 20, 30, 0, 0, DateTimeKind.Local), "Meditáció" },
                    { new Guid("8ac055c3-2cd4-4810-883d-8524d6a876c7"), new Guid("daba959d-3db1-40d6-b381-b07cf2dcf399"), "Férfiaknak", null, false, false, new Guid("7775f90e-7554-499c-894f-e9f3dd802f3d"), new Guid("1a72dfab-75d5-46e1-9396-f46a6d62dbd5"), new DateTime(2024, 7, 28, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("a1b8daff-6603-4ab4-94c3-6248fb262db9"), new Guid("daba959d-3db1-40d6-b381-b07cf2dcf399"), "Férfiaknak", new DateTime(2024, 9, 3, 21, 0, 0, 0, DateTimeKind.Local), false, false, new Guid("7775f90e-7554-499c-894f-e9f3dd802f3d"), new Guid("1a72dfab-75d5-46e1-9396-f46a6d62dbd5"), new DateTime(2024, 9, 3, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("a9c96df7-44e8-4cc6-bf5f-e4547314475c"), new Guid("daba959d-3db1-40d6-b381-b07cf2dcf399"), "Családoknak", new DateTime(2024, 8, 27, 1, 30, 0, 0, DateTimeKind.Local), false, false, new Guid("1026f88c-41fd-474b-adbb-394d1834c5da"), new Guid("e86814dd-5c1f-40ff-bbb9-feaa32767eea"), new DateTime(2024, 8, 26, 21, 0, 0, 0, DateTimeKind.Local), "Családcsoport" },
                    { new Guid("bc268fe5-c467-4958-b7cc-8d68163b0681"), new Guid("daba959d-3db1-40d6-b381-b07cf2dcf399"), "Apasebek tréning.", new DateTime(2024, 9, 1, 20, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("ccfac23e-c28a-453a-970c-68c2f1e8a530"), new Guid("1a72dfab-75d5-46e1-9396-f46a6d62dbd5"), new DateTime(2024, 9, 1, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" },
                    { new Guid("c1cab8a9-ca4d-4b32-89d4-b3a4d3cc4374"), new Guid("daba959d-3db1-40d6-b381-b07cf2dcf399"), "Férfiaknak", new DateTime(2024, 9, 6, 21, 0, 0, 0, DateTimeKind.Local), true, false, new Guid("7775f90e-7554-499c-894f-e9f3dd802f3d"), new Guid("1a72dfab-75d5-46e1-9396-f46a6d62dbd5"), new DateTime(2024, 9, 6, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("c5dc6c60-2b1f-4906-b9d4-6f8636ac2257"), new Guid("27f280a3-dc44-4063-9a6d-2aa0d52366b2"), "Csendes lelkigyakorlat felnőtteknek.", new DateTime(2024, 8, 27, 12, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("44bd17ff-e349-4314-af43-1cf630605048"), new Guid("e86814dd-5c1f-40ff-bbb9-feaa32767eea"), new DateTime(2024, 8, 26, 18, 0, 0, 0, DateTimeKind.Local), "Lelkigyakorlat" },
                    { new Guid("e096e163-dabb-407f-9c42-dfba97b609fa"), new Guid("27f280a3-dc44-4063-9a6d-2aa0d52366b2"), "Lányoknak...", new DateTime(2024, 11, 11, 21, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("4affe914-9898-436c-b4dc-e4341af28bb6"), new Guid("27e18359-c00e-4d00-b133-88bba17073cc"), new DateTime(2024, 11, 11, 15, 0, 0, 0, DateTimeKind.Local), "Ciklus show" }
                });

            migrationBuilder.InsertData(
                table: "Participation",
                columns: new[] { "Id", "Evaluation", "OrganizationProgramId", "RegisteredUserId" },
                values: new object[,]
                {
                    { new Guid("28caac82-81ee-4126-8852-1c3401114712"), -1, new Guid("c5dc6c60-2b1f-4906-b9d4-6f8636ac2257"), new Guid("ca005c1a-d39e-4454-9c3d-9f311a28d0ee") },
                    { new Guid("73d7e9db-0640-4968-83b8-14ed5c78df6d"), -1, new Guid("bc268fe5-c467-4958-b7cc-8d68163b0681"), new Guid("e7f454a0-790f-42b9-8941-87bb81c7d64c") },
                    { new Guid("93371a3d-9580-4634-9726-5249cd28bbd0"), 9, new Guid("7e598d28-848b-45af-9048-7bdbfbfdd9a0"), new Guid("56f06676-61a1-4051-b64c-aa08297f4d5d") },
                    { new Guid("df1b2af6-14d3-40a0-ae95-3f658054c0c0"), 9, new Guid("7e598d28-848b-45af-9048-7bdbfbfdd9a0"), new Guid("ca005c1a-d39e-4454-9c3d-9f311a28d0ee") },
                    { new Guid("ef347c4d-12d2-4217-b7ec-4e9f75ad757b"), -1, new Guid("c5dc6c60-2b1f-4906-b9d4-6f8636ac2257"), new Guid("e7f454a0-790f-42b9-8941-87bb81c7d64c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PublicScapeId",
                table: "Address",
                column: "PublicScapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_OrganizationCategoryId",
                table: "Organization",
                column: "OrganizationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAdminUser_AdminId",
                table: "OrganizationAdminUser",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAdminUser_OrganizationId",
                table: "OrganizationAdminUser",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAdminUser_OrganizationId1",
                table: "OrganizationAdminUser",
                column: "OrganizationId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrgranizationProgram_AddressId",
                table: "OrgranizationProgram",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgranizationProgram_OrganizationOwnerId",
                table: "OrgranizationProgram",
                column: "OrganizationOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_OrganizationProgramId",
                table: "Participation",
                column: "OrganizationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_RegisteredUserId",
                table: "Participation",
                column: "RegisteredUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "OrgranizationProgram");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "OrganizationAdminUser");

            migrationBuilder.DropTable(
                name: "PublicSpace");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "RegisteredUser");

            migrationBuilder.DropTable(
                name: "OrganizationCategory");
        }
    }
}
