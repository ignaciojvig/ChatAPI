using Chat.Domain.Models;
using Chat.Domain.Models.Identity_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Chat.Infra.Data.Seed
{
    public static class ChatDbSeed
    {
        static Guid adminRoleId = new Guid("BB3AF9EE-4D11-4F2D-8C5C-5CC9D5EFD9E0");
        static Guid managerRoleId = new Guid("4DF22B4F-27CA-48B9-A1C4-185200A5CDF1");
        static Guid regularUserRoleId = new Guid("F9AE2877-5BEE-4317-BBC5-0B12F82CB854");

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedIdentityEntities();
            modelBuilder.SeedBusinessEntities();
        }

        public static void SeedIdentityEntities(this ModelBuilder modelBuilder)
        {
            Guid adminClaimId = new Guid("55B5EFFA-7EA4-4E32-9BB8-E0BDD191B86E");
            Guid usersManagementClaimId = new Guid("E66C0C35-FA66-4E69-9235-3EBA45ACA3D4");
            Guid interestsManagementClaimId = new Guid("4CAD8312-1F57-48DE-99A8-1A1A7CAA00C6");
            Guid userInterestsManagementClaimId = new Guid("C2D8AD4D-E248-48FC-BE4B-EE3EF15EAA1D");

            modelBuilder.Entity<UserClaim>().HasData(
                new UserClaim { Id = adminClaimId, Name = "AdminClaim" },
                new UserClaim { Id = usersManagementClaimId, Name = "UsersManagement" },
                new UserClaim { Id = interestsManagementClaimId, Name = "InterestsManagement" },
                new UserClaim { Id = userInterestsManagementClaimId, Name = "UserInterestsManagement" }
                );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = adminRoleId, Title = "Admin" },
                new UserRole { Id = managerRoleId, Title = "Manager" },
                new UserRole { Id = regularUserRoleId, Title = "Regular User" }
                );

            modelBuilder.Entity<UserRoleClaim>().HasData(
                new UserRoleClaim { Id = new Guid("D82ABFA6-A769-4097-8233-4ADD1D495B64"), RoleId = adminRoleId, ClaimId = adminClaimId },

                new UserRoleClaim { Id = new Guid("5169C192-5C95-4EF4-8FF6-9BF790B2A05F"), RoleId = managerRoleId, ClaimId = usersManagementClaimId },
                new UserRoleClaim { Id = new Guid("C61451F5-46E6-4F6F-A97C-70139614971E"), RoleId = managerRoleId, ClaimId = interestsManagementClaimId },
                new UserRoleClaim { Id = new Guid("6E4EB59E-5E1A-494F-B06C-2D03322C664D"), RoleId = managerRoleId, ClaimId = userInterestsManagementClaimId },

                new UserRoleClaim { Id = new Guid("5850951A-F951-492E-8BC7-3767CD7AECC5"), RoleId = regularUserRoleId, ClaimId = interestsManagementClaimId }
                );
        }

        public static void SeedBusinessEntities(this ModelBuilder modelBuilder)
        {
            Guid thorinId = new Guid("D17FEE25-322C-40E9-A18F-98B2F03FAF81");
            Guid bilboId = new Guid("6157CD72-B417-42A0-B109-F28AD7678833");
            Guid frodoId = new Guid("39BF4B9A-44B3-47D7-8B90-E08C0EC2C9CB");

            Guid thorinInterestId = new Guid("7956B9F9-95E6-4D71-AC4B-511A4DF952BC");
            Guid bilboInterestId = new Guid("0394B33B-DC5E-4924-A565-0C4CB876D7FE");
            Guid frodoInterestId = new Guid("7DE7833E-A6C1-4876-A596-564449B65835");

            Guid userInterest1 = new Guid("24E1ABE0-B74C-409C-A14D-06827C322273");
            Guid userInterest2 = new Guid("CAB8B16D-60B0-4EC2-82BF-01304D2DCB05");
            Guid userInterest3 = new Guid("53C915BB-2AF2-4228-BC06-5CAA43BA6941");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = thorinId,
                    Name = "Thorin Oakenshield",
                    Username = "thorin123",
                    Password = "oaken123",
                    UserRoleId = adminRoleId
                },
                new User
                {
                    Id = bilboId,
                    Name = "Bilbo Baggings",
                    Username = "bilbo123",
                    Password = "baggings123",
                    UserRoleId = managerRoleId
                },
                new User
                {
                    Id = frodoId,
                    Name = "Frodo Baggings",
                    Username = "frodo123",
                    Password = "baggins123",
                    UserRoleId = regularUserRoleId
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
                },
                new Interest
                {
                    Id = frodoInterestId,
                    Name = "Simply enter Mordor and destroy the One Ring where it was created"
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
                },
                new UserInterest
                {
                    Id = userInterest3,
                    UserId = frodoId,
                    InterestId = frodoInterestId
                });
        }
    }
}
