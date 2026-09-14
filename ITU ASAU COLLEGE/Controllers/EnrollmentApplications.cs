using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using ITU_ASAU_COLLEGE.Data;
using ITU_ASAU_COLLEGE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ITU_ASAU_COLLEGE.Controllers
{
    public class EnrollmentApplicationsController : Controller
    {
        private readonly ITU_ASAU_COLLEGEContext _context;

        public EnrollmentApplicationsController(
            ITU_ASAU_COLLEGEContext context)
        {
            _context = context;
        }

        // Public application form
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        // Submit application form  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(EnrollmentApplication application)
        {
            if (!ModelState.IsValid)
            {
                return View(application);
            }

            application.ApplicationDate = DateTime.Now;
            application.Status = ApplicationStatus.Pending;

            _context.EnrollmentApplications.Add(application);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ApplicationSubmitted));
        }

        // Submission confirmation page
        [HttpGet]
        public IActionResult ApplicationSubmitted()
        {
            return View();
        }

        // Admin view of all applications
        [HttpGet]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminApplications()
        {
            var applications = await _context.EnrollmentApplications
                .OrderByDescending(a => a.ApplicationDate)
                .ToListAsync();

            return View(applications);
        }

        // Admin accept application
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> Accept(int id)
        {
            var application = await _context.EnrollmentApplications
                .FindAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            application.Status = ApplicationStatus.Accepted;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AdminApplications));
        }

        // Admin reject application
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject(int id)
        {
            var application = await _context.EnrollmentApplications
                .FindAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            application.Status = ApplicationStatus.Rejected;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AdminApplications));
        }
    }
}
