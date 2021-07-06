using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_School.Data;

namespace MVC_School.Components
{
    public class DocentVakkenViewComponent : ViewComponent
    {
        private readonly SchoolDbContext _context;

        public DocentVakkenViewComponent(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var vakken = await _context.Vakken
                .Where(b => b.DocentId == id)
                .ToListAsync();

            return View(vakken);
        }
    }
}
