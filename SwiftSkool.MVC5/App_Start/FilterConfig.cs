using SwiftSkool.MVC5.Infrastructure.Validation;
using System.Web;
using System.Web.Mvc;

namespace SwiftSkool.MVC5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ValidationActionFilter());
        }
    }
}
