using Chat.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.ViewModels.Interest
{
    public class InterestWithUsersViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserViewModel> Users { get; set; }
    }
}
