using GGYatirim.Models.ModelMetaDateTypes;
using GGYatirim.Models.Sinif;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using ActionResult = System.Web.Mvc.ActionResult;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace GGYatirim.Controllers
{
    [AllowAnonymous]
    [ModelMetadataType(typeof(KullaniciKayitMetaData))]

    public class MGirisController : Controller
    {

        GYatirimEntities dr = new GYatirimEntities();

        // GET: MGiris
        public ActionResult Index()
        {
            return View();
        }

        // GET: Giris


        [HttpGet]
        public ActionResult MLogin()
        {

            // TempData["mesaj"] = "Eksil Veya Hatalı Giriş!!!";
            return View();
        }

        // Müşteri Login Yeri
        [HttpPost]
        public ActionResult MLogin(DbKullanici a)
        {

            if (ModelState.IsValid)

            {
                var deger = dr.DbKullanici.Where(h => h.Durum == true).FirstOrDefault(f => f.EPosta == a.EPosta && f.Sifre == a.Sifre);


                if (deger != null)
                {
                    FormsAuthentication.SetAuthCookie(deger.EPosta, false);
                    Session["EPosta"] = deger.EPosta.ToString();
                    return RedirectToAction("Index", "GGKPanel");
                }

                else
                {
                    TempData["mesaj"] = "Nädogry giriş!!!";
                    return RedirectToAction("Index", "MGiris");
                    // return View();
                }

            }
            TempData["mesaj"] = "Şeýle hasaba alnan ulanyjylar ýok!!!";
            return View();

        }

        // Vitrin panelinden Kullanıcı Kaydını oluşturma yeri

        [HttpGet]
        public ActionResult MEkle()
        {



            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "V", "Q", "W", "Z" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;
            //List<SelectListItem> d1 = (from x in dr.DbYetki.ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.YetkiAd,
            //                               Value = x.AdminYetkiID.ToString()
            //                           }).ToList();
            //ViewBag.dgr1 = d1;

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        // Vitrin panelinden Kullanıcı Kaydını oluşturma yeri
        [HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult MEkle(DbKullanici u)
        {
            if (ModelState.IsValid)
            {

                var deger = dr.DbKullanici.Where(h => h.Durum == true).FirstOrDefault(f => f.EPosta == u.EPosta || f.Telefon == u.Telefon);

                if (deger != null)
                {
                    TempData["uyari"] = "Bu Ulanyjy eýýäm hasaba alyndy!!!";
                    return View();
                }
                else
                {

                    TempData["uyari"] = "Hasabyňyz döredildi!!!";
                    u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                    // u.KullaniciRolid = 1;
                    u.Durum = true;
                    dr.DbKullanici.Add(u);
                    dr.SaveChanges();
                    return RedirectToAction("Index", "MGiris");

                }
            }

            else
            {
                return View();
            }

            //return View();
        }


        [HttpGet]
        public ActionResult SifreResetM()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SifreResetM(DbKullanici k)
        {

            var model = dr.DbKullanici.Where(x => x.EPosta == k.EPosta && x.Durum == true).FirstOrDefault();
            if (model != null)
            {
                Guid rastgele = Guid.NewGuid();
                model.Sifre = rastgele.ToString().Substring(0, 10);
                dr.SaveChanges();
                SmtpClient client = new SmtpClient("mail.webigem.com", 587);
                client.EnableSsl = false;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("info@webigem.com", "Paroly täzeden düzmek");
                mail.To.Add(model.EPosta);
                mail.IsBodyHtml = true;
                mail.Subject = "Parol üýtgetmek haýyşy";
                mail.Body = "Salam (Hanym)-(Jenap): <b> " + model.KisiAdi + " </b> <br/> Telefon belgiňiz: <b> " + model.Telefon + " </b> <br/> Email adres: <b> " + model.EPosta + "</b> <br/> Täze parolyňyz: <b> </b>" + model.Sifre;
                NetworkCredential net = new NetworkCredential("info@webigem.com", "MGankara9697");
                client.Credentials = net;
                client.Send(mail);
                TempData["sifreyenile"] = "Täze parolyňyz e-poçta salgyňyza iberildi!!!";
                return RedirectToAction("Index", "MGiris");

            }
            TempData["sifreyenile"] = "Roralňyşlyk Şeýle e-poçta salgysy tapylmady!!!";
            return View();
        }
    }
}
