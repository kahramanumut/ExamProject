using ExamProject.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [_SessionControl]
        public ActionResult Index()
        {
          // Test class ı ilk çalıştırmada kullandım. VT'yi oluşturup örnek data insert etme
           Test test = new Test();
            return View();
        }
    }
}