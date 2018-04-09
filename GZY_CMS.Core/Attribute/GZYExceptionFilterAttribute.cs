using GZY_CMS.Utility.AjaxResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZY_CMS.Core.Attribute
{
    public class GZYExceptionFilterAttribute : ExceptionFilterAttribute
    {
       

        public override void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                string msg = context.Exception.Message;
                if (IsAjaxRequest(context.HttpContext.Request))
                {
                    var message = "Ajax访问时引发异常：";
                    message += msg;
                    context.Result = new JsonResult( new AjaxResult() { message = message, type = ResultType.error } ); //;
                    context.ExceptionHandled = true;
                }
            }

            context.ExceptionHandled = true; //异常已处理了
        }


        public static bool IsAjaxRequest(HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            return ((request.Headers != null) && (request.Headers["X-Requested-With"] == "XMLHttpRequest"));
        }

    }
}
