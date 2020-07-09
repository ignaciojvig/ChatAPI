using Chat.Domain.Models;
using Chat.Domain.ViewModels.Interest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Interfaces.Service_Interfaces
{
    public interface IInterestService
    {
        Task<IEnumerable<InterestViewModel>> GetAll();
        Task<InterestViewModel> GetById(Guid id);
        Task<Interest> Add(InterestCreateViewModel newInterest);
        Task<Interest> Update(InterestUpdateViewModel updateInterest);
        Task<Interest> Remove(Guid id);
        void Dispose();
    }
}
