using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Filters;

namespace TelefonRehberi.Ui.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [AdminLoginFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}