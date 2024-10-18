using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.DataAccess.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("UserId");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.FirstName).HasColumnName("FirstName");
        builder.Property(x => x.LastName).HasColumnName("LastName");
        builder.Property(x => x.Password).HasColumnName("Password");
        builder.Property(x => x.Email).HasColumnName("Email");
        builder.Property(x => x.UserName).HasColumnName("UserName");

        builder.HasMany(x => x.Posts)
            .WithOne(x => x.Author)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.User.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
