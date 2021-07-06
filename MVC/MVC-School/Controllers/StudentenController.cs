﻿using System;
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
    public class StudentenController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentenController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Studenten
        public async Task<IActionResult> Index()
        {
            return View(await _context.Studenten.ToListAsync());
        }

        // GET: Studenten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Studenten
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            ViewData["VakId"] = new SelectList(_context.Vakken, "Id", "Naam");

            return View(student);
        }

        // GET: Studenten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studenten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Voornaam,Achternaam,Adres,Woonplaats")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Studenten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Studenten.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Studenten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Voornaam,Achternaam,Adres,Woonplaats")] Student student)
        {
            if (id != student.ID)
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
                    if (!StudentExists(student.ID))
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

        // GET: Studenten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Studenten
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Studenten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Studenten.FindAsync(id);
            _context.Studenten.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Studenten.Any(e => e.ID == id);
        }

        //POST: Studenten.AddVak/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVak(VakStudent vakStudent)
        {
            var existingVakStudent = await _context.VakStudenten
                .FindAsync(vakStudent.StudentId, vakStudent.VakId);

            if (existingVakStudent == null)
            {
                _context.Add(vakStudent);
            }
            else
            {
                existingVakStudent.Uren = vakStudent.Uren;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = vakStudent.StudentId });
        }
    }
}
