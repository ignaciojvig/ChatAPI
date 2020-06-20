using Chat.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Infra.Data.Mappings
{
    public class InterestMap : IEntityTypeConfiguration<Interest>
    {
        public void Configure(EntityTypeBuilder<Interest> builder)
        {
            builder.HasKey(b => b.InterestId);

            builder
                .Property(b => b.InterestId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .Property(b => b.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
