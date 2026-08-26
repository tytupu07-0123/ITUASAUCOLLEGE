
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITU_ASAU_COLLEGE.Models;
using ITU_ASAU_COLLEGE.Areas.Identity.Data;

public class NoticesController : Controller
{
    private readonly ITU_ASAU_COLLEGEContext _context;

    public NoticesController(ITU_ASAU_COLLEGEContext context)
    {
        _context = context;
    }

    // GET: NOTICES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Notice.ToListAsync());
    }

    // GET: NOTICES/Details/5
    public async Task<IActionResult> Details(int? noticeid)
    {
        if (noticeid == null)
        {
            return NotFound();
        }

        var notice = await _context.Notice
            .FirstOrDefaultAsync(m => m.NoticeId == noticeid);
        if (notice == null)
        {
            return NotFound();
        }

        return View(notice);
    }

    // GET: NOTICES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NOTICES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("NoticeId,Date,NoticesTitle,NoticeDescription,Teacher")] Notice notice)
    {
        if (ModelState.IsValid)
        {
            _context.Add(notice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(notice);
    }

    // GET: NOTICES/Edit/5
    public async Task<IActionResult> Edit(int? noticeid)
    {
        if (noticeid == null)
        {
            return NotFound();
        }

        var notice = await _context.Notice.FindAsync(noticeid);
        if (notice == null)
        {
            return NotFound();
        }
        return View(notice);
    }

    // POST: NOTICES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? noticeid, [Bind("NoticeId,Date,NoticesTitle,NoticeDescription,Teacher")] Notice notice)
    {
        if (noticeid != notice.NoticeId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(notice);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeExists(notice.NoticeId))
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
        return View(notice);
    }

    // GET: NOTICES/Delete/5
    public async Task<IActionResult> Delete(int? noticeid)
    {
        if (noticeid == null)
        {
            return NotFound();
        }

        var notice = await _context.Notice
            .FirstOrDefaultAsync(m => m.NoticeId == noticeid);
        if (notice == null)
        {
            return NotFound();
        }

        return View(notice);
    }

    // POST: NOTICES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? noticeid)
    {
        var notice = await _context.Notice.FindAsync(noticeid);
        if (notice != null)
        {
            _context.Notice.Remove(notice);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NoticeExists(int? noticeid)
    {
        return _context.Notice.Any(e => e.NoticeId == noticeid);
    }
}
