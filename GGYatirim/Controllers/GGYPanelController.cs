using GGYatirim.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                    return RedirectToAction("Index", "Admin");
                }

                else
                {
                    TempData["mesaj"] = "Ingitirilen ýa-da nädogry giriş!!!";
                    return RedirectToAction("Index", "GGYPanel");
                    // return View();
                }

            }
            TempData["mesaj"] = "Şeýle hasaba alnan ulanyjylar ýok!!!";
            return View();

        }




        [HttpGet]
        public ActionResult SifreResetA()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SifreResetA(DbAdmin k)
        {

            var model = dr.DbAdmin.Where(x => x.EPosta == k.EPosta && x.Durum == true).FirstOrDefault();
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
                mail.Body = "Salam (Hanym)-(Jenap): <b> " + model.AdSoyad + " </b> <br/> Telefon belgiňiz: <b> " + model.Tel + " </b> <br/> Email adres: <b> " + model.EPosta + "</b> <br/> Täze parolyňyz: <b> </b>" + model.Sifre;
                NetworkCredential net = new NetworkCredential("info@webigem.com", "MGankara9697");
                client.Credentials = net;
                client.Send(mail);
                TempData["sifreyenile"] = "Täze parolyňyz e-poçta salgyňyza iberildi!!!";
                return RedirectToAction("Index", "GGYPanel");

            }

            TempData["sifreyenile"] = "Roralňyşlyk Şeýle e-poçta salgysy tapylmady!!!";
            return View();
        }


    }
}