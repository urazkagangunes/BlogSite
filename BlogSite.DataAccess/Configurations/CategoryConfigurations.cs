using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("CategoryId");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.Name).HasColumnName("CategoryName");

        builder
            .HasMany(x => x.Posts)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.Id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(new Category
        {
            Id = 1,
            Name = "Yazılım",
            CreatedDate = DateTime.Now
        });
    }
}
