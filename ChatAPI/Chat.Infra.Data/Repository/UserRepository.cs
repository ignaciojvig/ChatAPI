using Chat.Domain.Interfaces;
using Chat.Domain.Interfaces.Repository_Interfaces;
using Chat.Domain.Models;
using Chat.Domain.ViewModels.Auth;
using Chat.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ChatDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByCredentials(LoginViewModel loginCredentials)
        {
            return await DbSet
                .AsNoTracking()
                .Where(x =>
                    x.Username == loginCredentials.Username &&
                    x.Password == loginCredentials.Password)
                .Include(x => x.UserRole)
                    .ThenInclude(x => x.RoleClaims)
                        .ThenInclude(x => x.Claim)
                .FirstOrDefaultAsync();
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
