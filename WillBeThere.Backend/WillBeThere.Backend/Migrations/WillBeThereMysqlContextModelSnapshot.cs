﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WillBeThere.Backend.Context;

#nullable disable

namespace WillBeThere.Backend.Migrations
{
    [DbContext(typeof(WillBeThereMysqlContext))]
    partial class WillBeThereMysqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WillBeThere.Shared.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Door")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("House")
                        .HasColumnType("int");

                    b.Property<string>("Locality")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<Guid>("PublicScapeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("PublicSpaceName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("PublicScapeId");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fef36d7e-2819-4535-b6f7-3e19a35f7889"),
                            Door = -1,
                            Floor = -1,
                            House = 1,
                            Locality = "Szeged",
                            PostalCode = 6757,
                            PublicScapeId = new Guid("a2b0a9e8-3b9d-485b-977d-e8c5eab51e3c"),
                            PublicSpaceName = "Napraforgó utca"
                        },
                        new
                        {
                            Id = new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"),
                            Door = -1,
                            Floor = -1,
                            House = 49,
                            Locality = "Szeged",
                            PostalCode = 6757,
                            PublicScapeId = new Guid("a2b0a9e8-3b9d-485b-977d-e8c5eab51e3c"),
                            PublicSpaceName = "Koszorú utca"
                        },
                        new
                        {
                            Id = new Guid("f27bbab2-f078-43d3-93bf-162c4bb02999"),
                            Door = -1,
                            Floor = -1,
                            House = 33,
                            Locality = "Szeged",
                            PostalCode = 6757,
                            PublicScapeId = new Guid("a2b0a9e8-3b9d-485b-977d-e8c5eab51e3c"),
                            PublicSpaceName = "Koszorú utca"
                        },
                        new
                        {
                            Id = new Guid("ebf98c69-6894-4659-8bd9-5f6639e4c296"),
                            Door = -1,
                            Floor = -1,
                            House = 50,
                            Locality = "Szeged",
                            PostalCode = 6710,
                            PublicScapeId = new Guid("558ffa2d-12c2-4268-b6ec-313d3fa6a53b"),
                            PublicSpaceName = "Kapisztrán"
                        },
                        new
                        {
                            Id = new Guid("04bb57c1-673f-468d-bd70-a4b46a95a278"),
                            Door = -1,
                            Floor = -1,
                            House = 12,
                            Locality = "Szeged",
                            PostalCode = 6720,
                            PublicScapeId = new Guid("7e16a7a4-0065-4e9d-864b-489086bb845b"),
                            PublicSpaceName = "Dugonics"
                        });
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.Editor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Editor");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<Guid?>("OrganizationCategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationCategoryId");

                    b.ToTable("Organization");

                    b.HasData(
                        new
                        {
                            Id = new Guid("240fc663-c2d8-491b-973a-c1bde3e1b1f2"),
                            Description = "Gyálaréti Gyuris család programnaptára",
                            Name = "Gyálaréti Gyuris család",
                            Url = "gyuris-gyalaret",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("943e5be7-da40-426b-83af-96b112f48e51"),
                            Description = "Kikindáról elszármazott Gyuris Család",
                            Name = "Kikindai Gyuris család",
                            Url = "gyuris-kikinda",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("afd2b545-5924-4540-a8e6-cfeeda57ee50"),
                            Description = "Gyálaréten működő férfi sátor közösség",
                            Name = "Gyálaréti férfi sátor",
                            OrganizationCategoryId = new Guid("f27d8a99-5e11-4ed8-87ae-57d3fa17b8e5"),
                            Url = "ferfisator.filia.szeged-gyalaret.ottleszek.hu",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"),
                            Description = "Magyarorszagi férfi sátor közösség",
                            Name = "Férfi sátor",
                            OrganizationCategoryId = new Guid("f27d8a99-5e11-4ed8-87ae-57d3fa17b8e5"),
                            Url = "ferfisator.filia.szeged-gyalaret.ottleszek.hu",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("825da4a3-1b52-4586-8be4-e7d9e78a450b"),
                            Description = "Gyálaréten működő meditációs csoprot amely a Jézus imát gyakorolja",
                            Name = "Gyálaréti meditációs imacsoport",
                            OrganizationCategoryId = new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"),
                            Url = "meditacio.filia.szeged-gyalaret.ottleszek.hu",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("08af2a62-50ba-4fb3-b181-f4a225062060"),
                            Description = "Gyálaréti filához tartozó csaladcsoport",
                            Name = "Gyálaréti családcsoport",
                            OrganizationCategoryId = new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"),
                            Url = "csaladcsoport.flila.szeged-gyalaret.ottleszek.hu",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("4b9eda5b-6307-4815-bd7c-6aa372bd4abb"),
                            Description = "Gyálaréti művelődési ház",
                            Name = "Gyálaréti művelődési ház",
                            OrganizationCategoryId = new Guid("04d62928-1cba-4540-8eab-cc582d29a4c4"),
                            Url = "szeged-gyalaret.szeged-gyalaret.ottleszek.hu",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("5c7cfb01-e559-49de-9eaa-0c338832376f"),
                            Description = "Szentmihályi művelődési ház",
                            Name = "Szentmihályi művelődési ház",
                            OrganizationCategoryId = new Guid("04d62928-1cba-4540-8eab-cc582d29a4c4"),
                            Url = "muvelodesihaz.szeged-szentmihaly.ottleszek.hu",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("08f17caf-65f1-4faa-8691-458c0f09c798"),
                            Description = "Szeged-Csanád Egyházmegye Pasztorális helynöksége",
                            Name = "Szeged-Csanád Egyházmegye Pasztorális helynökség",
                            OrganizationCategoryId = new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"),
                            Url = "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("902a4e5b-da50-4a76-b48a-d4beeacb4c43"),
                            Description = "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció, ",
                            Name = "Szeged-Csanád egyházmegye Pasztorális helynökség - Családpasztoráció",
                            OrganizationCategoryId = new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"),
                            Url = "pasztoralis-helynokseg.szeged-csanádi-egyhazmegye.ottleszek.hu",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("4a5547f6-6051-4e6f-b933-ebf753801af0"),
                            Description = "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség",
                            Name = "Szeged-Csanád egyházmegye Pasztorális helynökség - Korházi lelkészség",
                            OrganizationCategoryId = new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"),
                            Url = "korhazi-lelekszseg.pasztoralis-helynokseg.szeged-csanádi - egyhazmegye.ottleszek.hu",
                            Website = ""
                        },
                        new
                        {
                            Id = new Guid("02461bba-032e-4e65-bc2f-b009c9619bef"),
                            Description = "Munkásmisszió, vezetői kör",
                            Name = "Munkáasmisszió",
                            OrganizationCategoryId = new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"),
                            Url = "vezetok.munkasmisszio.ottleszek.hu",
                            Website = ""
                        });
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.OrganizationCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ProgramCategory");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2301c8ad-052a-461f-a2c3-8ea4c24a777d"),
                            Name = "vallás"
                        },
                        new
                        {
                            Id = new Guid("e79b56d8-4475-4a2a-af44-fccd7199c895"),
                            Name = "nevelés"
                        },
                        new
                        {
                            Id = new Guid("181552e9-589c-48cc-b5ce-81718c80d9d2"),
                            Name = "házasság"
                        },
                        new
                        {
                            Id = new Guid("f27d8a99-5e11-4ed8-87ae-57d3fa17b8e5"),
                            Name = "férfi identitás"
                        },
                        new
                        {
                            Id = new Guid("2bda7ec3-0f31-4c85-9385-70e6d0de0826"),
                            Name = "ifjúság"
                        },
                        new
                        {
                            Id = new Guid("04d62928-1cba-4540-8eab-cc582d29a4c4"),
                            Name = "művelődés"
                        });
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.OrganizationEditor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("OrganizationEditor");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.OrganizationProgram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeffered")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProgramOwnerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("OrgranizationProgram");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ebbb478d-2d53-4535-ab40-fa4c902b6279"),
                            AddressId = new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"),
                            Description = "Csendes ima.",
                            IsDeffered = false,
                            IsPublic = true,
                            OrganizationId = new Guid("825da4a3-1b52-4586-8be4-e7d9e78a450b"),
                            ProgramOwnerId = new Guid("3ef41046-3367-4871-89e5-e14c75ea54cb"),
                            Start = new DateTime(2024, 8, 7, 20, 30, 0, 0, DateTimeKind.Local),
                            Title = "Meditáció"
                        },
                        new
                        {
                            Id = new Guid("c7db0031-8e2a-431a-9ba1-ae24cb6d286d"),
                            AddressId = new Guid("04bb57c1-673f-468d-bd70-a4b46a95a278"),
                            Description = "Csendes lelkigyakorlat felnőtteknek.",
                            End = new DateTime(2024, 9, 2, 12, 0, 0, 0, DateTimeKind.Local),
                            IsDeffered = false,
                            IsPublic = true,
                            OrganizationId = new Guid("4a5547f6-6051-4e6f-b933-ebf753801af0"),
                            ProgramOwnerId = new Guid("a20a11c4-326d-427f-9a47-2378f7f6bf87"),
                            Start = new DateTime(2024, 9, 1, 18, 0, 0, 0, DateTimeKind.Local),
                            Title = "Lelkigyakorlat"
                        },
                        new
                        {
                            Id = new Guid("62dc0fa9-e3b5-426b-9c87-51c528165ce5"),
                            AddressId = new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"),
                            Description = "Apasebek tréning.",
                            End = new DateTime(2024, 9, 7, 20, 0, 0, 0, DateTimeKind.Local),
                            IsDeffered = false,
                            IsPublic = true,
                            OrganizationId = new Guid("afd2b545-5924-4540-a8e6-cfeeda57ee50"),
                            ProgramOwnerId = new Guid("2b623efc-55a8-4303-84bb-c091f78b5bfc"),
                            Start = new DateTime(2024, 9, 7, 18, 0, 0, 0, DateTimeKind.Local),
                            Title = "Férfi sátor tréning"
                        },
                        new
                        {
                            Id = new Guid("40cffa31-e2c0-4c8c-8196-101a1457803f"),
                            AddressId = new Guid("04bb57c1-673f-468d-bd70-a4b46a95a278"),
                            Description = "Lányoknak...",
                            End = new DateTime(2024, 11, 17, 21, 0, 0, 0, DateTimeKind.Local),
                            IsDeffered = false,
                            IsPublic = true,
                            OrganizationId = new Guid("08f17caf-65f1-4faa-8691-458c0f09c798"),
                            ProgramOwnerId = new Guid("f1c3af2a-34c0-4d15-a144-000ee2d09752"),
                            Start = new DateTime(2024, 11, 17, 15, 0, 0, 0, DateTimeKind.Local),
                            Title = "Ciklus show"
                        },
                        new
                        {
                            Id = new Guid("eb8aaa97-688d-4c4f-b5e6-5cf11183e3e8"),
                            AddressId = new Guid("f27bbab2-f078-43d3-93bf-162c4bb02999"),
                            Description = "Délalföldi",
                            End = new DateTime(2024, 9, 2, 2, 30, 0, 0, DateTimeKind.Local),
                            IsDeffered = false,
                            IsPublic = true,
                            OrganizationId = new Guid("4b9eda5b-6307-4815-bd7c-6aa372bd4abb"),
                            ProgramOwnerId = new Guid("430c750e-f3b8-4bbe-a788-2a3a591b8486"),
                            Start = new DateTime(2024, 9, 1, 21, 0, 0, 0, DateTimeKind.Local),
                            Title = "Táncház"
                        },
                        new
                        {
                            Id = new Guid("a394e533-03a2-41a7-96e9-a38dd811e9d7"),
                            AddressId = new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"),
                            Description = "Férfiaknak",
                            IsDeffered = false,
                            IsPublic = false,
                            OrganizationId = new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"),
                            ProgramOwnerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Start = new DateTime(2024, 7, 7, 18, 0, 0, 0, DateTimeKind.Local),
                            Title = "Férfi sátor"
                        },
                        new
                        {
                            Id = new Guid("e4811177-c24b-4e42-b283-2fa6fd7bd41b"),
                            AddressId = new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"),
                            Description = "Férfiaknak",
                            IsDeffered = false,
                            IsPublic = false,
                            OrganizationId = new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"),
                            ProgramOwnerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Start = new DateTime(2024, 8, 3, 18, 0, 0, 0, DateTimeKind.Local),
                            Title = "Férfi sátor"
                        },
                        new
                        {
                            Id = new Guid("de58cefe-0229-463d-b1d3-910ef04aaff8"),
                            AddressId = new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"),
                            Description = "Férfiaknak",
                            End = new DateTime(2024, 9, 9, 21, 0, 0, 0, DateTimeKind.Local),
                            IsDeffered = false,
                            IsPublic = false,
                            OrganizationId = new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"),
                            ProgramOwnerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Start = new DateTime(2024, 9, 9, 18, 0, 0, 0, DateTimeKind.Local),
                            Title = "Férfi sátor"
                        },
                        new
                        {
                            Id = new Guid("ca1f0fa4-8cde-4d3f-a53b-ae764248fd05"),
                            AddressId = new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"),
                            Description = "Családoknak",
                            End = new DateTime(2024, 9, 2, 1, 30, 0, 0, DateTimeKind.Local),
                            IsDeffered = false,
                            IsPublic = false,
                            OrganizationId = new Guid("08af2a62-50ba-4fb3-b181-f4a225062060"),
                            ProgramOwnerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Start = new DateTime(2024, 9, 1, 21, 0, 0, 0, DateTimeKind.Local),
                            Title = "Családcsoport"
                        },
                        new
                        {
                            Id = new Guid("dab3cc94-7c82-4a63-9bd0-78b6be9b5fa7"),
                            AddressId = new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"),
                            Description = "Apasebek tréning.",
                            End = new DateTime(2024, 9, 22, 20, 0, 0, 0, DateTimeKind.Local),
                            IsDeffered = true,
                            IsPublic = true,
                            OrganizationId = new Guid("afd2b545-5924-4540-a8e6-cfeeda57ee50"),
                            ProgramOwnerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Start = new DateTime(2024, 9, 22, 18, 0, 0, 0, DateTimeKind.Local),
                            Title = "Férfi sátor tréning"
                        },
                        new
                        {
                            Id = new Guid("c7186512-480d-44d1-862c-9058ebbfff9c"),
                            AddressId = new Guid("24dbb8da-0f61-42c2-bab1-51aa74a0b34a"),
                            Description = "Férfiaknak",
                            End = new DateTime(2024, 9, 12, 21, 0, 0, 0, DateTimeKind.Local),
                            IsDeffered = true,
                            IsPublic = false,
                            OrganizationId = new Guid("fb3a1c35-1767-4f33-9bd6-64b84634e616"),
                            ProgramOwnerId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Start = new DateTime(2024, 9, 12, 18, 0, 0, 0, DateTimeKind.Local),
                            Title = "Férfi sátor"
                        });
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.Participation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Evaluation")
                        .HasColumnType("int");

                    b.Property<Guid>("OrganizationProgramId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ParticipantId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationProgramId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Participation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("293da214-d70f-49df-8690-8b925ff22e6b"),
                            Evaluation = 9,
                            OrganizationProgramId = new Guid("ebbb478d-2d53-4535-ab40-fa4c902b6279"),
                            ParticipantId = new Guid("ffbc52d2-a2f4-464c-a316-1d985c207087")
                        },
                        new
                        {
                            Id = new Guid("df075350-fbd3-4326-b4f7-ee03999e9f23"),
                            Evaluation = 9,
                            OrganizationProgramId = new Guid("ebbb478d-2d53-4535-ab40-fa4c902b6279"),
                            ParticipantId = new Guid("ae19fdc4-f8fa-417b-8c05-5aac00c9e96d")
                        },
                        new
                        {
                            Id = new Guid("7099339b-983b-4b10-89fa-3356fb648470"),
                            Evaluation = -1,
                            OrganizationProgramId = new Guid("c7db0031-8e2a-431a-9ba1-ae24cb6d286d"),
                            ParticipantId = new Guid("9daf7a9c-7334-4bf5-850e-9cc3bf4b268a")
                        },
                        new
                        {
                            Id = new Guid("d1ce8c91-a5d6-444f-a0f4-ea1cc3fd1fe5"),
                            Evaluation = -1,
                            OrganizationProgramId = new Guid("c7db0031-8e2a-431a-9ba1-ae24cb6d286d"),
                            ParticipantId = new Guid("ae19fdc4-f8fa-417b-8c05-5aac00c9e96d")
                        },
                        new
                        {
                            Id = new Guid("62a247ae-3121-4a0a-9c6c-748c01b0812c"),
                            Evaluation = -1,
                            OrganizationProgramId = new Guid("62dc0fa9-e3b5-426b-9c87-51c528165ce5"),
                            ParticipantId = new Guid("9daf7a9c-7334-4bf5-850e-9cc3bf4b268a")
                        });
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.ProgramOwner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("ProgramOwner");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2b623efc-55a8-4303-84bb-c091f78b5bfc")
                        },
                        new
                        {
                            Id = new Guid("8d29795d-fa0d-4477-bb7d-d3dc131c9c61")
                        },
                        new
                        {
                            Id = new Guid("f1c3af2a-34c0-4d15-a144-000ee2d09752")
                        },
                        new
                        {
                            Id = new Guid("3ef41046-3367-4871-89e5-e14c75ea54cb")
                        },
                        new
                        {
                            Id = new Guid("430c750e-f3b8-4bbe-a788-2a3a591b8486")
                        },
                        new
                        {
                            Id = new Guid("a20a11c4-326d-427f-9a47-2378f7f6bf87")
                        });
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.PublicSpace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("PublicSpace");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2b0a9e8-3b9d-485b-977d-e8c5eab51e3c"),
                            Name = "utca"
                        },
                        new
                        {
                            Id = new Guid("7e16a7a4-0065-4e9d-864b-489086bb845b"),
                            Name = "tér"
                        },
                        new
                        {
                            Id = new Guid("3fc82d09-3d17-424b-b0f1-159a2c83fc92"),
                            Name = "sugárút"
                        },
                        new
                        {
                            Id = new Guid("558ffa2d-12c2-4268-b6ec-313d3fa6a53b"),
                            Name = "köz"
                        },
                        new
                        {
                            Id = new Guid("46ad66d7-0014-4e2e-8b56-90d356f5b8ac"),
                            Name = "út"
                        });
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.RegisteredUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RegisteredUser");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ffbc52d2-a2f4-464c-a316-1d985c207087"),
                            FirstName = "Csaba",
                            LastName = "Gyuris"
                        },
                        new
                        {
                            Id = new Guid("ae19fdc4-f8fa-417b-8c05-5aac00c9e96d"),
                            FirstName = "Balázs",
                            LastName = "Szászi"
                        },
                        new
                        {
                            Id = new Guid("9daf7a9c-7334-4bf5-850e-9cc3bf4b268a"),
                            FirstName = "Katalin",
                            LastName = "Gyurisné Hutter"
                        },
                        new
                        {
                            Id = new Guid("39c81b90-8ed0-40b7-955a-bf74f38f7b15"),
                            FirstName = "Jenei",
                            LastName = "Kornél"
                        },
                        new
                        {
                            Id = new Guid("12997c71-c8fc-48f6-94e3-15d76abea643"),
                            FirstName = "Anikó",
                            LastName = "Szászi"
                        },
                        new
                        {
                            Id = new Guid("52979a8b-3ebf-4c4e-93c8-dd31576dc315"),
                            FirstName = "Zsuzsanna",
                            LastName = "Szabóné"
                        });
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.Address", b =>
                {
                    b.HasOne("WillBeThere.Shared.Models.PublicSpace", "PublicSpace")
                        .WithMany("Addresses")
                        .HasForeignKey("PublicScapeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PublicSpace");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.Organization", b =>
                {
                    b.HasOne("WillBeThere.Shared.Models.OrganizationCategory", "OrganizationCategory")
                        .WithMany("Organizations")
                        .HasForeignKey("OrganizationCategoryId");

                    b.Navigation("OrganizationCategory");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.OrganizationProgram", b =>
                {
                    b.HasOne("WillBeThere.Shared.Models.Address", "Address")
                        .WithMany("OrganizationPrograms")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WillBeThere.Shared.Models.Organization", "Organization")
                        .WithMany("OrganizationPrograms")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.Participation", b =>
                {
                    b.HasOne("WillBeThere.Shared.Models.OrganizationProgram", "OrganizationProgram")
                        .WithMany("Participants")
                        .HasForeignKey("OrganizationProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WillBeThere.Shared.Models.RegisteredUser", "Participant")
                        .WithMany("Paticipations")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganizationProgram");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.Address", b =>
                {
                    b.Navigation("OrganizationPrograms");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.Organization", b =>
                {
                    b.Navigation("OrganizationPrograms");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.OrganizationCategory", b =>
                {
                    b.Navigation("Organizations");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.OrganizationProgram", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.PublicSpace", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("WillBeThere.Shared.Models.RegisteredUser", b =>
                {
                    b.Navigation("Paticipations");
                });
#pragma warning restore 612, 618
        }
    }
}
