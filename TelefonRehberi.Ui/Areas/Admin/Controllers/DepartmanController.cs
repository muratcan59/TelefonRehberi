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
    public class DepartmanController : Controller
    {
        // GET: Admin/Departman
        
        DepartmanRepository repo = new DepartmanRepository();
        [AdminLoginFilter]       
        public ActionResult Ekle()
        {
            var sonuc = repo.GetByFilter(x => x.SilindiMi == false).ToList();
            ViewBag.Departmanlar = sonuc;
            return View();
        }

        
        [HttpPost]
        public ActionResult Ekle(Departman model,string ad)
        {
            var deger = repo.DepartmanGetir(ad);
            if (deger.Count == 0)
            {
                model.SilindiMi = false;
                model.KayitTarihi = DateTime.Now;
                bool sonuc = repo.Add(model);
                TempData["Mesaj"] = sonuc ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Departman eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Departman eklenemedi." } };
                return RedirectToAction(nameof(Ekle));
            }
            else
            {
                TempData["Mesaj"] = new TempDataDictionary { { "class", "alert-warning" }, { "Msg", "Departman daha önce eklendi." } };
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
            ViewBag.Departmanlar = repo.GetByFilter(x => x.SilindiMi == false).ToList();
            var sonuc = repo.GetById(id);
            return View(sonuc);
        }

        [HttpPost]
        public ActionResult Duzenle(Departman model,string ad)
        {
            var deger = repo.DepartmanGetir(ad);
            if (deger.Count == 0)
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
            var deger = repo.CalisanGetir(id);
            if (deger.Count == 0)
            {
                bool sonuc = repo.SoftDelete(id);
                return RedirectToAction(nameof(Listele));
            }
            else
            {
                return RedirectToAction(nameof(Listele));
            }           
        }
    }
}