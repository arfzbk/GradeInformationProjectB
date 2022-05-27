using Microsoft.AspNetCore.Mvc;

namespace GradeInformation.WebUI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
