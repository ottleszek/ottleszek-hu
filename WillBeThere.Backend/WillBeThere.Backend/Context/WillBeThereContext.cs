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
        public DbSet<OrganizationCategory> OrganizationCategory { get; set; }
        public DbSet<RegisteredUser> RegisteredUser { get; set; }
        public DbSet<OrganizationAdminUser> OrganizationAdminUser { get; set; }
        public DbSet<Participation> Participation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:N Organization - OrgranizationProgram
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.OrganizationPrograms)
                .WithOne(op => op.Organization)
                .HasForeignKey(op => op.OrganizationOwnerId)
                .IsRequired(true);
            // 1:N OrganizationAdminUser - OrganizationProgram
            modelBuilder.Entity<OrganizationAdminUser>()
                .HasMany(oau => oau.OrganizationPrograms)
                .WithOne(op => op.UserOwner)
                .HasForeignKey(op => op.ProgramOwnerId)
                .IsRequired(true);
            // 1:N Address - OrganizationPrograms
            modelBuilder.Entity<Address>()
                .HasMany(a => a.OrganizationPrograms)
                .WithOne(op => op.Address)
                .HasForeignKey(a => a.AddressId)
                .IsRequired(false);
            // 1:N PublicSpace - Address
            modelBuilder.Entity<PublicSpace>()
                .HasMany(ps => ps.Addresses)
                .WithOne(a => a.PublicSpace)
                .HasForeignKey(ps => ps.PublicScapeID)
                .IsRequired(true);
            // 1:N OrganizationCategory - Organization
            modelBuilder.Entity<OrganizationCategory>()
                .HasMany(oc => oc.Organizations)
                .WithOne(o => o.OrganizationCategory)
                .HasForeignKey(o => o.OrganizationCategoryId)
                .IsRequired(false);
            // N:M OeganizationProgram - RegisteredUser == Participation
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
            // 1:1 RegisteredUser - OrgranizationAdminUser
            modelBuilder.Entity<RegisteredUser>()
                .HasOne(ru => ru.OrganizationAdminUser)
                .WithOne(oau => oau.Admin)
                .HasForeignKey<OrganizationAdminUser>(oau => oau.AdminId)
                .IsRequired(false);
            // 1:N Organization - OrganizationAdminUser
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.OrganizationAdminUsers)
                .WithOne(oau => oau.Organization)
                .HasForeignKey(oau  => oau.OrganizationId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }


    }
}
