using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Airbooking.Api.Controllers
{
    [Authorize]
//    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
