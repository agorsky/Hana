using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hana.Controllers {
    [HandleError]
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Who() {
            return View();
        }
        public ActionResult Contact() {
            return View();
        }
        public ActionResult About() {
            return View();
        }
        public ActionResult Resume() {
            return View();
        }
    }
}
