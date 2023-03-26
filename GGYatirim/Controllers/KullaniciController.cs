using GGYatirim.Models.Sinif;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace GGYatirim.Controllers
{
    public class KullaniciController : Controller
    {
        GYatirimEntities dr = new GYatirimEntities();

        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Kullaniciilan(int id)
        {


            var mail = (string)Session["EPosta"];
            var kullaniciilansayi = dr.Dbilan.Where(k => k.KullaniciNo == mail && k.Durum == true).Count();
            ViewBag.adsoyad = kullaniciilansayi;

          
            var kullaniciilan = dr.Dbilan.Where(k => k.KullaniciNo == mail && k.Durum == true).ToList();
           // ViewBag.adsoyad = kullaniciilan;


            return View(kullaniciilan);
            //  var deger = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(u => u.ilanID).ToList();
            //var deger1 = dr.DbKullanici.Where(k => k.Durum == true).OrderByDescending(u => u.KullaniciID).ToList();
            //var deger2 = dr.DbHareket.OrderByDescending(u => u.HareketID).ToList();
            //if (true)
            //{

            //}
            // var deger = dr.DbHareket.Where(k => k.KullaniciIDD==id).Where(f=>f.HaraketilanIDD==id).OrderByDescending(u => u.HareketID).ToList();
            //   var deger = dr.DbKullanici.Where(k => k.id==id).OrderByDescending(u => u.HareketID).ToList();
            //  var deger = dr.DbHareket.Where(f => f.HaraketilanIDD == id).ToList();

        }



        // Musteri Profil Göster
        public ActionResult MProfilList()
        {

            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).ToList();


            // İlan Sayısı
            var toplamilan = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true).Count();
            ViewBag.toplamilan = toplamilan;

             // İlan Sayısı
            var onaybekleyenilan = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == false).Count();
            ViewBag.onaybekleyenilan = onaybekleyenilan;



            //  var ilan = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true).Where(d=>d.).ToList();
            //    ViewBag.ilan = ilan;

            return View(adsoyad);
        }



        // Müşteri Profil Güncelle

        // Getir

        public PartialViewResult MuteriGetr()
        {

            var mail = (string)Session["EPosta"];
            var id = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(k => k.KullaniciID).FirstOrDefault();
            var urngetr = dr.DbKullanici.Find(id);
            return PartialView("MuteriGetr", urngetr);
        }

        // Güncellle

        public ActionResult MusteriGuncelle(DbKullanici u, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {

                if (File != null)
                {
                    FileInfo fileinfo = new FileInfo(File.FileName);
                    WebImage img = new WebImage(File.InputStream);
                    string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                    //img.Resize(225, 180, false, false);
                    string tamyol = "~/ilanResimler/" + uzanti;
                    img.Save(Server.MapPath(tamyol));
                    u.Resim = "/ilanResimler/" + uzanti;

                }





                TempData["bilgiguncelle"] = "";

                var value = dr.DbKullanici.Find(u.KullaniciID);
                value.KisiAdi = u.KisiAdi;
                value.KisiSoyadi = u.KisiSoyadi;
                //   value.EPosta = u.EPosta;
                value.Sifre = u.Sifre;
                value.Meslek = u.Meslek;
                value.Telefon = u.Telefon;
                value.KisaAciklama = u.KisaAciklama;
                value.Face = u.Face;
                value.instagram = u.instagram;
                value.Sehir = u.Sehir;
                value.TamAdres = u.TamAdres;
                if (u.Resim != null)
                {
                    value.Resim = u.Resim;
                }
                value.Durum = true;
                //value.AdminYetki.id = u.id;
                dr.SaveChanges();
                return RedirectToAction("Index", "GGKPanel");
               // return RedirectToAction("MProfilList");
            }
            return View();
        }

        // Hesabımı Sil
        // Müşteri Hesabı Kalıcı Olarak Silinecektir
        ////  Sil
        ///
        public ActionResult HesabimiSil(int id)
        {
            var urnsil = dr.DbKullanici.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }



    }
}