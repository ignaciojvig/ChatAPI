using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chat.Domain.ViewModels.UserInterest
{
    public class UserInterestCreateViewModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid InterestId { get; set; }
    }
}
