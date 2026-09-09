using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;

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
