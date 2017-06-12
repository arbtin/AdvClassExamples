using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EndangeredSpecies.Data;
using EndangeredSpecies.Models;
using EndangeredSpecies.ViewModels;


namespace EndangeredSpecies.Controllers
{
    public class SpeciesController : Controller
    {
        private EsDbContext db_context;

        public SpeciesController(EsDbContext context)
        {
            db_context = context;    
        }

        // GET: Species
        public async Task<IActionResult> Index(string searchString, int? page, int statuscodeFilter = 0, int countrycodeFilter = 0)
        {
            if (searchString != null)
            {
                page = 1;
            }

            ViewData["CurrentFilter"] = searchString;

            var cc = db_context.CountryCode.OrderBy(c => c.Label).Select(a => new { id = a.Id, value = a.Label }).ToList();
            ViewBag.CountryCodeSelectList = new SelectList(cc, "id", "value");

            var sc = db_context.StatusCode.OrderBy(c => c.Label).Select(b => new { id = b.Id, value = b.Label }).ToList();
            ViewBag.StatusCodeSelectList = new SelectList(sc, "id", "value");

            //IQueryable<Species> species;
            IQueryable<SpeciesViewModel> speciesVM;
            
            var species_all = db_context.Species.Select(s => new SpeciesViewModel()
            {
                Id = s.Id,
                ComName = s.ComName,
                SciName = s.SciName,
                StatusCodeLabel = s.StatusCode.Label,
                StatusCodeId = s.StatusCodeId,
                CountryCodeLabel = s.CountryCode.Label,
                CountryCodeId = s.CountryCodeId,
                ListingDate = s.ListingDate
            });//.Include(a => a.StatusCode).Include(a => a.CountryCode);

            if (!String.IsNullOrEmpty(searchString))
            {
                species_all = species_all.Where(s => s.ComName.Contains(searchString)
                                       || s.SciName.Contains(searchString));
            }

            if (statuscodeFilter > 0)
            {
                speciesVM = species_all.Where(s => s.StatusCodeId == statuscodeFilter);
            }
            else if (countrycodeFilter > 0)
            {
                speciesVM = species_all.Where(s => s.CountryCodeId == countrycodeFilter);
            }
            else
            {
                // do nothing, all
                speciesVM = species_all.Select(s => s);
            }

            int pageSize = 25;
            return View(await PaginatedList<SpeciesViewModel>.CreateAsync(speciesVM.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await db_context.Species.SingleOrDefaultAsync(m => m.Id == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ComName,Name,SciName,title")] Species species)
        {
            if (ModelState.IsValid)
            {
                db_context.Add(species);
                await db_context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(species);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await db_context.Species.SingleOrDefaultAsync(m => m.Id == id);
            if (species == null)
            {
                return NotFound();
            }
            return View(species);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ComName,Name,SciName,title")] Species species)
        {
            if (id != species.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db_context.Update(species);
                    await db_context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeciesExists(species.Id))
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
            return View(species);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await db_context.Species.SingleOrDefaultAsync(m => m.Id == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var species = await db_context.Species.SingleOrDefaultAsync(m => m.Id == id);
            db_context.Species.Remove(species);
            await db_context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpeciesExists(int id)
        {
            return db_context.Species.Any(e => e.Id == id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db_context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
