using Chat.Domain.Models;
using Chat.Infra.Data.Mappings;
using Chat.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Infra.Data.Context
{
    public class ChatDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }

        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new InterestMap());
            modelBuilder.ApplyConfiguration(new UserInterestMap());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
