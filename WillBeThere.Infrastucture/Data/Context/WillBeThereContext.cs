using Microsoft.EntityFrameworkCore;
using WillBeThere.Domain.Entites;

namespace WillBeThere.Infrastucture.Context
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

            // 1:1 RegisteredUser - Editor
            modelBuilder.Entity<RegisteredUser>()
                .HasOne(r => r.Editor)
                .WithOne(e => e.RegisteredUser)
                .HasForeignKey<Editor>(e => e.Id);
            // 1:1 Editor - ProgramOwner
            modelBuilder.Entity<Editor>()
                .HasOne(e => e.ProgramOwner)
                .WithOne(po => po.Editor)
                .HasForeignKey<ProgramOwner>(po => po.Id);

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
            // 1:N Organization - OrgranizationProgram
            modelBuilder.Entity<Organization>()
                .HasMany(o => o.OrganizationPrograms)
                .WithOne(op => op.Organization)
                .HasForeignKey(op => op.OrganizationId)
                .IsRequired(true);
            // 1:N Address - OrganizationPrograms
            modelBuilder.Entity<Address>()
                .HasMany(a => a.OrganizationPrograms)
                .WithOne(op => op.Address)
                .HasForeignKey(a => a.AddressId)
                .IsRequired(true);


            // N:M OrganizationProgram -= Participation =- RegisteredUser 
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.OrganizationProgram)
                .WithMany(op => op.Participants)
                .HasForeignKey(p =>p.OrganizationProgramId)
                .IsRequired(true);
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Participant)
                .WithMany(ru => ru.Paticipations)
                .HasForeignKey(p => p.ParticipantId)
                .IsRequired(true);

            // N:M Organizaton -= OrganizationEditor - Editor
            modelBuilder.Entity<OrganizationEditor>()
                .HasOne(oe => oe.Organization)
                .WithMany(o => o.Editors)
                .HasForeignKey(oe => oe.OrganizationId)
                .IsRequired(true);
            modelBuilder.Entity<OrganizationEditor>()
                .HasOne(oe => oe.Editor)
                .WithMany(e => e.Organizations)
                .HasForeignKey(oe => oe.EditorId)
                .IsRequired(true);


            base.OnModelCreating(modelBuilder);
        }


    }
}
