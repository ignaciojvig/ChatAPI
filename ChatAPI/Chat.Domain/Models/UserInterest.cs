using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Models
{
    public class UserInterest
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
