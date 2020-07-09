using Chat.Domain.Interfaces;
using Chat.Domain.Models;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ChatDbContext context) : base(context)
        {
        }

        protected async override Task<IEnumerable<User>> GetAll()
        {
            return await DbSet
                .AsNoTracking()
                .Include(x => x.UserInterests)
                    .ThenInclude(x => x.Interest)
                .ToListAsync();
        }
    }
}
