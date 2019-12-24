using System.Web;
using System.Web.Mvc;

namespace GiupviecPalmy_com
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}