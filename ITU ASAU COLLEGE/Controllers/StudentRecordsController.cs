using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;

namespace ITU_ASAU_COLLEGE.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentRecordsController : Controller
    {
        private readonly ITU_ASAU_COLLEGEContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentRecordsController(
            ITU_ASAU_COLLEGEContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // ==========================================
        // MY RESULTS
        // ==========================================
        public async Task<IActionResult> MyResults()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null || string.IsNullOrWhiteSpace(currentUser.Email))
            {
                return Challenge();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(s => s.Email == currentUser.Email);

            if (student == null)
            {
                return NotFound("Your student profile could not be found.");
            }

            var results = await _context.Result
                .Where(r => r.StudentId == student.StudentId)
                .OrderByDescending(r => r.Date)
                .ThenBy(r => r.Subject)
                .ToListAsync();

            return View(results);
        }

        // ==========================================
        // MY ATTENDANCE
        // ==========================================
        public async Task<IActionResult> MyAttendance()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null || string.IsNullOrWhiteSpace(currentUser.Email))
            {
                return Challenge();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(s => s.Email == currentUser.Email);

            if (student == null)
            {
                return NotFound("Your student profile could not be found.");
            }

            var attendance = await _context.Attendance
                .Where(a => a.StudentId == student.StudentId)
                .OrderByDescending(a => a.Date)
                .ToListAsync();

            return View(attendance);
        }
    }
}