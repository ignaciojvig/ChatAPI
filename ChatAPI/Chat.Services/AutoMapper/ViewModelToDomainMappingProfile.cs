using AutoMapper;
using Chat.Domain.Models;
using Chat.Domain.ViewModels.Interest;
using Chat.Domain.ViewModels.User;
using Chat.Domain.ViewModels.UserInterest;

namespace Chat.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserCreateViewModel, User>();
            CreateMap<UserUpdateViewModel, User>();

            CreateMap<InterestCreateViewModel, Interest>();
            CreateMap<InterestUpdateViewModel, Interest>();

            CreateMap<UserInterestCreateViewModel, UserInterest>();
            CreateMap<UserInterestUpdateViewModel, UserInterest>();
        }
    }
}
