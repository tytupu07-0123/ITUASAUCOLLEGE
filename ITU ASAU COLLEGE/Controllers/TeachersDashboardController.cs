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
    public class TeachersDashboardController : Controller
    {
        private readonly ITU_ASAU_COLLEGEContext _context;
        private UserManager<IdentityUser> _userManager;

        public TeachersDashboardController(ITU_ASAU_COLLEGEContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var teacher = await _context.Teacher
                .FirstOrDefaultAsync(t => t.Email == user.Email);

            if (teacher == null)
            {
                return NotFound("Teacher record not found.");
            }
            return View(teacher);
        }
    }
}
