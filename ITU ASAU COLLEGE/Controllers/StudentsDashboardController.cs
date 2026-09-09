using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using ITU_ASAU_COLLEGE.Data;
using ITU_ASAU_COLLEGE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITU_ASAU_COLLEGE.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentsDashboardController : Controller
    {
        private readonly ITU_ASAU_COLLEGEContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentsDashboardController(
            ITU_ASAU_COLLEGEContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(s => s.Email == user.Email);

            if (student == null)
            {
                return NotFound("Student record not found.");
            }

            return View(student);
        }
    }
}