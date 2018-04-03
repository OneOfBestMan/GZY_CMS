using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GZY_CMS.WebServer.Models;
using GZY_CMS.IService;
using GZY_CMS.Core.Base;
using GZY_CMS.Utility.AjaxResult;

namespace GZY_CMS.WebServer.Controllers
{
    public class HomeController : BaseController
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
           // Json()
            return View();
        }

        public AjaxObjectResult<List<SystemModel.GZY_User>> UserSelect(string Loginname, string Name, string ValidYN, int index, int rows)
        {
            var date = userService.Select(Loginname, Name,ValidYN,index,rows,out int total);
            return SuccessData(date);
        }
    }
}
