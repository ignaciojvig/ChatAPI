using Chat.Domain.Models;
using Chat.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Interfaces.Service_Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<UserWithInterestsViewModel>> GetAll();
        Task<UserWithInterestsViewModel> GetById(Guid id);
        Task<User> Add(UserCreateViewModel newUser);
        Task<User> Update(UserUpdateViewModel updateUser);
        Task<User> Remove(Guid id);
    }
}
