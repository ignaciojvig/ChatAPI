using Chat.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.UserId);

            builder
                .Property(b => b.UserId)
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
