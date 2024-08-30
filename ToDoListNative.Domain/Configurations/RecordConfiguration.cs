using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ToDoListNative.Domain.Models.Entities;

namespace ToDoListNative.Domain.Configurations
{
    
    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Number)
                .IsRequired();

            builder.Property(b => b.Title)
                .IsRequired();

            builder.Property(b => b.Content)
                .IsRequired();

            builder.Property(b => b.IsComplete)
                .IsRequired();
        }
    }
}
