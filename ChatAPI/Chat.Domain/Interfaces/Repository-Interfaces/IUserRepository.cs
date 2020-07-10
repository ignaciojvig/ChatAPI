using Chat.Domain.Models;
using Chat.Domain.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Interfaces.Repository_Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByCredentials(LoginViewModel loginCredentials);
    }
}
