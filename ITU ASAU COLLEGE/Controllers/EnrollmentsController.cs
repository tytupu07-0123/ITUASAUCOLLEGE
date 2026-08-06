
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Models;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
public class EnrollmentsController : Controller
{
    private readonly ITU_ASAU_COLLEGEContext _context;

    public EnrollmentsController(ITU_ASAU_COLLEGEContext context)
    {
        _context = context;
    }
    
    // GET: ENROLLMENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Enrollment.ToListAsync());
    }

    // GET: ENROLLMENTS/Details/5
    public async Task<IActionResult> Details(int?id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollment
            .FirstOrDefaultAsync(m => m.EnrollmentId == id);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // GET: ENROLLMENTS/Create
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: ENROLLMENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([Bind("EnrollmentId,EnrollmentDate,CourseName")] Enrollment enrollment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(enrollment);
    }
    [Authorize(Roles = "Admin")]
    // GET: ENROLLMENTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollment.FindAsync(id);
        if (enrollment == null)
        {
            return NotFound();
        }
        return View(enrollment);
    }

    // POST: ENROLLMENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? id, [Bind("EnrollmentId,EnrollmentDate,CourseName")] Enrollment enrollment)
    {
        if (id != enrollment.EnrollmentId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(enrollment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(enrollment.EnrollmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(enrollment);
    }
    [Authorize(Roles = "Admin")]
    // GET: ENROLLMENTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollment
            .FirstOrDefaultAsync(m => m.EnrollmentId == id);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // POST: ENROLLMENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var enrollment = await _context.Enrollment.FindAsync(id);
        if (enrollment != null)
        {
            _context.Enrollment.Remove(enrollment);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EnrollmentExists(int? enrollmentid)
    {
        return _context.Enrollment.Any(e => e.EnrollmentId == enrollmentid);
    }
}
