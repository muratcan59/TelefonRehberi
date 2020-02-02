using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TelefonRehberi.Bll;
using TelefonRehberi.Filters;
using TelefonRehberi.Model;
using TelefonRehberi.Ui.Models;

namespace TelefonRehberi.Ui.Areas.Admin.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Admin/Kullanici
        KullaniciRepository repo = new KullaniciRepository();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            
            var kullanici = repo.Login(model.Email, model.Sifre);
            if (kullanici != null)
            {
                Session["LoginUser"] = kullanici;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Mesaj"] = new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Email veya şifre hatalı!" } };
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["LoginUser"] = null;
            Session.Remove("LoginUser");
            return RedirectToAction("Login", "User", new { Area = "Admin" });
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            RolRepository rolRepo = new RolRepository();
            bool sonuc = repo.Add(new Kullanici { AdSoyad = model.AdSoyad, Sifre = model.Sifre, Email = model.Email, SilindiMi = false, KayitTarihi = DateTime.Now, Tel = model.Tel });
            var userId = repo.GetByFilter(x => x.Email == model.Email).FirstOrDefault().Id;
            var roleId = rolRepo.GetByFilter(x => x.Ad == "Admin").FirstOrDefault().Id;
            repo.AddRole(userId, roleId);
            TempData["Mesaj"] = sonuc ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kayıt eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt eklenemedi." } };
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model,string email)
        {
            try
            {
                var deger = repo.Mail(model.Email);
                if (deger != null)
                {
                    Random rnd = new Random();
                    int kod = rnd.Next();
                    SifremiUnuttumRepository re = new SifremiUnuttumRepository();
                    bool sonuc = re.Add(new SifremiUnuttum { KayitTarihi = DateTime.Now, SilindiMi = false, Kod = kod, KullaniciId = deger.Id, Email = model.Email });
                    var ifade = re.IdGetir(email);
                    WebMail.SmtpServer = "smtp.office365.com";
                    WebMail.SmtpPort = 587;
                    WebMail.SmtpUseDefaultCredentials = true;
                    WebMail.EnableSsl = true;
                    WebMail.UserName = "muratcan_dongel@hotmail.com";
                    WebMail.Password = "mcTR5934..";
                                       
                    WebMail.Send(to: deger.Email,subject: "Şifre Doğrulama Kodu",body: "Doğrulama Kodu: " + kod,from:deger.Email);
                    ViewBag.Uyari = "Doğrulama kodu mail adresinize gönderildi.";
                    return Redirect(nameof(RecoverPassword) + "/" + deger.Id);
                        
                }
                else
                {
                    ViewBag.Uyari = "Bir hata oluştu.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }           
        }

        public ActionResult RecoverPassword(int id)
        {
            var ifade = repo.GetByFilter(x => x.Id == id).FirstOrDefault();
            return View(ifade);
        }

        [HttpPost]
        public ActionResult RecoverPassword(RecoverPasswordViewModel model,string email,int kod)
        {
            try
            {
                SifremiUnuttumRepository re = new SifremiUnuttumRepository();
                var deger = re.GetByFilter(x => x.Kod == model.Kod).FirstOrDefault();
                var veri = repo.Mail(deger.Email);
                if (veri != null && deger.Kod == kod)
                {
                    veri.Sifre = model.Sifre;
                    bool sonuc = repo.Update(new Kullanici { Sifre = model.Sifre });
                    ViewBag.Uyari = "Şifre değişimi sağlandı. Sisteme giriş yapabilirsiniz.";
                }
                else
                {
                    ViewBag.Uyari = "Bir hata oluştu.";
                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception ex)
            {

                return View();
            }
            
        }
    }
}