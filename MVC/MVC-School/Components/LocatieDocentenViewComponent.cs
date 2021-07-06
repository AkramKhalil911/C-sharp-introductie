using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_School.Data;

namespace MVC_School.Components
{
    public class LocatieDocentenViewComponent : ViewComponent
    {
        private readonly SchoolDbContext _context;
        public LocatieDocentenViewComponent(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var docenten = await _context.Docenten
                .Where(a => a.LocatieID == id)
                .ToListAsync();

            return View(docenten);
        }
    }
}
