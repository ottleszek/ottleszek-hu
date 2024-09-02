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
                name: "ProgramCategoryes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCategoryes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicSpacees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSpacees", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegisteredUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organizations",
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
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_ProgramCategoryes_OrganizationCategoryId",
                        column: x => x.OrganizationCategoryId,
                        principalTable: "ProgramCategoryes",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    PublicScapeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PublicSpaceName = table.Column<string>(type: "longtext", nullable: false),
                    Locality = table.Column<string>(type: "longtext", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Door = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    PublicSpaceId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_PublicSpacees_PublicSpaceId",
                        column: x => x.PublicSpaceId,
                        principalTable: "PublicSpacees",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Editors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Editors_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrgranizationPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeffered = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ProgramOwnerId = table.Column<Guid>(type: "char(36)", nullable: false),
                    AddressId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgranizationPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgranizationPrograms_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrgranizationPrograms_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationEditors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationId1 = table.Column<Guid>(type: "char(36)", nullable: true),
                    EditorId1 = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationEditors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationEditors_Editors_EditorId1",
                        column: x => x.EditorId1,
                        principalTable: "Editors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationEditors_Organizations_OrganizationId1",
                        column: x => x.OrganizationId1,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProgramOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    EditorDataId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramOwners_Editors_EditorDataId",
                        column: x => x.EditorDataId,
                        principalTable: "Editors",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RegisteredUserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationProgramId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Evaluation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participations_OrgranizationPrograms_OrganizationProgramId",
                        column: x => x.OrganizationProgramId,
                        principalTable: "OrgranizationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_RegisteredUsers_RegisteredUserId",
                        column: x => x.RegisteredUserId,
                        principalTable: "RegisteredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Door", "Floor", "House", "Locality", "PostalCode", "PublicScapeId", "PublicSpaceId", "PublicSpaceName" },
                values: new object[,]
                {
                    { new Guid("01f7c854-b768-42fb-8624-76f05c7c1405"), -1, -1, 50, "Szeged", 6710, new Guid("d6bccebe-5f7a-4e98-847c-c33d2ef59846"), null, "Kapisztrán" },
                    { new Guid("5c3b14ee-4817-4cce-b587-cbbea3efbbbc"), -1, -1, 1, "Szeged", 6757, new Guid("2136922e-03f2-42b4-9302-376d59d772a2"), null, "Napraforgó utca" },
                    { new Guid("6bbcbb10-8b5b-4c07-8209-1d9738d89788"), -1, -1, 12, "Szeged", 6720, new Guid("177fb4dd-7425-4594-96fe-f696b933ae1a"), null, "Dugonics" },
                    { new Guid("895c2717-4cd3-40de-bb36-d656b8c059aa"), -1, -1, 33, "Szeged", 6757, new Guid("2136922e-03f2-42b4-9302-376d59d772a2"), null, "Koszorú utca" },
                    { new Guid("a66b07e7-573b-469f-b679-be2298c01d80"), -1, -1, 49, "Szeged", 6757, new Guid("2136922e-03f2-42b4-9302-376d59d772a2"), null, "Koszorú utca" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "Name", "OrganizationCategoryId", "Url", "Website" },
                values: new object[,]
                {
                    { new Guid("7f928d5f-d456-4a18-9c3e-1ab568702071"), "Kikindáról elszármazott Gyuris Család", "Kikindai Gyuris család", null, "gyuris.kikinda.ottleszek.hu", "" },
                    { new Guid("e8b9c35a-95a8-4d89-a18c-606b4eadc267"), "Gyálaréti Gyuris család programnaptára", "Gyálaréti Gyuris család", null, "gyuris.gyalaret.ottleszek.hu", "" }
                });

            migrationBuilder.InsertData(
                table: "ProgramCategoryes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0a6b9791-2c40-469e-a756-ac887da92182"), "művelődés" },
                    { new Guid("1594f99b-4a56-428f-8a04-e8014b207a31"), "házasság" },
                    { new Guid("3c8fe967-11c8-4e9d-b543-3fa1bb6e8f82"), "nevelés" },
                    { new Guid("75b7661e-3771-4b92-a858-3c8dedfd5256"), "vallás" },
                    { new Guid("76f531fe-dfd8-42f1-bcac-67e116209036"), "férfi identitás" },
                    { new Guid("9633caf3-2c5c-4bf5-b9a5-5fe7d1965b3b"), "ifjúság" }
                });

            migrationBuilder.InsertData(
                table: "ProgramOwners",
                columns: new[] { "Id", "EditorDataId" },
                values: new object[,]
                {
                    { new Guid("410c7518-9cd9-4760-a911-28345eabc1bf"), null },
                    { new Guid("5a64fcba-7d9d-4376-ad66-ad8f899dc175"), null },
                    { new Guid("6e3dc83f-5651-4e7d-aa9d-457e4646b601"), null },
                    { new Guid("84d63948-8bd9-4a44-b22b-099cf6a0ec21"), null },
                    { new Guid("bdf5ff18-c93c-478b-b8d7-a473c4fa57c7"), null },
                    { new Guid("ffc70c9f-b7fe-4afe-9a60-c20c175fdf2d"), null }
                });

            migrationBuilder.InsertData(
                table: "PublicSpacees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("177fb4dd-7425-4594-96fe-f696b933ae1a"), "tér" },
                    { new Guid("2136922e-03f2-42b4-9302-376d59d772a2"), "utca" },
                    { new Guid("3b48496f-006b-4a6f-b13b-6c9530b44848"), "sugárút" },
                    { new Guid("d6bccebe-5f7a-4e98-847c-c33d2ef59846"), "köz" },
                    { new Guid("f5922e5e-fa02-4a39-8c48-35d4ce19c86e"), "út" }
                });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("5bacd927-2106-4fc0-a4e1-4517d307bef3"), "Katalin", "Gyurisné Hutter" },
                    { new Guid("7ad65965-1e60-4908-8531-149f9f54e1c9"), "Anikó", "Szászi" },
                    { new Guid("8263a126-1169-4dd5-b58e-bb2a17a9421d"), "Jenei", "Kornél" },
                    { new Guid("dd562ab7-6201-4e46-b9ea-f94c043ae30e"), "Csaba", "Gyuris" },
                    { new Guid("e7352d6f-d413-4af8-91a2-81e50013d3ec"), "Balázs", "Szászi" },
                    { new Guid("fe44fbad-8b41-47c3-b5a3-b33557f3a753"), "Zsuzsanna", "Szabóné" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "Name", "OrganizationCategoryId", "Url", "Website" },
                values: new object[,]
                {
                    { new Guid("2525ba33-38f5-42d1-bab8-fa587267d381"), "Gyálaréti filához tartozó csaladcsoport", "Gyálaréti családcsoport", new Guid("75b7661e-3771-4b92-a858-3c8dedfd5256"), "csaladcsoport.flila.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("38ea04e5-8cdb-43ea-8bee-df36ce10e35a"), "Gyálaréten működő férfi sátor közösség", "Gyálaréti férfi sátor", new Guid("76f531fe-dfd8-42f1-bcac-67e116209036"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("4cec6b6e-7bc9-4d62-9180-aab6e62fde1e"), "Szeged-Csanád Egyházmegye Pasztorális helynöksége", "Szeged-Csanád Egyházmegye Pasztorális helynökség", new Guid("75b7661e-3771-4b92-a858-3c8dedfd5256"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("59dee488-a5c7-4e35-b510-df102b3e6db8"), "Gyálaréten működő meditációs csoprot amely a Jézus imát gyakorolja", "Gyálaréti meditációs imacsoport", new Guid("75b7661e-3771-4b92-a858-3c8dedfd5256"), "meditacio.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("6633a14b-d741-4361-9a9e-5922bb352a54"), "Magyarorszagi férfi sátor közösség", "Férfi sátor", new Guid("76f531fe-dfd8-42f1-bcac-67e116209036"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("8e469acb-5e33-4487-8b86-038af1554f24"), "Munkásmisszió, vezetői kör", "Munkáasmisszió", new Guid("75b7661e-3771-4b92-a858-3c8dedfd5256"), "vezetok.munkasmisszio.ottleszek.hu", "" },
                    { new Guid("b344349a-3891-4c53-bd89-202b00228b79"), "Szentmihályi művelődési ház", "Szentmihályi művelődési ház", new Guid("0a6b9791-2c40-469e-a756-ac887da92182"), "muvelodesihaz.szeged-szentmihaly.ottleszek.hu", "" },
                    { new Guid("d4e31f1f-8cff-4ff4-8de8-6fe4f2b8f8d6"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", new Guid("75b7661e-3771-4b92-a858-3c8dedfd5256"), "korhazi-lelekszseg.pasztoralis-helynokseg.szeged-csanádi - egyhazmegye.ottleszek.hu", "" },
                    { new Guid("d8bde7de-404c-40b2-8451-455ad3996af2"), "Gyálaréti művelődési ház", "Gyálaréti művelődési ház", new Guid("0a6b9791-2c40-469e-a756-ac887da92182"), "szeged-gyalaret.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("ecea2b70-c39a-43a5-8d64-2fe95d96085f"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció, ", "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció", new Guid("75b7661e-3771-4b92-a858-3c8dedfd5256"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" }
                });

            migrationBuilder.InsertData(
                table: "OrgranizationPrograms",
                columns: new[] { "Id", "AddressId", "Description", "End", "IsDeffered", "IsPublic", "OrganizationId", "ProgramOwnerId", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("03df70bd-2fa8-4a8c-9393-e3580da3d41f"), new Guid("a66b07e7-573b-469f-b679-be2298c01d80"), "Családoknak", new DateTime(2024, 9, 2, 1, 30, 0, 0, DateTimeKind.Local), false, false, new Guid("2525ba33-38f5-42d1-bab8-fa587267d381"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 1, 21, 0, 0, 0, DateTimeKind.Local), "Családcsoport" },
                    { new Guid("05b29b28-bc66-48b6-903f-108d5e80855f"), new Guid("6bbcbb10-8b5b-4c07-8209-1d9738d89788"), "Lányoknak...", new DateTime(2024, 11, 17, 21, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("4cec6b6e-7bc9-4d62-9180-aab6e62fde1e"), new Guid("ffc70c9f-b7fe-4afe-9a60-c20c175fdf2d"), new DateTime(2024, 11, 17, 15, 0, 0, 0, DateTimeKind.Local), "Ciklus show" },
                    { new Guid("09f8dc9f-ec64-41dc-a6f6-c5eef32d2b4d"), new Guid("a66b07e7-573b-469f-b679-be2298c01d80"), "Férfiaknak", null, false, false, new Guid("6633a14b-d741-4361-9a9e-5922bb352a54"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 3, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("372b2fe1-6a01-419a-b376-6b5be43ae9e7"), new Guid("6bbcbb10-8b5b-4c07-8209-1d9738d89788"), "Csendes lelkigyakorlat felnőtteknek.", new DateTime(2024, 9, 2, 12, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("d4e31f1f-8cff-4ff4-8de8-6fe4f2b8f8d6"), new Guid("410c7518-9cd9-4760-a911-28345eabc1bf"), new DateTime(2024, 9, 1, 18, 0, 0, 0, DateTimeKind.Local), "Lelkigyakorlat" },
                    { new Guid("5dbddd4a-bed9-4c4e-9e3a-d607cc8deb81"), new Guid("a66b07e7-573b-469f-b679-be2298c01d80"), "Férfiaknak", new DateTime(2024, 9, 12, 21, 0, 0, 0, DateTimeKind.Local), true, false, new Guid("6633a14b-d741-4361-9a9e-5922bb352a54"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 12, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("7a5127b0-66ef-4d39-b9d3-2aaf857de94d"), new Guid("895c2717-4cd3-40de-bb36-d656b8c059aa"), "Délalföldi", new DateTime(2024, 9, 2, 2, 30, 0, 0, DateTimeKind.Local), false, true, new Guid("d8bde7de-404c-40b2-8451-455ad3996af2"), new Guid("5a64fcba-7d9d-4376-ad66-ad8f899dc175"), new DateTime(2024, 9, 1, 21, 0, 0, 0, DateTimeKind.Local), "Táncház" },
                    { new Guid("9ca5faad-49bd-40bf-8c57-c9db7382afca"), new Guid("a66b07e7-573b-469f-b679-be2298c01d80"), "Apasebek tréning.", new DateTime(2024, 9, 22, 20, 0, 0, 0, DateTimeKind.Local), true, true, new Guid("38ea04e5-8cdb-43ea-8bee-df36ce10e35a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 22, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" },
                    { new Guid("9fb0f281-48bd-485e-b9b7-913fea1bccd7"), new Guid("a66b07e7-573b-469f-b679-be2298c01d80"), "Csendes ima.", null, false, true, new Guid("59dee488-a5c7-4e35-b510-df102b3e6db8"), new Guid("84d63948-8bd9-4a44-b22b-099cf6a0ec21"), new DateTime(2024, 8, 7, 20, 30, 0, 0, DateTimeKind.Local), "Meditáció" },
                    { new Guid("a32d4262-2a21-4e2e-8082-3751aa8c8e82"), new Guid("a66b07e7-573b-469f-b679-be2298c01d80"), "Apasebek tréning.", new DateTime(2024, 9, 7, 20, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("38ea04e5-8cdb-43ea-8bee-df36ce10e35a"), new Guid("bdf5ff18-c93c-478b-b8d7-a473c4fa57c7"), new DateTime(2024, 9, 7, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" },
                    { new Guid("b2472591-324b-4caa-96f1-c4ae10c92c13"), new Guid("a66b07e7-573b-469f-b679-be2298c01d80"), "Férfiaknak", null, false, false, new Guid("6633a14b-d741-4361-9a9e-5922bb352a54"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 7, 7, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("fef0e8c5-292f-4666-9f58-59f98d403db6"), new Guid("a66b07e7-573b-469f-b679-be2298c01d80"), "Férfiaknak", new DateTime(2024, 9, 9, 21, 0, 0, 0, DateTimeKind.Local), false, false, new Guid("6633a14b-d741-4361-9a9e-5922bb352a54"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 9, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" }
                });

            migrationBuilder.InsertData(
                table: "Participations",
                columns: new[] { "Id", "Evaluation", "OrganizationProgramId", "RegisteredUserId" },
                values: new object[,]
                {
                    { new Guid("32aafbd4-f2fe-420a-9ef9-dcae1bb4b657"), -1, new Guid("372b2fe1-6a01-419a-b376-6b5be43ae9e7"), new Guid("5bacd927-2106-4fc0-a4e1-4517d307bef3") },
                    { new Guid("3e37c941-6add-4667-9f50-804eb43af73f"), 9, new Guid("9fb0f281-48bd-485e-b9b7-913fea1bccd7"), new Guid("e7352d6f-d413-4af8-91a2-81e50013d3ec") },
                    { new Guid("61305529-494d-48d1-a3d3-a37d06b67e4b"), -1, new Guid("372b2fe1-6a01-419a-b376-6b5be43ae9e7"), new Guid("e7352d6f-d413-4af8-91a2-81e50013d3ec") },
                    { new Guid("dda85b5d-711e-41e3-a5ed-6a2d56d91ded"), -1, new Guid("a32d4262-2a21-4e2e-8082-3751aa8c8e82"), new Guid("5bacd927-2106-4fc0-a4e1-4517d307bef3") },
                    { new Guid("ec294e86-fd64-4e03-b274-bd4c62758e42"), 9, new Guid("9fb0f281-48bd-485e-b9b7-913fea1bccd7"), new Guid("dd562ab7-6201-4e46-b9ea-f94c043ae30e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PublicSpaceId",
                table: "Addresses",
                column: "PublicSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Editors_OrganizationId",
                table: "Editors",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEditors_EditorId1",
                table: "OrganizationEditors",
                column: "EditorId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEditors_OrganizationId1",
                table: "OrganizationEditors",
                column: "OrganizationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationCategoryId",
                table: "Organizations",
                column: "OrganizationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgranizationPrograms_AddressId",
                table: "OrgranizationPrograms",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgranizationPrograms_OrganizationId",
                table: "OrgranizationPrograms",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_OrganizationProgramId",
                table: "Participations",
                column: "OrganizationProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_RegisteredUserId",
                table: "Participations",
                column: "RegisteredUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramOwners_EditorDataId",
                table: "ProgramOwners",
                column: "EditorDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationEditors");

            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "ProgramOwners");

            migrationBuilder.DropTable(
                name: "OrgranizationPrograms");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");

            migrationBuilder.DropTable(
                name: "Editors");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "PublicSpacees");

            migrationBuilder.DropTable(
                name: "ProgramCategoryes");
        }
    }
}
