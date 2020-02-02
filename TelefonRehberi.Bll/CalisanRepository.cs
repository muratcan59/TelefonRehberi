using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Model;

namespace TelefonRehberi.Bll
{
    public class CalisanRepository : BaseRepository<Calisan>
    {
        public bool SoftDelete(int id)
        {
            var veri = context.Calisanlar.Find(id);
            veri.SilindiMi = true;
            return base.Update(veri);
        }

        public List<Calisan> CalisanCek(int id)
        {
            var veri = context.Set<Calisan>().Where(x => x.Id == id).ToList();
            return veri;
        }

        public List<Calisan> CalisanYoneticiGetir(int id)
        {
            var veri = context.Set<Calisan>().Where(x => x.YoneticiId == id).ToList();
            return veri;
        }
    }
}
