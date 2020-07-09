using AutoMapper;
using Chat.Domain.Models;
using Chat.Domain.ViewModels.Interest;
using Chat.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserWithInterestsViewModel>();
            CreateMap<Interest, InterestViewModel>();
        }
    }
}
