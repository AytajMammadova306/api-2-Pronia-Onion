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
    internal class SizeConfiguration:IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");
            builder
                .HasIndex(s => s.Name)
                .IsUnique();
        }
    }
}
