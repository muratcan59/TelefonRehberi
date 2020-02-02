using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Model
{
    public class Calisan : Base
    {
        [Required]
        public string AdSoyad { get; set; }
        public string Tel { get; set; }
        public int? DepartmanId { get; set; }
        [ForeignKey("DepartmanId")]
        public virtual Departman Departmanlar { get; set; }
        public int? YoneticiId { get; set; }
        [ForeignKey("YoneticiId")]
        public virtual Calisan Yoneticiler { get; set; }
    }
}
