using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace WebFramework.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validate(string Username, string Password)
        {            
            
            if (WebFramework.Models.Login.CheckLogin(Username, PasswordHasher(Password)) == true)
            {
                System.Web.HttpContext.Current.Session["New"] = Username;
                return RedirectToAction("Index" , "Home");
            }
            else
            {
                ViewData["Validation"] = "You've entered invalid credentials!";
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["New"] = null;
            return RedirectToAction("Index", "Login");
        }

        public static string PasswordHasher(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
        }

    }
}
