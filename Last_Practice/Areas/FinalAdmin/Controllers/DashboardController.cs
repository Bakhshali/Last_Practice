using Microsoft.AspNetCore.Mvc;

namespace Last_Practice.Areas.FinalAdmin.Controllers
{
    [Area("FinalAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
