using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chat.Domain.ViewModels.User
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "The field Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
