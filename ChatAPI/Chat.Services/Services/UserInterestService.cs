
using AutoMapper;
using Chat.Domain.Interfaces.Repository_Interfaces;
using Chat.Domain.Interfaces.Service_Interfaces;
using Chat.Domain.Models;
using Chat.Domain.ViewModels.UserInterest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Services.Services
{
    public class UserInterestService : IUserInterestService, IDisposable
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UserInterest> _userInterestRepository;

        public UserInterestService(IMapper mapper, IRepository<UserInterest> userInterestRepository)
        {
            _mapper = mapper;
            _userInterestRepository = userInterestRepository;
        }

        public async Task<IEnumerable<UserInterestSimpleViewModel>> GetAll()
        {
            var userInterestList = await _userInterestRepository.GetAll();
            var userInterestViewModelList = userInterestList
                .Select(x => new UserInterestSimpleViewModel
                {
                    Id = x.Id,
                    UserName = x.User.Name,
                    InterestName = x.Interest.Name
                }).ToList();

            return userInterestViewModelList;
        }

        public async Task<UserInterest> GetById(Guid id)
        {
            return await _userInterestRepository.GetById(id);
        }

        public async Task<UserInterest> Add(UserInterestCreateViewModel userInterest)
        {
            return await _userInterestRepository.Add(
                _mapper.Map<UserInterest>(userInterest));
        }

        public async Task<UserInterest> Update(UserInterestUpdateViewModel updateUserInterest)
        {
            UserInterest existingUserInterest = await _userInterestRepository.GetById(updateUserInterest.Id);
            if (existingUserInterest == null)
            {
                return null;
            }

            return await _userInterestRepository.Update(
                _mapper.Map<UserInterest>(updateUserInterest));
        }

        public async Task<UserInterest> Remove(Guid id)
        {
            UserInterest userInterestToBeRemoved = await _userInterestRepository.GetById(id);
            if (userInterestToBeRemoved == null)
            {
                return null;
            }

            await _userInterestRepository.Remove(userInterestToBeRemoved);
            return userInterestToBeRemoved;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
