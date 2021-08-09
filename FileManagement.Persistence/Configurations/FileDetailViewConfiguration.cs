using FileManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileManagement.Persistence.Configurations
{
    public class FileDetailViewConfiguration : IEntityTypeConfiguration<FileDetailView>
    {
        public void Configure(EntityTypeBuilder<FileDetailView> builder)
        {
            builder.Property(x => x.FileName)
                .IsRequired();
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}