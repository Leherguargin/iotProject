using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.model;

namespace WebApplication2.Controllers
{
    public class SensorsController : Controller
    {
        private readonly SensorsContext _context;

        public SensorsController(SensorsContext context)
        {
            _context = context;
        }

        // GET: Sensors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sensors.ToListAsync());
        }

        // GET: Sensors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensors = await _context.Sensors
                .FirstOrDefaultAsync(m => m.NodeID == id);
            if (sensors == null)
            {
                return NotFound();
            }

            return View(sensors);
        }

        // GET: Sensors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sensors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NodeID,SensorID,Type")] Sensors sensors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sensors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sensors);
        }

        // GET: Sensors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensors = await _context.Sensors.FindAsync(id);
            if (sensors == null)
            {
                return NotFound();
            }
            return View(sensors);
        }

        // POST: Sensors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NodeID,SensorID,Type")] Sensors sensors)
        {
            if (id != sensors.NodeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sensors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SensorsExists(sensors.NodeID))
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
            return View(sensors);
        }

        // GET: Sensors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensors = await _context.Sensors
                .FirstOrDefaultAsync(m => m.NodeID == id);
            if (sensors == null)
            {
                return NotFound();
            }

            return View(sensors);
        }

        // POST: Sensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sensors = await _context.Sensors.FindAsync(id);
            _context.Sensors.Remove(sensors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SensorsExists(int id)
        {
            return _context.Sensors.Any(e => e.NodeID == id);
        }
    }
}
