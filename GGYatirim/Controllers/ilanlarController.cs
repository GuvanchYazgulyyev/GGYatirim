using GGYatirim.Models.Sinif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GGYatirim.Controllers
{
    [AllowAnonymous]
    public class ilanlarController : Controller
    {
        GYatirimEntities dr = new GYatirimEntities();
        // GET: ilanlar


        // Apartman
        public ActionResult Apartman()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(deger);
        }

        // Daire

        public ActionResult Daire()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }



         // Arsa

        public ActionResult Arsa()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }

        // Müstakil

        public ActionResult Mustakil()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }



        // Dubleks
        public ActionResult Dubleks()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }



        // Arazi
        public ActionResult Arazi()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }

        // Dükkan
        public ActionResult Dukkan()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }


        // İşyeri
        public ActionResult isyeri()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }


        // Bahçe
        public ActionResult Bahce()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }


        // Petrol İstasyonu
        public ActionResult Petrolistasyon()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }


        // Çiftlik
        public ActionResult Ciftlik()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }


        // Ahır
        public ActionResult Ahir()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }


        // Otomobil
        public ActionResult Otomobil()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }


        // Traktör
        public ActionResult Traktor()
        {
            //  var d1 = dr.Dbilan.Where(f => f.Durum == true).Where(f => f.ilanDurumIDD == 1).ToList();
            var d1 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList();
            return View(d1);
        }


        // İlan Ara

        public PartialViewResult ilanAra( string p)
        {
            var sonuc = from s in dr.Dbilan select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p));
            }

            return PartialView(sonuc.ToList());
            //var urngtr = from x in dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID) select x;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    urngtr = urngtr.Where(x => x.ilanNo.Contains(p));
            //}
            //return PartialView(urngtr.ToList());


        }




    }
}