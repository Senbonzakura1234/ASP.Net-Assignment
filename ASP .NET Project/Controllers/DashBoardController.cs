using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Project.Models;

namespace ASP.NET_Project.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();

        // GET: DashBoard
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }

    }
}