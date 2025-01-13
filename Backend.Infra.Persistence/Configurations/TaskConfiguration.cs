using Entities = Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infra.Persistence.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Entities.Task>
{
    public void Configure(EntityTypeBuilder<Entities.Task> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.Priority)
            .HasConversion<string>();

        builder.Property(x => x.Status)
            .HasConversion<string>();

        builder.Property(x => x.Date);

        builder.HasOne(x => x.User).WithMany(x => x.Tasks)
            .HasForeignKey(x => x.UserId);

        builder.HasIndex(x => x.UserId, "fk_task_user_idx");
    }
}
