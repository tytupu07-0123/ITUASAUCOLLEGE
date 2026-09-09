
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Models;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;

public class ResultsController : Controller
{
    private readonly ITU_ASAU_COLLEGEContext _context;

    public ResultsController(ITU_ASAU_COLLEGEContext context)
    {
        _context = context;
    }

    // GET: Results
    public async Task<IActionResult> Index()    
    {
        var results = await _context.Result
            .Include(r => r.Student)
            .ToListAsync();
        return View(results);
    }

    // GET: Results/Details/5
    public async Task<IActionResult> Details(int? resultid)
    {
        if (resultid == null)
        {
            return NotFound();
        }

        var result = await _context.Result
            .FirstOrDefaultAsync(m => m.ResultId == resultid);
        if (result == null)
        {
            return NotFound();
        }

        return View(result);
    }

    // GET: Results/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Results/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ResultId,StudentId,Student,Subject,Mark,Grade,AssessmentType,Date")] Result result)
    {
        if (ModelState.IsValid)
        {
            _context.Add(result);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(result);
    }

    // GET: Results/Edit/5
    public async Task<IActionResult> Edit(int? resultid)
    {
        if (resultid == null)
        {
            return NotFound();
        }

        var result = await _context.Result.FindAsync(resultid);
        if (result == null)
        {
            return NotFound();
        }
        return View(result);
    }

    // POST: Results/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? resultid, [Bind("ResultId,StudentId,Student,Subject,Mark,Grade,AssessmentType,Date")] Result result)
    {
        if (resultid != result.ResultId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
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
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(result);
    }

    // GET: Results/Delete/5
    public async Task<IActionResult> Delete(int? resultid)
    {
        if (resultid == null)
        {
            return NotFound();
        }

        var result = await _context.Result
            .FirstOrDefaultAsync(m => m.ResultId == resultid);
        if (result == null)
        {
            return NotFound();
        }

        return View(result);
    }

    // POST: Results/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? resultid)
    {
        var result = await _context.Result.FindAsync(resultid);
        if (result != null)
        {
            _context.Result.Remove(result);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ResultExists(int? resultid)
    {
        return _context.Result.Any(e => e.ResultId == resultid);
    }
}
