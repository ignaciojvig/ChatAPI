using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Chat.Domain.Models.Identity_Entities
{
    public class UserRole : Entity
    {
        public string Title { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<UserRoleClaim> RoleClaims { get; set; }
    }
}
