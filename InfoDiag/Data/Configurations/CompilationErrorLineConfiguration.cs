using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CompilationErrorLineConfiguration : IEntityTypeConfiguration<CompilationErrorLine>
    {
        public void Configure(EntityTypeBuilder<CompilationErrorLine> builder)
        {
            builder.ToTable("CompilationErrorLine");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
