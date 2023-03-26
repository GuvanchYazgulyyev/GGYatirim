using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGYatirim.Models
{
    public class GalleryModel
    {
        public int ilanGalleryID { get; set; }
        public string Ad { get; set; }
        public string URL { get; set; }
        public DateTime EklenmeTarihi { get; set; }
    }
}