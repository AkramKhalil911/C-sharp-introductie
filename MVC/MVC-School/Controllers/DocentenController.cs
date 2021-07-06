using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_School.Data;
using MVC_School.Models;

namespace MVC_School.Controllers
{
    public class DocentenController : Controller
    {
        private readonly SchoolDbContext _context;

        public DocentenController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Docenten
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.Docenten.Include(d => d.Locatie);
            return View(await schoolDbContext.ToListAsync());
        }

        // GET: Docenten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docent = await _context.Docenten
                .Include(d => d.Locatie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (docent == null)
            {
                return NotFound();
            }

            return View(docent);
        }

        // GET: Docenten/Create
        public IActionResult Create()
        {
            ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "Naam");
            return View();
        }

        // POST: Docenten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Voornaam,Achternaam,LocatieID")] Docent docent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "Naam", docent.LocatieID);
            return View(docent);
        }

        // GET: Docenten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docent = await _context.Docenten.FindAsync(id);
            if (docent == null)
            {
                return NotFound();
            }
            ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "Naam", docent.LocatieID);
            return View(docent);
        }

        // POST: Docenten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Voornaam,Achternaam,LocatieID")] Docent docent)
        {
            if (id != docent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocentExists(docent.ID))
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
            ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "Naam", docent.LocatieID);
            return View(docent);
        }

        // GET: Docenten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docent = await _context.Docenten
                .Include(d => d.Locatie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (docent == null)
            {
                return NotFound();
            }

            return View(docent);
        }

        // POST: Docenten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docent = await _context.Docenten.FindAsync(id);
            _context.Docenten.Remove(docent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocentExists(int id)
        {
            return _context.Docenten.Any(e => e.ID == id);
        }
    }
}
