using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Testing()
        {
            return View();
        }
    }
}
