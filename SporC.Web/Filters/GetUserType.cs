using Microsoft.AspNetCore.Mvc.Rendering;
using SporC.BL.Abstract;
using SporC.BL.Concrete;
using System.Security.Claims;

namespace SporC.Web.Filters
{
    public static class GetUserType
    {

        public static int GetUserTypeId(this IHtmlHelper htmlHelper )
        {
           
            var userService = htmlHelper.ViewContext.HttpContext.RequestServices.GetService<UserManager>();

            var user = userService.GetUserById();


           int userTypeId = user.Result.UserTypeId ?? 0; // Veya başka bir varsayılan değer

        return userTypeId;
        }
    }
}
