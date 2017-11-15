using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // Setting this filter applies authorization globally, requiring a user to be logged in to view any content. We can get around this by applying [AllowAnonymous] to a controller or action.
        }
    }
}
