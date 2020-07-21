using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Models.Identity_Entities
{
    public class UserRoleClaim : Entity
    {
        public Guid RoleId { get; set; }
        public UserRole Role { get; set; }
        public Guid ClaimId { get; set; }
        public UserClaim Claim { get; set; }
    }
}
