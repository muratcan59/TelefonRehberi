using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Ui.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(80, ErrorMessage = "Ad 2-80 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string AdSoyad { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Sifre { get; set; }
        [Compare("Sifre")]
        [DataType(DataType.Password)]
        public string SifreTekrar { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }
    }
}