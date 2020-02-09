namespace Data.Configurations
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Email);
            builder.HasMany(x => x.CourseGroupClients);
            builder.Ignore(x => x.CourseGroups);
        }
    }
}
