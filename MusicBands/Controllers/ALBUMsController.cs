using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicBands.Data;
using MusicBands.Models;

namespace MusicBands.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly BandsContext _context;

        public AlbumsController(BandsContext context)
        {
            _context = context;
        }

        // GET: ALBUMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ALBUMS.ToListAsync());
        }

        // GET: ALBUMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aLBUM = await _context.ALBUMS.Include(s=>s.SONGS).AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aLBUM == null)
            {
                return NotFound();
            }

            return View(aLBUM);
        }

        // GET: ALBUMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ALBUMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AL_NAME,AL_YEAR")] ALBUMS aLBUM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(aLBUM);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            
            }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
             return View(aLBUM);
        }

        // GET: ALBUMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aLBUM = await _context.ALBUMS.FindAsync(id);
            if (aLBUM == null)
            {
                return NotFound();
            }
            return View(aLBUM);
        }

        // POST: ALBUMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AL_NAME,AL_YEAR")] ALBUMS aLBUM)
        {
            if (id != aLBUM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aLBUM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ALBUMExists(aLBUM.ID))
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
            return View(aLBUM);
        }

        // GET: ALBUMs/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aLBUM = await _context.ALBUMS.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aLBUM == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(aLBUM);
        }

        // POST: ALBUMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aLBUM = await _context.ALBUMS.FindAsync(id);
            _context.ALBUMS.Remove(aLBUM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ALBUMExists(int id)
        {
            return _context.ALBUMS.Any(e => e.ID == id);
        }
    }
}
