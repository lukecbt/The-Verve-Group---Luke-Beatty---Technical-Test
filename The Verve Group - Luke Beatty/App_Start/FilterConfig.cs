using System.Web;
using System.Web.Mvc;

namespace The_Verve_Group___Luke_Beatty
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
