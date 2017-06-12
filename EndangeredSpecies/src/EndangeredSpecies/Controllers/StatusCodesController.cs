using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EndangeredSpecies.Data;
using EndangeredSpecies.Models;

namespace EndangeredSpecies.Controllers
{
    public class StatusCodesController : Controller
    {
        private readonly EsDbContext _context;

        public StatusCodesController(EsDbContext context)
        {
            _context = context;    
        }

        // GET: StatusCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusCode.ToListAsync());
        }

        // GET: StatusCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusCode = await _context.StatusCode.SingleOrDefaultAsync(m => m.Id == id);
            if (statusCode == null)
            {
                return NotFound();
            }

            return View(statusCode);
        }

        // GET: StatusCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] StatusCode statusCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusCode);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(statusCode);
        }

        // GET: StatusCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusCode = await _context.StatusCode.SingleOrDefaultAsync(m => m.Id == id);
            if (statusCode == null)
            {
                return NotFound();
            }
            return View(statusCode);
        }

        // POST: StatusCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] StatusCode statusCode)
        {
            if (id != statusCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusCodeExists(statusCode.Id))
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
            return View(statusCode);
        }

        // GET: StatusCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusCode = await _context.StatusCode.SingleOrDefaultAsync(m => m.Id == id);
            if (statusCode == null)
            {
                return NotFound();
            }

            return View(statusCode);
        }

        // POST: StatusCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusCode = await _context.StatusCode.SingleOrDefaultAsync(m => m.Id == id);
            _context.StatusCode.Remove(statusCode);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StatusCodeExists(int id)
        {
            return _context.StatusCode.Any(e => e.Id == id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
