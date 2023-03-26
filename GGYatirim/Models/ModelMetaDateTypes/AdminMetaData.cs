using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GGYatirim.Models.ModelMetaDateTypes
{
    //  [ModelMetadataType(typeof(AdminMetaData))] Bu kısmını Admin Tabloya yazıyoruz
    public class AdminMetaData
    {
        [Required(ErrorMessage = "Ad Soyad Giriniz")]
        [MinLength(12, ErrorMessage = "Ad Soyad En Az 12 Karakter olabilir.")]
        [MaxLength(60, ErrorMessage = "Ad Soyad En Fazla 60 Karakter olabilir.")]

        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "E Posta Giriniz")]
        [MinLength(10, ErrorMessage = "E Posta En Az 10 Karakter olabilir.")]
        [MaxLength(90, ErrorMessage = "E Posta En Fazla 90 Karakter olabilir.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Geçerli E Posta Giriniz!")]

        [DataType(DataType.EmailAddress)]
        public string EPosta { get; set; }

        [Required(ErrorMessage = "Telefon No Giriniz")]
        [MinLength(10, ErrorMessage = "Telefon No En Az 10 Karakter olabilir.")]
        [MaxLength(13, ErrorMessage = "Telefon No En Fazla 13 Karakter olabilir.")]
        public string Tel { get; set; }
    }
}