using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using System.Diagnostics;

namespace Trello.Filters
{
    public class LogAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("onActionExecuted", filterContext.RouteData);
        }
        private void Log(string methodName, RouteData routeData)
        {
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} action method has been executed",actionName);
            Debug.WriteLine(message);
        }
    }
}