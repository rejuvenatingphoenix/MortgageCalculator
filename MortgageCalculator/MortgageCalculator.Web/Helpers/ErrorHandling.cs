using System;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Helpers
{
  public  class ExceptionFilter : FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                var controllerName =(string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/CustomErrorPage.cshtml",
                    MasterName = "~/Views/Shared/_Layout.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
