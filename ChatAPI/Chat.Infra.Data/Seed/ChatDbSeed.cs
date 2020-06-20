using Chat.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Infra.Data.Seed
{
    public static class ChatDbSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid thorinId = new Guid("D17FEE25-322C-40E9-A18F-98B2F03FAF81");
            Guid bilboId = new Guid("6157CD72-B417-42A0-B109-F28AD7678833");

            Guid thorinInterestId = new Guid("7956B9F9-95E6-4D71-AC4B-511A4DF952BC");
            Guid bilboInterestId = new Guid("0394B33B-DC5E-4924-A565-0C4CB876D7FE");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = thorinId,
                    Name = "Thorin Oakenshield"
                },
                new User
                {
                    UserId = bilboId,
                    Name = "Bilbo Baggings"
                });

            modelBuilder.Entity<Interest>().HasData(
                new Interest
                {
                    InterestId = thorinInterestId,
                    Name = "Kick Smaug out of the Lonely Mountain"
                },
                new Interest
                {
                    InterestId = bilboInterestId,
                    Name = "Chill in the Shire"
                });

            modelBuilder.Entity<UserInterest>().HasData(
                new UserInterest
                {
                    UserId = thorinId,
                    InterestId = thorinInterestId
                },
                new UserInterest
                {
                    UserId = bilboId,
                    InterestId = bilboInterestId
                });
        }
    }
}
