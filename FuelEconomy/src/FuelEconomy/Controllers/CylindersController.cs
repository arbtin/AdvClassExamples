using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuelEconomy.Data;
using FuelEconomy.Models;

namespace FuelEconomy.Controllers
{
    public class CylindersController : Controller
    {
        private readonly VehicleDbContext _context;

        public CylindersController(VehicleDbContext context)
        {
            _context = context;    
        }

        // GET: Cylinders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cylinders.ToListAsync());
        }

        // GET: Cylinders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cylinders = await _context.Cylinders.SingleOrDefaultAsync(m => m.Id == id);
            if (cylinders == null)
            {
                return NotFound();
            }

            return View(cylinders);
        }

        // GET: Cylinders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cylinders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] Cylinders cylinders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cylinders);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cylinders);
        }

        // GET: Cylinders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cylinders = await _context.Cylinders.SingleOrDefaultAsync(m => m.Id == id);
            if (cylinders == null)
            {
                return NotFound();
            }
            return View(cylinders);
        }

        // POST: Cylinders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] Cylinders cylinders)
        {
            if (id != cylinders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cylinders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CylindersExists(cylinders.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(cylinders);
        }

        // GET: Cylinders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cylinders = await _context.Cylinders.SingleOrDefaultAsync(m => m.Id == id);
            if (cylinders == null)
            {
                return NotFound();
            }

            return View(cylinders);
        }

        // POST: Cylinders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cylinders = await _context.Cylinders.SingleOrDefaultAsync(m => m.Id == id);
            _context.Cylinders.Remove(cylinders);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CylindersExists(int id)
        {
            return _context.Cylinders.Any(e => e.Id == id);
        }
    }
}
