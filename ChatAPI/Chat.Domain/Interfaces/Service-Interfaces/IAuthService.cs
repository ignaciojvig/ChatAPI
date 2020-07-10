using Chat.Domain.Models;
using Chat.Domain.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Interfaces.Service_Interfaces
{
    public interface IAuthService
    {
        Task<User> GetUserByCredentials(LoginViewModel loginCredentials);
        string GenerateToken(User user);
    }
}
