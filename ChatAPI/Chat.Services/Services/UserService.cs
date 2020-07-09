using AutoMapper;
using Chat.Domain.Interfaces;
using Chat.Domain.Interfaces.Repository_Interfaces;
using Chat.Domain.Interfaces.Service_Interfaces;
using Chat.Domain.Models;
using Chat.Domain.ViewModels.Interest;
using Chat.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;

        public UserService(IMapper mapper, IRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserWithInterestsViewModel>> GetAll()
        {
            var userList = await _userRepository.GetAll();
            var userListViewModel = userList
                .Select(x => new UserWithInterestsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserInterests = x.UserInterests.Select(y => new InterestViewModel
                    {
                        Id = y.Interest.Id,
                        Name = y.Interest.Name
                    }).ToList()
                }).ToList();

            return userListViewModel;
        }

        public async Task<UserWithInterestsViewModel> GetById(Guid id)
        {
            return _mapper.Map<UserWithInterestsViewModel>(
                await _userRepository.GetById(id));
        }

        public async Task<User> Add(UserCreateViewModel newUser)
        {
            return await _userRepository.Add(
                _mapper.Map<User>(newUser));
        }

        public async Task<User> Update(UserUpdateViewModel updateUser)
        {
            User existingUser = await _userRepository.GetById(updateUser.Id);
            if (existingUser == null)
            {
                return null;
            }

            return await _userRepository.Update(
                _mapper.Map<User>(updateUser));
        }

        public async Task<User> Remove(Guid id)
        {
            User userToBeRemoved = await _userRepository.GetById(id);
            if (userToBeRemoved == null)
            {
                return null;
            }

            await _userRepository.Remove(userToBeRemoved);
            return userToBeRemoved;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
