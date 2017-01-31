using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SwiftSkool.MVC5.Infrastructure.Validation
{
    public class ValidationActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                if(filterContext.HttpContext.Request.HttpMethod == "GET")
                {
                    var result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    filterContext.Result = result;
                }
                else
                {
                    var result = new ContentResult();
                    string content = JsonConvert.SerializeObject(filterContext.Controller.ViewData.ModelState,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                    result.Content = content;
                    result.ContentType = "application/json";

                    filterContext.HttpContext.Response.StatusCode = 400;
                    filterContext.Result = result;
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}