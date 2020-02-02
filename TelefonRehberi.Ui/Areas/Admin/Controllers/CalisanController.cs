using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Bll;
using TelefonRehberi.Filters;
using TelefonRehberi.Model;

namespace TelefonRehberi.Ui.Areas.Admin.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Admin/Calisan
        CalisanRepository repo = new CalisanRepository();
        [AdminLoginFilter]
        public ActionResult Ekle()
        {
            DepartmanRepository rep = new DepartmanRepository();
            var sonuc = rep.GetByFilter(x => x.SilindiMi == false).ToList();
            ViewBag.Departmanlar = sonuc;
            YoneticiRepository re = new YoneticiRepository();
            var sonuc2 = re.GetByFilter(x => x.SilindiMi == false).ToList();
            ViewBag.Yoneticiler = sonuc2;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Calisan model, int id)
        {
            var deger = repo.CalisanCek(id);
            if (deger.Count == 0)
            {
                model.SilindiMi = false;
                model.KayitTarihi = DateTime.Now;
                bool sonuc = repo.Add(model);
                TempData["Mesaj"] = sonuc ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Çalışan eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Çalışan eklenemedi." } };
                return RedirectToAction(nameof(Ekle));
            }
            else
            {
                TempData["Mesaj"] = new TempDataDictionary { { "class", "alert-warning" }, { "Msg", "Çalışan daha önce eklendi." } };
                return RedirectToAction(nameof(Ekle));
            }

        }

        [AdminLoginFilter]
        public ActionResult Listele()
        {
            var sonuc = repo.GetByFilter(x => x.SilindiMi == false).ToList();
            return View(sonuc);
        }

        public ActionResult Duzenle(int id)
        {
            DepartmanRepository rep = new DepartmanRepository();
            ViewBag.Departmanlar = rep.GetByFilter(x => x.SilindiMi == false).ToList();
            YoneticiRepository re = new YoneticiRepository();
            ViewBag.Yoneticiler = re.GetByFilter(x => x.SilindiMi == false).ToList();
            var sonuc = repo.GetById(id);
            return View(sonuc);
        }

        [HttpPost]
        public ActionResult Duzenle(Calisan model,int id)
        {
            var ifade = repo.CalisanCek(id);            
            if (ifade != null)
            { 
                model.KayitTarihi = DateTime.Now;
                bool sonuc = repo.Update(model);
                return RedirectToAction(nameof(Listele));
            }
            else
            {
                return RedirectToAction(nameof(Listele));
            }

        }

        public ActionResult Sil(int id)
        {
            var ifade = repo.CalisanYoneticiGetir(id);
            if (ifade.Count != 0)
            {
                return RedirectToAction(nameof(Listele));
            }
            else
            {
                bool sonuc = repo.SoftDelete(id);
                return RedirectToAction(nameof(Listele));
            }
            
            
        }
    }
}