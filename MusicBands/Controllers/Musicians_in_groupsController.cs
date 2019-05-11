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
    public class Musicians_in_groupsController : Controller
    {
        private readonly BandsContext _context;

        public Musicians_in_groupsController(BandsContext context)
        {
            _context = context;
        }

        // GET: Musicians_in_groups
        public async Task<IActionResult> Index()
        {
            return View(await _context.MUSICIANS_IN_GROUPS.ToListAsync());
        }

        // GET: Musicians_in_groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicians_in_groups = await _context.MUSICIANS_IN_GROUPS
                .FirstOrDefaultAsync(m => m.ID == id);
            if (musicians_in_groups == null)
            {
                return NotFound();
            }

            return View(musicians_in_groups);
        }

        // GET: Musicians_in_groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Musicians_in_groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MS_ID,GR_ID,MUC_YEAR,MUS_LYEAR")] Musicians_in_groups musicians_in_groups)
        {
            try { 
            if (ModelState.IsValid)
            {
                _context.Add(musicians_in_groups);
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
            return View(musicians_in_groups);
        }

        // GET: Musicians_in_groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicians_in_groups = await _context.MUSICIANS_IN_GROUPS.FindAsync(id);
            if (musicians_in_groups == null)
            {
                return NotFound();
            }
            return View(musicians_in_groups);
        }

        // POST: Musicians_in_groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MS_ID,GR_ID,MUC_YEAR,MUS_LYEAR")] Musicians_in_groups musicians_in_groups)
        {
            if (id != musicians_in_groups.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicians_in_groups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Musicians_in_groupsExists(musicians_in_groups.ID))
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
            return View(musicians_in_groups);
        }

        // GET: Musicians_in_groups/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicians_in_groups = await _context.MUSICIANS_IN_GROUPS.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (musicians_in_groups == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(musicians_in_groups);
        }

        // POST: Musicians_in_groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicians_in_groups = await _context.MUSICIANS_IN_GROUPS.FindAsync(id);
            _context.MUSICIANS_IN_GROUPS.Remove(musicians_in_groups);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Musicians_in_groupsExists(int id)
        {
            return _context.MUSICIANS_IN_GROUPS.Any(e => e.ID == id);
        }
    }
}
