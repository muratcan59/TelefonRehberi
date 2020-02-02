using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Model
{
    public class Kullanici : Base
    {
        public Kullanici()
        {
            this.Rolleri = new HashSet<Rol>();
        }
        [Required]
        [StringLength(80, ErrorMessage = "Karakter girişi 2-80 uzunluğu arası olmalı.", MinimumLength = 2)]
        public string AdSoyad { get; set; }
        public string Tel { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        public virtual ICollection<Rol> Rolleri { get; set; }
    }
}
