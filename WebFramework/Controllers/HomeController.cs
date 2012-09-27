using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFramework.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewData["Page"] = WebFramework.Models.Database.GetPage("TestPage");            
            return View();
        }

        public ActionResult About()
        {
            ViewData["Page"] = WebFramework.Models.Database.GetAbout();
            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Page"] = WebFramework.Models.Database.GetContact();
            return View();
        }

        public ActionResult Groups()
        {
            ViewData["Group"] = WebFramework.Models.Database.GetGroups();
            return View();
        }

        public ActionResult Pages(string group)
        {
            ViewData["Group"] = group;            
            ViewData["Page"] = WebFramework.Models.Database.ListPages(group);
            return View();
        }

        public ActionResult Content(string page)
        {
            ViewData["Content"] = WebFramework.Models.Database.GetPage(page); 
            return View();
        }

    }
}
