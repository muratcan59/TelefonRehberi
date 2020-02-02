using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Bll;
using TelefonRehberi.Filters;
using TelefonRehberi.Model;

namespace TelefonRehberi.Ui.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Calisan
        KullaniciRepository repo = new KullaniciRepository();       
        public ActionResult Calisanlar()
        {   
            var sonuc = repo.GetByFilter(x => x.SilindiMi == false).ToList();
            return View(sonuc);
        }

        public ActionResult CalisanDetay(int id)
        {
            var sonuc = repo.GetById(id);
            return View(sonuc);
        }
    }
}