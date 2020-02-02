using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Ui.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        public int Kod { get; set; }
        [Required]
        public string Sifre { get; set; }
        [Compare("Sifre")]
        [DataType(DataType.Password)]
        public string SifreTekrar { get; set; }
    }
}