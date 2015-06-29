using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Website.Models;

namespace Website.Controllers
{
    public class TopTimesTodayEntriesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/TopTimesTodayEntries
        public IQueryable<TopTimesTodayEntry> GettopTimesToday()
        {
            var entries = from entry in db.topTimesToday
                          select entry;

            entries = entries.OrderBy ( entry => entry.LevelCompleteTime );
            return entries;
        }

        // GET: api/TopTimesTodayEntries/5
        [ResponseType(typeof(TopTimesTodayEntry))]
        public async Task<IHttpActionResult> GetTopTimesTodayEntry(int id)
        {
            TopTimesTodayEntry topTimesTodayEntry = await db.topTimesToday.FindAsync(id);
            if (topTimesTodayEntry == null)
            {
                return NotFound();
            }

            return Ok(topTimesTodayEntry);
        }

        // PUT: api/TopTimesTodayEntries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTopTimesTodayEntry(int id, TopTimesTodayEntry topTimesTodayEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topTimesTodayEntry.Id)
            {
                return BadRequest();
            }

            db.Entry(topTimesTodayEntry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopTimesTodayEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TopTimesTodayEntries
        [ResponseType(typeof(TopTimesTodayEntry))]
        public async Task<IHttpActionResult> PostTopTimesTodayEntry(TopTimesTodayEntry topTimesTodayEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.topTimesToday.Add(topTimesTodayEntry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = topTimesTodayEntry.Id }, topTimesTodayEntry);
        }

        // DELETE: api/TopTimesTodayEntries/5
        [ResponseType(typeof(TopTimesTodayEntry))]
        public async Task<IHttpActionResult> DeleteTopTimesTodayEntry(int id)
        {
            TopTimesTodayEntry topTimesTodayEntry = await db.topTimesToday.FindAsync(id);
            if (topTimesTodayEntry == null)
            {
                return NotFound();
            }

            db.topTimesToday.Remove(topTimesTodayEntry);
            await db.SaveChangesAsync();

            return Ok(topTimesTodayEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopTimesTodayEntryExists(int id)
        {
            return db.topTimesToday.Count(e => e.Id == id) > 0;
        }
    }
}