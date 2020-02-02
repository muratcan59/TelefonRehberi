using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Model;

namespace TelefonRehberi.Bll
{
    public class KullaniciRepository : BaseRepository<Kullanici>
    {
        public Kullanici Login(string email,string sifre)
        {
            return context.Set<Kullanici>().Where(x => x.Email == email && x.Sifre == sifre).FirstOrDefault();
        }

        public Kullanici Mail(string email)
        {
            return context.Set<Kullanici>().Where(x => x.Email == email).SingleOrDefault();
        }

        public bool AddRole(int userId,int roleId)
        {
            SqlParameter[] parameters = { new SqlParameter("userId", userId), new SqlParameter("rolId", roleId) };
            int sonuc = context.Database.ExecuteSqlCommand("insert into RolKullanici (Kullanici_Id, Rol_Id) values (@userId,@rolId)", parameters);
            return sonuc > 0 ? true : false;
        }        
    }
}
