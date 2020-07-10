using Chat.Domain.Models;
using Chat.Domain.ViewModels.UserInterest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Interfaces.Service_Interfaces
{
    public interface IUserInterestService
    {
        Task<IEnumerable<UserInterestSimpleViewModel>> GetAll();
        Task<UserInterest> GetById(Guid id);
        Task<UserInterest> Add(UserInterestCreateViewModel userInterest);
        Task<UserInterest> Update(UserInterestUpdateViewModel updateUserInterest);
        Task<UserInterest> Remove(Guid id);
    }
}
