using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Model
{
    public class Departman : Base
    {
        [Required]
        public string Ad { get; set; }
    }
}
