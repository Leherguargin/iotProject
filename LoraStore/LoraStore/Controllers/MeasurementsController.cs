using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoraStore.Data;
using LoraStore.Models;
using LoraStore.ViewModels;

namespace LoraStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MeasurementsController(ApplicationDbContext context)
        {
            _context = context;
        }
                
        // GET: api/Measurements?id=1
        [HttpGet]
        public async Task<IActionResult> GetMeasurements([FromQuery] int id, [FromQuery] int? top)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var measurementsQuery = _context.Measurements.Where(m => m.SensorId == id).OrderByDescending(m => m.MeasurementDate);
            List<Measurement> measurements;
            if (top != null)
                measurements = await measurementsQuery.Take(top.Value).ToListAsync();
            else
                measurements = await measurementsQuery.ToListAsync();
            if (measurements == null || measurements.Count == 0)
                return NotFound();

            return Ok(measurements);
        }

        // GET: api/Measurements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeasurement([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var measurement = await _context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return Ok(measurement);
        }

        // POST: api/Measurements
        [HttpPost]
        public async Task<IActionResult> PostMeasurement([FromBody] MeasurementInput measurementInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sensor = _context.Sensors.SingleOrDefault(s => s.SensorId == measurementInput.SensorId && s.SensorPassword == measurementInput.SensorPassword);

            if (sensor == null)
            {
                return Unauthorized();
            }

            var measurement = new Measurement
            {
                MeasurementDate = DateTime.Now,
                SensorId = measurementInput.SensorId,
                Value = measurementInput.Value
            };

            _context.Measurements.Add(measurement);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeasurement", new { id = measurement.MeasurementId }, measurement);
        }
    }
}