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
    public class VehiclesController : Controller
    {
        private readonly VehicleDbContext _context;

        public VehiclesController(VehicleDbContext context)
        {
            _context = context;    
        }

        // GET: Vehicles
        public async Task<IActionResult> Index(string searchString, int? fyFilter = 0, int? cycFilter = 0)
        {
            // FY 
            var fy = _context.Vehicle.Select(y => new { id = y.Year, value = y.Year }).Distinct().ToList();
            ViewBag.FySelectList = new SelectList(fy, "id", "value");

            // Cylinders
            var cylinder = _context.Cylinders.Select(y => new { id = y.Id, value = y.Label }).Distinct().ToList();
            ViewBag.CycSelectList = new SelectList(cylinder, "id", "value");

            // Create an empty Event object
            IQueryable<Vehicle> vehicles;

            var all_vehicles = _context.Vehicle.Include(v => v.Cylinders).Include(v => v.Cylinders).Include(v => v.Drive).Select(v => v);

            if (!String.IsNullOrEmpty(searchString))
            {
                fyFilter = 0;

                all_vehicles = all_vehicles.Where(v => v.Model.Contains(searchString));
            }

            if (fyFilter > 0)
            {
                vehicles = all_vehicles.Where(s => s.Year == fyFilter);
            }
            else if (cycFilter > 0)
            {
                vehicles = all_vehicles.Where(s => s.CylindersId == cycFilter);
            }
            else
            {
                // do nothing, all
                vehicles = all_vehicles.Select(s => s);
            }

            return View(vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["CylindersId"] = new SelectList(_context.Cylinders, "Id", "Id");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityMilage,CylindersId,Displacement,DriveId,FuelCost,FuelTypeId,HywayMilage,MakeiId,Model,TransmissionId,VehicleClassId,YearId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CylindersId"] = new SelectList(_context.Cylinders, "Id", "Id", vehicle.CylindersId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["CylindersId"] = new SelectList(_context.Cylinders, "Id", "Id", vehicle.CylindersId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CityMilage,CylindersId,Displacement,DriveId,FuelCost,FuelTypeId,HywayMilage,MakeiId,Model,TransmissionId,VehicleClassId,YearId")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            ViewData["CylindersId"] = new SelectList(_context.Cylinders, "Id", "Id", vehicle.CylindersId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.SingleOrDefaultAsync(m => m.Id == id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
