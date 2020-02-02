using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Model;

namespace TelefonRehberi.Bll
{
    public class SifremiUnuttumRepository : BaseRepository<SifremiUnuttum>
    {
        public SifremiUnuttum IdGetir(string email)
        {
            return context.Set<SifremiUnuttum>().Where(x => x.Email == email).FirstOrDefault();
        }
    }
}
