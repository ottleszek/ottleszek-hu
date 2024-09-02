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
                name: "Editor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editor", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationEditor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationEditor", x => x.Id);
                })
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
                name: "ProgramOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOwner", x => x.Id);
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
                    { new Guid("240fc663-c2d8-491b-973a-c1bde3e1b1f2"), "Gyálaréti Gyuris család programnaptára", "Gyálaréti Gyuris család", null, "gyuris-gyalaret", "" },
                    { new Guid("943e5be7-da40-426b-83af-96b112f48e51"), "Kikindáról elszármazott Gyuris Család", "Kikindai Gyuris család", null, "gyuris-kikinda", "" }
                });

            migrationBuilder.InsertData(
                table: "ProgramCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04d62928-1cba-4540-8eab-cc582d29a4c4"), "művelődés" },
                    { new Guid("181552e9-589c-48cc-b5ce-81718c80d9d2"), "házasság" },
                    { new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"), "vallás" },
                    { new Guid("2bda7ec3-0f31-4c85-9385-70e6d0de0826"), "ifjúság" },
                    { new Guid("e79b56d8-4475-4a2a-af44-fccd7199c895"), "nevelés" },
                    { new Guid("f27d8a99-5e11-4ed8-87ae-57d3fa17b8e5"), "férfi identitás" }
                });

            migrationBuilder.InsertData(
                table: "ProgramOwner",
                column: "Id",
                values: new object[]
                {
                    new Guid("2b623efc-55a8-4303-84bb-c091f78b5bfc"),
                    new Guid("3ef41046-3367-4871-89e5-e14c75ea54cb"),
                    new Guid("430c750e-f3b8-4bbe-a788-2a3a591b8486"),
                    new Guid("8d29795d-fa0d-4477-bb7d-d3dc131c9c61"),
                    new Guid("a20a11c4-326d-427f-9a47-2378f7f6bf87"),
                    new Guid("f1c3af2a-34c0-4d15-a144-000ee2d09752")
                });

            migrationBuilder.InsertData(
                table: "PublicSpace",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3fc82d09-3d17-424b-b0f1-159a2c83fc92"), "sugárút" },
                    { new Guid("46ad66d7-0014-4e2e-8b56-90d356f5b8ac"), "út" },
                    { new Guid("558ffa2d-12c2-4268-b6ec-313d3fa6a53b"), "köz" },
                    { new Guid("7e16a7a4-0065-4e9d-864b-489086bb845b"), "tér" },
                    { new Guid("a2b0a9e8-3b9d-485b-977d-e8c5eab51e3c"), "utca" }
                });

            migrationBuilder.InsertData(
                table: "RegisteredUser",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("12997c71-c8fc-48f6-94e3-15d76abea643"), "Anikó", "Szászi" },
                    { new Guid("39c81b90-8ed0-40b7-955a-bf74f38f7b15"), "Jenei", "Kornél" },
                    { new Guid("52979a8b-3ebf-4c4e-93c8-dd31576dc315"), "Zsuzsanna", "Szabóné" },
                    { new Guid("9daf7a9c-7334-4bf5-850e-9cc3bf4b268a"), "Katalin", "Gyurisné Hutter" },
                    { new Guid("ae19fdc4-f8fa-417b-8c05-5aac00c9e96d"), "Balázs", "Szászi" },
                    { new Guid("ffbc52d2-a2f4-464c-a316-1d985c207087"), "Csaba", "Gyuris" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "Door", "Floor", "House", "Locality", "PostalCode", "PublicScapeId", "PublicSpaceName" },
                values: new object[,]
                {
                    { new Guid("04bb57c1-673f-468d-bd70-a4b46a95a278"), -1, -1, 12, "Szeged", 6720, new Guid("7e16a7a4-0065-4e9d-864b-489086bb845b"), "Dugonics" },
                    { new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"), -1, -1, 49, "Szeged", 6757, new Guid("a2b0a9e8-3b9d-485b-977d-e8c5eab51e3c"), "Koszorú utca" },
                    { new Guid("ebf98c69-6894-4659-8bd9-5f6639e4c296"), -1, -1, 50, "Szeged", 6710, new Guid("558ffa2d-12c2-4268-b6ec-313d3fa6a53b"), "Kapisztrán" },
                    { new Guid("f27bbab2-f078-43d3-93bf-162c4bb02999"), -1, -1, 33, "Szeged", 6757, new Guid("a2b0a9e8-3b9d-485b-977d-e8c5eab51e3c"), "Koszorú utca" },
                    { new Guid("fef36d7e-2819-4535-b6f7-3e19a35f7889"), -1, -1, 1, "Szeged", 6757, new Guid("a2b0a9e8-3b9d-485b-977d-e8c5eab51e3c"), "Napraforgó utca" }
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "Description", "Name", "OrganizationCategoryId", "Url", "Website" },
                values: new object[,]
                {
                    { new Guid("02461bba-032e-4e65-bc2f-b009c9619bef"), "Munkásmisszió, vezetői kör", "Munkáasmisszió", new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"), "vezetok.munkasmisszio.ottleszek.hu", "" },
                    { new Guid("08af2a62-50ba-4fb3-b181-f4a225062060"), "Gyálaréti filához tartozó csaladcsoport", "Gyálaréti családcsoport", new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"), "csaladcsoport.flila.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("08f17caf-65f1-4faa-8691-458c0f09c798"), "Szeged-Csanád Egyházmegye Pasztorális helynöksége", "Szeged-Csanád Egyházmegye Pasztorális helynökség", new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("4a5547f6-6051-4e6f-b933-ebf753801af0"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"), "korhazi-lelekszseg.pasztoralis-helynokseg.szeged-csanádi - egyhazmegye.ottleszek.hu", "" },
                    { new Guid("4b9eda5b-6307-4815-bd7c-6aa372bd4abb"), "Gyálaréti művelődési ház", "Gyálaréti művelődési ház", new Guid("04d62928-1cba-4540-8eab-cc582d29a4c4"), "szeged-gyalaret.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("5c7cfb01-e559-49de-9eaa-0c338832376f"), "Szentmihályi művelődési ház", "Szentmihályi művelődési ház", new Guid("04d62928-1cba-4540-8eab-cc582d29a4c4"), "muvelodesihaz.szeged-szentmihaly.ottleszek.hu", "" },
                    { new Guid("825da4a3-1b52-4586-8be4-e7d9e78a450b"), "Gyálaréten működő meditációs csoprot amely a Jézus imát gyakorolja", "Gyálaréti meditációs imacsoport", new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"), "meditacio.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("902a4e5b-da50-4a76-b48a-d4beeacb4c43"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció, ", "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció", new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("afd2b545-5924-4540-a8e6-cfeeda57ee50"), "Gyálaréten működő férfi sátor közösség", "Gyálaréti férfi sátor", new Guid("f27d8a99-5e11-4ed8-87ae-57d3fa17b8e5"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"), "Magyarorszagi férfi sátor közösség", "Férfi sátor", new Guid("f27d8a99-5e11-4ed8-87ae-57d3fa17b8e5"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" }
                });

            migrationBuilder.InsertData(
                table: "OrgranizationProgram",
                columns: new[] { "Id", "AddressId", "Description", "End", "IsDeffered", "IsPublic", "OrganizationId", "ProgramOwnerId", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("40cffa31-e2c0-4c8c-8196-101a1457803f"), new Guid("04bb57c1-673f-468d-bd70-a4b46a95a278"), "Lányoknak...", new DateTime(2024, 11, 17, 21, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("08f17caf-65f1-4faa-8691-458c0f09c798"), new Guid("f1c3af2a-34c0-4d15-a144-000ee2d09752"), new DateTime(2024, 11, 17, 15, 0, 0, 0, DateTimeKind.Local), "Ciklus show" },
                    { new Guid("62dc0fa9-e3b5-426b-9c87-51c528165ce5"), new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"), "Apasebek tréning.", new DateTime(2024, 9, 7, 20, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("afd2b545-5924-4540-a8e6-cfeeda57ee50"), new Guid("2b623efc-55a8-4303-84bb-c091f78b5bfc"), new DateTime(2024, 9, 7, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" },
                    { new Guid("a394e533-03a2-41a7-96e9-a38dd811e9d7"), new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"), "Férfiaknak", null, false, false, new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 7, 7, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("c7186512-480d-44d1-862c-9058ebbfff9c"), new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"), "Férfiaknak", new DateTime(2024, 9, 12, 21, 0, 0, 0, DateTimeKind.Local), true, false, new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 12, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("c7db0031-8e2a-431a-9ba1-ae24cb6d286d"), new Guid("04bb57c1-673f-468d-bd70-a4b46a95a278"), "Csendes lelkigyakorlat felnőtteknek.", new DateTime(2024, 9, 2, 12, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("4a5547f6-6051-4e6f-b933-ebf753801af0"), new Guid("a20a11c4-326d-427f-9a47-2378f7f6bf87"), new DateTime(2024, 9, 1, 18, 0, 0, 0, DateTimeKind.Local), "Lelkigyakorlat" },
                    { new Guid("ca1f0fa4-8cde-4d3f-a53b-ae764248fd05"), new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"), "Családoknak", new DateTime(2024, 9, 2, 1, 30, 0, 0, DateTimeKind.Local), false, false, new Guid("08af2a62-50ba-4fb3-b181-f4a225062060"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 1, 21, 0, 0, 0, DateTimeKind.Local), "Családcsoport" },
                    { new Guid("dab3cc94-7c82-4a63-9bd0-78b6be9b5fa7"), new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"), "Apasebek tréning.", new DateTime(2024, 9, 22, 20, 0, 0, 0, DateTimeKind.Local), true, true, new Guid("afd2b545-5924-4540-a8e6-cfeeda57ee50"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 22, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" },
                    { new Guid("de58cefe-0229-463d-b1d3-910ef04aaff8"), new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"), "Férfiaknak", new DateTime(2024, 9, 9, 21, 0, 0, 0, DateTimeKind.Local), false, false, new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 9, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("e4811177-c24b-4e42-b283-2fa6fd7bd41b"), new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"), "Férfiaknak", null, false, false, new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 3, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor" },
                    { new Guid("eb8aaa97-688d-4c4f-b5e6-5cf11183e3e8"), new Guid("f27bbab2-f078-43d3-93bf-162c4bb02999"), "Délalföldi", new DateTime(2024, 9, 2, 2, 30, 0, 0, DateTimeKind.Local), false, true, new Guid("4b9eda5b-6307-4815-bd7c-6aa372bd4abb"), new Guid("430c750e-f3b8-4bbe-a788-2a3a591b8486"), new DateTime(2024, 9, 1, 21, 0, 0, 0, DateTimeKind.Local), "Táncház" },
                    { new Guid("ebbb478d-2d53-4535-ab40-fa4c902b6279"), new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"), "Csendes ima.", null, false, true, new Guid("825da4a3-1b52-4586-8be4-e7d9e78a450b"), new Guid("3ef41046-3367-4871-89e5-e14c75ea54cb"), new DateTime(2024, 8, 7, 20, 30, 0, 0, DateTimeKind.Local), "Meditáció" }
                });

            migrationBuilder.InsertData(
                table: "Participation",
                columns: new[] { "Id", "Evaluation", "OrganizationProgramId", "ParticipantId" },
                values: new object[,]
                {
                    { new Guid("293da214-d70f-49df-8690-8b925ff22e6b"), 9, new Guid("ebbb478d-2d53-4535-ab40-fa4c902b6279"), new Guid("ffbc52d2-a2f4-464c-a316-1d985c207087") },
                    { new Guid("62a247ae-3121-4a0a-9c6c-748c01b0812c"), -1, new Guid("62dc0fa9-e3b5-426b-9c87-51c528165ce5"), new Guid("9daf7a9c-7334-4bf5-850e-9cc3bf4b268a") },
                    { new Guid("7099339b-983b-4b10-89fa-3356fb648470"), -1, new Guid("c7db0031-8e2a-431a-9ba1-ae24cb6d286d"), new Guid("9daf7a9c-7334-4bf5-850e-9cc3bf4b268a") },
                    { new Guid("d1ce8c91-a5d6-444f-a0f4-ea1cc3fd1fe5"), -1, new Guid("c7db0031-8e2a-431a-9ba1-ae24cb6d286d"), new Guid("ae19fdc4-f8fa-417b-8c05-5aac00c9e96d") },
                    { new Guid("df075350-fbd3-4326-b4f7-ee03999e9f23"), 9, new Guid("ebbb478d-2d53-4535-ab40-fa4c902b6279"), new Guid("ae19fdc4-f8fa-417b-8c05-5aac00c9e96d") }
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
                name: "Editor");

            migrationBuilder.DropTable(
                name: "OrganizationEditor");

            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "ProgramOwner");

            migrationBuilder.DropTable(
                name: "OrgranizationProgram");

            migrationBuilder.DropTable(
                name: "RegisteredUser");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "PublicSpace");

            migrationBuilder.DropTable(
                name: "ProgramCategory");
        }
    }
}
