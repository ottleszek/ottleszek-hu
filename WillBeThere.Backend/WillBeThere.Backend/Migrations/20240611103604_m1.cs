using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WillBeThere.Backend.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
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
                    PublicScapeID = table.Column<Guid>(type: "char(36)", nullable: false),
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
                        name: "FK_Address_PublicSpace_PublicScapeID",
                        column: x => x.PublicScapeID,
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
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAdminUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAdminUser_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationAdminUser_RegisteredUser_AdminId",
                        column: x => x.AdminId,
                        principalTable: "RegisteredUser",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrgranizationProgram",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
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
                        name: "FK_OrgranizationProgram_OrganizationAdminUser_ProgramOwnerId",
                        column: x => x.ProgramOwnerId,
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
                    { new Guid("3ae02173-56cd-4029-a8c1-3b465e59098f"), "Kikindáról elszármazott Gyuris Család", "Kikindai Gyuris család", null, "gyuris.kikinda.ottleszek.hu", "" },
                    { new Guid("adc0a58a-5b80-45fe-a736-18fec5e4d96a"), "Gyálaréti Gyuris család programnaptára", "Gyálaréti Gyuris család", null, "gyuris.gyalaret.ottleszek.hu", "" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("08af18b0-1d3c-411e-a692-d81c8d40cb75"), "nevelés" },
                    { new Guid("3274bb0c-beff-4511-9fba-6e440236c493"), "ifjúság" },
                    { new Guid("3cd6fca2-5a0c-4950-88bc-496ff7f94eaa"), "férfi identitás" },
                    { new Guid("72c62fda-9ace-4ee7-95ad-28225327f3c6"), "művelődés" },
                    { new Guid("dc5fcd4e-8e87-47e0-a944-c94a1c84b2d2"), "házasság" },
                    { new Guid("f0e51975-494e-4467-b00a-66a3c56c9972"), "vallás" }
                });

            migrationBuilder.InsertData(
                table: "PublicSpace",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1cd972c8-4f03-46af-879c-b353faa8669a"), "tér" },
                    { new Guid("54ea22f4-d013-4cb4-8709-6aeeb022c975"), "utca" },
                    { new Guid("8e757ad5-f7ca-4806-9be2-d6ba3f0aa4a1"), "köz" },
                    { new Guid("ac4180df-f964-4d83-ae49-2afe31bb8579"), "sugárút" },
                    { new Guid("b290bb88-c3d3-40e8-934a-22aed8b4b329"), "út" }
                });

            migrationBuilder.InsertData(
                table: "RegisteredUser",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("13fce26a-556f-4b02-a6ad-04e86aac26c1"), "Anikó", "Szászi" },
                    { new Guid("93b1acbd-6333-4f90-8fa2-a6d58969708c"), "Balázs", "Szászi" },
                    { new Guid("d18f16be-c8d7-4941-bf85-fcf69821fee1"), "Jenei", "Kornél" },
                    { new Guid("e0afccfe-364c-436e-9306-88187e8344bd"), "Katalin", "Gyurisné Hutter" },
                    { new Guid("fc10650f-efbf-42a0-91bc-ee326f4c9453"), "Csaba", "Gyuris" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "Door", "Floor", "House", "Locality", "PostalCode", "PublicScapeID", "PublicSpaceName" },
                values: new object[,]
                {
                    { new Guid("25602120-2ffd-45e5-ac57-dbaa87b6967a"), -1, -1, 50, "Szeged", 6710, new Guid("8e757ad5-f7ca-4806-9be2-d6ba3f0aa4a1"), "Kapisztrán" },
                    { new Guid("42f26620-e28f-48f0-bd51-4dbf5f906c06"), -1, -1, 33, "Szeged", 6757, new Guid("54ea22f4-d013-4cb4-8709-6aeeb022c975"), "Koszorú utca" },
                    { new Guid("b0f835de-2e5d-44a1-a619-c52f07865ce8"), -1, -1, 1, "Szeged", 6757, new Guid("54ea22f4-d013-4cb4-8709-6aeeb022c975"), "Napraforgó utca" },
                    { new Guid("e8d0aaa3-54df-4088-b680-4d4d23b97066"), -1, -1, 12, "Szeged", 6720, new Guid("1cd972c8-4f03-46af-879c-b353faa8669a"), "Dugonics" },
                    { new Guid("ee9ff0d5-6cf8-4a6f-9a2e-3c85b621bbf8"), -1, -1, 49, "Szeged", 6757, new Guid("54ea22f4-d013-4cb4-8709-6aeeb022c975"), "Koszorú utca" }
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "Description", "Name", "OrganizationCategoryId", "Url", "Website" },
                values: new object[,]
                {
                    { new Guid("1344c061-2e5c-4ddc-893b-056f17183c14"), "Gyálaréten működő meditációs csoprot amely a Jézus imát gyakorolja", "Gyálaréti meditációs imacsoport", new Guid("f0e51975-494e-4467-b00a-66a3c56c9972"), "meditacio.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("3ba794ad-ef38-465a-b983-3af4e5982f06"), "Munkásmisszió, vezetői kör", "Munkáasmisszió", new Guid("f0e51975-494e-4467-b00a-66a3c56c9972"), "vezetok.munkasmisszio.ottleszek.hu", "" },
                    { new Guid("4e99d6f3-5720-4821-832a-aa7c4ce582e6"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség", new Guid("f0e51975-494e-4467-b00a-66a3c56c9972"), "korhazi-lelekszseg.pasztoralis-helynokseg.szeged-csanádi - egyhazmegye.ottleszek.hu", "" },
                    { new Guid("5b05c3dc-769e-403b-9f81-5d0109c6c642"), "Gyálaréten működő férfi sátor közösség", "Gyálaréti férfi sátor", new Guid("3cd6fca2-5a0c-4950-88bc-496ff7f94eaa"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("772abf07-d0dd-4628-b177-55b54c322003"), "Szentmihályi művelődési ház", "Szentmihályi művelődési ház", new Guid("72c62fda-9ace-4ee7-95ad-28225327f3c6"), "muvelodesihaz.szeged-szentmihaly.ottleszek.hu", "" },
                    { new Guid("8d96f87f-4067-4370-a2f4-74062754e328"), "Szeged-Csanád egyházmegye Pasztorális helynöksége", "Szeged-Csanád egyházmegye Pasztorális helynökség", new Guid("f0e51975-494e-4467-b00a-66a3c56c9972"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("ad839041-43cd-454e-acb7-c895d757b8b1"), "Magyarorszagi férfi sátor közösség", "Férfi sátor", new Guid("3cd6fca2-5a0c-4950-88bc-496ff7f94eaa"), "ferfisator.filia.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("c39517de-6ffe-4fc2-9072-93bcd77d2a36"), "Gyálaréti filához tartozó csaladcsoport", "Gyálaréti családcsoport", new Guid("f0e51975-494e-4467-b00a-66a3c56c9972"), "csaladcsoport.flila.szeged-gyalaret.ottleszek.hu", "" },
                    { new Guid("c8e7e94d-eae1-4ce9-96d2-0dde187ebfe5"), "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció, ", "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció", new Guid("f0e51975-494e-4467-b00a-66a3c56c9972"), "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu", "" },
                    { new Guid("d1a192af-77dd-4634-b938-8ee5ebd7eddd"), "Gyálaréti művelődési ház", "Gyálaréti művelődési ház", new Guid("72c62fda-9ace-4ee7-95ad-28225327f3c6"), "szeged-gyalaret.szeged-gyalaret.ottleszek.hu", "" }
                });

            migrationBuilder.InsertData(
                table: "OrganizationAdminUser",
                columns: new[] { "Id", "AdminId", "OrganizationId" },
                values: new object[,]
                {
                    { new Guid("0ce02714-a5b8-46af-89ef-a8bc770adfa5"), new Guid("fc10650f-efbf-42a0-91bc-ee326f4c9453"), new Guid("ad839041-43cd-454e-acb7-c895d757b8b1") },
                    { new Guid("4185938b-5c5a-4c5f-acdf-5392ce5f53b3"), new Guid("e0afccfe-364c-436e-9306-88187e8344bd"), new Guid("1344c061-2e5c-4ddc-893b-056f17183c14") },
                    { new Guid("ec0cf70c-79ae-4861-b93f-3d5225797795"), new Guid("93b1acbd-6333-4f90-8fa2-a6d58969708c"), new Guid("4e99d6f3-5720-4821-832a-aa7c4ce582e6") }
                });

            migrationBuilder.InsertData(
                table: "OrgranizationProgram",
                columns: new[] { "Id", "AddressId", "End", "IsDeffered", "IsPublic", "OrganizationOwnerId", "ProgramOwnerId", "Start", "Title" },
                values: new object[,]
                {
                    { new Guid("387378db-b9d8-476c-8f2f-c8bb8af10f3c"), new Guid("e8d0aaa3-54df-4088-b680-4d4d23b97066"), new DateTime(2024, 6, 11, 12, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("4e99d6f3-5720-4821-832a-aa7c4ce582e6"), new Guid("e0afccfe-364c-436e-9306-88187e8344bd"), new DateTime(2024, 6, 10, 18, 0, 0, 0, DateTimeKind.Local), "Lelkigyakorlat" },
                    { new Guid("c395bb6b-9424-486d-8004-947a98af713c"), new Guid("ee9ff0d5-6cf8-4a6f-9a2e-3c85b621bbf8"), null, false, true, new Guid("1344c061-2e5c-4ddc-893b-056f17183c14"), new Guid("93b1acbd-6333-4f90-8fa2-a6d58969708c"), new DateTime(2024, 5, 16, 20, 30, 0, 0, DateTimeKind.Local), "Meditáció" },
                    { new Guid("ee0e79db-3cd9-42fe-aad8-5b35b672e97f"), new Guid("ee9ff0d5-6cf8-4a6f-9a2e-3c85b621bbf8"), new DateTime(2024, 6, 16, 20, 0, 0, 0, DateTimeKind.Local), false, true, new Guid("5b05c3dc-769e-403b-9f81-5d0109c6c642"), new Guid("fc10650f-efbf-42a0-91bc-ee326f4c9453"), new DateTime(2024, 6, 16, 18, 0, 0, 0, DateTimeKind.Local), "Férfi sátor tréning" }
                });

            migrationBuilder.InsertData(
                table: "Participation",
                columns: new[] { "Id", "Evaluation", "OrganizationProgramId", "RegisteredUserId" },
                values: new object[,]
                {
                    { new Guid("5c6fe2b8-d989-4358-8d81-5100e750a8f3"), -1, new Guid("387378db-b9d8-476c-8f2f-c8bb8af10f3c"), new Guid("e0afccfe-364c-436e-9306-88187e8344bd") },
                    { new Guid("81634e17-cfbb-41f2-8bdd-2957c7fcf101"), -1, new Guid("387378db-b9d8-476c-8f2f-c8bb8af10f3c"), new Guid("93b1acbd-6333-4f90-8fa2-a6d58969708c") },
                    { new Guid("c25b1d5c-f6e4-411d-806e-c6411db9fcf2"), -1, new Guid("ee0e79db-3cd9-42fe-aad8-5b35b672e97f"), new Guid("e0afccfe-364c-436e-9306-88187e8344bd") },
                    { new Guid("d2309d8a-17cd-4edd-a7f4-e3affe218fdf"), 9, new Guid("c395bb6b-9424-486d-8004-947a98af713c"), new Guid("fc10650f-efbf-42a0-91bc-ee326f4c9453") },
                    { new Guid("d8df8595-2e38-496b-8e99-ae348fcc4416"), 9, new Guid("c395bb6b-9424-486d-8004-947a98af713c"), new Guid("93b1acbd-6333-4f90-8fa2-a6d58969708c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PublicScapeID",
                table: "Address",
                column: "PublicScapeID");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_OrganizationCategoryId",
                table: "Organization",
                column: "OrganizationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAdminUser_AdminId",
                table: "OrganizationAdminUser",
                column: "AdminId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAdminUser_OrganizationId",
                table: "OrganizationAdminUser",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgranizationProgram_AddressId",
                table: "OrgranizationProgram",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgranizationProgram_OrganizationOwnerId",
                table: "OrgranizationProgram",
                column: "OrganizationOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgranizationProgram_ProgramOwnerId",
                table: "OrgranizationProgram",
                column: "ProgramOwnerId");

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
