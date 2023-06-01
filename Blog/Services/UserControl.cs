using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Services
{
    public class UserControl : Controller
    {
        public bool IsSessionAlive()
        {
            var value = HttpContext.Session.GetInt32("UserId");
            if(value == null)
                return false;
            return true;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!IsSessionAlive())
            {
                context.Result = RedirectToAction("Login","Account");
                return;
            }
        }
    }
}
