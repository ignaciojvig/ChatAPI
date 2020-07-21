using Chat.Domain.Models.Identity_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Infra.Data.Mappings
{
    public class UserRoleClaimMap : IEntityTypeConfiguration<UserRoleClaim>
    {
        public void Configure(EntityTypeBuilder<UserRoleClaim> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .HasOne(b => b.Role)
                .WithMany(b => b.RoleClaims)
                .HasForeignKey(b => b.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(b => b.Claim)
                .WithMany(b => b.RoleClaims)
                .HasForeignKey(b => b.ClaimId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
