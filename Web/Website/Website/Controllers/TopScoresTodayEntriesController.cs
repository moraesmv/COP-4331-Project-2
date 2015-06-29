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
    public class TopScoresTodayEntriesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/TopScoresTodayEntries
        public IQueryable<TopScoresTodayEntry> GettopScoresToday()
        {
            var entries = from entry in db.topScoresToday
                          select entry;
            entries = entries.OrderByDescending ( entry => entry.Score );
            return entries;
        }

        // GET: api/TopScoresTodayEntries/5
        [ResponseType(typeof(TopScoresTodayEntry))]
        public async Task<IHttpActionResult> GetTopScoresTodayEntry(int id)
        {
            TopScoresTodayEntry topScoresTodayEntry = await db.topScoresToday.FindAsync(id);
            if (topScoresTodayEntry == null)
            {
                return NotFound();
            }

            return Ok(topScoresTodayEntry);
        }

        // PUT: api/TopScoresTodayEntries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTopScoresTodayEntry(int id, TopScoresTodayEntry topScoresTodayEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topScoresTodayEntry.Id)
            {
                return BadRequest();
            }

            db.Entry(topScoresTodayEntry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopScoresTodayEntryExists(id))
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

        // POST: api/TopScoresTodayEntries
        [ResponseType(typeof(TopScoresTodayEntry))]
        public async Task<IHttpActionResult> PostTopScoresTodayEntry(TopScoresTodayEntry topScoresTodayEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.topScoresToday.Add(topScoresTodayEntry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = topScoresTodayEntry.Id }, topScoresTodayEntry);
        }

        // DELETE: api/TopScoresTodayEntries/5
        [ResponseType(typeof(TopScoresTodayEntry))]
        public async Task<IHttpActionResult> DeleteTopScoresTodayEntry(int id)
        {
            TopScoresTodayEntry topScoresTodayEntry = await db.topScoresToday.FindAsync(id);
            if (topScoresTodayEntry == null)
            {
                return NotFound();
            }

            db.topScoresToday.Remove(topScoresTodayEntry);
            await db.SaveChangesAsync();

            return Ok(topScoresTodayEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopScoresTodayEntryExists(int id)
        {
            return db.topScoresToday.Count(e => e.Id == id) > 0;
        }
    }
}