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
                name: "Editors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editors", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationEditors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationEditors", x => x.Id);
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProgramCategoryes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramCategoryes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProgramOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOwners", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicSpacees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
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
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
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
                    PublicSpaceName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Locality = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Door = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_PublicSpacees_PublicScapeId",
                        column: x => x.PublicScapeId,
                        principalTable: "PublicSpacees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "Name", "OrganizationCategoryId", "Url", "Website" },
                values: new object[,]
                {
                    { new Guid("3a9cd136-12ad-48b3-9f36-d30add467854"), "Kikindáról elszármazott Gyuris Család", "Kikindai Gyuris család", null, "gyuris-kikinda", "" },
                    { new Guid("9406d91c-0644-481e-bb8c-ddd925afb315"), "Gyálaréti Gyuris család programnaptára", "Gyálaréti Gyuris család", null, "gyuris-gyalaret", "" }
                });

            migrationBuilder.InsertData(
                table: "OrgranizationPrograms",
                columns: new[] { "Id", "AddressId", "Description", "End", "IsDeffered", "IsPublic", "OrganizationId", "ProgramOwnerId", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("40233e2b-3ef6-4bd4-a3fe-9c8fb0852ae9"), new Guid("1e90a60f-23de-469b-894f-475ee1776670"), "Délalföldi", new DateTime(2024, 9, 2, 2, 30, 0, 0, DateTimeKind.Local), false, true, new Guid("499bf7bb-e621-4073-bafd-0da2968fb477"), new Guid("baa85118-12ee-4275-8d58-68ca602d9cf6"), new DateTime(2024, 9, 1, 21, 0, 0, 0, DateTimeKind.Local), "Táncház" },
                    { new Guid("5a957ba3-b8b9-4098-a17d-32534b2d0e13"), new Guid("88ccabcc-517a-406d-8f97-7171b5140ef5"), "Családoknak", new DateTime(2024, 9, 2, 1, 30, 0, 0, DateTimeKind.Local), false, false, new Guid("2cc51b26-578b-48f4-b17e-520a28988c60"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 1, 21, 0, 0, 0, DateTimeKind.Local), "Családcsoport" },
                    { new Guid("74ac7a11-4548-46a2-ae11-3b5f5051ab46"), new Guid("88ccabcc-517a-406d-8f97-7171b5140ef5"), "Férfiaknak", null, false, false, new Guid("2a9cecea-d4df-498f-b7f2-416a455e6dc3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 7, 7, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("7a2f3a10-6a30-400a-a6b0-45ce02304fb3"), new Guid("88ccabcc-517a-406d-8f97-7171b5140ef5"), "Csendes ima.", null, false, true, new Guid("de390825-2a35-481f-82e4-5f2d3439dc3d"), new Guid("ba3597d9-f608-4e80-be14-03a3e7387e76"), new DateTime(2024, 8, 7, 20, 30, 0, 0, DateTimeKind.Local), "Meditáció" },
                    { new Guid("9e3d9970-a1e5-443a-8745-75c89d1a1351"), new Guid("845061b6-9f3a-458e-8212-bcf6a6aa21fc"), "Csendes lelkigyakorlat felnőtteknek.", new DateTime(2024, 9, 2, 12, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("855c57c1-ac33-4f10-b080-982841cddbdf"), new Guid("80da74e6-a850-47b3-b5fd-0fa1fa002a63"), new DateTime(2024, 9, 1, 18, 0, 0, 0, DateTimeKind.Local), "Lelkigyakorlat" },
                    { new Guid("a96bff66-da30-442f-8b2d-5a4f821cb10d"), new Guid("88ccabcc-517a-406d-8f97-7171b5140ef5"), "Apasebek tréning.", new DateTime(2024, 9, 22, 20, 0, 0, 0, DateTimeKind.Local), true, true, new Guid("734b04cb-cf30-45ef-9a75-50fb221edab8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 22, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" },
                    { new Guid("be2b7b85-c273-40b2-ae6c-664b4d0a2fdd"), new Guid("845061b6-9f3a-458e-8212-bcf6a6aa21fc"), "Lányoknak...", new DateTime(2024, 11, 17, 21, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("f662779d-d6b9-4362-9298-4b6bd6cc7d9b"), new Guid("bc565be1-171a-4795-9656-6ec58424e461"), new DateTime(2024, 11, 17, 15, 0, 0, 0, DateTimeKind.Local), "Ciklus show" },
                    { new Guid("c279b9e3-0be7-47d4-a30d-c5eeadddcbe0"), new Guid("88ccabcc-517a-406d-8f97-7171b5140ef5"), "Férfiaknak", null, false, false, new Guid("2a9cecea-d4df-498f-b7f2-416a455e6dc3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 3, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("c2969fec-4037-4ee7-8bd3-d5908f623b4b"), new Guid("88ccabcc-517a-406d-8f97-7171b5140ef5"), "Férfiaknak", new DateTime(2024, 9, 12, 21, 0, 0, 0, DateTimeKind.Local), true, false, new Guid("2a9cecea-d4df-498f-b7f2-416a455e6dc3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 12, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("cb7846ca-f8da-4e62-bfc3-4982de05d0b2"), new Guid("88ccabcc-517a-406d-8f97-7171b5140ef5"), "Férfiaknak", new DateTime(2024, 9, 9, 21, 0, 0, 0, DateTimeKind.Local), false, false, new Guid("2a9cecea-d4df-498f-b7f2-416a455e6dc3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 9, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("d1e8cbf6-5a4b-4831-ba41-ec5573e2e26a"), new Guid("88ccabcc-517a-406d-8f97-7171b5140ef5"), "Apasebek tréning.", new DateTime(2024, 9, 7, 20, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("734b04cb-cf30-45ef-9a75-50fb221edab8"), new Guid("6e9506b2-9d5b-40dc-814a-4153e0d305d6"), new DateTime(2024, 9, 7, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" }
                });

            migrationBuilder.InsertData(
                table: "Participations",
                columns: new[] { "Id", "Evaluation", "OrganizationProgramId", "RegisteredUserId" },
                values: new object[,]
                {
                    { new Guid("00bff483-a42f-403d-9e93-89c7fffa9601"), -1, new Guid("d1e8cbf6-5a4b-4831-ba41-ec5573e2e26a"), new Guid("52041eb9-9412-4f13-829b-e6c4a1fd894d") },
                    { new Guid("14637558-5f89-4c55-9d14-d6fca69e71c8"), 9, new Guid("7a2f3a10-6a30-400a-a6b0-45ce02304fb3"), new Guid("c0056648-d631-4e65-8088-eb48b15b458a") },
                    { new Guid("39d1d954-24d9-4831-b165-0af9a04094ef"), -1, new Guid("9e3d9970-a1e5-443a-8745-75c89d1a1351"), new Guid("52041eb9-9412-4f13-829b-e6c4a1fd894d") },
                    { new Guid("612dab44-ca3d-4b62-af26-d99b3f224c14"), -1, new Guid("9e3d9970-a1e5-443a-8745-75c89d1a1351"), new Guid("c0056648-d631-4e65-8088-eb48b15b458a") },
                    { new Guid("99bdd0fa-e4f0-40cf-83a5-a61d30698a91"), 9, new Guid("7a2f3a10-6a30-400a-a6b0-45ce02304fb3"), new Guid("1aa6800e-5170-4b9a-a7a3-e67f396cda1e") }
                });

            migrationBuilder.InsertData(
                table: "ProgramCategoryes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0057db2f-aa9f-40d6-9ec3-7a40b23fa9b7"), "ifjúság" },
                    { new Guid("503b9d1e-52a6-4cf9-8599-b663c741ff9d"), "vallás" },
                    { new Guid("5cd06ad6-ec0a-4efb-be73-e5d27dae1506"), "férfi identitás" },
                    { new Guid("6cca6b59-02eb-4ad1-8d0f-bc731f53ef0a"), "művelődés" },
                    { new Guid("f07a4fef-3c2a-453f-950e-cf75a3e26da2"), "házasság" },
                    { new Guid("fc7da9bc-ca39-4a70-86b5-9a8751e3866a"), "nevelés" }
                });

            migrationBuilder.InsertData(
                table: "ProgramOwners",
                column: "Id",
                values: new object[]
                {
                    new Guid("5bef3553-b9f7-44cc-89fc-73d9ef60ff3d"),
                    new Guid("6e9506b2-9d5b-40dc-814a-4153e0d305d6"),
                    new Guid("80da74e6-a850-47b3-b5fd-0fa1fa002a63"),
                    new Guid("ba3597d9-f608-4e80-be14-03a3e7387e76"),
                    new Guid("baa85118-12ee-4275-8d58-68ca602d9cf6"),
                    new Guid("bc565be1-171a-4795-9656-6ec58424e461")
                });

            migrationBuilder.InsertData(
                table: "PublicSpacees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("20aaef2b-0e0a-43ce-8275-89b4b3f72feb"), "út" },
                    { new Guid("a881178b-c510-4476-889e-8e7e53fb80a9"), "tér" },
                    { new Guid("c1a1772c-84cb-4afa-8c4f-ebf55de579c0"), "sugárút" },
                    { new Guid("f811251b-54d2-4feb-95f4-e09fdac81f0e"), "köz" },
                    { new Guid("fd3b63a6-3cf6-4282-b97e-4863a60ee372"), "utca" }
                });

            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("101020e1-48ef-43d1-9a81-acac083a9221"), "Anikó", "Szászi" },
                    { new Guid("1aa6800e-5170-4b9a-a7a3-e67f396cda1e"), "Csaba", "Gyuris" },
                    { new Guid("52041eb9-9412-4f13-829b-e6c4a1fd894d"), "Katalin", "Gyurisné Hutter" },
                    { new Guid("581025d7-a318-4d6e-8083-1569b51638de"), "Jenei", "Kornél" },
                    { new Guid("c0056648-d631-4e65-8088-eb48b15b458a"), "Balázs", "Szászi" },
                    { new Guid("f3086400-1cc6-49cf-8734-dd8ea68a6638"), "Zsuzsanna", "Szabóné" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Door", "Floor", "House", "Locality", "PostalCode", "PublicScapeId", "PublicSpaceName" },
                values: new object[,]
                {
                    { new Guid("097855e5-b5dc-410c-962a-18d90234b59a"), -1, -1, 1, "Szeged", 6757, new Guid("fd3b63a6-3cf6-4282-b97e-4863a60ee372"), "Napraforgó utca" },
                    { new Guid("1e90a60f-23de-469b-894f-475ee1776670"), -1, -1, 33, "Szeged", 6757, new Guid("fd3b63a6-3cf6-4282-b97e-4863a60ee372"), "Koszorú utca" },
                    { new Guid("589290f9-8098-4bcc-8b7e-636cdb1dc6b1"), -1, -1, 50, "Szeged", 6710, new Guid("f811251b-54d2-4feb-95f4-e09fdac81f0e"), "Kapisztrán" },
                    { new Guid("845061b6-9f3a-458e-8212-bcf6a6aa21fc"), -1, -1, 12, "Szeged", 6720, new Guid("a881178b-c510-4476-889e-8e7e53fb80a9"), "Dugonics" },
                    { new Guid("88ccabcc-517a-406d-8f97-7171b5140ef5"), -1, -1, 49, "Szeged", 6757, new Guid("fd3b63a6-3cf6-4282-b97e-4863a60ee372"), "Koszorú utca" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Description", "Name", "OrganizationCategoryId", "Url", "Website" },
                values: new object[,]
                {
                    { new Guid("226b760a-a5ab-469a-b17d-2df2680f00b8"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció, ", "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció", new Guid("503b9d1e-52a6-4cf9-8599-b663c741ff9d"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("2a9cecea-d4df-498f-b7f2-416a455e6dc3"), "Magyarorszagi férfi sátor közösség", "Férfi sátor", new Guid("5cd06ad6-ec0a-4efb-be73-e5d27dae1506"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("2cc51b26-578b-48f4-b17e-520a28988c60"), "Gyálaréti filához tartozó csaladcsoport", "Gyálaréti családcsoport", new Guid("503b9d1e-52a6-4cf9-8599-b663c741ff9d"), "csaladcsoport.flila.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("499bf7bb-e621-4073-bafd-0da2968fb477"), "Gyálaréti művelődési ház", "Gyálaréti művelődési ház", new Guid("6cca6b59-02eb-4ad1-8d0f-bc731f53ef0a"), "szeged-gyalaret.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("734b04cb-cf30-45ef-9a75-50fb221edab8"), "Gyálaréten működő férfi sátor közösség", "Gyálaréti férfi sátor", new Guid("5cd06ad6-ec0a-4efb-be73-e5d27dae1506"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("7c49006e-a0e4-4e67-b196-87d3beefcde7"), "Munkásmisszió, vezetői kör", "Munkáasmisszió", new Guid("503b9d1e-52a6-4cf9-8599-b663c741ff9d"), "vezetok.munkasmisszio.ottleszek.hu", "" },
                    { new Guid("855c57c1-ac33-4f10-b080-982841cddbdf"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", new Guid("503b9d1e-52a6-4cf9-8599-b663c741ff9d"), "korhazi-lelekszseg.pasztoralis-helynokseg.szeged-csanádi - egyhazmegye.ottleszek.hu", "" },
                    { new Guid("c69976a2-8ef4-42f9-a6af-7d9355055cc7"), "Szentmihályi művelődési ház", "Szentmihályi művelődési ház", new Guid("6cca6b59-02eb-4ad1-8d0f-bc731f53ef0a"), "muvelodesihaz.szeged-szentmihaly.ottleszek.hu", "" },
                    { new Guid("de390825-2a35-481f-82e4-5f2d3439dc3d"), "Gyálaréten működő meditációs csoprot amely a Jézus imát gyakorolja", "Gyálaréti meditációs imacsoport", new Guid("503b9d1e-52a6-4cf9-8599-b663c741ff9d"), "meditacio.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("f662779d-d6b9-4362-9298-4b6bd6cc7d9b"), "Szeged-Csanád Egyházmegye Pasztorális helynöksége", "Szeged-Csanád Egyházmegye Pasztorális helynökség", new Guid("503b9d1e-52a6-4cf9-8599-b663c741ff9d"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PublicScapeId",
                table: "Addresses",
                column: "PublicScapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationCategoryId",
                table: "Organizations",
                column: "OrganizationCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Editors");

            migrationBuilder.DropTable(
                name: "OrganizationEditors");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "OrgranizationPrograms");

            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "ProgramOwners");

            migrationBuilder.DropTable(
                name: "RegisteredUsers");

            migrationBuilder.DropTable(
                name: "PublicSpacees");

            migrationBuilder.DropTable(
                name: "ProgramCategoryes");
        }
    }
}
