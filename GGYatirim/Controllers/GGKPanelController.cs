using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GGYatirim.Controllers
{
    [AllowAnonymous]
    public class GGKPanelController : Controller
    {
        // GET: GGKPanel
        public ActionResult Index()
        {
            return View();
        }
    }
}