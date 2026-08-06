
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Models;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;   

public class StudentsController : Controller
{
   
    private readonly ITU_ASAU_COLLEGEContext _context;

    public StudentsController(ITU_ASAU_COLLEGEContext context)
    {
        _context = context;
    }
    // GET: STUDENTS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Student.ToListAsync());
    }

    // GET: STUDENTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Student
            .FirstOrDefaultAsync(m => m.StudentId == id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
    [Authorize(Roles = "Admin")]
    // GET: STUDENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName,Gender,ClassCode,DateOfBirth,Enrollments")] Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }
    [Authorize(Roles = "Admin")]
    // GET: STUDENTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Student.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }
    
    public async Task<IActionResult> EditStudent(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var student = await _context.Student.FindAsync(id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // POST: STUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? id, [Bind("StudentId,FirstName,LastName,Gender,ClassCode,DateOfBirth,Enrollments")] Student student)
    {
        if (id != student.StudentId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.StudentId))
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
        return View(student);
    }
    [Authorize(Roles = "Admin")]
    // GET: STUDENTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Student
            .FirstOrDefaultAsync(m => m.StudentId == id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
    
    public async Task<IActionResult> DeleteStudent(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var student = await _context.Student
            .FirstOrDefaultAsync(m => m.StudentId == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // POST: STUDENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var student = await _context.Student.FindAsync(id);
        if (student != null)
        {
            _context.Student.Remove(student);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentExists(int? id)
    {
        return _context.Student.Any(e => e.StudentId == id);
    }
}
