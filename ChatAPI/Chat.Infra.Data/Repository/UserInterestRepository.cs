using Chat.Domain.Models;
using Chat.Domain.ViewModels.UserInterest;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repository
{
    public class UserInterestRepository : Repository<UserInterest>
    {
        public UserInterestRepository(ChatDbContext context) : base(context)
        {
        }

        protected async override Task<IEnumerable<UserInterest>> GetAll()
        {
            return await DbSet
                .AsNoTracking()
                .Include(x => x.Interest)
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
