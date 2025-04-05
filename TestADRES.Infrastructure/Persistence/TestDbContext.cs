using Microsoft.EntityFrameworkCore;
using TestADRES.Domain.Entities;

namespace TestADRES.Infrastructure.Persistence
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<RequirementStatus> RequirementStatuses { get; set; }
        public DbSet<HistoricalRequirement> HistoricalRequirements { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Requirement>()
                .HasOne(r => r.Supplier)
                .WithMany(s => s.Requirements)
                .HasForeignKey(r => r.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Requirement>()
                .HasOne(r => r.RequirementStatus)
                .WithMany(rs => rs.Requirements)
                .HasForeignKey(r => r.RequirementStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Requirement>()
                .HasOne(r => r.User)
                .WithMany(u => u.Requirements)
                .HasForeignKey(r => r.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
