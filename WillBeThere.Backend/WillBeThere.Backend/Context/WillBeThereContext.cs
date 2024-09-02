using Microsoft.EntityFrameworkCore;
using WillBeThere.Shared.Models;

namespace WillBeThere.Backend.Context
{
    public class WillBeThereContext : DbContext
    {
        public WillBeThereContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OrganizationProgram> OrgranizationProgram { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<PublicSpace> PublicSpace { get; set; }
        public DbSet<OrganizationCategory> ProgramCategory { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<RegisteredUser> RegisteredUser { get; set; }
        public DbSet<ProgramOwner> ProgramOwner { get; set; }
        public DbSet<Participation> Participation { get; set; }
        public DbSet<Editor> Editor { get; set; }
        public DbSet<OrganizationEditor> OrganizationEditor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // 1:N OrganizationCategory - Organization
            modelBuilder.Entity<OrganizationCategory>()
                .HasMany(oc => oc.Organizations)
                .WithOne(o => o.OrganizationCategory)
                .HasForeignKey(o => o.OrganizationCategoryId)
                .IsRequired(false);
            // 1:N PublicSpace - Address
            modelBuilder.Entity<PublicSpace>()
                .HasMany(ps => ps.Addresses)
                .WithOne(a => a.PublicSpace)
                .HasForeignKey(a => a.PublicScapeId)
                .IsRequired(true);

            /*
                        // 1:N Organization - OrgranizationProgram
                        modelBuilder.Entity<Organization>()
                            .HasMany(o => o.OrganizationPrograms)
                            .WithOne(op => op.Organization)
                            .HasForeignKey(op => op.OrganizationId)
                            .IsRequired(true);
                        // 1:N OrganizationAdminUser (ProgramOwner) - OrganizationProgram
                        modelBuilder.Entity<ProgramOwner>()
                            .HasMany(oau => oau.OrganizationPrograms)
                            .WithOne(op => op.ProgramOwner)
                            .HasForeignKey(op => op.OrganizationId)
                            .IsRequired(true);
                        // 1:N Address - OrganizationPrograms
                        modelBuilder.Entity<Address>()
                            .HasMany(a => a.OrganizationPrograms)
                            .WithOne(op => op.Address)
                            .HasForeignKey(a => a.AddressId)
                            .IsRequired(false);

                        // N:M OrganizationProgram - RegisteredUser == Participation
                        modelBuilder.Entity<Participation>()
                            .HasOne(ope => ope.OrganizationProgram)
                            .WithMany(op => op.ProgramParticipants)
                            .HasForeignKey(ope => ope.OrganizationProgramId)
                            .IsRequired(true);
                        modelBuilder.Entity<Participation>()
                            .HasOne(ope => ope.Participant)
                            .WithMany(op => op.RegisteredUserPaticipations )
                            .HasForeignKey(ope => ope.RegisteredUserId)
                            .IsRequired(true);
                        // N:M Organization - OrganizationAdminUser - RegisteredUser
                        modelBuilder.Entity<ProgramOwner>()
                            .HasOne(oau => oau.EditorData)
                            .WithMany(ru => ru.AdminsOrganizations)
                            .HasForeignKey(oau => oau.AdminId)
                            .IsRequired(true);
                        modelBuilder.Entity<ProgramOwner>()
                            .HasOne(oau => oau.Organization)
                            .WithMany(o => o.OrganizationsAdmins)
                            .HasForeignKey(oau => oau.OrganizationId)
                            .IsRequired(true);
            */

            base.OnModelCreating(modelBuilder);
        }


    }
}
