using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistance.Configurations
{
    internal class ColorConfiguration:IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");
            builder
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}
