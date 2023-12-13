using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SporC.Web.Filters
{
    public class RedirectToHomeIfLoggedInAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
               
                context.Result = new RedirectToActionResult("Index", "Post", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
