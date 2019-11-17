using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register(string username, string fullname, string email)
        {
            ViewBag.Username = username = "Senbonzakura";
            ViewBag.Fullname = fullname = "Phạm Anh Dũng";
            ViewBag.Email = email = "anhdungpham090@gmail.com";
            ViewData["Name"] = username;
            ViewData["Fullname"] = fullname;
            ViewData["Email"] = email;
            return View("UserForm");
        }
    }
}