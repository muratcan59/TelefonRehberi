using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Model;

namespace TelefonRehberi.Bll
{
    public class YoneticiRepository : BaseRepository<Yonetici>
    {
        public bool SoftDelete(int id)
        {
            var veri = context.Yoneticiler.Find(id);
            veri.SilindiMi = true;
            return base.Update(veri);
        }

        public List<Yonetici> YoneticiCek(int id)
        {
            var veri = context.Set<Yonetici>().Where(x => x.Id == id).ToList();
            return veri;
        }
    }
}
