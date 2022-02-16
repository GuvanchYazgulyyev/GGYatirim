using GGYatirim.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GGYatirim.Controllers
{
    [AllowAnonymous]

    public class GGYPanelController : Controller
    {
        // GET: GGYPanel
        GYatirimEntities dr = new GYatirimEntities();
        // GET: Giris


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {

            // TempData["mesaj"] = "Eksil Veya Hatalı Giriş!!!";
            return View();
        }


        [HttpPost]
        public ActionResult AdminLogin(DbAdmin a)
        {

            if (ModelState.IsValid)

            {
                var deger = dr.DbAdmin.Where(h => h.Durum == true).FirstOrDefault(f => f.EPosta == a.EPosta && f.Sifre == a.Sifre);


                if (deger != null)
                {
                    FormsAuthentication.SetAuthCookie(deger.EPosta, false);
                    Session["EPosta"] = deger.EPosta.ToString();
                    return RedirectToAction("AdmKisiilan", "Admin");
                }

                else
                {
                    TempData["mesaj"] = "Eksik Veya Hatalı Giriş!!!";
                    return RedirectToAction("Index", "GGYPanel");
                }

            }
            TempData["mesaj"] = "Böyle Bir Kayıtlı kullanıcı yok!!!";
            return View();

        }
    }
}