using GGYatirim.Models;
using GGYatirim.Models.Sinif;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using PagedList;
using Dbilan = GGYatirim.Models.Sinif.Dbilan;

namespace GGYatirim.Controllers
{

    // Düzenleme yapılacak
    public class GGKPanelController : Controller
    {
        // GET: GGYPanel
        GYatirimEntities dr = new GYatirimEntities();

        public List<GalleryModel> Cokluresimgoster2 { get; private set; }
        public List<DbilanGallery> Cokluresimgoster { get; set; }
        // GET: GGKPanel
        public ActionResult Index()
        {

            var mail = (string)Session["EPosta"];
            // Ad
            var ad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.ad = ad;

            // Soyad
            var soyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.soyad = soyad;


            // Onaylı İlanlar say
            var onayilan = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == true).Count();
            ViewBag.onayilan = onayilan;


            // Onaylı İlanlar say
            var onaysiz = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == false).Count();
            ViewBag.onaysiz = onaysiz;

            // Onaylı İlanlar say
            var toplamilan = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true).Count();
            ViewBag.toplamilan = toplamilan;

            // Bilgi Güncelleme Durumu 

            var bilgiguncelle = dr.DbKullanici.Where(l => l.EPosta == mail && l.Durum == true).ToList();

            //ViewBag.bilgiguncelle = bilgiguncelle;

            return View(bilgiguncelle);
        }



        // Tüm Onaylanan ilanları Listele
        public ActionResult Onayliilanlar(string p, int sayfa = 1)
        {

            var mail = (string)Session["EPosta"];
            //var deger = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == true).OrderByDescending(k => k.ilanID).ToList();
            //return View(deger);

            // saydır
            var tumonayliilan = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == true).Count();
            ViewBag.tumonayliilan = tumonayliilan;

            var sonuc = from s in dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == true).OrderByDescending(f => f.ilanID) select s;
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




        //  Onay Bekleyen  ilanları Listele
        public ActionResult OnayBekleyenilan(string p, int sayfa = 1)
        {

            var mail = (string)Session["EPosta"];
            //var deger = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == false).OrderByDescending(k => k.ilanID).ToList();
            //return View(deger);

            // saydır
            var tumonayliilan = dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == false).Count();
            ViewBag.tumonayliilan = tumonayliilan;

            var sonuc = from s in dr.Dbilan.Where(k => k.EPosta == mail && k.MOnay == false).OrderByDescending(f => f.ilanID) select s;
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




        //  Tüm  ilanları Listele
        public ActionResult MTumilanList(string p, int sayfa = 1)
        {

            var mail = (string)Session["EPosta"];
            //var deger = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true).OrderByDescending(k => k.ilanID).ToList();
            //return View(deger);

            // saydır
            var tumonayliilan = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true).Count();
            ViewBag.tumonayliilan = tumonayliilan;

            var sonuc = from s in dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true).OrderByDescending(f => f.ilanID) select s;
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

        public ActionResult MilanDetay(int id)
        {
            var mail = (string)Session["EPosta"];
            // var degerler = dr.Dbilan.Where(l => l.ilanID == id).ToList();
            var ilandetay = dr.Dbilan.Include(u => u.DbilanGallery).SingleOrDefault(k => k.EPosta == mail && k.Durum == true && k.ilanID == id);

            // var ilandetay = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true && k.ilanID == id).ToList();


            return View(ilandetay);
        }


        // Deneme Action 
        public ActionResult ResimIncele2(int id)
        {
            var mail = (string)Session["EPosta"];
            var ilandetay = dr.Dbilan.Include(u => u.DbilanGallery).SingleOrDefault(k => k.EPosta == mail && k.Durum == true && k.ilanID == id);

            //var ilandetay = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true && k.ilanID == id).ToList();
            return View(ilandetay);
        }




        ////// Müşteri İlan Silme
        /////


        public ActionResult MilanSil()
        {

            var mail = (string)Session["EPosta"];
            var id = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true).Select(k => k.ilanID).FirstOrDefault();
            var milanbul = dr.Dbilan.Find(id);


            // var urnsil = dr.Dbilan.Find(id);
            milanbul.Durum = false;
            dr.SaveChanges();
            return RedirectToAction("Index", "GGKPanel");
        }




        // Müşteri ilan Ekle Apartman
        [HttpGet]
        public ActionResult MilanEkle()
        {
            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;



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





        // Veriler geldiginde HttpPost çalışır Müşteri İlan Ekle
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult MilanEkle(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.Durum = true;
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }














        //  Müşteri İlan Güncelle

        // İlan Güncelle

        public ActionResult MilanGetir(int id)
        {


            var mail = (string)Session["EPosta"];
            if ((string)Session["EPosta"] == null)
            {
                return RedirectToAction("MTumilanList", "GGKPanel");
            }
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;




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

            ////DbilanOzellik
            List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.OzellikAd,
                                           Value = x.ilanOzellikID.ToString()
                                       }).ToList();
            ViewBag.dgr4 = d4;


            ////DbKonum
            List<SelectListItem> d5 = (from x in dr.DbKonum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.SehirAd,
                                           Value = x.KonumID.ToString()
                                       }).ToList();
            ViewBag.dgr5 = d5;


            // var id = dr.Dbilan.Where(k => k.EPosta == mail && k.Durum == true).Select(k => k.ilanID).FirstOrDefault();
           // var ilandetay = dr.Dbilan.SingleOrDefault(k => k.EPosta == mail && k.Durum == true && k.ilanID == id);
            var urngetr = dr.Dbilan.Where(i => i.EPosta == mail && i.ilanID == id).FirstOrDefault();
          //  var urngetr = dr.Dbilan.Find(id);
            return View("MilanGetir", urngetr);
        }


        // İlan Güncelle

        public ActionResult MilanGuncelle(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                //  var mail = (string)Session["EPosta"];
                //  var value = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
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
                return RedirectToAction("Index", "GGKPanel");

            }
            return View();

        }




        /// <summary>
        /// //////////////////////////////////////////////////////////////Daire
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleDaire()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





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
        public ActionResult MilanEkleDaire(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }













        /// <summary>
        /// //////////////////////////////////////////////////////////////Arsa
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleArsa()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            ////DbilanOzellik
            //List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.OzellikAd,
            //                               Value = x.ilanOzellikID.ToString()
            //                           }).ToList();
            //ViewBag.dgr4 = d4;


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
        public ActionResult MilanEkleArsa(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.ilanOzellikIDD = 2;
                u.Durum = true;
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }



















        /// <summary>
        /// //////////////////////////////////////////////////////////////Müstakil
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleMustakil()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





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
        public ActionResult MilanEkleMustakil(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }





















        /// <summary>
        /// //////////////////////////////////////////////////////////////Dubleks
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleDubleks()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





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
        public ActionResult MilanEkleDubleks(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }




















        /// <summary>
        /// //////////////////////////////////////////////////////////////Arazş
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleArazi()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            ////DbilanOzellik
            //List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.OzellikAd,
            //                               Value = x.ilanOzellikID.ToString()
            //                           }).ToList();
            //ViewBag.dgr4 = d4;


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
        public ActionResult MilanEkleArazi(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.ilanOzellikIDD = 2;
                u.Durum = true;
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }


















        /// <summary>
        /// //////////////////////////////////////////////////////////////Dükkan
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleDukkan()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





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
        public ActionResult MilanEkleDukkan(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }






















        /// <summary>
        /// //////////////////////////////////////////////////////////////İşyeri
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleisteri()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





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
        public ActionResult MilanEkleisteri(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }




















        /// <summary>
        /// //////////////////////////////////////////////////////////////Bahçe
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleBahce()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            //List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.OzellikAd,
            //                               Value = x.ilanOzellikID.ToString()
            //                           }).ToList();
            //ViewBag.dgr4 = d4;


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
        public ActionResult MilanEkleBahce(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.ilanOzellikIDD = 2;

                u.Durum = true;
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }



















        /// <summary>
        /// //////////////////////////////////////////////////////////////Petrol İstasyonu
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEklePetrolistasyon()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            //List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.OzellikAd,
            //                               Value = x.ilanOzellikID.ToString()
            //                           }).ToList();
            //ViewBag.dgr4 = d4;


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
        public ActionResult MilanEklePetrolistasyon(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.ilanOzellikIDD = 2;

                u.Durum = true;
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }



















        /// <summary>
        /// //////////////////////////////////////////////////////////////Çiftlik
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleCiftlik()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            //List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.OzellikAd,
            //                               Value = x.ilanOzellikID.ToString()
            //                           }).ToList();
            //ViewBag.dgr4 = d4;


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
        public ActionResult MilanEkleCiftlik(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.ilanOzellikIDD = 2;

                u.Durum = true;
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }






















        /// <summary>
        /// //////////////////////////////////////////////////////////////Ahır
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleAhir()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            //List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.OzellikAd,
            //                               Value = x.ilanOzellikID.ToString()
            //                           }).ToList();
            //ViewBag.dgr4 = d4;


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
        public ActionResult MilanEkleAhir(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.ilanOzellikIDD = 2;

                u.Durum = true;
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }





















        /// <summary>
        /// //////////////////////////////////////////////////////////////Otomobil
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Otomobil
        [HttpGet]
        public ActionResult MilanEkleOtomobil()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





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
        public ActionResult MilanEkleOtomobil(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }

























        /// <summary>
        /// //////////////////////////////////////////////////////////////Traktör
        /// </summary>
        /// <returns></returns>



        // Müşteri ilan Ekle Daire
        [HttpGet]
        public ActionResult MilanEkleTraktor()
        {





            var mail = (string)Session["EPosta"];
            var adsoyad = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiAdi).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var adsoyadd = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KisiSoyadi).FirstOrDefault();
            ViewBag.adsoyadd = adsoyadd;

            TempData["adsoyad"] = "adsoyad";

            // E Posta
            var eposta = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.EPosta).FirstOrDefault();
            ViewBag.eposta = eposta;

            // KullaniciNo
            var kno = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.KullaniciNo).FirstOrDefault();
            ViewBag.kno = kno;



            var tel = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Telefon).FirstOrDefault();
            ViewBag.tel = tel;
            var profil = dr.DbKullanici.Where(k => k.EPosta == mail && k.Durum == true).Select(f => f.Resim).FirstOrDefault();
            ViewBag.profil = profil;





            //DbilanDurum
            List<SelectListItem> d3 = (from x in dr.DbilanDurum.Where(l => l.Durum == true).ToList()
                                       select new SelectListItem
                                       {
                                           Text = x.ilanDurumAd,
                                           Value = x.ilanDurumID.ToString()
                                       }).ToList();
            ViewBag.dgr3 = d3;

            //DbilanOzellik
            //List<SelectListItem> d4 = (from x in dr.DbilanOzellik.Where(l => l.Durum == true).ToList()
            //                           select new SelectListItem
            //                           {
            //                               Text = x.OzellikAd,
            //                               Value = x.ilanOzellikID.ToString()
            //                           }).ToList();
            //ViewBag.dgr4 = d4;


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
        public ActionResult MilanEkleTraktor(Dbilan u, HttpPostedFileBase File, IEnumerable<HttpPostedFileBase> CokluResim)
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
                u.ilanOzellikIDD = 2;


                u.Durum = true;
                u.MOnay = false;
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
                    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
                    NetworkCredential net = new NetworkCredential("talep@wesigo.com", "Wesigo2021.");
                    client.Credentials = net;
                    client.Send(mail);
                    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";


                }






                //if (u != null)
                //{

                //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                //    client.EnableSsl = true;
                //    MailMessage mail = new MailMessage();
                //    mail.From = new MailAddress("kivancturkmenn@gmail.com", "İlan Yayınlama İsteği");
                //    mail.To.Add(u.EPosta);
                //    mail.IsBodyHtml = true;
                //    mail.Subject = "Güner Group İlan Yayınlama Bildirimi";
                //    mail.Body = "Merhaba Sayın: <b> " + u.KAdSoyad + " </b> <br/> Telefon Numaranız: <b> " + u.KTel + " </b> <br/> Kullanıcı Numaranız: <b> " + u.KullaniciNo + " </b> <br/> Yayınladıgınız  <b> " + u.ilanNo + " </b> No lu İlan şu an Yetkililerimiz tarafından incelenmektedir, <br/> İlanınızı en kısa sürede yayınlayacağız saygılarımızla Güner Group Yatırım Ailesi.";
                //    NetworkCredential net = new NetworkCredential("kivancturkmenn@gmail.com", "150305653G");
                //    client.Credentials = net;
                //    client.Send(mail);
                //    //  TempData["sifreyenile"] = "Yeni Şifreniz E Posta Adresinize Gönderilmiştir!!!";


                //}

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
                return RedirectToAction("Index", "GGKPanel");


            }
            return View();
        }





















        ///-----------------------------------------------------------------Çıkış (Log Out)
        ///
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "MGiris");
        }


    }


}