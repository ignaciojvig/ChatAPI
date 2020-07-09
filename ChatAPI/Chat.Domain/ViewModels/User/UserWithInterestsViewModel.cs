using Chat.Domain.ViewModels.Interest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.ViewModels.User
{
    public class UserWithInterestsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<InterestViewModel> UserInterests { get; set; }
    }
}
