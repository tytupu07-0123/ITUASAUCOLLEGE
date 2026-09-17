using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using ITU_ASAU_COLLEGE.Models;
using ITU_ASAU_COLLEGE.VewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin, Teacher")]
public class AttendancesController : Controller
{
    private readonly ITU_ASAU_COLLEGEContext _context;

    public AttendancesController(ITU_ASAU_COLLEGEContext context)
    {
        _context = context;
    }

    // ============================================================
    // TEACHER ATTENDANCE REGISTER
    // ============================================================

    // GET: Attendances/Register
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Register(
        string? className,
        string? subject,
        DateTime? date)
    {
        var model = new AttendanceRegisterViewModel
        {
            ClassName = className ?? string.Empty,
            Subject = subject ?? string.Empty,
            Date = date?.Date ?? DateTime.Today
        };

        // Only load students after a class has been selected
        if (!string.IsNullOrWhiteSpace(className))
        {
            if (Enum.TryParse<ClassCode>(className, out var selectedClass))
            {
                var students = await _context.Student
                    .Where(s => s.ClassCode == selectedClass)
                    .OrderBy(s => s.LastName)
                    .ThenBy(s => s.FirstName)
                    .ToListAsync();

                // Find attendance already recorded for this date/class/subject
                var existingAttendance = await _context.Attendance
                    .Where(a =>
                        a.Date.Date == model.Date.Date &&
                        a.ClassName == className &&
                        a.Subject == subject)
                    .ToListAsync();

                foreach (var student in students)
                {
                    var existing = existingAttendance
                        .FirstOrDefault(a => a.StudentId == student.StudentId);

                    model.Students.Add(new AttendanceStudentViewModel
                    {
                        StudentId = student.StudentId,
                        StudentName = $"{student.FirstName} {student.LastName}",
                        IsPresent = existing?.IsPresent ?? true
                    });
                }
            }
        }

        return View(model);
    }


    // POST: Attendances/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> Register(AttendanceRegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (!Enum.TryParse<ClassCode>(model.ClassName, out var selectedClass))
        {
            ModelState.AddModelError(
                nameof(model.ClassName),
                "Please select a valid class.");

            return View(model);
        }

        // Get all students belonging to the selected class
        var students = await _context.Student
            .Where(s => s.ClassCode == selectedClass)
            .ToListAsync();

        if (!students.Any())
        {
            ModelState.AddModelError(
                nameof(model.ClassName),
                "No students were found in this class.");

            return View(model);
        }

        // Get existing attendance records for this date/class/subject
        var existingAttendance = await _context.Attendance
            .Where(a =>
                a.Date.Date == model.Date.Date &&
                a.ClassName == model.ClassName &&
                a.Subject == model.Subject)
            .ToListAsync();

        foreach (var student in students)
        {
            var submittedStudent = model.Students
                .FirstOrDefault(s => s.StudentId == student.StudentId);

            if (submittedStudent == null)
            {
                continue;
            }

            var existing = existingAttendance
                .FirstOrDefault(a => a.StudentId == student.StudentId);

            if (existing != null)
            {
                // Update existing attendance
                existing.IsPresent = submittedStudent.IsPresent;
            }
            else
            {
                // Create new attendance record
                var attendance = new Attendance
                {
                    StudentId = student.StudentId,
                    Date = model.Date.Date,
                    IsPresent = submittedStudent.IsPresent,
                    Subject = model.Subject,
                    ClassName = model.ClassName
                };

                _context.Attendance.Add(attendance);
            }
        }

        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] =
            $"Attendance for {model.ClassName} has been saved successfully.";

        return RedirectToAction(
            nameof(Register),
            new
            {
                className = model.ClassName,
                subject = model.Subject,
                date = model.Date.ToString("yyyy-MM-dd")
            });
    }


    // ============================================================
    // EXISTING ADMIN ATTENDANCE INDEX
    // ============================================================

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var attendances = await _context.Attendance
            .Include(a => a.Student)
            .OrderByDescending(a => a.Date)
            .ToListAsync();

        return View(attendances);
    }


    // ============================================================
    // DETAILS
    // ============================================================

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Details(int? attendanceid)
    {
        if (attendanceid == null)
        {
            return NotFound();
        }

        var attendance = await _context.Attendance
            .Include(a => a.Student)
            .FirstOrDefaultAsync(
                m => m.AttendanceId == attendanceid);

        if (attendance == null)
        {
            return NotFound();
        }

        return View(attendance);
    }


    // ============================================================
    // CREATE
    // ============================================================

    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(
        [Bind("AttendanceId,StudentId,Date,IsPresent,Subject,ClassName")]
        Attendance attendance)
    {
        if (ModelState.IsValid)
        {
            _context.Add(attendance);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(attendance);
    }


    // ============================================================
    // EDIT
    // ============================================================

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? attendanceid)
    {
        if (attendanceid == null)
        {
            return NotFound();
        }

        var attendance =
            await _context.Attendance.FindAsync(attendanceid);

        if (attendance == null)
        {
            return NotFound();
        }

        return View(attendance);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(
        int? attendanceid,
        [Bind("AttendanceId,StudentId,Date,IsPresent,Subject,ClassName")]
        Attendance attendance)
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

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(attendance);
    }


    // ============================================================
    // DELETE
    // ============================================================

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? attendanceid)
    {
        if (attendanceid == null)
        {
            return NotFound();
        }

        var attendance = await _context.Attendance
            .Include(a => a.Student)
            .FirstOrDefaultAsync(
                m => m.AttendanceId == attendanceid);

        if (attendance == null)
        {
            return NotFound();
        }

        return View(attendance);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(
        int? attendanceid)
    {
        var attendance =
            await _context.Attendance.FindAsync(attendanceid);

        if (attendance != null)
        {
            _context.Attendance.Remove(attendance);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }


    private bool AttendanceExists(int attendanceid)
    {
        return _context.Attendance
            .Any(e => e.AttendanceId == attendanceid);
    }
}