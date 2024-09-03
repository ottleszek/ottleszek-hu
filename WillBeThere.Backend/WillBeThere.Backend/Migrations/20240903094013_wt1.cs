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
                name: "ProgramCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCategory", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicSpace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
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
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
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
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false),
                    Website = table.Column<string>(type: "longtext", nullable: false),
                    OrganizationCategoryId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_ProgramCategory_OrganizationCategoryId",
                        column: x => x.OrganizationCategoryId,
                        principalTable: "ProgramCategory",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    PublicScapeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PublicSpaceName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Locality = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
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
                name: "Editor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Editor_RegisteredUser_Id",
                        column: x => x.Id,
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
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeffered = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ProgramOwnerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgranizationProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgranizationProgram_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgranizationProgram_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationEditor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EditorId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationEditor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationEditor_Editor_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationEditor_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProgramOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramOwner_Editor_Id",
                        column: x => x.Id,
                        principalTable: "Editor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "char(36)", nullable: false),
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
                        name: "FK_Participation_RegisteredUser_ParticipantId",
                        column: x => x.ParticipantId,
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
                    { new Guid("0d27f57c-04f4-4f39-8d96-97f738eb4d95"), "Gyálaréti Gyuris család programnaptára", "Gyálaréti Gyuris család", null, "gyuris-gyalaret", "" },
                    { new Guid("ded5eff7-a465-4d32-bcbf-a4e2f21ed100"), "Kikindáról elszármazott Gyuris Család", "Kikindai Gyuris család", null, "gyuris-kikinda", "" }
                });

            migrationBuilder.InsertData(
                table: "ProgramCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("02a57923-f857-4fd6-90fe-2b21fc7be918"), "vallás" },
                    { new Guid("6ef25418-d306-4f71-8105-e0e22680dd46"), "férfi identitás" },
                    { new Guid("8fc45db0-5c9a-4bb2-8605-1f03177352f1"), "nevelés" },
                    { new Guid("9421f6d4-cb9d-4989-9617-ce51ee897d95"), "művelődés" },
                    { new Guid("945e70af-6620-4d1a-8840-a235ad1ca23a"), "ifjúság" },
                    { new Guid("f0847104-3402-4ef0-a1d9-692d18005e7c"), "házasság" }
                });

            migrationBuilder.InsertData(
                table: "PublicSpace",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17682174-b7a6-4313-9654-7357762b1f98"), "út" },
                    { new Guid("832bb42d-9da0-411b-a29e-abf0c2f7b8d3"), "utca" },
                    { new Guid("af3fe631-6c0f-452d-b185-508abe514b35"), "köz" },
                    { new Guid("d9824104-2006-480c-bb9e-105b50bb68f4"), "tér" },
                    { new Guid("ebe47883-b5ba-449c-9085-6c7f3f95e5c2"), "sugárút" }
                });

            migrationBuilder.InsertData(
                table: "RegisteredUser",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("0d13af0d-a040-484d-833b-e9c15e841073"), "Csaba", "Gyuris" },
                    { new Guid("0f9cc30e-21e8-4316-b3f1-7a361c49754e"), "Név13", "Felhasználó" },
                    { new Guid("110d7c48-92a1-4e34-aa77-de30f9008d68"), "Anikó", "Szászi" },
                    { new Guid("25b003a6-23bf-41bc-8baa-80e46f416c7d"), "Név10", "Felhasználó" },
                    { new Guid("3f35105b-cc00-4305-a232-1687c6a0f65a"), "Zsuzsanna", "Szabóné" },
                    { new Guid("5e816088-47dc-46cf-b79b-f8618c826ef5"), "Név15", "Felhasználó" },
                    { new Guid("7bb4beb2-1d9e-4e0c-87fb-d7af8db83e00"), "Balázs", "Szászi" },
                    { new Guid("95955821-1b20-4606-8133-7951c0733d25"), "Katalin", "Gyurisné Hutter" },
                    { new Guid("ba6bc4da-5da4-46a4-8413-2fca1e786bc0"), "Jenei", "Kornél" },
                    { new Guid("c27b5d01-5b9b-4a35-aedc-144fbeb2e15a"), "Név10", "Felhasznál1" },
                    { new Guid("d0c6960d-48d4-4a70-a277-f69a976c3980"), "Név12", "Felhasználó" },
                    { new Guid("e55e39dd-a519-44de-a45e-51f1a4a244f0"), "Név16", "Felhasználó" },
                    { new Guid("eb6b4fca-d482-4e38-8e4e-d4259a16672d"), "Név14", "Felhasználó" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "Door", "Floor", "House", "Locality", "PostalCode", "PublicScapeId", "PublicSpaceName" },
                values: new object[,]
                {
                    { new Guid("2a0edd05-858f-481e-a7ce-5527e83e2e14"), -1, -1, 1, "Szeged", 6757, new Guid("832bb42d-9da0-411b-a29e-abf0c2f7b8d3"), "Napraforgó utca" },
                    { new Guid("6405e55d-d063-4d30-b0f6-c9ed8b53832e"), -1, -1, 50, "Szeged", 6710, new Guid("af3fe631-6c0f-452d-b185-508abe514b35"), "Kapisztrán" },
                    { new Guid("ba3c4a7c-9c12-46cd-95d0-2b2840435b8b"), -1, -1, 12, "Szeged", 6720, new Guid("d9824104-2006-480c-bb9e-105b50bb68f4"), "Dugonics" },
                    { new Guid("beb42da6-11f1-4aee-b969-3f6d6fe3d7bc"), -1, -1, 49, "Szeged", 6757, new Guid("832bb42d-9da0-411b-a29e-abf0c2f7b8d3"), "Koszorú utca" },
                    { new Guid("ed439cbe-70ed-45a5-8252-276ecf602590"), -1, -1, 33, "Szeged", 6757, new Guid("832bb42d-9da0-411b-a29e-abf0c2f7b8d3"), "Koszorú utca" }
                });

            migrationBuilder.InsertData(
                table: "Editor",
                column: "Id",
                values: new object[]
                {
                    new Guid("0d13af0d-a040-484d-833b-e9c15e841073"),
                    new Guid("110d7c48-92a1-4e34-aa77-de30f9008d68"),
                    new Guid("3f35105b-cc00-4305-a232-1687c6a0f65a"),
                    new Guid("7bb4beb2-1d9e-4e0c-87fb-d7af8db83e00"),
                    new Guid("95955821-1b20-4606-8133-7951c0733d25"),
                    new Guid("ba6bc4da-5da4-46a4-8413-2fca1e786bc0")
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "Description", "Name", "OrganizationCategoryId", "Url", "Website" },
                values: new object[,]
                {
                    { new Guid("060aa634-36c5-4acd-a050-c3f7c39e160a"), "Magyarorszagi férfi sátor közösség", "Férfi sátor", new Guid("6ef25418-d306-4f71-8105-e0e22680dd46"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("06132d73-9950-42a2-97b5-a2c8e749a302"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció, ", "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció", new Guid("02a57923-f857-4fd6-90fe-2b21fc7be918"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("11145a50-f446-412d-8b9a-b40223970b38"), "Munkásmisszió, vezetői kör", "Munkáasmisszió", new Guid("02a57923-f857-4fd6-90fe-2b21fc7be918"), "vezetok.munkasmisszio.ottleszek.hu", "" },
                    { new Guid("28215cb0-d259-48df-a269-116c51bb1281"), "Szentmihályi művelődési ház", "Szentmihályi művelődési ház", new Guid("9421f6d4-cb9d-4989-9617-ce51ee897d95"), "muvelodesihaz.szeged-szentmihaly.ottleszek.hu", "" },
                    { new Guid("2a862e9f-6165-4da0-839a-aeb1f9e893d3"), "Gyálaréti művelődési ház", "Gyálaréti művelődési ház", new Guid("9421f6d4-cb9d-4989-9617-ce51ee897d95"), "szeged-gyalaret.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("3d2c4d9a-8c3c-40ba-9931-6e6eb7199fc0"), "Szeged-Csanád Egyházmegye Pasztorális helynöksége", "Szeged-Csanád Egyházmegye Pasztorális helynökség", new Guid("02a57923-f857-4fd6-90fe-2b21fc7be918"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("4dcc0818-3a9e-46ca-9162-e711dae5bd47"), "Gyálaréti filához tartozó csaladcsoport", "Gyálaréti családcsoport", new Guid("02a57923-f857-4fd6-90fe-2b21fc7be918"), "csaladcsoport.flila.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("890799e5-0139-427a-976f-b187be5a36b2"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", new Guid("02a57923-f857-4fd6-90fe-2b21fc7be918"), "korhazi-lelekszseg.pasztoralis-helynokseg.szeged-csanádi - egyhazmegye.ottleszek.hu", "" },
                    { new Guid("b99f6686-1ad4-4187-a212-1c0ead42843a"), "Gyálaréten működő férfi sátor közösség", "Gyálaréti férfi sátor", new Guid("6ef25418-d306-4f71-8105-e0e22680dd46"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("f584dccc-2a33-43fc-a5ad-beb03b603777"), "Gyálaréten működő meditációs csoprot amely a Jézus imát gyakorolja", "Gyálaréti meditációs imacsoport", new Guid("02a57923-f857-4fd6-90fe-2b21fc7be918"), "meditacio.filia.szeged-gyalaret.ottleszek.hu", "" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationEditor",
                columns: new[] { "Id", "EditorId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("7c751cf7-8d0d-4e85-8227-59e8e29ee091"), new Guid("0d13af0d-a040-484d-833b-e9c15e841073"), new Guid("0d27f57c-04f4-4f39-8d96-97f738eb4d95") },
                    { new Guid("7efae4af-0709-4305-8ca9-89ff6049d178"), new Guid("0d13af0d-a040-484d-833b-e9c15e841073"), new Guid("ded5eff7-a465-4d32-bcbf-a4e2f21ed100") },
                    { new Guid("9bb98ebb-cc7a-41a9-8d04-ef0696374b68"), new Guid("110d7c48-92a1-4e34-aa77-de30f9008d68"), new Guid("f584dccc-2a33-43fc-a5ad-beb03b603777") },
                    { new Guid("9ee8ecbd-cef5-4f73-88b5-ebbd399e3842"), new Guid("0d13af0d-a040-484d-833b-e9c15e841073"), new Guid("b99f6686-1ad4-4187-a212-1c0ead42843a") },
                    { new Guid("a721c868-33fa-482a-b87c-1e5fdb61d2c3"), new Guid("95955821-1b20-4606-8133-7951c0733d25"), new Guid("3d2c4d9a-8c3c-40ba-9931-6e6eb7199fc0") },
                    { new Guid("a8575148-e4f0-4fa2-ae32-d7a3cb12aedc"), new Guid("3f35105b-cc00-4305-a232-1687c6a0f65a"), new Guid("4dcc0818-3a9e-46ca-9162-e711dae5bd47") },
                    { new Guid("c2db5a6d-fc3c-413f-8d7d-35264be6325f"), new Guid("110d7c48-92a1-4e34-aa77-de30f9008d68"), new Guid("060aa634-36c5-4acd-a050-c3f7c39e160a") },
                    { new Guid("e76786e1-5579-455a-9eed-1c444487cbdf"), new Guid("95955821-1b20-4606-8133-7951c0733d25"), new Guid("06132d73-9950-42a2-97b5-a2c8e749a302") }
                });

            migrationBuilder.InsertData(
                table: "OrgranizationProgram",
                columns: new[] { "Id", "AddressId", "Description", "End", "IsDeffered", "IsPublic", "OrganizationId", "ProgramOwnerId", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("31491233-163d-4260-8647-61d1a26a56cb"), new Guid("beb42da6-11f1-4aee-b969-3f6d6fe3d7bc"), "Apasebek tréning.", new DateTime(2024, 9, 23, 20, 0, 0, 0, DateTimeKind.Local), true, true, new Guid("b99f6686-1ad4-4187-a212-1c0ead42843a"), new Guid("ba6bc4da-5da4-46a4-8413-2fca1e786bc0"), new DateTime(2024, 9, 23, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" },
                    { new Guid("347cd965-9a69-4181-aa33-e6e233e21e7e"), new Guid("ba3c4a7c-9c12-46cd-95d0-2b2840435b8b"), "Csendes lelkigyakorlat felnőtteknek.", new DateTime(2024, 9, 3, 12, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("890799e5-0139-427a-976f-b187be5a36b2"), new Guid("d0f97edd-3470-45b4-8f1a-b3af7f84e557"), new DateTime(2024, 9, 2, 18, 0, 0, 0, DateTimeKind.Local), "Lelkigyakorlat" },
                    { new Guid("4ef29f5a-8b71-402d-a766-de45ad4b050b"), new Guid("ed439cbe-70ed-45a5-8252-276ecf602590"), "Délalföldi", new DateTime(2024, 9, 3, 2, 30, 0, 0, DateTimeKind.Local), false, true, new Guid("2a862e9f-6165-4da0-839a-aeb1f9e893d3"), new Guid("96bfb0ad-b4b4-4c6c-9784-e3720f0e1327"), new DateTime(2024, 9, 2, 21, 0, 0, 0, DateTimeKind.Local), "Táncház" },
                    { new Guid("5153286c-0566-4b0d-8f9b-6c4987b03e7f"), new Guid("beb42da6-11f1-4aee-b969-3f6d6fe3d7bc"), "Férfiaknak", null, false, false, new Guid("060aa634-36c5-4acd-a050-c3f7c39e160a"), new Guid("ba6bc4da-5da4-46a4-8413-2fca1e786bc0"), new DateTime(2024, 8, 4, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("530aba93-345b-467d-a316-620e3c4b60a1"), new Guid("beb42da6-11f1-4aee-b969-3f6d6fe3d7bc"), "Apasebek tréning.", new DateTime(2024, 9, 8, 20, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("b99f6686-1ad4-4187-a212-1c0ead42843a"), new Guid("40dcf7fb-9fcc-4ded-8e70-0359002b97a6"), new DateTime(2024, 9, 8, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" },
                    { new Guid("77d0b830-b787-41e6-8652-f9e7896d37ca"), new Guid("ba3c4a7c-9c12-46cd-95d0-2b2840435b8b"), "Lányoknak...", new DateTime(2024, 11, 18, 21, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("3d2c4d9a-8c3c-40ba-9931-6e6eb7199fc0"), new Guid("48259978-19b3-43c0-9815-7590eb2ffac1"), new DateTime(2024, 11, 18, 15, 0, 0, 0, DateTimeKind.Local), "Ciklus show" },
                    { new Guid("798d9e2c-e745-4b9e-b5c7-9cd8906378e8"), new Guid("beb42da6-11f1-4aee-b969-3f6d6fe3d7bc"), "Férfiaknak", null, false, false, new Guid("060aa634-36c5-4acd-a050-c3f7c39e160a"), new Guid("ba6bc4da-5da4-46a4-8413-2fca1e786bc0"), new DateTime(2024, 7, 8, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("8222f273-cb0d-4fc3-800d-1a577d88b30c"), new Guid("beb42da6-11f1-4aee-b969-3f6d6fe3d7bc"), "Férfiaknak", new DateTime(2024, 9, 13, 21, 0, 0, 0, DateTimeKind.Local), true, false, new Guid("060aa634-36c5-4acd-a050-c3f7c39e160a"), new Guid("ba6bc4da-5da4-46a4-8413-2fca1e786bc0"), new DateTime(2024, 9, 13, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("a41e8251-b60b-4af0-8737-2e4aef914441"), new Guid("beb42da6-11f1-4aee-b969-3f6d6fe3d7bc"), "Csendes ima.", null, false, true, new Guid("f584dccc-2a33-43fc-a5ad-beb03b603777"), new Guid("d7e2a3f6-b67b-4879-9ae6-1371520981a6"), new DateTime(2024, 8, 8, 20, 30, 0, 0, DateTimeKind.Local), "Meditáció" },
                    { new Guid("a8c2dd82-7452-4470-b216-0fd852d2e7a7"), new Guid("beb42da6-11f1-4aee-b969-3f6d6fe3d7bc"), "Családoknak", new DateTime(2024, 9, 3, 1, 30, 0, 0, DateTimeKind.Local), false, false, new Guid("4dcc0818-3a9e-46ca-9162-e711dae5bd47"), new Guid("3f35105b-cc00-4305-a232-1687c6a0f65a"), new DateTime(2024, 9, 2, 21, 0, 0, 0, DateTimeKind.Local), "Családcsoport" },
                    { new Guid("d91b1411-6a03-47f7-9dda-a0c76a62ecc4"), new Guid("beb42da6-11f1-4aee-b969-3f6d6fe3d7bc"), "Férfiaknak", new DateTime(2024, 9, 10, 21, 0, 0, 0, DateTimeKind.Local), false, false, new Guid("060aa634-36c5-4acd-a050-c3f7c39e160a"), new Guid("ba6bc4da-5da4-46a4-8413-2fca1e786bc0"), new DateTime(2024, 9, 10, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" }
                });

            migrationBuilder.InsertData(
                table: "ProgramOwner",
                column: "Id",
                values: new object[]
                {
                    new Guid("3f35105b-cc00-4305-a232-1687c6a0f65a"),
                    new Guid("ba6bc4da-5da4-46a4-8413-2fca1e786bc0")
                });

            migrationBuilder.InsertData(
                table: "Participation",
                columns: new[] { "Id", "Evaluation", "OrganizationProgramId", "ParticipantId" },
                values: new object[,]
                {
                    { new Guid("22a991ec-10cc-4647-a5d2-9d9f22e7f250"), -1, new Guid("347cd965-9a69-4181-aa33-e6e233e21e7e"), new Guid("7bb4beb2-1d9e-4e0c-87fb-d7af8db83e00") },
                    { new Guid("2ee2943e-787a-4fa8-b908-0d56ba0ee7ca"), -1, new Guid("347cd965-9a69-4181-aa33-e6e233e21e7e"), new Guid("95955821-1b20-4606-8133-7951c0733d25") },
                    { new Guid("6013c2f4-8129-41b1-b55b-aa3b57c9596f"), -1, new Guid("530aba93-345b-467d-a316-620e3c4b60a1"), new Guid("95955821-1b20-4606-8133-7951c0733d25") },
                    { new Guid("ac77b98b-d882-429c-a84e-f888dac62ca5"), 9, new Guid("a41e8251-b60b-4af0-8737-2e4aef914441"), new Guid("7bb4beb2-1d9e-4e0c-87fb-d7af8db83e00") },
                    { new Guid("bba0b0f6-9802-493e-b51c-10515b1d7932"), 9, new Guid("a41e8251-b60b-4af0-8737-2e4aef914441"), new Guid("0d13af0d-a040-484d-833b-e9c15e841073") }
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
                name: "IX_OrganizationEditor_EditorId",
                table: "OrganizationEditor",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEditor_OrganizationId",
                table: "OrganizationEditor",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgranizationProgram_AddressId",
                table: "OrgranizationProgram",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgranizationProgram_OrganizationId",
                table: "OrgranizationProgram",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_OrganizationProgramId",
                table: "Participation",
                column: "OrganizationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_ParticipantId",
                table: "Participation",
                column: "ParticipantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationEditor");

            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "ProgramOwner");

            migrationBuilder.DropTable(
                name: "OrgranizationProgram");

            migrationBuilder.DropTable(
                name: "Editor");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "RegisteredUser");

            migrationBuilder.DropTable(
                name: "PublicSpace");

            migrationBuilder.DropTable(
                name: "ProgramCategory");
        }
    }
}
