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
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Url = table.Column<string>(type: "longtext", nullable: false),
                    Website = table.Column<string>(type: "longtext", nullable: false),
                    OrgranizationRigth = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProgramCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
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
                        name: "FK_OrgranizationProgram_Organization_OrganizationOwnerId",
                        column: x => x.OrganizationOwnerId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrgranizationProgram_RegisteredUser_ProgramOwnerId",
                        column: x => x.ProgramOwnerId,
                        principalTable: "RegisteredUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationProgramCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationProgramId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationProgramCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationProgramCategories_OrgranizationProgram_Organizat~",
                        column: x => x.OrganizationProgramId,
                        principalTable: "OrgranizationProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationProgramCategories_ProgramCategory_OrganizationPr~",
                        column: x => x.OrganizationProgramId,
                        principalTable: "ProgramCategory",
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
                table: "ProgramCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("46dee8f4-2b0e-47c0-8827-332e494c2e14"), "nevelés" },
                    { new Guid("839b4139-9106-47f3-80ff-c0804d3cf029"), "férfi identitás" },
                    { new Guid("ca584071-2dfe-4cf6-96b8-4729bc0e380d"), "házasság" },
                    { new Guid("f2ea3d2f-13f2-4140-bf90-999995da865f"), "ifjúság" },
                    { new Guid("f4d629ed-f9de-4974-a296-a26cfba12dbe"), "vallás" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_PublicScapeID",
                table: "Address",
                column: "PublicScapeID");

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
                name: "IX_OrganizationProgramCategories_OrganizationProgramId",
                table: "OrganizationProgramCategories",
                column: "OrganizationProgramId");

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
                name: "OrganizationAdminUser");

            migrationBuilder.DropTable(
                name: "OrganizationProgramCategories");

            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "ProgramCategory");

            migrationBuilder.DropTable(
                name: "OrgranizationProgram");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "RegisteredUser");

            migrationBuilder.DropTable(
                name: "PublicSpace");
        }
    }
}
