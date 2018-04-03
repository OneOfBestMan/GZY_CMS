using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GZY_CMS.WebServer.Models;
using GZY_CMS.IService;

namespace GZY_CMS.WebServer.Controllers
{
    public class HomeController : Controller
    {

        public IUserService userService { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult UserManager()
        {
            return View();
        }



        public string UserSelect()
        {
            var date = userService.Select();
            return View();
        }
    }
}
