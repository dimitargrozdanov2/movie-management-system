using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
