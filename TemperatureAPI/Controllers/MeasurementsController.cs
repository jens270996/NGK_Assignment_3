using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemperatureAPI.Data;
using TemperatureAPI.Models;

namespace TemperatureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MeasurementsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Measurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurements()
        {
            return await _context.Measurements.ToListAsync();
        }

        // GET: api/Measurements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return measurement;
        }
        //"yy-mm-dd"
        [HttpGet("{firstDate}")]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurementsFromDate(string firstDate)
        {
            DateTime date = new DateTime(0, 0, 0);
            try
            {
                var tokens = firstDate.Split("-");
                date= new DateTime(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]));
            }
            catch(Exception e)
            {
                throw new HttpListenerException(400, "Bad request: "+e.Message);
            }

            return await _context.Measurements.Where(m => m.Time.Date == date).ToListAsync<Measurement>();
        }
        //"yy-mm-dd"/"hh:mm"/"hh:mm"
        [HttpGet("{firstDate}/{hours}/{hours2}")]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurementsBetweenDates(string firstDate, string hours,string hours2)
        {
            DateTime start = new DateTime(0,0,0);
            DateTime end = new DateTime(0, 0, 0);

            try
            {
                var tokens = firstDate.Split("-");
                var tokensh1 = hours.Split(":");
                var tokensh2 = hours2.Split(":");
                start = new DateTime(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokensh1[0]), int.Parse(tokensh1[1]), 0);
                end = new DateTime(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokensh2[0]), int.Parse(tokensh2[1]), 0);
            }
            catch(Exception e)
            {
                throw new HttpListenerException(400, "Bad request: " + e.Message);
            }

            return await _context.Measurements.Where(m => m.Time >= start && m.Time <= end).ToListAsync<Measurement>();
        }

        // PUT: api/Measurements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasurement(int id, Measurement measurement)
        {
            if (id != measurement.MeasurementId)
            {
                return BadRequest();
            }

            _context.Entry(measurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Measurements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Measurement>> PostMeasurement(Measurement measurement)
        {
            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeasurement", new { id = measurement.MeasurementId }, measurement);
        }

        // DELETE: api/Measurements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Measurement>> DeleteMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            _context.Measurements.Remove(measurement);
            await _context.SaveChangesAsync();

            return measurement;
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurements.Any(e => e.MeasurementId == id);
        }
    }
}
