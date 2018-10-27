using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MeasurementsController : Controller
    {
        private readonly MeasurementsContext _context;

        public MeasurementsController(MeasurementsContext context)
        {
            _context = context;
        }

        // GET: Measurements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Measurements.ToListAsync());
        }

        // GET: Measurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurements = await _context.Measurements
                .FirstOrDefaultAsync(m => m.MeasurementsID == id);
            if (measurements == null)
            {
                return NotFound();
            }

            return View(measurements);
        }

        // GET: Measurements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Measurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeasurementsID,SensorID,Value,Time")] Measurements measurements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measurements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measurements);
        }

        // GET: Measurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurements = await _context.Measurements.FindAsync(id);
            if (measurements == null)
            {
                return NotFound();
            }
            return View(measurements);
        }

        // POST: Measurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeasurementsID,SensorID,Value,Time")] Measurements measurements)
        {
            if (id != measurements.MeasurementsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasurementsExists(measurements.MeasurementsID))
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
            return View(measurements);
        }

        // GET: Measurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var measurements = await _context.Measurements
                .FirstOrDefaultAsync(m => m.MeasurementsID == id);
            if (measurements == null)
            {
                return NotFound();
            }

            return View(measurements);
        }

        // POST: Measurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var measurements = await _context.Measurements.FindAsync(id);
            _context.Measurements.Remove(measurements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeasurementsExists(int id)
        {
            return _context.Measurements.Any(e => e.MeasurementsID == id);
        }
    }
}
