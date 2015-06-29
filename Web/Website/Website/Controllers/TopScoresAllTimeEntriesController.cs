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
    public class TopScoresAllTimeEntriesController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/TopScoresAllTimeEntries
        public IQueryable<TopScoresAllTimeEntry> GettopScoresAllTime()
        {
            var entries = from s in db.topScoresAllTime
                         select s;
            entries = entries.OrderByDescending ( s => s.Score);
            return entries;
        }

        // GET: api/TopScoresAllTimeEntries/5
        [ResponseType(typeof(TopScoresAllTimeEntry))]
        public async Task<IHttpActionResult> GetTopScoresAllTimeEntry(int id)
        {
            TopScoresAllTimeEntry topScoresAllTimeEntry = await db.topScoresAllTime.FindAsync(id);
            if (topScoresAllTimeEntry == null)
            {
                return NotFound();
            }

            return Ok(topScoresAllTimeEntry);
        }

        // PUT: api/TopScoresAllTimeEntries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTopScoresAllTimeEntry(int id, TopScoresAllTimeEntry topScoresAllTimeEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topScoresAllTimeEntry.Id)
            {
                return BadRequest();
            }

            db.Entry(topScoresAllTimeEntry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopScoresAllTimeEntryExists(id))
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

        // POST: api/TopScoresAllTimeEntries
        [ResponseType(typeof(TopScoresAllTimeEntry))]
        public async Task<IHttpActionResult> PostTopScoresAllTimeEntry(TopScoresAllTimeEntry topScoresAllTimeEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.topScoresAllTime.Add(topScoresAllTimeEntry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = topScoresAllTimeEntry.Id }, topScoresAllTimeEntry);
        }

        // DELETE: api/TopScoresAllTimeEntries/5
        [ResponseType(typeof(TopScoresAllTimeEntry))]
        public async Task<IHttpActionResult> DeleteTopScoresAllTimeEntry(int id)
        {
            TopScoresAllTimeEntry topScoresAllTimeEntry = await db.topScoresAllTime.FindAsync(id);
            if (topScoresAllTimeEntry == null)
            {
                return NotFound();
            }

            db.topScoresAllTime.Remove(topScoresAllTimeEntry);
            await db.SaveChangesAsync();

            return Ok(topScoresAllTimeEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopScoresAllTimeEntryExists(int id)
        {
            return db.topScoresAllTime.Count(e => e.Id == id) > 0;
        }
    }
}