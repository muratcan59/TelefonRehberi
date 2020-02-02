using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TelefonRehberi.Bll;

namespace TelefonRehberi.WebService
{
    /// <summary>
    /// Summary description for TelefonRehberiWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TelefonRehberiWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<CalisanKisiler> CalisanlariGetir()
        {
            CalisanRepository repo = new CalisanRepository();
            var veri = repo.GetAll();
            List<CalisanKisiler> calisanlar = new List<CalisanKisiler>();
            veri.ForEach(x => calisanlar.Add(new CalisanKisiler { Id = x.Id, AdSoyad = x.AdSoyad, Telefon = x.Telefon }));
            return calisanlar;
        }

        public class CalisanKisiler
        {
            public int Id { get; set; }
            public string AdSoyad { get; set; }
            public string Telefon { get; set; }
        }

    }
}
