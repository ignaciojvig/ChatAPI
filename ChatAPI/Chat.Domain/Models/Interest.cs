using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.Models
{
    public class Interest : Entity
    {
        public string Name { get; set; }
        public ICollection<UserInterest> UserInterests { get; set; }
    }
}
