using Chat.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Infra.Data.Mappings
{
    public class UserInterestMap : IEntityTypeConfiguration<UserInterest>
    {
        public void Configure(EntityTypeBuilder<UserInterest> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .HasOne(b => b.User)
                .WithMany(b => b.UserInterests)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(b => b.Interest)
                .WithMany(b => b.UserInterests)
                .HasForeignKey(b => b.InterestId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
