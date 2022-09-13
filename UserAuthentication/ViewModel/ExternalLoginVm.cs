using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Authentication.ViewModel
{
    public class ExternalLoginVm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
