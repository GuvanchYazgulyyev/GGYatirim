using GGYatirim.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; ///  Sayfalama için gerekli olan Kütüphaneler
using PagedList.Mvc;  ///  Sayfalama için gerekli olan Kütüphaneler
using Microsoft.EntityFrameworkCore;
using GGYatirim.Models;
using System.Net;
using Newtonsoft.Json;

namespace GGYatirim.Controllers
{
    [AllowAnonymous]
    // [RoutePrefix("Tumilanlar")]
    public class HomeController : Controller
    {
        GYatirimEntities dr = new GYatirimEntities();


        public ActionResult Index(string p, int sayfa = 1)
        {

            // var degerr = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(u => u.ilanID).ToList().ToPagedList(sayfa, 5);


            //var deger1 = dr.Dbilan.Where(d=>d.Durum==true).ToList();
            //ViewBag.dg1 = deger1;

            var deger = dr.DbEmlakTipi.Where(k => k.Durum == true).Count();
            ViewBag.d1 = deger;
            var dg = dr.Dbilan.Where(l => l.Durum == true).Count();
            ViewBag.d2 = dg;
            // Akrif ilan
            var aktifilan = dr.Dbilan.Where(k => k.Durum == true).Count();
            ViewBag.aktifilan = aktifilan;
            // Satılık
            var satilik = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 1).Count();
            ViewBag.satilik = satilik;
            // Kiralık
            var kiralik = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 2).Count();
            ViewBag.kiralik = kiralik;
            //Otomobil
            var d13 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 13).Count();
            ViewBag.d13 = d13;


            var d = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 1).Count();
            ViewBag.d3 = d;

            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));


        }


        // Part Kısmıları satılık kiralık
        public PartialViewResult DbilanDurum()
        {
            var degr = dr.DbilanDurum.Where(k => k.Durum == true).ToList();

            var d = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 1).Count();
            ViewBag.d3 = d;

            var d1 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 2).Count();
            ViewBag.d4 = d1;


            return PartialView(degr);
        }


         // Part Kısmıları satılık kiralık
        public PartialViewResult DbilanFilter()
        {
            var degr = dr.Dbilan.Where(k => k.Durum == true  && k.MOnay==true).ToList();

            var d = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 1).Count();
            ViewBag.d3 = d;

            var d1 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 2).Count();
            ViewBag.d4 = d1;


            return PartialView(degr);
        }


         // güncel dövüz çek
        //public PartialViewResult GuncelDovuz()
        //{
        //    List<DovizModel> CurList = null;

        //    WebClient client = new WebClient();

        //    var json = client.DownloadString("https://api.genelpara.com/embed/doviz.json");

        //    CurList = JsonConvert.DeserializeObject<List<DovizModel>>(json);

        //    if (CurList == null)
        //        return null;

        //    return PartialView(CurList.Take(3).ToList());
        //}




        // Kiralık ilan

        public ActionResult Kiralikilan(string p, int sayfa = 1)
        {
            //var d1 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 2).ToList();
            //return View(d1);

            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 5));
        }

        // Satılık ilan

        public ActionResult Satilikilan(string p, int sayfa = 1)
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            // var d1 = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(l => l.ilanID).ToList();
            // var d1 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 1).ToList();

            // return View(d1);
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 5));
        }



        // Part Kısmıları Villa, Aprt vs
        public PartialViewResult DbEmlakTipi()
        {
            var degr = dr.DbEmlakTipi.Where(l => l.Durum == true).ToList();

            //Apartman
            var d1 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 1).Count();
            ViewBag.d1 = d1;

            //Daire
            var d2 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 2).Count();
            ViewBag.d2 = d2;

            //Arsa
            var d3 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 3).Count();
            ViewBag.d3 = d3;
            //Müstakil
            var d4 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 4).Count();
            ViewBag.d4 = d4;

            //Dubleks
            var d5 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 5).Count();
            ViewBag.d5 = d5;

            //Arazi
            var d6 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 6).Count();
            ViewBag.d6 = d6;

            //Dükkan
            var d7 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 7).Count();
            ViewBag.d7 = d7;
            //İşyeri
            var d8 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 8).Count();
            ViewBag.d8 = d8;

            //Bahçe
            var d9 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 9).Count();
            ViewBag.d9 = d9;

            //Petrol İstasyonu
            var d10 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 10).Count();
            ViewBag.d10 = d10;

            //Çiftlik
            var d11 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 11).Count();
            ViewBag.d11 = d11;

            //Ahır
            var d12 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 12).Count();
            ViewBag.d12 = d12;
            //Otomobil
            var d13 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 13).Count();
            ViewBag.d13 = d13;

            //Traktör
            var d14 = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.EmlakTipIDD == 14).Count();
            ViewBag.d14 = d14;



            return PartialView(degr);
        }



        // İlan Detay Yeni 10 ilan

        public PartialViewResult AnasayfaKiralikilanPart()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(u => u.ilanID).Take(5).ToList();
            return PartialView(deger);
        }




        // Tüm İlanlar

        public ActionResult Tumilanlar()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(u => u.ilanID).ToList();

            return View(deger);
        }

        // İlan Ara
        [HttpGet]
        public PartialViewResult ilanAra(int? id, string p)
        {
            var sonuc = from s in dr.Dbilan select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }
            return PartialView(sonuc.ToList());
        }





        // Ana Sayfa yeni 5 ilan

        public PartialViewResult YeniilanPart(int sayfa = 1)
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(u => u.ilanID).ToList().ToPagedList(sayfa, 5);
            return PartialView(deger);
        }

        // İlan Detay
        [Route("ilanlari_incele/{baslik1}")]
        public ViewResult ilanDetay(int? id)
        {
            // var degerler = dr.Dbilan.Where(l => l.ilanID == id).ToList();
            //var degerler = dr.Dbilan.Include(k => k.DbilanGallery).Where(l => l.ilanID == id).ToList();
            var degerler = dr.Dbilan.Include(k => k.DbilanGallery).SingleOrDefault(l => l.ilanID == id);
            return View(degerler);

        }


        public ActionResult ResimIncele(int id)
        {
            var d = dr.DbilanGallery.Where(x => x.İlanIDD == id).ToList();
            return View(d);
        }

        //public ViewResult ilanDetay(int id)
        //{
        //    var degerler = dr.Dbilan.Where(l => l.ilanID == id).ToList();
        //    return View(degerler);
        //}



        // İlan Detay Yeni 10 ilan

        public PartialViewResult ilanDetayPart()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(u => u.ilanID).Take(6).ToList();
            return PartialView(deger);
        }




        // İlan Detay Satılık Yeni 10 ilan

        public PartialViewResult ilanDetayKiralikPart()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(y => y.ilanID).Take(6).ToList();
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
                ViewBag.Kontrol = "Habaryňyz üstünlikli iberildi!";
                m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                m.Durum = true;
                dr.SaveChanges();
                TempData["mesaj"] = "";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Kontrol = "Habaryňyzy ibereniňizde säwlik ýüze çykdy.!!!!";
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
        [Route("BlogDetay/{baslik3}")]
        public ActionResult BlogDetay(int id)
        {
            var deger = dr.DbBlog.Where(k => k.BlogID == id).ToList();
            return View(deger);
        }





        // KVKK
        public ActionResult KVKK()
        {
            return View();
        }


    }
}