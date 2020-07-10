using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain.ViewModels.UserInterest
{
    public class UserInterestSimpleViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string InterestName { get; set; }
    }
}
