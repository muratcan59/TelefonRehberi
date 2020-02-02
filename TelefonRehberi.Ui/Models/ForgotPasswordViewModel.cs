using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Ui.Models
{
    public class ForgotPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}