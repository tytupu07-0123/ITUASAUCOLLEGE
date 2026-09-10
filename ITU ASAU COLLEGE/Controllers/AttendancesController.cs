
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Models;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin, Teacher")]
public class AttendancesController : Controller
{
    private readonly ITU_ASAU_COLLEGEContext _context;

    public AttendancesController(ITU_ASAU_COLLEGEContext context)
    {
        _context = context;
    }

    // GET: Attendances
    [Authorize(Roles = "Admin, Teacher")]
    public async Task<IActionResult> Index()
    {
       
        var attendances = await _context.Attendance
            .Include(a => a.Student)
            .ToListAsync();
        return View(attendances);
    }

    // GET: Attendances/Details/5
    [Authorize(Roles = "Admin, Teacher, Student")]
    public async Task<IActionResult> Details(int? attendanceid)
    {
        if (attendanceid == null)
        {
            return NotFound();
        }

        var attendance = await _context.Attendance
            .FirstOrDefaultAsync(m => m.AttendanceId == attendanceid);
        if (attendance == null)
        {
            return NotFound();
        }

        return View(attendance);
    }

    // GET: Attendances/Create
    [Authorize(Roles = "Admin, Teacher")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: Attendances/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("AttendanceId,StudentId,Student,Date,IsPresent,Subject,ClassName")] Attendance attendance)
    {
        if (ModelState.IsValid)
        {
            _context.Add(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(attendance);
    }

    // GET: Attendances/Edit/5
    public async Task<IActionResult> Edit(int? attendanceid)
    {
        if (attendanceid == null)
        {
            return NotFound();
        }

        var attendance = await _context.Attendance.FindAsync(attendanceid);
        if (attendance == null)
        {
            return NotFound();
        }
        return View(attendance);
    }

    // POST: Attendances/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? attendanceid, [Bind("AttendanceId,StudentId,Student,Date,IsPresent,Subject,ClassName")] Attendance attendance)
    {
        if (attendanceid != attendance.AttendanceId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(attendance);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(attendance.AttendanceId))
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
        return View(attendance);
    }

    // GET: Attendances/Delete/5
    public async Task<IActionResult> Delete(int? attendanceid)
    {
        if (attendanceid == null)
        {
            return NotFound();
        }

        var attendance = await _context.Attendance
            .FirstOrDefaultAsync(m => m.AttendanceId == attendanceid);
        if (attendance == null)
        {
            return NotFound();
        }

        return View(attendance);
    }

    // POST: Attendances/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? attendanceid)
    {
        var attendance = await _context.Attendance.FindAsync(attendanceid);
        if (attendance != null)
        {
            _context.Attendance.Remove(attendance);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AttendanceExists(int? attendanceid)
    {
        return _context.Attendance.Any(e => e.AttendanceId == attendanceid);
    }
}
