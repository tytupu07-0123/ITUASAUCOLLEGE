using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITU_ASAU_COLLEGE.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeachersDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}