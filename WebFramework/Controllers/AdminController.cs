using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace WebFramework.Controllers
{
    public class AdminController : Controller
    {
        private SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\webFrameworkDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckPage(string page)
        {
            if (page == "content")
            {
                return RedirectToAction("AddContentPage","Admin");
            }
            else if (page == "image")
            {
                return RedirectToAction("AddImagePage" , "Admin");
            }
            else if (page == "about")
            {
                return RedirectToAction("EditAbout" , "Admin");
            }
            else
                return RedirectToAction("EditContact" , "Admin");
        }

        public ActionResult AddContentPage()
        {
            return View();
        }

        public ActionResult AddImagePage()
        {
            return View();
        }

        public ActionResult EditAbout()
        {
            ViewData["Page"] = WebFramework.Models.Database.GetAbout();
            return View();
        }

        public ActionResult EditContact()
        {
            ViewData["Page"] = WebFramework.Models.Database.GetContact();
            return View();
        }

        public ActionResult EditPage()
        {
            return View();
        }

        /* COME BACK AND CHECK---------------------------------------------------------------------------------*///////////
        public ActionResult DeletePage(string title, string group, string content)
        {

            if (WebFramework.Models.Database.CheckGroups(group) == true)
            {
               // SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                conn.Open();

                SqlCommand comm = new SqlCommand("DELETE FROM ContentPage(Title, Groups, Contents) values (@title, @groups, @contents)", conn);

                comm.Parameters.AddWithValue("@title", title);
                comm.Parameters.AddWithValue("@groups", group);
                comm.Parameters.AddWithValue("@contents", content);

                comm.ExecuteNonQuery();
                conn.Close();

                return View();
            }

            else
            {
               // SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                conn.Open();

                SqlCommand comm = new SqlCommand("DELETE FROM ContentPage(Title, Groups, Contents) values (@title, @groups, @contents)", conn);

                comm.Parameters.AddWithValue("@title", title);
                comm.Parameters.AddWithValue("@groups", group);
                comm.Parameters.AddWithValue("@contents", content);

                SqlCommand comm2 = new SqlCommand("DELETE FROM Groups(Groups) values (@groups)", conn);

                comm2.Parameters.AddWithValue("@groups", group);

                comm2.ExecuteNonQuery();
                comm.ExecuteNonQuery();
                conn.Close();

                return View();
            }
        }
        /*----------------------------------------------------------------------------------------------------------------*/

        public ActionResult CreateAbout(string title, string name, string content)
        {
            WebFramework.Models.Database.CreateAbout(title, name, content);            

            return View();
        }

        public ActionResult CreateContact(string title, string name, string email, string content)
        {
            WebFramework.Models.Database.CreateContact(title, name, email, content);

            return View();
        }

        public ActionResult Create(string title, string group, string content)
        {
            if (WebFramework.Models.Database.AddPage(title, group, content) == true)
            {
             //   SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                conn.Open();

                SqlCommand comm = new SqlCommand("INSERT into ContentPage(Title, Groups, Contents) values (@title, @groups, @contents)", conn);

                comm.Parameters.AddWithValue("@title", title);
                comm.Parameters.AddWithValue("@groups", group);
                comm.Parameters.AddWithValue("@contents", content);

                comm.ExecuteNonQuery();

                conn.Close();

                ViewData["Page"] = title;

            return View();
            }

            else
            {
              //  SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Chris\\Documents\\TestDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                conn.Open();

                SqlCommand comm = new SqlCommand("INSERT into ContentPage(Title, Groups, Contents) values (@title, @groups, @contents)", conn);

                comm.Parameters.AddWithValue("@title", title);
                comm.Parameters.AddWithValue("@groups", group);
                comm.Parameters.AddWithValue("@contents", content);

                SqlCommand comm2 = new SqlCommand("INSERT into Groups(Groups) values (@groups)", conn);

                comm2.Parameters.AddWithValue("@groups", group);

                comm2.ExecuteNonQuery();
                comm.ExecuteNonQuery();

                conn.Close();
                
                ViewData["Page"] = title;

            return View();
            }

            
        }

    }
}
