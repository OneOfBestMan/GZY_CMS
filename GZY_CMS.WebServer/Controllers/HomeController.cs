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
using GZY_CMS.SystemModel;

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


        public AjaxResult AddUser(GZY_User user)
        {
            var date = userService.Add(user);
            if (date)
            {
                return Success("添加成功!");
            }
            else
            {
                return Errors("添加失败!");
            }
          
        }

        public AjaxResult RomeUsers(int[] ids)
        {
            var date = userService.DeleteUser(ids);
            if (date > 0)
            {
                return Success("删除成功!");
            }
            return Errors("删除失败!");
        }

        public AjaxObjectResult<dynamic> UserSelect(string Loginname, string Name, string ValidYN, int page, int rows)
        {
            var date = userService.Select(Loginname, Name,ValidYN, page, rows,out int Records);
            int total = Records / rows + (Records % rows > 0 ? 1 : 0);
            var json = new
            {
                page = page,
                total = total,
                records = Records,
                rows = date
            };
            return SuccessData<dynamic>(json);
        }

        public AjaxObjectResult<GZY_User> SelectUserModel(int id)
        {
            var model = userService.SelectUserModel(id);
            return SuccessData<GZY_User>(model);
        }

        public AjaxResult UpdateUser(GZY_User user)
        {
            if (userService.UpdataUserModel(user))
            {
                return Success("修改成功!");
            }
            return Errors("修改失败!");
        }
    }
}
