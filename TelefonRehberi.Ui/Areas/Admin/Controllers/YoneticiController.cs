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
    public class YoneticiController : Controller
    {
        // GET: Admin/Yonetici
        YoneticiRepository repo = new YoneticiRepository();
        [AdminLoginFilter]
        public ActionResult Ekle()
        {
            
            CalisanRepository rep = new CalisanRepository();
            var sonuc = rep.GetByFilter(x => x.SilindiMi == false).ToList();
            ViewBag.Calisanlar = sonuc;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Yonetici model,int id)
        {
            var deger = repo.YoneticiCek(id);
            if (deger.Count == 0)
            {
                model.SilindiMi = false;
                model.KayitTarihi = DateTime.Now;
                bool sonuc = repo.Add(model);
                TempData["Mesaj"] = sonuc ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Yönetici eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Yönetici eklenemedi." } };
                return RedirectToAction(nameof(Ekle));
            }
            else
            {
                TempData["Mesaj"] = new TempDataDictionary { { "class", "alert-warning" }, { "Msg", "Yönetici daha önce eklendi." } };
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
            CalisanRepository rep = new CalisanRepository();
            ViewBag.Calisanlar = rep.GetByFilter(x => x.SilindiMi == false).ToList();
            var sonuc = repo.GetById(id);
            return View(sonuc);
        }

        [HttpPost]
        public ActionResult Duzenle(Yonetici model,int id)
        {
            var deger = repo.YoneticiCek(id);
            if (deger.Count == 0)
            {
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
            bool sonuc = repo.SoftDelete(id);
            return RedirectToAction(nameof(Listele));         
        }
    }
}