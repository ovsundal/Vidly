using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //applies Views/Shared/Error.cshtml to all app pages
            filters.Add(new HandleErrorAttribute());
            //this line makes the entire app require authorization
            //use [AllowAnonymous] to add exceptions
            filters.Add(new AuthorizeAttribute());

            filters.Add(new RequireHttpsAttribute());
        }
    }
}
