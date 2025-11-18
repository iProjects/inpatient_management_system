using System.Web;
using System.Web.Mvc;

namespace inpatient_management_system.ui.web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
