using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(a => a.Text)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
