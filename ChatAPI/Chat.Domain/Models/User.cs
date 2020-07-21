using Chat.Domain.Models.Identity_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
        public ICollection<UserInterest> UserInterests { get; set; }
    }
}
