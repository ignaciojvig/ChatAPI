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

            Guid userInterest1 = new Guid("24E1ABE0-B74C-409C-A14D-06827C322273");
            Guid userInterest2 = new Guid("CAB8B16D-60B0-4EC2-82BF-01304D2DCB05");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = thorinId,
                    Name = "Thorin Oakenshield",
                    Username = "thorin123",
                    Password = "oaken123",
                    Role = "Admin",
                },
                new User
                {
                    Id = bilboId,
                    Name = "Bilbo Baggings",
                    Username = "bilbo123",
                    Password = "baggings123",
                    Role = "Admin",
                });

            modelBuilder.Entity<Interest>().HasData(
                new Interest
                {
                    Id = thorinInterestId,
                    Name = "Kick Smaug out of the Lonely Mountain"
                },
                new Interest
                {
                    Id = bilboInterestId,
                    Name = "Chill in the Shire"
                });

            modelBuilder.Entity<UserInterest>().HasData(
                new UserInterest
                {
                    Id = userInterest1,
                    UserId = thorinId,
                    InterestId = thorinInterestId
                },
                new UserInterest
                {
                    Id = userInterest2,
                    UserId = bilboId,
                    InterestId = bilboInterestId
                });
        }
    }
}
