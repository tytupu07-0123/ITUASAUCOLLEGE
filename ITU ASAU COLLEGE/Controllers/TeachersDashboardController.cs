using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using ITU_ASAU_COLLEGE.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITU_ASAU_COLLEGE.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeachersDashboardController : Controller
    {
        private readonly ITU_ASAU_COLLEGEContext _context;

        public TeachersDashboardController(ITU_ASAU_COLLEGEContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Student.ToListAsync();

            return View(students);
        }
    }
}