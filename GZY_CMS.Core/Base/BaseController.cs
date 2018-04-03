using GZY_CMS.Utility.AjaxResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;


namespace GZY_CMS.Core.Base
{

    public class BaseController: Controller
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public AjaxArrayResult<T> SuccessData<T>(IEnumerable<T> list) where T : class
        {
            return new AjaxArrayResult<T>() { resultdata = list, message = "操作成功。", type =ResultType.success };
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public AjaxObjectResult<T> SuccessData<T>(T t) where T : class
        {
            return new AjaxObjectResult<T>() { resultdata = t, message = "操作成功。", type =ResultType.success };
        }

        /// <summary>
        /// 正确消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected AjaxResult Success<T>(T data, string message, int errcode = 200)
        {
            if (data == null)
            {
                if (data.GetType().IsClass)
                {
                    return new AjaxResult() { message = message, type =ResultType.success, code = errcode, resultdata = "{}" };
                }
                else
                {
                    return new AjaxResult() { message = message, type = ResultType.success, code = errcode, resultdata = "" };
                }
            }
            return new AjaxResult() { message = message, type =ResultType.success, code = errcode, resultdata = data };
        }
        /// <summary>
        /// 正确消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected AjaxResult Success(string message, int errcode = 0)
        {
            return new AjaxResult() { message = message, type =ResultType.success, code = errcode };
        }

        /// <summary>
        /// 正确消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected AjaxResult Success<T>(IEnumerable<T> data, string message = "操作成功。", int errcode = 0)
        {
            return new AjaxResult() { message = message, type = ResultType.success, code = errcode, resultdata = data };
        }

        /// <summary>
        /// 错误消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected AjaxResult Errors(string message, int errcode = -1)
        {
            return new AjaxResult() { message = message, type = ResultType.error, code = errcode };
        }
    }

}
