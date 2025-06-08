using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Domain.Entities;

namespace ProductMS.Infrastructure.DataBase.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.BasePrice).IsRequired();
            builder.Property(s => s.Category).IsRequired();
            builder.Property(s => s.Images).IsRequired();
            builder.Property(s => s.State).IsRequired().HasConversion<string>();
            builder.Property(s => s.CreatedAt).IsRequired();
        }
    }

}
