using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
