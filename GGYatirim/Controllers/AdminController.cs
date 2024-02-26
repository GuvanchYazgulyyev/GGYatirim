using GGYatirim.Models.Sinif;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList; ///  Sayfalama için gerekli olan Kütüphaneler
using PagedList.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Web.Security;
using ActionResult = System.Web.Mvc.ActionResult;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;  // Resim detay kısmı için gerekli (include)  Methodu

///  Sayfalama için gerekli olan Kütüphaneler

namespace GGYatirim.Controllers
{

    public class AdminController : Controller
    {

        GYatirimEntities dr = new GYatirimEntities();

        // GET: Admin
        public ActionResult Index()
        {

            var mail = (string)Session["EPosta"];
            // Ad
            var ad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.ad = ad;

            // Onaylı İlanlar say
            var onayilan = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == true).Count();
            ViewBag.onayilan = onayilan;

            // Onaylı İlanlar say
            var onaysiz = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == false).Count();
            ViewBag.onaysiz = onaysiz;

            // Onaylı İlanlar say
            var toplamilan = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == false && k.MOnay == true).Count();
            ViewBag.toplamilan = toplamilan;

            // Bilgi Güncelleme Durumu 

            var bilgiguncelle = dr.DbAdmin.Where(l => l.EPosta == mail && l.Durum == true).ToList();

            //ViewBag.bilgiguncelle = bilgiguncelle;


            // Admin Görebilir 
            // Aktif Müşteri
            var musterisay = dr.DbKullanici.Where(k => k.Durum == true).Count();
            ViewBag.musterisay = musterisay;

            // Admin Görebilir 
            // pasif  Müşteri
            var musterisay2 = dr.DbKullanici.Where(k => k.Durum == false).Count();
            ViewBag.musterisay2 = musterisay2;

            // Akrif ilan
            var aktifilan = dr.Dbilan.Where(k => k.Durum == true).Count();
            ViewBag.aktifilan = aktifilan;
            // Pasif ilan
            var pasifilan = dr.Dbilan.Where(k => k.Durum == false).Count();
            ViewBag.pasifilan = pasifilan;
            // OnayBekleyen ilan
            var onaybekleyenilan = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == false).Count();
            ViewBag.onaybekleyenilan = onaybekleyenilan;

            // Gelenmesajlar
            var gelenmesaj = dr.DbiletisimForm.Where(k => k.Durum == true).Count();
            ViewBag.gelenmesaj = gelenmesaj;

            // Temsilci
            var temsilci = dr.DbTemsilci.Where(k => k.Durum == true).Count();
            ViewBag.temsilci = temsilci;

            // Blogsayisi
            var blogsayisi = dr.DbBlog.Where(k => k.Durum == true).Count();
            ViewBag.blogsayisi = blogsayisi;

            // Satılık
            var satilik = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 1).Count();
            ViewBag.satilik = satilik;

            // Kiralık
            var kiralik = dr.Dbilan.Where(f => f.Durum == true && f.MOnay == true).Where(f => f.ilanDurumIDD == 2).Count();
            ViewBag.kiralik = kiralik;


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




            return View(bilgiguncelle);
        }




        /////////////////////////////////---------------------------------------------- AdmEmlakTipi
        /////

        public ActionResult AdmEmlakTipi()
        {
            var value33 = dr.DbEmlakTipi.Where(k => k.Durum == true).OrderByDescending(l => l.EmlakTipiID).ToList();
            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmEmlakTipiEkle()
        {

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdmEmlakTipiEkle(DbEmlakTipi u)
        {



            u.Durum = true;
            dr.DbEmlakTipi.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdmEmlakTipi");


        }

        ////// Hizmet Sil
        /////
        public ActionResult AdmEmlakTipiSil(int id)
        {
            var urnsil = dr.DbEmlakTipi.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmEmlakTipi");
        }


        // Getir

        public ActionResult AdmEmlakTipiGetir(int id)
        {


            var urngetr = dr.DbEmlakTipi.Find(id);
            return View("AdmEmlakTipiGetir", urngetr);
        }

        //// Güncellle

        public ActionResult AdmEmlakTipiGuncelle(DbEmlakTipi u)
        {
            var value = dr.DbEmlakTipi.Find(u.EmlakTipiID);

            value.EmlakTipAd = u.EmlakTipAd;
            value.Durum = true;
            dr.SaveChanges();
            return RedirectToAction("AdmEmlakTipi");

        }








        /////////////////////////////////---------------------------------------------- AdmilanDurumu
        /////

        public ActionResult AdmilanDurumu()
        {
            var value33 = dr.DbilanDurum.Where(k => k.Durum == true).OrderByDescending(l => l.ilanDurumID).ToList();
            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmilanDurumuEkle()
        {

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdmilanDurumuEkle(DbilanDurum u)
        {



            u.Durum = true;
            dr.DbilanDurum.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdmilanDurumu");


        }

        ////// Hizmet Sil
        /////
        public ActionResult AdmilanDurumuSil(int id)
        {
            var urnsil = dr.DbilanDurum.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmilanDurumu");
        }


        // Getir

        public ActionResult AdmilanDurumuGetir(int id)
        {


            var urngetr = dr.DbilanDurum.Find(id);
            return View("AdmilanDurumuGetir", urngetr);
        }

        //// Güncellle

        public ActionResult AdmilanDurumuGuncelle(DbilanDurum u)
        {
            var value = dr.DbilanDurum.Find(u.ilanDurumID);

            value.ilanDurumAd = u.ilanDurumAd;
            value.Durum = true;
            dr.SaveChanges();
            return RedirectToAction("AdmilanDurumu");

        }












        /////////////////////////////////---------------------------------------------- AdmilanOzellik
        /////

        public ActionResult AdmilanOzellik()
        {
            var value33 = dr.DbilanOzellik.Where(k => k.Durum == true).OrderByDescending(l => l.ilanOzellikID).ToList();
            return View(value33);
        }



        ///// Ekle AdmilanOzellik
        ///

        [HttpGet]
        public ActionResult AdmilanOzellikEkle()
        {

            return View();
        }


        // Veriler geldiginde HttpPost çalışır AdmilanOzellik
        [HttpPost]
        public ActionResult AdmilanOzellikEkle(DbilanOzellik u)
        {



            u.Durum = true;
            dr.DbilanOzellik.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdmilanOzellik");


        }

        ////// Hizmet Sil  AdmilanOzellik
        /////
        public ActionResult AdmilanOzellikSil(int id)
        {
            var urnsil = dr.DbilanOzellik.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmilanOzellik");
        }


        // Getir  AdmilanOzellik

        public ActionResult AdmilanOzellikGetir(int id)
        {


            var urngetr = dr.DbilanOzellik.Find(id);
            return View("AdmilanOzellikGetir", urngetr);
        }

        //// Güncellle  AdmilanOzellik

        public ActionResult AdmilanOzellikGuncelle(DbilanOzellik u)
        {
            var value = dr.DbilanOzellik.Find(u.ilanOzellikID);

            value.OzellikAd = u.OzellikAd;
            value.Durum = true;
            dr.SaveChanges();
            return RedirectToAction("AdmilanOzellik");

        }









        /////////////////////////////////---------------------------------------------- AdmKonum
        /////

        public ActionResult AdmKonum()
        {
            var value33 = dr.DbKonum.Where(k => k.Durum == true).OrderByDescending(l => l.KonumID).ToList();
            return View(value33);
        }



        ///// Ekle AdmKonum
        ///

        [HttpGet]
        public ActionResult AdmKonumEkle()
        {

            return View();
        }


        // Veriler geldiginde HttpPost çalışır AdmKonum
        [HttpPost]
        public ActionResult AdmKonumEkle(DbKonum u)
        {



            u.Durum = true;
            dr.DbKonum.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdmKonum");


        }

        ////// Hizmet Sil  AdmKonum
        /////
        public ActionResult AdmKonumSil(int id)
        {
            var urnsil = dr.DbKonum.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmKonum");
        }


        // Getir  AdmilanOzellik

        public ActionResult AdmKonumGetir(int id)
        {


            var urngetr = dr.DbKonum.Find(id);
            return View("AdmKonumGetir", urngetr);
        }

        //// Güncellle  AdmilanOzellik

        public ActionResult AdmKonumGuncelle(DbKonum u)
        {
            var value = dr.DbKonum.Find(u.KonumID);

            value.SehirAd = u.SehirAd;
            value.Durum = true;
            dr.SaveChanges();
            return RedirectToAction("AdmKonum");

        }






        /////////////////////////////////---------------------------------------------- Siliniş İlanlar
        /////
        [Authorize(Roles = "Admin")]
        public ActionResult AdmSilinmisilan(string p, int sayfa = 1)
        {
            var silinmisilan = dr.Dbilan.Where(k => k.Durum == false).Count();
            ViewBag.silinmisilan = silinmisilan;

            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == false).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower()) || s.KAdSoyad.Contains(p.ToLower())
                || s.KEPosta.Contains(p.ToLower()) || s.KTel.Contains(p.ToLower()) || s.KullaniciNo.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }

            if (sonuc == null)
            {
                throw new Exception("İlan Bulunamadı!");
            }

            return View(sonuc.ToList().ToPagedList(sayfa, 10));

        }






        /////////////////////////////////---------------------------------------------- Siliniş Müşteriler
        /////
        [Authorize(Roles = "Admin")]
        public ActionResult AdmSilinmisMusteriler()
        {
            var value33 = dr.DbKullanici.Where(k => k.Durum == false).OrderByDescending(l => l.KullaniciID).ToList();
            return View(value33);
        }







        //  İlan Detay

        public ActionResult AdmSilinmisilanDetay(int id)
        {

            //  var degerler = dr.Dbilan.Where(l => l.ilanID == id).ToList();
            var ilandetay = dr.Dbilan.Include(u => u.DbilanGallery).SingleOrDefault(k => k.Durum == true && k.ilanID == id);

            // Yeni Eklendi
            // var mail = (string)Session["EPosta"];
            // var ilandetay = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true && k.ilanID == id).ToList();
            return View(ilandetay);
        }





        // Toplam Silinmiş İlan Detay

        public ActionResult AdmToplamSilinmisilanDetay(int id)
        {
            var ilandetay = dr.Dbilan.Include(u => u.DbilanGallery).SingleOrDefault(k => k.Durum == false && k.ilanID == id);

            if (ilandetay.Durum != null)
            {
                return View(ilandetay);
            }
            else
            {
                return RedirectToAction("Admin", "AdmSilinmisilan");
            }

        }








        /////////////////////////////////---------------------------------------------- Admilan Kişilere Ozel ilan
        /////

        public ActionResult AdmKisiilan(string p, int sayfa = 1)
        {
            // saydır
            var tumonayliilan = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).Count();
            ViewBag.tumonayliilan = tumonayliilan;

            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower()) || s.KAdSoyad.Contains(p.ToLower())
                || s.KEPosta.Contains(p.ToLower()) || s.KTel.Contains(p.ToLower()) || s.KullaniciNo.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }

            if (sonuc == null)
            {
                throw new Exception("İlan Bulunamadı!");
            }

            return View(sonuc.ToList().ToPagedList(sayfa, 10));
        }


        //  Kişinin Kenddine Ait ilanları Listeler Listele
        public ActionResult Admilanlarim(string p, int sayfa = 1)
        {

            var mail = (string)Session["EPosta"];

            // saydır
            var tumonayliilanadmin = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true && k.MOnay == true).Count();
            ViewBag.tumonayliilanadmin = tumonayliilanadmin;

            var sonuc = from s in dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower()) || s.KAdSoyad.Contains(p.ToLower())
                || s.KEPosta.Contains(p.ToLower()) || s.KTel.Contains(p.ToLower()) || s.KullaniciNo.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }

            if (sonuc == null)
            {
                throw new Exception("İlan Bulunamadı!");
            }

            return View(sonuc.ToList().ToPagedList(sayfa, 10));
        }






        /////////////////////////////////---------------------------------------------- Admilannnn
        /////
        [Authorize(Roles = "Admin")]
        public ActionResult Admilan(string p, int sayfa = 1)
        {
            var mail = (string)Session["EPosta"];
            var ilansayi = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true && k.MOnay == true).Count();
            ViewBag.ilansayi = ilansayi;

            var sonuc = from s in dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower()) || s.KAdSoyad.Contains(p.ToLower())
                || s.KEPosta.Contains(p.ToLower()) || s.KTel.Contains(p.ToLower()) || s.KullaniciNo.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }

            if (sonuc == null)
            {
                throw new Exception("İlan Bulunamadı!");
            }

            return View(sonuc.ToList().ToPagedList(sayfa, 10));
        }



        // Müşteriler Onay Bekleyen İlanlar

        //[Authorize(Roles = "Admin")]
        //public ActionResult OnayBekleyenilan(int sayfa = 1)
        //{
        //    var mail = (string)Session["EPosta"];
        //    var adsoyad = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true && k.MOnay == false).Count();
        //    ViewBag.adsoyad = adsoyad;
        //    var value33 = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == false).OrderByDescending(l => l.ilanID).ToList().ToPagedList(sayfa, 10);
        //    if (value33 == null)
        //    {
        //        throw new Exception("İlan Bulunamadı!");
        //    }
        //    return View(value33);

        //}




        // Müşteriler Onay Bekleyen İlanlar

        [Authorize(Roles = "Admin")]
        public ActionResult OnayBekleyenilan(string p, int sayfa = 1)
        {
            var mail = (string)Session["EPosta"];
            var onaybekleyen = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == false).Count();
            ViewBag.onaybekleyen = onaybekleyen;

            var sonuc = from s in dr.Dbilan.Where(k => k.Durum == true && k.MOnay == false).OrderByDescending(f => f.ilanID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.ilanNo.Contains(p.ToLower()) || s.EmlakTipi.Contains(p.ToLower()) || s.KAdSoyad.Contains(p.ToLower())
                || s.KEPosta.Contains(p.ToLower()) || s.KTel.Contains(p.ToLower()) || s.KullaniciNo.Contains(p.ToLower())
                || s.Aciklama.Contains(p.ToLower()) || s.DbEmlakTipi.EmlakTipAd.Contains(p.ToLower())
                || s.DbilanDurum.ilanDurumAd.Contains(p.ToLower()));
            }

            if (sonuc == null)
            {
                throw new Exception("İlan Bulunamadı!");
            }

            return View(sonuc.ToList().ToPagedList(sayfa, 10));


        }




        ////// Müşteriden Gelen İlanları Onayla
        /////
        public ActionResult MusteriilanOnayla(int id)
        {
            var urnsil = dr.Dbilan.Find(id);
            urnsil.Durum = true;
            urnsil.MOnay = true;
            dr.SaveChanges();

            if (urnsil != null)
            {
                SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("talep@wesigo.com", "İlan Onayı");
                mail.To.Add(urnsil.EPosta);
                mail.IsBodyHtml = true;
                mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                mail.Body = "Merhaba Sayın: <b> " + urnsil.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + urnsil.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + urnsil.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + urnsil.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                client.Credentials = net;
                client.Send(mail);
                //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
            }


            return RedirectToAction("Admilan", "Admin");
        }









        ////// Hizmet Sil  Admilan
        /////


        public ActionResult AdmilanSil(int id)
        {
            var urnsil = dr.Dbilan.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("Admilan");
        }



        ///// Ekle AdmKonum
        ///

        [HttpGet]
        public ActionResult AdmilanEkle()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;
            var tel = dr.DbAdmin.Where(k => k.EPosta == mail).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;

            //DbEmlakTipi
            //List<SelectListItem> d2 = (from x in dr.DbEmlakTipi.Where(l => l.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.EmlakTipAd,
            //                               Value = x.EmlakTipiID.ToString()
            //                           }).ToList();
            //ViewBag.dgr2 = d2;

            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }


        // Veriler geldiginde HttpPost çalışır Admilan
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkle(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 1;
                u.MOnay = true;
                u.Durum = true;
                dr.SaveChanges();

                if (u != null)
                {

                    //SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    //client.EnableSsl = true;
                    //MailMessage mail = new MailMessage();
                    //mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    //mail.To.Add(u.EPosta);
                    //mail.IsBodyHtml = true;
                    //mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    //mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    //NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    //client.Credentials = net;
                    //client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";


                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);

                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");


            }
            return View();
        }





        // İlan Güncelle

        public ActionResult AdmilanGetir(int id)
        {

            var mail = (string)Session["EPosta"];
            if ((string)Session["EPosta"] == null)
            { 
              //  return RedirectToAction("LogOut", "Admin");
                return RedirectToAction("Index", "Admin");
            }


            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;
            var tel = dr.DbAdmin.Where(k => k.EPosta == mail).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;

            var kno = dr.DbAdmin.Where(k => k.EPosta == mail).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            //DbEmlakTipi
            //List<SelectListItem> d2 = (from x in dr.DbEmlakTipi.Where(l => l.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.EmlakTipAd,
            //                               Value = x.EmlakTipiID.ToString()
            //                           }).ToList();
            //ViewBag.dgr2 = d2;

            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;

           // var id = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true).Select(k => k.ilanID).SingleOrDefault();  birden fazla ilan yayınlalınca hata alıyoruz
        //    var ilandetay = dr.Dbilan.SingleOrDefault(k => k.EPosta == mail && k.Durum == true && k.ilanID == id);

            var urngetr = dr.Dbilan.Where(i=>i.EPosta==mail && i.ilanID == id).FirstOrDefault();
            //var urngetr = dr.Dbilan.Find(id);
            return View("AdmilanGetir", urngetr);
        }


        // İlan Güncelle

        public ActionResult AdmilanGuncelle(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }
                var value = dr.Dbilan.Find(u.ilanID);

                if (u.VitrinResim != null)
                {
                    value.VitrinResim = u.VitrinResim;
                }
                if (u.CokluResim != null)
                {
                    value.CokluResim = u.CokluResim;
                }
                value.EmlakTipi = u.EmlakTipi;
                value.TamAdres = u.TamAdres;
                value.TamFiyat = u.TamFiyat;
                value.MetreKareFiyat = u.MetreKareFiyat;
                value.Aciklama = u.Aciklama;
                value.AlanBoyutu = u.AlanBoyutu;
                value.KurulusYili = u.KurulusYili;
                value.AraziAlanı = u.AraziAlanı;
                value.Banyo = u.Banyo;
                value.OdaSayisi = u.OdaSayisi;
                value.Garaj = u.Garaj;
                value.Aidat = u.Aidat;
                value.BulunduguKat = u.BulunduguKat;
                value.KatSayisi = u.KatSayisi;
                value.ilanOzellikIDD = u.ilanOzellikIDD;
                //  value.EmlakTipIDD = u.EmlakTipIDD;
                value.ilanDurumIDD = u.ilanDurumIDD;
                value.KonumIDD = u.KonumIDD;
                value.Durum = true;
                value.isitma = u.isitma;
                value.Esyali = u.Esyali;
                value.KullanimDurumu = u.KullanimDurumu;
                value.Siteicerisinde = u.Siteicerisinde;
                value.KrediyeUygun = u.KrediyeUygun;
                value.Takasli = u.Takasli;
                value.TapuDurumu = u.TapuDurumu;
                value.ZeminEtudu = u.ZeminEtudu;
                value.YapininDurumu = u.YapininDurumu;
                value.YakitTipi = u.YakitTipi;
                value.OzelNor = u.OzelNor;
                value.Balkon = u.Balkon;
                value.SiteAdi = u.SiteAdi;
                u.MOnay = true;
                value.GoogleMapAdres = u.GoogleMapAdres;
                // Burası Kullanıcı Bilgilerini Kaydeder

                value.KProfil = u.KProfil;
                value.KAdSoyad = u.KAdSoyad;
                value.KMeslek = u.KMeslek;
                value.KKisaAciklama = u.KKisaAciklama;
                value.KTel = u.KTel;
                value.KEPosta = u.KEPosta;
                value.KullaniciNo = u.KullaniciNo;

                // Burası Kullanıcı Bilgilerini Kaydeder

                value.ArsaImarDurum = u.ArsaImarDurum;
                value.ArsaAdaNo = u.ArsaAdaNo;
                value.ArsaParselNo = u.ArsaParselNo;
                value.ArsaPaftaNo = u.ArsaPaftaNo;
                value.ArsaKaks = u.ArsaKaks;
                value.ArsaGabari = u.ArsaGabari;

                value.PetrolAcilAlan = u.PetrolAcilAlan;
                value.PetrolKapaliAlan = u.PetrolKapaliAlan;
                value.PetrolPompaSayisi = u.PetrolPompaSayisi;

                value.ArabaSerisi = u.ArabaSerisi;
                value.ArabaModel = u.ArabaModel;
                value.ArabaYil = u.ArabaYil;
                value.ArabaVites = u.ArabaVites;
                value.ArabaKM = u.ArabaKM;
                value.ArabaKasaTipi = u.ArabaKasaTipi;
                value.ArabaMotorGucu = u.ArabaMotorGucu;
                value.ArabaMotorHacmi = u.ArabaMotorHacmi;
                value.ArabaCekis = u.ArabaCekis;
                value.ArabaRenk = u.ArabaRenk;
                value.ArabaGarantili = u.ArabaGarantili;
                value.ArabaPlakaUyrugu = u.ArabaPlakaUyrugu;

                value.TraktorMarka = u.TraktorMarka;
                value.TraktorKabin = u.TraktorKabin;
                value.TraktorVites = u.TraktorVites;
                value.TraktorMotorGücü = u.TraktorMotorGücü;
                value.TraktorSlinderSayisi = u.TraktorSlinderSayisi;
                value.TraktorCalismaSaati = u.TraktorCalismaSaati;
                value.TraktorOnYukleyiciKepce = u.TraktorOnYukleyiciKepce;
                value.TraktorOnLastik = u.TraktorOnLastik;
                value.TraktorArkaLastik = u.TraktorArkaLastik;





                // Çoklu Resim
                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {

                        string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                        string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                        string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                        item.SaveAs(Server.MapPath(tamYol));

                        var ilanGaleri = new DbilanGallery
                        {
                            URL = tamYol,
                            EklenmeTarihi = DateTime.Now
                        };
                        ilanGaleri.İlanIDD = u.ilanID;
                        dr.DbilanGallery.Add(ilanGaleri);

                        u.Durum = true;
                        dr.SaveChanges();

                    }
                }



                dr.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }



















        /// <summary>
        /// //////////////////////////////////////////////////////////////Daire
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleDaire()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleDaire(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 2;
                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {

                    //SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    //client.EnableSsl = true;
                    //MailMessage mail = new MailMessage();
                    //mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    //mail.To.Add(u.EPosta);
                    //mail.IsBodyHtml = true;
                    //mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    //mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    //NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    //client.Credentials = net;
                    //client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";


                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }













        /// <summary>
        /// //////////////////////////////////////////////////////////////Arsa
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleArsa()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;


            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            ////DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleArsa(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 3;
                // u.ilanOzellikIDD = 2;
                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }



















        /// <summary>
        /// //////////////////////////////////////////////////////////////Müstakil
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleMustakil()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;

            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleMustakil(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 4;

                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                //  return RedirectToAction("Admilan");
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }





















        /// <summary>
        /// //////////////////////////////////////////////////////////////Dubleks
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleDubleks()
        {

            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;



            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleDubleks(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 5;

                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }


                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }




















        /// <summary>
        /// //////////////////////////////////////////////////////////////Arazş
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleArazi()
        {

            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;




            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            ////DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleArazi(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 6;
                // u.ilanOzellikIDD = 2;
                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }


















        /// <summary>
        /// //////////////////////////////////////////////////////////////Dükkan
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleDukkan()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;




            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleDukkan(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 7;

                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }






















        /// <summary>
        /// //////////////////////////////////////////////////////////////İşyeri
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleisteri()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;




            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleisteri(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 8;

                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }


                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }




















        /// <summary>
        /// //////////////////////////////////////////////////////////////Bahçe
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleBahce()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;




            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleBahce(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 9;
                //  u.ilanOzellikIDD = 2;

                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }



















        /// <summary>
        /// //////////////////////////////////////////////////////////////Petrol İstasyonu
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEklePetrolistasyon()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEklePetrolistasyon(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 10;
                // u.ilanOzellikIDD = 2;

                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }



















        /// <summary>
        /// //////////////////////////////////////////////////////////////Çiftlik
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleCiftlik()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleCiftlik(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 11;
                // u.ilanOzellikIDD = 2;

                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }






















        /// <summary>
        /// //////////////////////////////////////////////////////////////Ahır
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleAhir()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleAhir(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 12;
                //u.ilanOzellikIDD = 2;

                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }





















        /// <summary>
        /// //////////////////////////////////////////////////////////////Otomobil
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleOtomobil()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleOtomobil(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 13;


                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }

                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }

























        /// <summary>
        /// //////////////////////////////////////////////////////////////Traktör
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult AdmilanEkleTraktor()
        {

            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;



            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Tel).FirstOrDefault();
            ViewBag.tel = tel;
            //var profil = dr.DbAdmin.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.).FirstOrDefault();
            //ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            //DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;



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
            return View();
        }





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmilanEkleTraktor(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                    u.VitrinResim = "/ilanResimler/" + uzanti;

                }



                dr.Dbilan.Add(u);
                u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.EmlakTipIDD = 14;
                //   u.ilanOzellikIDD = 2;


                u.Durum = true;
                u.MOnay = true;
                dr.SaveChanges();

                //if (u != null)
                //{
                //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                //    client.EnableSsl = true;
                //    MailMessage mail = new MailMessage();
                //    mail.From = new MailAddress("kivancturkmen@gmail.com", "İlan Yayınlama İsteği");
                //    mail.To.Add(u.EPosta);
                //    mail.IsBodyHtml = true;
                //    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                //    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                //    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                //    client.Credentials = net;
                //    client.Send(mail);
                //    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                //}


                if (u != null)
                {
                    SmtpClient client = new SmtpClient("webmail.wesigo.com", 587);
                    client.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("talep@wesigo.com", "İlan Yayınlama İsteği");
                    mail.To.Add(u.EPosta);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlanınız Yayınlanmıştır, saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";
                }



                string CokResim = System.IO.Path.GetExtension(Request.Files[1].FileName);
                // if (CokluResim != null)
                if (CokResim != "")
                {
                    foreach (var item in CokluResim)
                    {
                        if (item.ContentLength > 0)
                        {
                            string dosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            string uzanti = System.IO.Path.GetExtension(Request.Files[1].FileName);
                            string tamYol = "/ilanResimler/" + dosyaAdi + uzanti;
                            item.SaveAs(Server.MapPath(tamYol));

                            var ilanGaleri = new DbilanGallery
                            {
                                URL = tamYol,
                                EklenmeTarihi = DateTime.Now
                            };
                            ilanGaleri.İlanIDD = u.ilanID;
                            dr.DbilanGallery.Add(ilanGaleri);
                            // u.MOnay = false;
                            u.Durum = true;
                            dr.SaveChanges();
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");

            }
            return View();
        }









        // Eklemenin Yanındaki İlan Sadece 1 tane ilan Göster


        public PartialViewResult AdmYeniilanPart()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true && k.MOnay == true).OrderByDescending(k => k.ilanID).Take(1).ToList();
            return PartialView(deger);
        }







        /////////////////////////////////---------------------------------------------- AdmiletisimBilgi
        /////

        public ActionResult AdmiletisimBilgi()
        {
            var value33 = dr.DbiletisimBilgi.Where(k => k.Durum == true).OrderByDescending(l => l.iletisimBilgiID).ToList();
            return View(value33);
        }



        ///// Ekle AdmiletisimBilgi
        ///

        [HttpGet]
        public ActionResult AdmiletisimBilgiEkle()
        {

            return View();
        }


        // Veriler geldiginde HttpPost çalışır AdmiletisimBilgi
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AdmiletisimBilgiEkle(DbiletisimBilgi u)
        {



            u.Durum = true;
            dr.DbiletisimBilgi.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdmiletisimBilgi");


        }

        ////// Hizmet Sil  AdmiletisimBilgi
        /////
        public ActionResult AdmiletisimBilgiSil(int id)
        {
            var urnsil = dr.DbiletisimBilgi.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmiletisimBilgi");
        }


        // Getir  AdmiletisimBilgi

        public ActionResult AdmiletisimBilgiGetir(int id)
        {


            var urngetr = dr.DbiletisimBilgi.Find(id);
            return View("AdmiletisimBilgiGetir", urngetr);
        }

        //// Güncellle  AdmiletisimBilgi

        public ActionResult AdmiletisimBilgiGuncelle(DbiletisimBilgi u)
        {
            var value = dr.DbiletisimBilgi.Find(u.iletisimBilgiID);

            value.Sube = u.Sube;
            value.Adres = u.Adres;
            value.Tel = u.Tel;
            value.EPosta = u.EPosta;
            value.Harita = u.Harita;
            value.Facebook = u.Facebook;
            value.Twetter = u.Twetter;
            value.instagram = u.instagram;
            value.Durum = true;
            dr.SaveChanges();
            return RedirectToAction("AdmiletisimBilgi");

        }
















        /////----------------------------------------------------------------İletişim (Gelen Mesaj)-----//////
        /////

        public ActionResult AdmiletsmGMesaj(string p)
        {

            var urngtr = from x in dr.DbiletisimForm.Where(k => k.Durum == true).OrderByDescending(l => l.iletisimFormID) select x;
            if (!string.IsNullOrEmpty(p))
            {
                urngtr = urngtr.Where(x => x.Tel.Contains(p));
            }
            return View(urngtr.ToList());
        }

        ////  Sil
        ///
        public ActionResult AdmMesjSil(int id)
        {
            var urnsil = dr.DbiletisimForm.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmiletsmGMesaj");
        }











        ///-----------------------------------------------------------------
        ///--------------------------------------------------Admin Kullanıcı Güncelle Ekle Sil [Authorize(Roles ="Admin")]
        ///
        ///-----------
        ///

        [Authorize(Roles = "Admin")]
        public ActionResult Adminkullanici()
        {
            var value33 = dr.DbAdmin.Where(k => k.Durum == true).ToList();

            return View(value33);
        }



        ///// Ekle
        ///
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AdminKulEkle()
        {
            List<SelectListItem> d1 = (from x in dr.DbYetki.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.YetkiAd,
                                           Value = x.AdminYetkiID.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;





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

            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdminKulEkle(DbAdmin u)
        {
            //if (ModelState.IsValid)
            //{
            //}
            u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            u.Durum = true;
            dr.DbAdmin.Add(u);
            dr.SaveChanges();
            return RedirectToAction("Adminkullanici");

            //return View();
        }

        ////  Sil
        ///
        public ActionResult AdminKulSil(int id)
        {
            var urnsil = dr.DbAdmin.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("Adminkullanici");
        }


        // Getir

        public ActionResult AdminKulGetr(int id)
        {
            List<SelectListItem> d1 = (from x in dr.DbYetki.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.YetkiAd,
                                           Value = x.AdminYetkiID.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;

            var urngetr = dr.DbAdmin.Find(id);
            return View("AdminKulGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmKulGuncelle(DbAdmin u)
        {

            var value = dr.DbAdmin.Find(u.AdminID);
            value.AdSoyad = u.AdSoyad;
            value.Tel = u.Tel;
            value.EPosta = u.EPosta;
            value.Sifre = u.Sifre;
            value.RolId = u.RolId;
            value.Durum = true;
            //value.AdminYetki.id = u.id;
            dr.SaveChanges();
            return RedirectToAction("Adminkullanici");
        }













        ///-----------------------------------------------------------------
        ///-------------------------------------------------- Kayıtlı Kullanıcı Güncelle Ekle Sil [Authorize(Roles ="Admin")]
        ///
        ///-----------
        ///
        public ActionResult AdmKayitliKullanici(string p, int sayfa = 1)
        {
            //say
            var kulsay = dr.DbKullanici.Where(k => k.Durum == true).Count();
            ViewBag.kulsay = kulsay;

            var sonuc = from s in dr.DbKullanici.Where(k => k.Durum == true).OrderByDescending(f => f.KullaniciID) select s;
            if (!string.IsNullOrEmpty(p))
            {
                sonuc = sonuc.Where(s => s.KisiAdi.Contains(p.ToLower()) || s.KisiSoyadi.Contains(p.ToLower()) || s.Telefon.Contains(p.ToLower())
                || s.EPosta.Contains(p.ToLower()) || s.Meslek.Contains(p.ToLower()) || s.KullaniciNo.Contains(p.ToLower())
                || s.KisaAciklama.Contains(p.ToLower()) || s.Sehir.Contains(p.ToLower())
                || s.TamAdres.Contains(p.ToLower()));
            }

            if (sonuc == null)
            {
                throw new Exception("İlan Bulunamadı!");
            }

            return View(sonuc.ToList().ToPagedList(sayfa, 16));
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmKayitliKullaniciEkle()
        {
            List<SelectListItem> d1 = (from x in dr.DbYetki.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.YetkiAd,
                                           Value = x.AdminYetkiID.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;

            // Kullanıcı No Üret
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


            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]

        public ActionResult AdmKayitliKullaniciEkle(DbKullanici u, HttpPostedFileBase File)
        {
            //if (ModelState.IsValid)
            //{
            //}
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
            u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            if (u.Resim != null)
            {
                u.Resim = u.Resim;
            }
            u.Durum = true;
            dr.DbKullanici.Add(u);
            dr.SaveChanges();
            return RedirectToAction("AdmKayitliKullanici");

        }

        ////  Sil
        ///
        public ActionResult AdmKayitliKullaniciSil(int id)
        {
            var urnsil = dr.DbKullanici.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmKayitliKullanici");
        }


        // Getir

        public ActionResult AdmKayitliKullaniciGetr(int id)
        {
            List<SelectListItem> d1 = (from x in dr.DbYetki.ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.YetkiAd,
                                           Value = x.AdminYetkiID.ToString()
                                       }).ToList();
            ViewBag.dgr1 = d1;

            var urngetr = dr.DbKullanici.Find(id);
            return View("AdmKayitliKullaniciGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmKayitliKullaniciGuncelle(DbKullanici u, HttpPostedFileBase File)
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
            var value = dr.DbKullanici.Find(u.KullaniciID);
            if (u.Resim != null)
            {
                value.Resim = u.Resim;
            }
            value.KisiAdi = u.KisiAdi;
            value.KisiSoyadi = u.KisiSoyadi;
            value.EPosta = u.EPosta;
            value.Sifre = u.Sifre;
            value.Meslek = u.Meslek;
            value.Telefon = u.Telefon;
            value.KisaAciklama = u.KisaAciklama;
            value.Face = u.Face;
            value.instagram = u.instagram;
            value.KullaniciRolid = u.KullaniciRolid;
            value.ilanOnaylandi = u.ilanOnaylandi;
            value.Durum = true;
            //value.AdminYetki.id = u.id;
            dr.SaveChanges();
            return RedirectToAction("AdmKayitliKullanici");
        }













        ///-----------------------------------------------------------------
        ///--------------------------------------------------Temsilci Güncelle Ekle Sil
        ///
        ///-----------
        ///
        public ActionResult AdmTemsilci()
        {
            var value33 = dr.DbTemsilci.Where(k => k.Durum == true).ToList();

            return View(value33);
        }



        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmTemsilciEkle()
        {
            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]

        public ActionResult AdmTemsilciEkle(DbTemsilci u, HttpPostedFileBase File)
        {

            if (File != null)
            {
                FileInfo fileinfo = new FileInfo(File.FileName);
                WebImage img = new WebImage(File.InputStream);
                string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                //img.Resize(225, 180, false, false);
                string tamyol = "~/ilanResimler/" + uzanti;
                img.Save(Server.MapPath(tamyol));
                u.ProfilResim = "/ilanResimler/" + uzanti;

            }

            u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            u.Durum = true;
            dr.DbTemsilci.Add(u);
            if (u.ProfilResim != null)
            {
                u.ProfilResim = u.ProfilResim;
            }
            dr.SaveChanges();
            return RedirectToAction("AdmTemsilci");

            //return View();
        }

        ////  Sil
        ///
        public ActionResult AdmTemsilciSil(int id)
        {
            var urnsil = dr.DbTemsilci.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmTemsilci");
        }


        // Getir

        public ActionResult AdmTemsilciGetr(int id)
        {
            var urngetr = dr.DbTemsilci.Find(id);
            return View("AdmTemsilciGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmTemsilciGuncelle(DbTemsilci u, HttpPostedFileBase File)
        {



            if (File != null)
            {
                FileInfo fileinfo = new FileInfo(File.FileName);
                WebImage img = new WebImage(File.InputStream);
                string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                //img.Resize(225, 180, false, false);
                string tamyol = "~/ilanResimler/" + uzanti;
                img.Save(Server.MapPath(tamyol));
                u.ProfilResim = "/ilanResimler/" + uzanti;

            }

            var value = dr.DbTemsilci.Find(u.TemsilciID);
            if (u.ProfilResim != null)
            {
                value.ProfilResim = u.ProfilResim;
            }
            value.AdSoyad = u.AdSoyad;
            value.Tel = u.Tel;
            value.EPosta = u.EPosta;
            value.Makam = u.Makam;
            value.Facebook = u.Facebook;
            value.instagram = u.instagram;
            value.Twetter = u.Twetter;
            value.WebSite = u.WebSite;
            value.Durum = true;
            //value.AdminYetki.id = u.id;
            dr.SaveChanges();
            return RedirectToAction("AdmTemsilci");
        }








        // Bloglar
        public ActionResult AdmBlog()
        {
            var deger = dr.DbBlog.Where(k => k.Durum == true).OrderByDescending(k => k.BlogID).ToList();
            return View(deger);
        }




        ///// Ekle
        ///

        [HttpGet]
        public ActionResult AdmBlogEkle()
        {
            return View();
        }


        // Veriler geldiginde HttpPost çalışır
        [HttpPost]
        public ActionResult AdmBlogEkle(DbBlog u, HttpPostedFileBase File)
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

            u.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            u.Durum = true;
            dr.DbBlog.Add(u);
            if (u.Resim != null)
            {
                u.Resim = u.Resim;
            }
            dr.SaveChanges();
            return RedirectToAction("AdmBlog");

            //return View();
        }

        ////  Sil
        ///
        public ActionResult AdmBlogSil(int id)
        {
            var urnsil = dr.DbBlog.Find(id);
            urnsil.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("AdmBlog");
        }


        // Getir

        public ActionResult AdmBlogGetr(int id)
        {
            var urngetr = dr.DbBlog.Find(id);
            return View("AdmBlogGetr", urngetr);
        }

        // Güncellle

        public ActionResult AdmBlogGuncelle(DbBlog u, HttpPostedFileBase File)
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

            var value = dr.DbBlog.Find(u.BlogID);
            if (u.Resim != null)
            {
                value.Resim = u.Resim;
            }
            value.Baslik = u.Baslik;
            value.icerik1 = u.icerik1;
            value.icerik2 = u.icerik2;
            value.icerik3 = u.icerik3;
            value.EPosta = u.EPosta;
            value.EPosta = u.EPosta;
            value.Durum = true;
            //value.AdminYetki.id = u.id;
            dr.SaveChanges();
            return RedirectToAction("AdmBlog");
        }





















        ///-----------------------------------------------------------------Çıkış (Log Out)
        ///
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }




    }



}