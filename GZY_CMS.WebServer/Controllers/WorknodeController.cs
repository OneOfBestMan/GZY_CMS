using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GZY_CMS.Core.Base;
using GZY_CMS.IService;
using GZY_CMS.SystemModel;
using GZY_CMS.Utility.AjaxResult;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GZY_CMS.WebServer.Controllers
{
    public class WorknodeController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IWorknodeService userService { get; set; }

        public AjaxResult AddWorknode(GZY_Worknode user)
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

        public AjaxResult RomeWorknode(int[] ids)
        {
            var date = userService.DeleteWorknode(ids);
            if (date > 0)
            {
                return Success("删除成功!");
            }
            return Errors("删除失败!");
        }

        public AjaxObjectResult<dynamic> WorknodeSelect(string Node_abbre, string Node_href, int? Node_type, string NodeValid, int page, int rows)
        {
            var date = userService.Select(Node_abbre, Node_href, Node_type, NodeValid, page, rows, out int Records);
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

        public AjaxArrayResult<dynamic> SelectWorknodes(string name)
        {
            var model = userService.SelectWorks(name);
            return SuccessData<dynamic>(model);
        }

        public AjaxObjectResult<GZY_Worknode> SelectWorknodeModel(int id)
        {
            var model = userService.SelectWorknodeModel(id);
            return SuccessData<GZY_Worknode>(model);
        }

        public AjaxResult UpdateWorknode(GZY_Worknode user)
        {
            if (userService.UpdataWorknodeModel(user))
            {
                return Success("修改成功!");
            }
            return Errors("修改失败!");
        }
    }
}
