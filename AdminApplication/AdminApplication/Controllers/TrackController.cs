using Microsoft.AspNetCore.Mvc;

namespace AdminApplication.Controllers
{
    public class TrackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
