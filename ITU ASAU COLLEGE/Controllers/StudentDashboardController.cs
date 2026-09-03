using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Data;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;

namespace ITU_ASAU_COLLEGE.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentDashboardController : Controller
    {
        private readonly ITU_ASAU_COLLEGEContext _context;
        public StudentDashboardController(ITU_ASAU_COLLEGEContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var email = User.Identity.Name; // Get the logged-in user's email
            //Find the student by their email
            var student = _context.Student.FirstOrDefault(s => s.Email == email);
            if (student == null) 
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
