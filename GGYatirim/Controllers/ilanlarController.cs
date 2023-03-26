using GGYatirim.Models.Sinif;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GGYatirim.Controllers
{
    [AllowAnonymous]
    public class ilanlarController : Controller
    {
        GYatirimEntities dr = new GYatirimEntities();
        // GET: ilanlar


        // Apartman


        [Route("Tumilanlar")]
        public ActionResult Apartman()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(l => l.ilanID).ToList();
            return View(deger);
        }

        // Daire

        public ActionResult Daire(string p, int sayfa = 1)
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            // var d1 = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(l => l.ilanID).ToList();
            // return View(d1);

            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }



        // Arsa

        public ActionResult Arsa(string p, int sayfa = 1)
        {

            //var d1 = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(l => l.ilanID).ToList();
            //return View(d1);

            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }

        // Müstakil

        public ActionResult Mustakil(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }



        // Dubleks
        public ActionResult Dubleks(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }



        // Arazi 6
        public ActionResult Arazi(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }

        // Dükkan 7
        public ActionResult Dukkan(string p, int sayfa = 1)
        {
            //  var d1 = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(l => l.ilanID).ToList();
            // return View(d1);
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }


        // İşyeri 8
        public ActionResult isyeri(string p, int sayfa = 1)
        {
            //  var d1 = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(l => l.ilanID).ToList();
            // return View(d1);
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }


        // Bahçe 9
        public ActionResult Bahce(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }


        // Petrol İstasyonu 10
        public ActionResult Petrolistasyon(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }


        // Çiftlik 11
        public ActionResult Ciftlik(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }


        // Ahır 12
        public ActionResult Ahir(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }


        // Otomobil 13
        public ActionResult Otomobil(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }


        // Traktör 14
        public ActionResult Traktor(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }


        // İlan Ara
        // Çalışmıyor
        public PartialViewResult ilanAra(string p)
        {
            var sonuc = from s in dr.Dbilan.Where(k=>k.Durum==true && k.MOnay==true) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }

            return PartialView(sonuc.ToList());
            //var urngtr = from x in dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID) select x;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    urngtr = urngtr.Where(x => x.ilanNo.Contains(p));
            //}
            //return PartialView(urngtr.ToList());


        }





        // Sıralama Kısmı Max Fiyat

        public ActionResult FiyatArtan(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.TamFiyat) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }

          // Sıralama Kısmı Min Fiyat

        public ActionResult FiyatAzalan(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderBy(f => f.TamFiyat) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }

        // Sıralama Kısmı Tarih

        public ActionResult Tarih(string p, int sayfa = 1)
        {
            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.Tarih) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }


            return View(sonuc.ToList().ToPagedList(sayfa, 6));
        }




        // İlan Detay
        [Route("ilanDetaylar/{baslik2}")]
        public ViewResult ilanDetaylar(int? id)
        {
            // var degerler = dr.Dbilan.Where(l => l.ilanID == id).ToList();
            //var degerler = dr.Dbilan.Include(k => k.DbilanGallery).Where(l => l.ilanID == id).ToList();
            var degerler = dr.Dbilan.Include(k => k.DbilanGallery).SingleOrDefault(l => l.ilanID == id);
            return View(degerler);

        }

    }
}