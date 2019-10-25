using System;
using Constants.Enums;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (UserRole)Enum.Parse(typeof(UserRole), v));

            builder.HasAlternateKey(x => x.Email);

            builder.HasMany(x => x.Employees).WithOne(x => x.Manager).HasForeignKey(x => x.ManagerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
