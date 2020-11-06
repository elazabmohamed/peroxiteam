using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace peroxiteam.SessionAttirbute
{
    public class CheckSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var MySession = HttpContext.Current.Session;

            if (MySession["Student_Email"] == null && MySession["Company_Email"] == null)
            {
                filterContext.Result = new RedirectResult(string.Format("/Home/"));
            }


        }
    }
}