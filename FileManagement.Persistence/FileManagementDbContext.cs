using System;
using System.Threading;
using System.Threading.Tasks;
using FileManagement.Domain.Common;
using FileManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileManagement.Persistence
{
    public class FileManagementDbContext : DbContext
    {
        public FileManagementDbContext(DbContextOptions<FileManagementDbContext> options) : base(options)
        {
        }
        
        public DbSet<FileDetailView> FileDetailViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FileManagementDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}