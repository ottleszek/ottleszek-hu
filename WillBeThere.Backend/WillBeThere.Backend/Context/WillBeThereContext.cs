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
        public DbSet<ProgramCategory> ProgramCategory { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrganizationProgramCategories> OrganizationProgramCategories { get; set; }
        public DbSet<RegisteredUser> RegisteredUser { get; set; }
        public DbSet<OrganizationAdminUser> OrganizationAdminUser { get; set; }
        public DbSet<Participation> Participation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:N Organization - OrgranizationProgram
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Programs)
                .WithOne(op => op.Organization)
                .HasForeignKey(op => op.OrganizationOwnerId)
                .IsRequired(true);
            // 1:N RegisteredUser - OrganizationProgram
            modelBuilder.Entity<RegisteredUser>()
                .HasMany(ru => ru.OrganizationPrograms)
                .WithOne(op => op.ProgramOwner)
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
            // N:M ProgramCategory - OrganizationProgram == OrganizationProgramCategories
            modelBuilder.Entity<OrganizationProgramCategories>()
                .HasOne(opc => opc.OrganizationProgram)
                .WithMany(op => op.ProgramCategories)
                .HasForeignKey(opc => opc.OrganizationProgramId)
                .IsRequired(true);
            modelBuilder.Entity<OrganizationProgramCategories>()
                .HasOne(opc => opc.ProgramCategory)
                .WithMany(pc => pc.OrganizationPrograms)
                .HasForeignKey(opc => opc.OrganizationProgramId)
                .IsRequired(true);
            // N:M OeganizationProgram - RegisteredUser == Participation
            modelBuilder.Entity<Participation>()
                .HasOne(ope => ope.OrganizationProgram)
                .WithMany(op => op.ProgrammeParticipants)
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
                .HasMany(o => o.OranizationAdminUsers)
                .WithOne(oau => oau.Organization)
                .HasForeignKey(oau  => oau.OrganizationId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }


    }
}
