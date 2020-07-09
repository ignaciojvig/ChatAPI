using Chat.Domain.Interfaces;
using Chat.Domain.Interfaces.Repository_Interfaces;
using Chat.Domain.Interfaces.Service_Interfaces;
using Chat.Domain.Models;
using Chat.Infra.Data.Context;
using Chat.Infra.Data.Repository;
using Chat.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Chat.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInterestService, InterestService>();
            #endregion

            #region Infra.Data
            services.AddScoped<ChatDbContext>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Interest>, InterestRepository>();
            #endregion
        }
    }
}
