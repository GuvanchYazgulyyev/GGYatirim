using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GGYatirim.Models.ModelMetaDateTypes
{
    public class KullaniciKayitMetaData
    {
        [Required(ErrorMessage = "Adınızı Giriniz")]
        [MinLength(3, ErrorMessage = "Ad En Az 3 Karakter olabilir.")]
        [MaxLength(60, ErrorMessage = "Ad En Fazla 60 Karakter olabilir.")]
        public string KisiAdi { get; set; }


        [Required(ErrorMessage = "Soyadınızı Giriniz")]
        [MinLength(3, ErrorMessage = "Soyad En Az 3 Karakter olabilir.")]
        [MaxLength(60, ErrorMessage = "Soyad En Fazla 60 Karakter olabilir.")]
        public string KisiSoyadi { get; set; }



        [Required(ErrorMessage = "E Posta Giriniz")]
        [MinLength(10, ErrorMessage = "E Posta En Az 10 Karakter olabilir.")]
        [MaxLength(90, ErrorMessage = "E Posta En Fazla 90 Karakter olabilir.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Geçerli E Posta Giriniz!")]
        [DataType(DataType.EmailAddress)]
        public string EPosta { get; set; }


        [Required(ErrorMessage = "Şifre  Giriniz")]
        [MinLength(6, ErrorMessage = "Şifre En Az 6 Karakter olabilir.")]
        [MaxLength(16, ErrorMessage = "Şifre En Fazla 16 Karakter olabilir.")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Telefon No Giriniz")]
        [MinLength(10, ErrorMessage = "Telefon No En Az 10 Karakter olabilir.")]
        [MaxLength(13, ErrorMessage = "Telefon No En Fazla 13 Karakter olabilir.")]
        public string Telefon { get; set; }
    }
}