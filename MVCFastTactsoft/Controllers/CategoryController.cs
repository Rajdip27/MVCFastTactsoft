using Microsoft.AspNetCore.Mvc;

namespace MVCFastTactsoft.Controllers
{
    public class CategoryController : Controller
    {
        public async Task< IActionResult> Index()
        {
            return View();
        }
    }
}
