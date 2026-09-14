using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using ITU_ASAU_COLLEGE.Models;
using ITU_ASAU_COLLEGE.Data;

namespace ITU_ASAU_COLLEGE.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
