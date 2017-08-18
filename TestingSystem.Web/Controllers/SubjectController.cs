using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestingSystem.Web.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Create()
        {
            return View();
        }
    }
}