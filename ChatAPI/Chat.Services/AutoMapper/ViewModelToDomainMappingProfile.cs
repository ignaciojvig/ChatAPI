using AutoMapper;
using Chat.Domain.Models;
using Chat.Domain.ViewModels.Interest;
using Chat.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
