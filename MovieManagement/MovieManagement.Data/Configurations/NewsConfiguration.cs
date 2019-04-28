﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Data.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(a => a.Title)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(a => a.Text)
               .IsRequired();
        }
    }
}
