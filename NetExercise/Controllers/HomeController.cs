using System.Web.Mvc;

namespace NetExercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.OutputFolder = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            return View();
        }
    }
}
