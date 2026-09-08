using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;

namespace ITU_ASAU_COLLEGE.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherDashboardController : Controller
    {
        private readonly ITU_ASAU_COLLEGEContext _context;
        public TeacherDashboardController(ITU_ASAU_COLLEGEContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var email = User.Identity.Name; // Get the logged-in user's email
            // Find the teacher by their email
            var Teacher = await _context.Teacher.FirstOrDefaultAsync(t => t.Email == email);
            if (Teacher == null)
            {
                return NotFound();
            }
            return View(Teacher);
        }
    }
}
