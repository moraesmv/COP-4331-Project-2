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
    public class LeaderboardEntriesAPIController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/LeaderboardEntriesAPI
        public IQueryable<LeaderboardEntry> GetLeaderboardEntries()
        {
            return db.LeaderboardEntries;
        }

        // GET: api/LeaderboardEntriesAPI/5
        [ResponseType(typeof(LeaderboardEntry))]
        public async Task<IHttpActionResult> GetLeaderboardEntry(int id)
        {
            LeaderboardEntry leaderboardEntry = await db.LeaderboardEntries.FindAsync(id);
            if (leaderboardEntry == null)
            {
                return NotFound();
            }

            return Ok(leaderboardEntry);
        }

        // PUT: api/LeaderboardEntriesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLeaderboardEntry(int id, LeaderboardEntry leaderboardEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leaderboardEntry.Id)
            {
                return BadRequest();
            }

            db.Entry(leaderboardEntry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaderboardEntryExists(id))
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

        // POST: api/LeaderboardEntriesAPI
        [ResponseType(typeof(LeaderboardEntry))]
        public async Task<IHttpActionResult> PostLeaderboardEntry(LeaderboardEntry leaderboardEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LeaderboardEntries.Add(leaderboardEntry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = leaderboardEntry.Id }, leaderboardEntry);
        }

        // DELETE: api/LeaderboardEntriesAPI/5
        [ResponseType(typeof(LeaderboardEntry))]
        public async Task<IHttpActionResult> DeleteLeaderboardEntry(int id)
        {
            LeaderboardEntry leaderboardEntry = await db.LeaderboardEntries.FindAsync(id);
            if (leaderboardEntry == null)
            {
                return NotFound();
            }

            db.LeaderboardEntries.Remove(leaderboardEntry);
            await db.SaveChangesAsync();

            return Ok(leaderboardEntry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaderboardEntryExists(int id)
        {
            return db.LeaderboardEntries.Count(e => e.Id == id) > 0;
        }
    }
}