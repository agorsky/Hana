using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Hana.Controllers
{
    public class PostsController : Controller
    {
        //
        // GET: /Posts/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Posts/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Posts/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Posts/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Posts/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Posts/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
