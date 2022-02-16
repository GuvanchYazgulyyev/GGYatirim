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
            var adsoyad = dr.DbAdmin.Where(k => k.EPosta == mail).Select(f => f.AdSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var is1 = dr.Dbilan.Where(k => k.Durum == true).Count().ToString();
            ViewBag.d1 = is1;

            var is2 = dr.DbilanDurum.Where(k => k.Durum == true).Count().ToString();
            ViewBag.d2 = is2;

            var is3 = dr.DbKonum.Where(k => k.Durum == true).Count().ToString();
            ViewBag.d3 = is3;


            var is4 = dr.DbTemsilci.Where(k => k.Durum == true).Count().ToString();
            ViewBag.d4 = is4;

            var is5 = dr.DbiletisimForm.Where(k => k.Durum == true).Count().ToString();
            ViewBag.d5 = is5;


            return View();
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

        public ActionResult AdmSilinmisilan()
        {
            var value33 = dr.Dbilan.Where(k => k.Durum == false).OrderByDescending(l => l.ilanID).ToList();
            return View(value33);
        }




        /////////////////////////////////---------------------------------------------- Siliniş Müşteriler
        /////
        [Authorize(Roles = "Admin")]
        public ActionResult AdmSilinmisMusteriler()
        {
            var value33 = dr.DbKullanici.Where(k => k.Durum == false).OrderByDescending(l => l.KullaniciID).ToList();
            return View(value33);
        }







        // Silinmiş İlan Detay

        public ActionResult AdmSilinmisilanDetay(int id)
        {
            var degerler = dr.Dbilan.Where(l => l.ilanID == id).ToList();
            return View(degerler);
        }








        /////////////////////////////////---------------------------------------------- Admilan Kişilere Ozel ilan
        /////

        public ActionResult AdmKisiilan(int sayfa = 1)
        {
            var value33 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList().ToPagedList(sayfa, 5);
            return View(value33);
        }







        /////////////////////////////////---------------------------------------------- Admilan
        /////

        public ActionResult Admilan(int sayfa = 1)
        {
            var value33 = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(l => l.ilanID).ToList().ToPagedList(sayfa, 10);
            if (value33 == null)
            {
                throw new Exception("İlan Bulunamadı!");
            }
            return View(value33);
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
            //DbEmlakTipi
            List<SelectListItem> d2 = (from x in dr.DbEmlakTipi.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.EmlakTipAd,
                                           Value = x.EmlakTipiID.ToString()
                                       }).ToList();
            ViewBag.dgr2 = d2;

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
                if (u.VitrinResim != null)
                {
                    u.VitrinResim = u.VitrinResim;
                }
                u.Durum = true;
                dr.SaveChanges();

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
                return RedirectToAction("Admilan");


            }
            return View();
        }





        // İlan Güncelle

        public ActionResult AdmilanGetir(int id)
        {
            //DbEmlakTipi
            List<SelectListItem> d2 = (from x in dr.DbEmlakTipi.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.EmlakTipAd,
                                           Value = x.EmlakTipiID.ToString()
                                       }).ToList();
            ViewBag.dgr2 = d2;

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


            var urngetr = dr.Dbilan.Find(id);
            return View("AdmilanGetir", urngetr);
        }


        // İlan Güncelle

        public ActionResult AdmilanGuncelle(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
        {


            if (File != null)
            {
                FileInfo fileinfo = new FileInfo(File.FileName);
                WebImage img = new WebImage(File.InputStream);
                string uzanti = (Guid.NewGuid().ToString() + fileinfo.Extension).ToLower();
                //img.Resize(225, 180, false, false);
                string tamyol = "~/ilanResimler/" + uzanti;
                img.Save(Server.MapPath(tamyol));
                u.CokluResim = "/ilanResimler/" + uzanti;

            }
            var value = dr.Dbilan.Find(u.ilanID);
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
            value.EmlakTipIDD = u.EmlakTipIDD;
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
            value.GoogleMapAdres = u.GoogleMapAdres;



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
            return RedirectToAction("Admilan");

        }








        // Eklemenin Yanındaki İlan Sadece 1 tane ilan Göster


        public PartialViewResult AdmYeniilanPart()
        {
            var deger = dr.Dbilan.Where(k => k.Durum == true).OrderByDescending(k => k.ilanID).Take(1).ToList();
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
        public ActionResult Adminkullanici()
        {
            var value33 = dr.DbAdmin.Where(k => k.Durum == true).ToList();

            return View(value33);
        }



        ///// Ekle
        ///

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
        public ActionResult AdmKayitliKullanici(int sayfa = 1)
        {
            var value33 = dr.DbKullanici.Where(k => k.Durum == true).OrderByDescending(k => k.KullaniciID).ToList().ToPagedList(sayfa, 16);

            return View(value33);
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