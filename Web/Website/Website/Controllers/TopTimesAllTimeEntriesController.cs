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
    public class TopTimesAllTimeEntriesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/TopTimesAllTimeEntries
        public IQueryable<TopTimesAllTimeEntry> GettopTimesAllTime()
        {
            var entries = from entry in db.topTimesAllTime
                          select entry;
            entries = entries.OrderBy ( entry => entry.LevelCompleteTime );
            return entries;
        }

        // GET: api/TopTimesAllTimeEntries/5
        [ResponseType(typeof(TopTimesAllTimeEntry))]
        public async Task<IHttpActionResult> GetTopTimesAllTimeEntry(int id)
        {
            TopTimesAllTimeEntry topTimesAllTimeEntry = await db.topTimesAllTime.FindAsync(id);
            if (topTimesAllTimeEntry == null)
            {
                return NotFound();
            }

            return Ok(topTimesAllTimeEntry);
        }

        // PUT: api/TopTimesAllTimeEntries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTopTimesAllTimeEntry(int id, TopTimesAllTimeEntry topTimesAllTimeEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topTimesAllTimeEntry.Id)
            {
                return BadRequest();
            }

            db.Entry(topTimesAllTimeEntry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopTimesAllTimeEntryExists(id))
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

        // POST: api/TopTimesAllTimeEntries
        [ResponseType(typeof(TopTimesAllTimeEntry))]
        public async Task<IHttpActionResult> PostTopTimesAllTimeEntry(TopTimesAllTimeEntry topTimesAllTimeEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.topTimesAllTime.Add(topTimesAllTimeEntry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = topTimesAllTimeEntry.Id }, topTimesAllTimeEntry);
        }

        // DELETE: api/TopTimesAllTimeEntries/5
        [ResponseType(typeof(TopTimesAllTimeEntry))]
        public async Task<IHttpActionResult> DeleteTopTimesAllTimeEntry(int id)
        {
            TopTimesAllTimeEntry topTimesAllTimeEntry = await db.topTimesAllTime.FindAsync(id);
            if (topTimesAllTimeEntry == null)
            {
                return NotFound();
            }

            db.topTimesAllTime.Remove(topTimesAllTimeEntry);
            await db.SaveChangesAsync();

            return Ok(topTimesAllTimeEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopTimesAllTimeEntryExists(int id)
        {
            return db.topTimesAllTime.Count(e => e.Id == id) > 0;
        }
    }
}