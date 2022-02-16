using GGYatirim.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; ///  Sayfalama için gerekli olan Kütüphaneler
using PagedList.Mvc;  ///  Sayfalama için gerekli olan Kütüphaneler

namespace GGYatirim.Controllers
{
    [AllowAnonymous]

    public class HomeController : Controller
    {
        GYatirimEntities dr = new GYatirimEntities();


        public ActionResult Index()
        {

            //var deger1 = dr.Dbilan.Where(d=>d.Durum==true).ToList();
            //ViewBag.dg1 = deger1;

            var deger = dr.DbEmlakTipi.Where(k => k.Durum == true).Count();
            ViewBag.d1 = deger;
            var dg = dr.Dbilan.Where(l => l.Durum == true).Count();
            ViewBag.d2 = dg;


            var d = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).Count();
            ViewBag.d3 = d;

            return View();


        }


        // Part Kısmıları satılık kiralık
        public PartialViewResult DbilanDurum()
        {
            var degr = dr.DbilanDurum.Where(k => k.Durum == true).ToList();

            var d = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).Count();
            ViewBag.d3 = d;

            var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 2).Count();
            ViewBag.d4 = d1;


            return PartialView(degr);
        }

        // Kiralık ilan

        public ActionResult Kiralikilan()
        {
            var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 2).ToList();
            return View(d1);
        }

        // Satılık ilan

        public ActionResult Satilikilan()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }



        // Part Kısmıları Villa, Aprt vs
        public PartialViewResult DbEmlakTipi()
        {
            var degr = dr.DbEmlakTipi.Where(l => l.Durum == true).ToList();

            //Apartman
            var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 1).Count();
            ViewBag.d1 = d1;

            //Daire
            var d2 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 2).Count();
            ViewBag.d2 = d2;

            //Arsa
            var d3 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 3).Count();
            ViewBag.d3 = d3;
            //Müstakil
            var d4 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 4).Count();
            ViewBag.d4 = d4;

            //Dubleks
            var d5 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 5).Count();
            ViewBag.d5 = d5;

            //Arazi
            var d6 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 6).Count();
            ViewBag.d6 = d6;

            //Dükkan
            var d7 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 7).Count();
            ViewBag.d7 = d7;
            //İşyeri
            var d8 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 8).Count();
            ViewBag.d8 = d8;

            //Bahçe
            var d9 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 9).Count();
            ViewBag.d9 = d9;

            //Petrol İstasyonu
            var d10 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 10).Count();
            ViewBag.d10 = d10;

            //Çiftlik
            var d11 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 11).Count();
            ViewBag.d11 = d11;

            //Ahır
            var d12 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 12).Count();
            ViewBag.d12 = d12;
            //Otomobil
            var d13 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 13).Count();
            ViewBag.d13 = d13;

            //Traktör
            var d14 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.EmlakTipIDD == 14).Count();
            ViewBag.d14 = d14;



            return PartialView(degr);
        }



        // İlan Detay Yeni 10 ilan

        public PartialViewResult AnasayfaKiralikilanPart()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(u => u.ilanID).Take(5).ToList();
            return PartialView(deger);
        }




        // Tüm İlanlar

        public ActionResult Tumilanlar()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(u => u.ilanID).ToList();

            return View(deger);
        }





        // Ana Sayfa yeni 5 ilan

        public PartialViewResult YeniilanPart(int sayfa = 1)
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(u => u.ilanID).ToList().ToPagedList(sayfa, 5);
            return PartialView(deger);
        }

        // İlan Detay

        //public ActionResult ilanDetay(int id)
        //{
        //    var degerler = dr.Dbilan.Where(l => l.ilanID == id).ToList();
        //    return View(degerler);
        //}

        public ViewResult ilanDetay(int id)
        {
            var degerler = dr.Dbilan.Where(l => l.ilanID == id).ToList();
            return View(degerler);
        }



        // İlan Detay Yeni 10 ilan

        public PartialViewResult ilanDetayPart()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(u => u.ilanID).Take(6).ToList();
            return PartialView(deger);
        }




        // İlan Detay Satılık Yeni 10 ilan

        public PartialViewResult ilanDetayKiralikPart()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(y => y.ilanID).Take(6).ToList();
            return PartialView(deger);
        }











        // iletisim Kısmı
        [HttpGet]
        public ActionResult iletisim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult iletisim(DbiletisimForm m)
        {

            if (ModelState.IsValid)
            {
                dr.DbiletisimForm.Add(m);
                ViewBag.Kontrol = "Mesajınız Başarılı Bir Şekilde Gönderilmiştir!";
                m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                m.Durum = true;
                dr.SaveChanges();
                TempData["mesaj"] = "";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Kontrol = "Mesajınızı Göndeririken hata oluştu!!!!";
                return View();
            }

        }

        // İletişim bilgilerini getir

        public PartialViewResult iletisimBilgi()
        {
            var deger = dr.DbiletisimBilgi.ToList();
            return PartialView(deger);
        }






        // Partial Temsilci Kısmı
        public PartialViewResult Temsilci()
        {
            var deger = dr.DbTemsilci.Where(k => k.Durum == true).OrderByDescending(l => l.TemsilciID).ToList();
            return PartialView(deger);
        }




        // Partial Blog Kısmı
        public PartialViewResult PartialBlog()
        {
            var deger = dr.DbBlog.Where(k => k.Durum == true).OrderByDescending(l => l.BlogID).ToList();
            return PartialView(deger);
        }


        // Partial BlogicdetayPartial Kısmı
        public PartialViewResult BlogicdetayPartial()
        {
            var deger = dr.DbBlog.Where(k => k.Durum == true).OrderByDescending(l => l.BlogID).Take(5).ToList();
            return PartialView(deger);
        }


        // Blog Kısmı
        public ActionResult Blog()
        {
            var deger = dr.DbBlog.Where(k => k.Durum == true).OrderByDescending(l => l.BlogID).ToList();
            return View(deger);
        }

        // Blog Detay
        public ActionResult BlogDetay(int id)
        {
            var deger = dr.DbBlog.Where(k => k.BlogID == id).ToList();
            return View(deger);
        }


    }
}