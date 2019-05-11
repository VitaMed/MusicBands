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
    public class GroupsController : Controller
    {
        private readonly BandsContext _context;

        public GroupsController(BandsContext context)
        {
            _context = context;
        }

        // GET: Groups
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GROUPS.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<int> SelectedInstruments)
        {
            var res = _context.GROUPS.Select(gr => gr.ID).ToList();
            foreach (int inst_id in SelectedInstruments)
            {
                var grIds = _context.GROUPS.Where(gr =>
                                gr.MUSICIANS_IN_GROUPS.Any(musician =>
                                musician.MUSICIAN.Instruments.Any(instrm =>
                                instrm.TYPE_ID == inst_id))).Select(gr => gr.ID).ToList();

                List<int> toDel = new List<int>();
                foreach (int id in res)
                {
                    if (!grIds.Contains(id))
                        toDel.Add(id);
                }
                foreach (int id in toDel)
                    res.Remove(id);
            }
            var groups = await _context.GROUPS.
                         Where(group => res.Contains(group.ID)).
                         ToListAsync();
            return View(groups);
        }
        //   public async Task<IActionResult> BandsSearch()
        //  {
        // }
        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.GROUPS.Include(s=>s.MUSICIANS_IN_GROUPS).ThenInclude(e=>e.MUSICIAN).AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["Producers"] = _context.PRODUCERS.ToList();
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GR_NAME,PR_ID")] Group @group)
        {
            try { 
            if (ModelState.IsValid)
            {
                _context.Add(@group);
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
            ViewData["Producers"] = _context.PRODUCERS.ToList();
            return View(@group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.GROUPS.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GR_NAME,PR_ID")] Group @group)
        {
            if (id != @group.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.ID))
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
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.GROUPS.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@group == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.GROUPS.FindAsync(id);
            _context.GROUPS.Remove(@group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.GROUPS.Any(e => e.ID == id);
        }
    }
}
