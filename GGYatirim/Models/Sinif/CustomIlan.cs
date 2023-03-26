using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GGYatirim.Models.Sinif
{
 
    public partial class Dbilan
    {
        [NotMapped]
        public string EncriptId { get; set; }
    }
}