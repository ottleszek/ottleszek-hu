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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:N Organization - OrgranizationProgram
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.Programs)
                .WithOne(op => op.Orgranization)
                .HasForeignKey(op => op.OrgranizationId)
                .IsRequired(true);
            // 1:N RegisteredUser - OrganizationProgram
            modelBuilder.Entity<RegisteredUser>()
                .HasMany(ru => ru.OrganizationPrograms)
                .WithOne(op => op.RegisteredUser)
                .HasForeignKey(op => op.RegisteredUserId)
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
            // 1:N ProgramCategory - OrganizationProgram
            modelBuilder.Entity<ProgramCategory>()
                .HasMany(pc => pc.OrganizationPrograms)
                .WithOne(op => op.ProgramCategory)
                .HasForeignKey(pc => pc.ProgramCategoryId)
                .IsRequired(true);


            base.OnModelCreating(modelBuilder);
        }


    }
}
