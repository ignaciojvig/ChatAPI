using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Models.Identity_Entities
{
    public class UserClaim : Entity
    {
        public string Name { get; set; }

        public ICollection<UserRoleClaim> RoleClaims { get; set; }
    }
}
