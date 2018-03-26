using System.Web;
using System.Web.Mvc;

namespace m3_w2d5_FlashScope_Practice
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
