using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Models;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using ITU_ASAU_COLLEGE.ViewModels;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin, Teacher")]
public class ResultsController : Controller
{
    private readonly ITU_ASAU_COLLEGEContext _context;

    public ResultsController(ITU_ASAU_COLLEGEContext context)
    {
        _context = context;
    }

    // =========================================================
    // ADMIN - VIEW ALL RESULTS
    // =========================================================
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var results = await _context.Result
            .Include(r => r.Student)
            .OrderBy(r => r.Student!.LastName)
            .ThenBy(r => r.Student!.FirstName)
            .ThenBy(r => r.Subject)
            .ThenBy(r => r.Date)
            .ToListAsync();

        return View(results);
    }

    // =========================================================
    // TEACHER - OPEN GRADEBOOK
    // =========================================================
    [Authorize(Roles = "Teacher")]
    [HttpGet]
    public async Task<IActionResult> Gradebook(
        string? className,
        string? subject,
        string? assessmentType,
        DateTime? date)
    {
        var model = new ResultGradebookViewModel
        {
            ClassName = className ?? "",
            Subject = subject ?? "",
            AssessmentType = assessmentType ?? "",
            Date = date ?? DateTime.Today
        };

        // Do not load students until the teacher selects a class.
        if (string.IsNullOrWhiteSpace(className))
        {
            return View(model);
        }

        if (!Enum.TryParse<ClassCode>(className, out var selectedClass))
        {
            ModelState.AddModelError("ClassName", "Please select a valid class.");
            return View(model);
        }

        var students = await _context.Student
            .Where(s => s.ClassCode == selectedClass)
            .OrderBy(s => s.LastName)
            .ThenBy(s => s.FirstName)
            .ToListAsync();

        // Load existing results when all fields have been selected.
        var existingResults = new List<Result>();

        if (!string.IsNullOrWhiteSpace(subject) &&
            !string.IsNullOrWhiteSpace(assessmentType))
        {
            existingResults = await _context.Result
                .Where(r =>
                    r.Subject == subject &&
                    r.AssessmentType == assessmentType &&
                    r.Date.Date == model.Date.Date &&
                    r.Student != null &&
                    r.Student.ClassCode == selectedClass)
                .ToListAsync();
        }

        foreach (var student in students)
        {
            var existing = existingResults
                .FirstOrDefault(r => r.StudentId == student.StudentId);

            model.Students.Add(new ResultStudentViewModel
            {
                StudentId = student.StudentId,
                StudentName = $"{student.FirstName} {student.LastName}",
                Mark = existing?.Mark,
                Grade = existing?.Grade
            });
        }

        return View(model);
    }

    // =========================================================
    // TEACHER - SAVE GRADEBOOK
    // =========================================================
    [Authorize(Roles = "Teacher")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Gradebook(ResultGradebookViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (!Enum.TryParse<ClassCode>(model.ClassName, out var selectedClass))
        {
            ModelState.AddModelError("ClassName", "Please select a valid class.");
            return View(model);
        }

        var studentIds = await _context.Student
            .Where(s => s.ClassCode == selectedClass)
            .Select(s => s.StudentId)
            .ToListAsync();

        foreach (var studentResult in model.Students)
        {
            // Make sure the student actually belongs to the selected class.
            if (!studentIds.Contains(studentResult.StudentId))
            {
                continue;
            }

            var existingResult = await _context.Result
                .FirstOrDefaultAsync(r =>
                    r.StudentId == studentResult.StudentId &&
                    r.Subject == model.Subject &&
                    r.AssessmentType == model.AssessmentType &&
                    r.Date.Date == model.Date.Date);

            // If no mark was entered, skip the student.
            if (!studentResult.Mark.HasValue)
            {
                continue;
            }

            decimal mark = studentResult.Mark.Value;

            // Keep mark between 0 and 100.
            if (mark < 0 || mark > 100)
            {
                ModelState.AddModelError(
                    "",
                    $"The mark for {studentResult.StudentName} must be between 0 and 100.");

                return View(model);
            }

            string grade = CalculateGrade(mark);

            if (existingResult != null)
            {
                // Update existing result.
                existingResult.Mark = mark;
                existingResult.Grade = grade;
            }
            else
            {
                // Create new result.
                var result = new Result
                {
                    StudentId = studentResult.StudentId,
                    Subject = model.Subject,
                    Mark = mark,
                    Grade = grade,
                    AssessmentType = model.AssessmentType,
                    Date = model.Date
                };

                _context.Result.Add(result);
            }
        }

        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Student results have been saved successfully.";

        return RedirectToAction(
            nameof(Gradebook),
            new
            {
                className = model.ClassName,
                subject = model.Subject,
                assessmentType = model.AssessmentType,
                date = model.Date.ToString("yyyy-MM-dd")
            });
    }

    // =========================================================
    // DETAILS
    // =========================================================
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var result = await _context.Result
            .Include(r => r.Student)
            .FirstOrDefaultAsync(r => r.ResultId == id);

        if (result == null)
        {
            return NotFound();
        }

        return View(result);
    }

    // =========================================================
    // EDIT
    // =========================================================
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var result = await _context.Result
            .Include(r => r.Student)
            .FirstOrDefaultAsync(r => r.ResultId == id);

        if (result == null)
        {
            return NotFound();
        }

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("ResultId,StudentId,Subject,Mark,Grade,AssessmentType,Date")]
        Result result)
    {
        if (id != result.ResultId)
        {
            return NotFound();
        }

        if (result.Mark < 0 || result.Mark > 100)
        {
            ModelState.AddModelError("Mark", "Mark must be between 0 and 100.");
        }

        if (ModelState.IsValid)
        {
            result.Grade = CalculateGrade(result.Mark);

            try
            {
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(result.ResultId))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(result);
    }

    // =========================================================
    // DELETE
    // =========================================================
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var result = await _context.Result
            .Include(r => r.Student)
            .FirstOrDefaultAsync(r => r.ResultId == id);

        if (result == null)
        {
            return NotFound();
        }

        return View(result);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _context.Result.FindAsync(id);

        if (result != null)
        {
            _context.Result.Remove(result);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    // =========================================================
    // CALCULATE GRADE
    // =========================================================
    private static string CalculateGrade(decimal mark)
    {
        if (mark >= 80)
            return "A";

        if (mark >= 70)
            return "B";

        if (mark >= 60)
            return "C";

        if (mark >= 50)
            return "D";

        return "E";
    }

    private bool ResultExists(int id)
    {
        return _context.Result.Any(e => e.ResultId == id);
    }
}