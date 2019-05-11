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
    public class Type_of_instrumentsController : Controller
    {
        private readonly BandsContext _context;

        public Type_of_instrumentsController(BandsContext context)
        {
            _context = context;
        }

        // GET: Type_of_instruments
        public async Task<IActionResult> Index()
        {
            return View(await _context.TYPE_OF_INSTRUMENTS.ToListAsync());
        }

        // GET: Type_of_instruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_of_instruments = await _context.TYPE_OF_INSTRUMENTS.FirstOrDefaultAsync(m => m.ID == id);
            if (type_of_instruments == null)
            {
                return NotFound();
            }

            return View(type_of_instruments);
        }

        // GET: Type_of_instruments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Type_of_instruments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IN_NAME")] Type_of_instruments type_of_instruments)
        {
            try { 
            if (ModelState.IsValid)
            {
                _context.Add(type_of_instruments);
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
            return View(type_of_instruments);
        }

        // GET: Type_of_instruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_of_instruments = await _context.TYPE_OF_INSTRUMENTS.FindAsync(id);
            if (type_of_instruments == null)
            {
                return NotFound();
            }
            return View(type_of_instruments);
        }

        // POST: Type_of_instruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IN_NAME")] Type_of_instruments type_of_instruments)
        {
            if (id != type_of_instruments.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(type_of_instruments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Type_of_instrumentsExists(type_of_instruments.ID))
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
            return View(type_of_instruments);
        }

        // GET: Type_of_instruments/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_of_instruments = await _context.TYPE_OF_INSTRUMENTS.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (type_of_instruments == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(type_of_instruments);
        }

        // POST: Type_of_instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var type_of_instruments = await _context.TYPE_OF_INSTRUMENTS.FindAsync(id);
            _context.TYPE_OF_INSTRUMENTS.Remove(type_of_instruments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Type_of_instrumentsExists(int id)
        {
            return _context.TYPE_OF_INSTRUMENTS.Any(e => e.ID == id);
        }
    }
}
