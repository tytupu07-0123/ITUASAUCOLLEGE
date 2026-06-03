
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Models;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;

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
    public async Task<IActionResult> Details(int? enrollmentid)
    {
        if (enrollmentid == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollment
            .FirstOrDefaultAsync(m => m.EnrollmentId == enrollmentid);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // GET: ENROLLMENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ENROLLMENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
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

    // GET: ENROLLMENTS/Edit/5
    public async Task<IActionResult> Edit(int? enrollmentid)
    {
        if (enrollmentid == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollment.FindAsync(enrollmentid);
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
    public async Task<IActionResult> Edit(int? enrollmentid, [Bind("EnrollmentId,EnrollmentDate,CourseName")] Enrollment enrollment)
    {
        if (enrollmentid != enrollment.EnrollmentId)
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

    // GET: ENROLLMENTS/Delete/5
    public async Task<IActionResult> Delete(int? enrollmentid)
    {
        if (enrollmentid == null)
        {
            return NotFound();
        }

        var enrollment = await _context.Enrollment
            .FirstOrDefaultAsync(m => m.EnrollmentId == enrollmentid);
        if (enrollment == null)
        {
            return NotFound();
        }

        return View(enrollment);
    }

    // POST: ENROLLMENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? enrollmentid)
    {
        var enrollment = await _context.Enrollment.FindAsync(enrollmentid);
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
