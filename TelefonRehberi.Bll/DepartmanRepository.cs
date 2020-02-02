using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Model;

namespace TelefonRehberi.Bll
{
    public class DepartmanRepository : BaseRepository<Departman>
    {
        public bool SoftDelete(int id)
        {
            var veri = context.Departmanlar.Find(id);
            veri.SilindiMi = true;
            return base.Update(veri);
        }

        public List<Departman> DepartmanGetir(string ad)
        {
            var veri = context.Set<Departman>().Where(x => x.Ad == ad).ToList();
            return veri;
        }
        public List<Calisan> CalisanGetir(int id)
        {
            var veri = context.Set<Calisan>().Where(x => x.DepartmanId == id).ToList();
            return veri;
        }
    }
}
