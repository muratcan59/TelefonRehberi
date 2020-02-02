using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Model
{
    public class SifremiUnuttum : Base
    {
        public int KullaniciId { get; set; }
        public int Kod { get; set; }

        public string Email { get; set; }
        [ForeignKey("KullaniciId")]

        public virtual Kullanici Kullanicilar { get; set; }
    }
}
