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
    public class LocatiesController : Controller
    {
        private readonly SchoolDbContext _context;

        public LocatiesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Locaties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locatie.ToListAsync());
        }

        // GET: Locaties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatie = await _context.Locatie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (locatie == null)
            {
                return NotFound();
            }

            return View(locatie);
        }

        // GET: Locaties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locaties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naam,Adres,Woonplaats")] Locatie locatie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locatie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locatie);
        }

        // GET: Locaties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatie = await _context.Locatie.FindAsync(id);
            if (locatie == null)
            {
                return NotFound();
            }
            return View(locatie);
        }

        // POST: Locaties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naam,Adres,Woonplaats")] Locatie locatie)
        {
            if (id != locatie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locatie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocatieExists(locatie.ID))
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
            return View(locatie);
        }

        // GET: Locaties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatie = await _context.Locatie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (locatie == null)
            {
                return NotFound();
            }

            return View(locatie);
        }

        // POST: Locaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locatie = await _context.Locatie.FindAsync(id);
            _context.Locatie.Remove(locatie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocatieExists(int id)
        {
            return _context.Locatie.Any(e => e.ID == id);
        }
    }
}
