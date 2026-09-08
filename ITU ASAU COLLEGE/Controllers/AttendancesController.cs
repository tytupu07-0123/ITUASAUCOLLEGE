
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

    // GET: ATTENDANCES
    [Authorize(Roles = "Admin, Teacher")]
    public async Task<IActionResult> Index()
    {
       
        return View(await _context.Attendance.ToListAsync());
    }

    // GET: ATTENDANCES/Details/5
    [Authorize(Roles = "Admin, Teacher")]
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

    // GET: ATTENDANCES/Create
    [Authorize(Roles = "Admin, Teacher")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: ATTENDANCES/Create
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

    // GET: ATTENDANCES/Edit/5
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

    // POST: ATTENDANCES/Edit/5
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

    // GET: ATTENDANCES/Delete/5
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

    // POST: ATTENDANCES/Delete/5
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
