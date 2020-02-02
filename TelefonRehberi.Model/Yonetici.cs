using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Model
{
    public class Yonetici : Base
    {
        [Required]
        public int CalisanId { get; set; }
        [ForeignKey("CalisanId")]
        public virtual Calisan Calisanlar { get; set; }
    }
}
