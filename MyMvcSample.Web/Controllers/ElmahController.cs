using System.Web.Mvc;
using MyMvcSample.Common.Mvc.ActionResults;

namespace MyMvcSample.Controllers
{
    public class ElmahController : Controller
    {
        public ActionResult Index(string type)
        {
            return new ElmahResult(type);
        }

        public ActionResult Detail(string type)
        {
            return new ElmahResult(type);
        }
    }
}